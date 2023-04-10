#!/usr/bin/env python
# coding -utf-8
#hdict2txt输出的txt的文件转换为xml文件
from ast import Num
import os
import xml.etree.ElementTree as ET
import cv2 as cv
from dataclasses import replace
import numpy as np
import json
import sys
import argparse

os.environ['CUDA_VISIBLE_DEVICES'] = '-1'

def indent(elem, level=0):
     i = "\n" + level*"\t"
     if len(elem):
         if not elem.text or not elem.text.strip():
             elem.text = i + "\t"
         if not elem.tail or not elem.tail.strip():
             elem.tail = i
         for elem in elem:
             indent(elem, level+1)
         if not elem.tail or not elem.tail.strip():
             elem.tail = i
     else:
         if level and (not elem.tail or not elem.tail.strip()):
             elem.tail = i

def create_xml(image_path,class_names, defects, save_dir):
    #ymin,xmin,ymax,xmax / height or width
    if not os.path.exists(image_path):
        print(image_path+ 'error!!!!!!!!!!!!!!!!')
    image = cv.imread(image_path, cv.IMREAD_UNCHANGED)

    width = image.shape[1]
    height = image.shape[0]
    if len(image.shape) == 3:
        depth = image.shape[2]
    else:
        depth = 1

    if len(defects) > 0:
        folder = os.path.dirname(image_path)
        image_name = os.path.basename(image_path)
        path = os.path.abspath(image_path)
        xml_path = save_dir
        root = ET.Element("annotation")
        ET.SubElement(root, "folder").text = folder
        ET.SubElement(root, "filename").text = image_name
        ET.SubElement(root, "path").text = path
        source = ET.SubElement(root, "source")
        ET.SubElement(source, "database").text = "Unknown"
        size = ET.SubElement(root, "size")
        ET.SubElement(size, "width").text = str(width)
        ET.SubElement(size, "height").text = str(height)
        ET.SubElement(size, "depth").text = "1"
        ET.SubElement(root, "segmented").text = "0"
        for d in defects:
            object = ET.SubElement(root, "object")
            ET.SubElement(object, "name").text = class_names[d[4]]
            ET.SubElement(object, "pose").text = "Unspecified"
            ET.SubElement(object, "truncated").text = "0"
            ET.SubElement(object, "difficult").text = "0"
            bnbox = ET.SubElement(object, "bndbox")
            ET.SubElement(bnbox, "xmin").text = str(d[0])
            ET.SubElement(bnbox, "ymin").text = str(d[1])
            ET.SubElement(bnbox, "xmax").text = str(d[2])
            ET.SubElement(bnbox, "ymax").text = str(d[3])
        indent(root) 
        tree = ET.ElementTree(root)
        tree.write(xml_path)


if __name__=='__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument("images_path")    ###加数
    parser.add_argument("annotation_dir")    ###加数
    parser.add_argument("class_name_path")    ###加数
    parser.add_argument("txt_dir")    ###加数
    args = parser.parse_args()

    images_path = args.images_path
    annotation_dir = args.annotation_dir
    class_name_path = args.class_name_path
    txt_dir = args.txt_dir

    if not os.path.exists(annotation_dir):
        os.makedirs(annotation_dir)
    else:
        for f in os.listdir(annotation_dir):
            if (f.endswith('.xml')):
                os.remove(os.path.join(annotation_dir, f))

    if os.path.exists(class_name_path):
        with open(class_name_path,'r') as file:
            class_names=file.readlines()
            class_names=[d.split('\n')[0] for d in class_names]
            #print(class_names)
    else:
        print(class_name_path +'is not exists.')
    with open(txt_dir,'r') as file:
        lines=file.readlines()
        for line in lines:
            line_list=line.split()
            ori_image_path=line_list[0]
            image_name=os.path.basename(ori_image_path)
            image_path=os.path.join(images_path,image_name)
            image_name=image_name.split('.')[0]
            xml_path=os.path.join(annotation_dir,image_name+'.xml')
            defects=[]
            for box in line_list[1:]:
                box=box.split(',')
                if(len(box)<5):
                    print(box)
                    continue
                box=[int(b) for b in box]
                defects.append(box)
            create_xml(image_path, class_names,defects,xml_path)
        print('write  over!')

  












