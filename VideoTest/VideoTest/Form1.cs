/*
    WebCam Streaming Code 
*/

using AForge.Video; // NuGet으로 추가 해 줌...
using System;
using System.Drawing;   // Bitmap Class 사용하기 위해 선언
using System.Windows.Forms;

namespace VideoTest
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;

        public Form1()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.0.232:8090/?action=stream"); // 720x480 : 화면 비율
            stream.Start();

            stream.NewFrame += stream_NewFrame;
        }

        void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone(); 
            pictureBox1.Image = bmp;
        }

    }
}
