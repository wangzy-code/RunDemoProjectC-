import pandas
import argparse

if __name__=='__main__':

    parser = argparse.ArgumentParser()
    parser.add_argument("para1")    ###加数
    parser.add_argument("para2")    ###加数
    args = parser.parse_args()

    arg1 = args.para1
    path = args.para2
    sum=arg1+path # 字符串的拼接
    print(sum)

    # print(result)