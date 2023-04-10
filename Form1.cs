using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace RunDemoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = mybmp;
        }

        private void btnFileSelect1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Title = "打开文件";
            pOpenFileDialog.Filter = "hdict文件|*.hdict";
            pOpenFileDialog.CheckFileExists = true;

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbxFileSelect1.Text = pOpenFileDialog.FileName;

            }
        }

        private void btnFileSelect2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // 设置默认的根目录
            string defaultPath;
            if (tbxFileSelect2.Text!="")
            {
                defaultPath = tbxFileSelect2.Text;
            }
            else
            {
                defaultPath = @"\\ZNJC-EXP-HOST\data-shared\ML\wangzy\images_data";
            }
            folderBrowserDialog.Description = "请选择一个图像文件夹";
            if (!string.IsNullOrEmpty(defaultPath))
            {
                Type type = folderBrowserDialog.GetType();
                FieldInfo fieldInfo = type.GetField("selectedPath", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(folderBrowserDialog, defaultPath); // 设置默认路径
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // 用户点击了确定按钮，获取选择的路径
                tbxFileSelect2.Text = folderBrowserDialog.SelectedPath;
                // 处理选择的路径
            }
        }

        private void btnFileSelect3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer; // 设置默认的根目录
            string defaultPath;
            if (tbxFileSelect3.Text != "")
            {
                defaultPath = tbxFileSelect3.Text;
            }
            else
            {
                defaultPath = @"\\ZNJC-EXP-HOST\data-shared\ML\wangzy\images_data";
            }
            folderBrowserDialog.Description = "请选择一个标注文件夹";
            if (!string.IsNullOrEmpty(defaultPath))
            {
                Type type = folderBrowserDialog.GetType();
                FieldInfo fieldInfo = type.GetField("selectedPath", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(folderBrowserDialog, defaultPath); // 设置默认路径
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // 用户点击了确定按钮，获取选择的路径
                tbxFileSelect3.Text = folderBrowserDialog.SelectedPath;
                // 处理选择的路径
            }
        }

        private void btnRunPython_Click(object sender, EventArgs e)
        {
            //第一种方法
            string[] strArr = new string[5];//参数列表
            string sArguments = @"Python\txt2xml_para.py";//这里是python的文件名字
            strArr[0] = tbxFileSelect2.Text; //图像路径
            strArr[1] = tbxFileSelect3.Text; //annotations路径
            string hdictPath = tbxFileSelect1.Text;
            strArr[2] = hdictPath.Replace(".hdict", ".names");
            strArr[3] = hdictPath.Replace(".hdict", ".txt");
          
            RunPythonScript(sArguments, strArr);
        }

        public void RunPythonScript(string sArgName, params string[] tep)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径（将文件放在c#的debug文件夹中可以这样操作）
            //path = @"C:\code_workspace\pyenose\" + sArgName;//如果没放debug下，可以直接写的绝对路径,替换掉上面的路径
            //string path_python = path + "\\matlab";
            p.StartInfo.FileName = @"C:\ProgramsUsers\Anaconda3\python.exe";//启动外部程序的类型，这里交代了Python的配置环境路径
            string sArguments = path;
            sArguments = sArguments + " " + tep[0] + " " + tep[1]+" " + tep[2] + " " + tep[3];//实现参数的拼接+" " + tep[2]+ " " + tep[3]
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;////是否使用操作系统shell启动，直接从可执行文件创建进程
            p.StartInfo.RedirectStandardOutput = true;///由调用程序获取输出信息
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            p.Start();     //实际上是新创建了一个进程
            ShowLabel1.Text = "convert .";
            p.BeginOutputReadLine();
            ShowLabel1.Text = "convert end.";
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);//接受Python文件print的内容
            Console.ReadLine();
            p.WaitForExit();
        }
        //下面是使用委托来输出打印信息
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public static void AppendText(string text)
        {
            MessageBox.Show(text);
        }

        /// <summary>
        /// halcon绑定图片
        /// </summary>
        private HObject _himage = new HObject();
        public void Hdict2Txt(string sTxtDir)
        {
            //HOperatorSet.ReadImage(out _himage, @"C:\Users\Administrator\Desktop\1\004_0.tiff");
            //hWindow_Final1.HobjectToHimage(_himage);
            HTuple hv_HdictDir = new HTuple(), hv_Substrings = new HTuple();
            HTuple hv_Length = new HTuple(), hv_SubstringsSec = new HTuple();
            HTuple hv_Position = new HTuple(), hv_SaveDir = new HTuple();
            HTuple hv_HdictName = new HTuple(), hv_DictHandle = new HTuple();
            HTuple hv_ClassNameFile = new HTuple(), hv_TxtFileDir = new HTuple();
            HTuple hv_ClassIds = new HTuple(), hv_ClassNames = new HTuple();
            HTuple hv_NameFileHandle = new HTuple(), hv_i = new HTuple();
            HTuple hv_TxtFileHandle = new HTuple(), hv_Samples = new HTuple();
            HTuple hv_ImageDir = new HTuple(), hv_ImageDict = new HTuple();
            HTuple hv_TxtString = new HTuple(), hv_ImageName = new HTuple();
            HTuple hv_CrtImgDir = new HTuple(), hv_BboxRow1 = new HTuple();
            HTuple hv_BboxCol1 = new HTuple(), hv_BboxRow2 = new HTuple();
            HTuple hv_BboxCol2 = new HTuple(), hv_BboxId = new HTuple();
            HTuple hv_j = new HTuple(), hv_BboxObject = new HTuple();
            HTuple hv_Row1 = new HTuple(), hv_Col1 = new HTuple();
            HTuple hv_Row2 = new HTuple(), hv_Col2 = new HTuple();
            HTuple hv_Indices = new HTuple(), hv_Id = new HTuple();


            hv_HdictDir.Dispose();
            hv_HdictDir = sTxtDir;
            hv_Substrings.Dispose();
            HOperatorSet.ReadDict(hv_HdictDir, new HTuple(), new HTuple(), out hv_DictHandle);
            HOperatorSet.TupleSplit(hv_HdictDir, ".", out hv_Substrings);


            HOperatorSet.TupleLength(hv_Substrings, out hv_Length);

            if (hv_Length > 0)
            {
                hv_SaveDir = hv_Substrings.TupleSelect(0);
            }

            //SaveDir := '//znjc-exp-host/data-shared/ML/wangzy/images_data/projects_dlt/'
            //HdictName := 'one_class'


            HOperatorSet.ReadDict(hv_SaveDir + ".hdict", new HTuple(), new HTuple(), out hv_DictHandle);

            //export_name := ['unable_location', 'special_shaped', 'loss_metarial', 'wrinkle', 'black_contamination',   'white_contamination', 'dent', 'product_mixing',  'oil_contamination', 'bubbles']


            hv_ClassNameFile = hv_SaveDir + ".names";

            hv_TxtFileDir = hv_SaveDir + ".txt";

            HOperatorSet.GetDictTuple(hv_DictHandle, "class_ids", out hv_ClassIds);


            HOperatorSet.GetDictTuple(hv_DictHandle, "class_names", out hv_ClassNames);

            HOperatorSet.OpenFile(hv_ClassNameFile, "output", out hv_NameFileHandle);
            for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_ClassNames.TupleLength())) - 1); hv_i = (int)hv_i + 1)
            {
                if ((int)(new HTuple(hv_i.TupleEqual((new HTuple(hv_ClassNames.TupleLength()
                    )) - 1))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        HOperatorSet.FwriteString(hv_NameFileHandle, hv_ClassNames.TupleSelect(hv_i));
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        HOperatorSet.FwriteString(hv_NameFileHandle, (hv_ClassNames.TupleSelect(hv_i)) + "\n");
                    }
                }
            }

            HOperatorSet.OpenFile(hv_TxtFileDir, "output", out hv_TxtFileHandle);

            HOperatorSet.GetDictTuple(hv_DictHandle, "samples", out hv_Samples);
            HOperatorSet.GetDictTuple(hv_DictHandle, "image_dir", out hv_ImageDir);



            for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Samples.TupleLength())) - 1); hv_i = (int)hv_i + 1)
            {
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_ImageDict = hv_Samples.TupleSelect(
                        hv_i);
                }
                hv_TxtString = "";
                HOperatorSet.GetDictTuple(hv_ImageDict, "image_file_name", out hv_ImageName);
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_CrtImgDir = hv_ImageDir + hv_ImageName;
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_TxtString = hv_CrtImgDir + " ";
                }

                HOperatorSet.GetDictTuple(hv_ImageDict, "bbox_row1", out hv_BboxRow1);
                HOperatorSet.GetDictTuple(hv_ImageDict, "bbox_col1", out hv_BboxCol1);
                HOperatorSet.GetDictTuple(hv_ImageDict, "bbox_row2", out hv_BboxRow2);
                HOperatorSet.GetDictTuple(hv_ImageDict, "bbox_col2", out hv_BboxCol2);
                HOperatorSet.GetDictTuple(hv_ImageDict, "bbox_label_id", out hv_BboxId);

                for (hv_j = 0; (int)hv_j <= (int)((new HTuple(hv_BboxRow1.TupleLength())) - 1); hv_j = (int)hv_j + 1)
                {

                    hv_BboxObject = new HTuple();
                    hv_BboxObject = hv_BboxObject.TupleConcat(hv_BboxRow1.TupleSelect(hv_j));
                    hv_BboxObject = hv_BboxObject.TupleConcat(hv_BboxCol1.TupleSelect(hv_j));
                    hv_BboxObject = hv_BboxObject.TupleConcat(hv_BboxRow2.TupleSelect(hv_j));
                    hv_BboxObject = hv_BboxObject.TupleConcat(hv_BboxCol2.TupleSelect(hv_j));
                    hv_BboxObject = hv_BboxObject.TupleConcat(hv_BboxId.TupleSelect(hv_j));

                    HOperatorSet.TupleString(hv_BboxRow1.TupleSelect(hv_j), ".0f", out hv_Row1);


                    HOperatorSet.TupleString(hv_BboxCol1.TupleSelect(hv_j), ".0f", out hv_Col1);

                    HOperatorSet.TupleString(hv_BboxRow2.TupleSelect(hv_j), ".0f", out hv_Row2);

                    HOperatorSet.TupleString(hv_BboxCol2.TupleSelect(hv_j), ".0f", out hv_Col2);

                    HOperatorSet.TupleFind(hv_ClassIds, hv_BboxId.TupleSelect(hv_j), out hv_Indices);


                    HOperatorSet.TupleString(hv_Indices, ".0f", out hv_Id);


                    HTuple ExpTmpLocalVar_TxtString = (((((((((hv_TxtString + hv_Col1) + new HTuple(",")) + hv_Row1) + new HTuple(",")) + hv_Col2) + new HTuple(",")) + hv_Row2) + new HTuple(",")) + hv_Id) + " ";

                    hv_TxtString = ExpTmpLocalVar_TxtString;

                    if ((int)(new HTuple(hv_j.TupleEqual((new HTuple(hv_BboxRow1.TupleLength())) - 1))) != 0)
                    {

                        HTuple ExpTmpLocalVar_TxtString1 = hv_TxtString + "\n";

                        hv_TxtString = ExpTmpLocalVar_TxtString1;

                    }
                }
                HOperatorSet.FwriteString(hv_TxtFileHandle, hv_TxtString);

                ShowLabel.Text = "convert......";
            }
            ShowLabel.Text = "convert end .";
            hv_HdictDir.Dispose();
            hv_HdictDir.Dispose();
            hv_Substrings.Dispose();
            hv_Length.Dispose();
            hv_SubstringsSec.Dispose();
            hv_Position.Dispose();
            hv_SaveDir.Dispose();
            hv_HdictName.Dispose();
            hv_DictHandle.Dispose();
            hv_ClassNameFile.Dispose();
            hv_TxtFileDir.Dispose();
            hv_ClassIds.Dispose();
            hv_ClassNames.Dispose();
            hv_NameFileHandle.Dispose();
            hv_i.Dispose();
            hv_TxtFileHandle.Dispose();
            hv_Samples.Dispose();
            hv_ImageDir.Dispose();
            hv_ImageDict.Dispose();
            hv_TxtString.Dispose();
            hv_ImageName.Dispose();
            hv_CrtImgDir.Dispose();
            hv_BboxRow1.Dispose();
            hv_BboxCol1.Dispose();
            hv_BboxRow2.Dispose();
            hv_BboxCol2.Dispose();
            hv_BboxId.Dispose();
            hv_j.Dispose();
            hv_BboxObject.Dispose();
            hv_Row1.Dispose();
            hv_Col1.Dispose();
            hv_Row2.Dispose();
            hv_Col2.Dispose();
            hv_Indices.Dispose();
            hv_Id.Dispose();




        }
        private void btnHalcon_Click(object sender, EventArgs e)
        {
            string sTxtDir = tbxFileSelect1.Text;
            Hdict2Txt(sTxtDir);

        }

        private void lblFileSelect1_Click(object sender, EventArgs e)
        {

        }

        private void hWindow_Final1_Load_1(object sender, EventArgs e)
        {

        }

        private void lblFileSelect1_Click_1(object sender, EventArgs e)
        {

        }

        private void tbpSelect_Click(object sender, EventArgs e)
        {

        }

        Point mouseDownPoint = new Point();
        bool ismove = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 记录鼠标左键按下时的位置
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                ismove = true;

                // 鼠标滚轮事件（缩放时）需要pictureBox1有焦点
                pictureBox1.Focus();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ismove = false;
            }
        }

        int zoomStep = 2;
        Bitmap mybmp = new Bitmap(@"..\\Debug\\1.png");

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int ow = pictureBox1.Width;
            int oh = pictureBox1.Height;
            int vx, vy;  //因缩放产生的位移矢量
            if (e.Delta > 0) //放大
            {
                if (pictureBox1.Width * pictureBox1.Height < 100000000)
                {
                    //第①步
                    pictureBox1.Width *= zoomStep;
                    pictureBox1.Height *= zoomStep;
                    //第②步
                    PropertyInfo pinfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pinfo.GetValue(pictureBox1, null);
                    //第③步
                    pictureBox1.Width = rect.Width;
                    pictureBox1.Height = rect.Height;
                }
            }
            if (e.Delta < 0) //缩小
            {
                //防止一直缩成负值
                if (pictureBox1.Width < mybmp.Width / 10)
                    return;

                pictureBox1.Width /= zoomStep;
                pictureBox1.Height /= zoomStep;
                PropertyInfo pinfo = pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                BindingFlags.NonPublic);
                Rectangle rect = (Rectangle)pinfo.GetValue(pictureBox1, null);
                pictureBox1.Width = rect.Width;
                pictureBox1.Height = rect.Height;
            }
            //第④步，求因缩放产生的位移，进行补偿，实现锚点缩放的效果
            vx = (int)((double)x * (ow - pictureBox1.Width) / ow);
            vy = (int)((double)y * (oh - pictureBox1.Height) / oh);
            pictureBox1.Location = new Point(pictureBox1.Location.X + vx, pictureBox1.Location.Y + vy);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // 鼠标在pictureBox1上时才有焦点，此时可以缩放
            pictureBox1.Focus();
            if (ismove)
            {
                // 新的pictureBox1.Location(x,y)
                int x, y;

                // x方向，y方向移动大小
                int moveX, moveY;

                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox1.Location.X + moveX;
                y = pictureBox1.Location.Y + moveY;
                pictureBox1.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                // 记录鼠标左键按下时的位置
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                ismove = true;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ismove = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // 鼠标不在pictureBox1上时焦点给别的控件，此时无法缩放
            panel1.Focus();
            if(ismove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pictureBox1.Location.X + moveX;
                y = pictureBox1.Location.Y + moveY;
                pictureBox1.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("..\\Debug\\FilePathConfig.xml");
            
            tbxFileSelect1.Text = sr.ReadLine();
            tbxFileSelect2.Text = sr.ReadLine();
            tbxFileSelect3.Text = sr.ReadLine();
            sr.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter("..\\Debug\\FilePathConfig.xml");
            sw.WriteLine(tbxFileSelect1.Text);//按行写
            sw.WriteLine(tbxFileSelect2.Text);
            sw.WriteLine(tbxFileSelect3.Text);
            sw.Close();//关闭
        }
    }
}
