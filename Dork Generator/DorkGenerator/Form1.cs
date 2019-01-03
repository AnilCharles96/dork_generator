using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DorkGenerator
{
    public partial class Form1 : Form
    {
        string pathapp, apppath;
        string resultpath;


        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            


            Directory.CreateDirectory("pages");
            apppath = Path.GetDirectoryName(Application.ExecutablePath);
            pathapp = apppath + "/pages";
            File.Delete(Path.Combine(pathapp, "box1.txt"));
            File.Delete(Path.Combine(pathapp, "box2.txt"));
            File.Delete(Path.Combine(pathapp, "box3.txt"));
            File.Delete(Path.Combine(pathapp, "box4.txt"));
            File.Delete(Path.Combine(pathapp, "box5.txt"));
            File.WriteAllText(Path.Combine(pathapp, "box1.txt"), bunifuCustomTextbox1.Text);
            File.WriteAllText(Path.Combine(pathapp, "box2.txt"), bunifuCustomTextbox2.Text);
            File.WriteAllText(Path.Combine(pathapp, "box3.txt"), bunifuCustomTextbox3.Text);
            File.WriteAllText(Path.Combine(pathapp, "box4.txt"), bunifuCustomTextbox4.Text);
            File.WriteAllText(Path.Combine(pathapp, "box5.txt"), bunifuCustomTextbox5.Text);


            inputworks();





        }
        public string inputworks()
        {
            string read1, read2, read3, read4, read5;

            List<string> combiner = new List<string>();




            StreamReader firstreader = new StreamReader(Path.Combine(pathapp, "box1.txt"));

            while ((read1 = firstreader.ReadLine()) != null)
            {
                StreamReader secondreader = new StreamReader(Path.Combine(pathapp, "box2.txt"));
                while ((read2 = secondreader.ReadLine()) != null)
                {
                    StreamReader thirdreader = new StreamReader(Path.Combine(pathapp, "box3.txt"));
                    while ((read3 = thirdreader.ReadLine()) != null)
                    {
                        StreamReader fourthreader = new StreamReader(Path.Combine(pathapp, "box4.txt"));
                        while ((read4 = fourthreader.ReadLine()) != null)
                        {
                            StreamReader fifthreader = new StreamReader(Path.Combine(pathapp, "box5.txt"));
                            while ((read5 = fifthreader.ReadLine()) != null)
                            {
                                combiner.Add(read1 + read2 + read3 + read4 + read5 + "\n");
                                 
                            }
                            fifthreader.Close();
                        }
                        fourthreader.Close();
                    }
                    thirdreader.Close();
                }
                secondreader.Close();

            }
            firstreader.Close();
            string filename = string.Format("{0:HH-MM-SS.ss_dd-MM-yyyy}_{1}", DateTime.Now, "Result.txt");
            resultpath = Path.Combine(apppath, filename);
            StreamWriter sr = new StreamWriter(resultpath);
            foreach (string s in combiner)
            {
                sr.WriteLine(s);
            }
            sr.Close();
            MessageBox.Show("Dork Generated");
            
            return null;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            apppath = Path.GetDirectoryName(Application.ExecutablePath);
            Process.Start("explorer.exe", apppath);

        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        

    }

   

}
