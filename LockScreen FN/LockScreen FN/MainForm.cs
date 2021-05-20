using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace LockScreen_FN
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public CvWindow window;
        public CvCapture CATP = CvCapture.FromCamera(0);
        public static string MD5Hash, UserInfo, DemodulationKey, Key, Return, GPS, CAPTURE, FilePath = "C:\\Windows\\SC_Key.ini";
        public string ownerkey = "0";
        public static string P = "C:\\Windows\\TE_PT";

        public static int sec, Net;

        public static int CapCount = 0;
        private int Count = 0;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void Form1_Load(object sender, EventArgs e)
        {
            /* 실행 시 관리자 권한 상승을 위한 코드 시작 */
            if (/* Main 아래에 정의된 함수 */IsAdministrator() == false)
            {
                try
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    procInfo.UseShellExecute = true;
                    procInfo.FileName = Application.ExecutablePath;
                    procInfo.WorkingDirectory = Environment.CurrentDirectory;
                    procInfo.Verb = "runas";
                    Process.Start(procInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

                Application.ExitThread();
                Application.Exit();
                return;
            }
            //Thread cts = new Thread(new ThreadStart(CTS));
            //cts.Start();

        Directory.CreateDirectory("C:\\Windows\\TE_PT");

            if (!File.Exists("C:\\Windows\\ENUMA_Key.ocx"))
            {
                EX.Show();
                label1.Show();
            }
            else if (File.Exists("C:\\Windows\\ENUMA_Key.ocx"))
            {
                EX.Hide();
                label1.Hide();
            }
            var myForm = new SSV();
            myForm.Show();

            this.Activate();
            Pass.Focus();

            Thread PK = new Thread(new ThreadStart(ProcessKill));
            PK.Start();

            Thread PK2 = new Thread(new ThreadStart(ProcessKill2));
            PK2.Start();

            sec = 1800; //로그인 대기 시간초

            timer1_Tick(sender, e);
            timer1.Interval = 1000; //스케쥴 간격을 1초로 준 것이다.
            timer1.Start();
        }

        /* 실행 시 관리자 권한 상승을 위한 함수 시작 */
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (null != identity)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }


            return false;
        }
        /* 실행 시 관리자 권한 상승을 위한 함수 끝 */

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec--;
            int Delkey = Convert.ToInt32(ownerkey);

            if (Delkey == 1)
            {
                label1.Show();
                EX.Show();
            }
            else
            {
                label1.Hide();
                EX.Hide();
            }

            timer.Text = sec + "초 후 종료됩니다.".ToString();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Net = 0;
            }
            else
            {
                Net = 1;
            }
            if (sec == 0)
            {
                try
                {
                    if (Net == 1)
                    {
                        MessageBox.Show("인터넷에 연결되어있지않습니다.");
                        return;
                    }

                    CAP();

                    window.Close();


                    CAPTURE = Path.Combine("C:\\Windows\\캡쳐.zip");
                    ZipFile.CreateFromDirectory("C:\\Windows\\TE_PT", CAPTURE);
                    String WanIP = new WebClient().DownloadString("http://ip.mc-blacklist.kr/");
                    GPS = "http://whatismyipaddress.com/ip/" + WanIP;

                    MailWAR();
                    Del("C:\\Windows\\TE_PT");
                    Directory.Delete("C:\\Windows\\TE_PT");
                    File.Delete(CAPTURE);

                    sec = 1800;
                }
                catch
                {
                    Del("C:\\Windows\\TE_PT");
                    Directory.Delete("C:\\Windows\\TE_PT");
                    File.Delete(CAPTURE);
                    MessageBox.Show("계정등록이 되지 않았습니다.");
                    Exit();


                }

                //Count = 1;
                //CapCount = 1;
                //Application.ExitThread();
                //Process.Start("shutdown.exe", "-s -t 1");
                //Application.Exit();


            }
        }

        public void CAP() //카메라 캡쳐
        {
            window = new CvWindow("CAM");
            try
            {

                if (!Directory.Exists("C:\\Windows\\TE_PT"))
                {
                    Directory.CreateDirectory("C:\\Windows\\TE_PT");
                }
                while (CapCount != 10)
                {
                    CapCount++;
                    CvWindow.WaitKey(10);
                    window.Image = CATP.QueryFrame();

                }
                for (int i = 0; i < 3; i++)
                {
                    window.Image.SaveImage("C:\\Windows\\TE_PT\\temp" + i + ".jpg");
                }

            }

            catch //주모니터 캡쳐
            {

                MessageBox.Show("2");
                if (!Directory.Exists("C:\\Windows\\TE_PT"))
                {
                    Directory.CreateDirectory("C:\\Windows\\TE_PT");
                }
                Rectangle rect = Screen.PrimaryScreen.Bounds;

                int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
                PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
                if (bitsPerPixel <= 16)
                {
                    pixelFormat = PixelFormat.Format16bppRgb565;
                }
                if (bitsPerPixel == 24)
                {
                    pixelFormat = PixelFormat.Format24bppRgb;
                }

                Bitmap bmp = new Bitmap(rect.Width, rect.Height, pixelFormat);

                // Bitmap 이미지 변경을 위해 Graphics 객체 생성
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                    gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
                }

                // Bitmap 데이타를 파일로 저장


                for (int i = 0; i < 3; i++)
                {
                    bmp.Save("C:\\Windows\\TE_PT\\temp" + i + ".jpg");
                }

                bmp.Dispose();
            }
        }

        private void EX_Click(object sender, EventArgs e)
        {
            Exit();
        }

        void Exit()
        {
            Count = 1;
            CapCount = 1;
            Process.Start("C:\\Windows\\explorer.exe");
            Application.ExitThread();
            Application.Exit();
        }

        // ini파일에서 읽기
        void ReadINI()
        {
            StringBuilder temp = new StringBuilder();

            Int64 ret = GetPrivateProfileString("PASS", "Key", "입력된 패스워드가 맞지 않습니다.", temp, 255, FilePath);
            DemodulationKey = temp.ToString();
            Key = Demodulation(DemodulationKey);

        }

        void ProcessKill2()
        {
            while (Count != 1)
            {
                try
                {
                    Process[] List = Process.GetProcessesByName("explorer");

                    if (List.Length > 0)
                    {
                        List[0].Kill();
                    }
                }
                catch
                {

                }
            }
        }

        private void DelAccount_Click(object sender, EventArgs e)
        {
            //var myForm = new DelAC();
            //myForm.Show();

            DelAC frm2 = new DelAC();
            frm2.Owner = this; //MainForm을 지정하게 된다.
            frm2.Show(); //DelAC을 연다.
        }

        private void SingUp_Click(object sender, EventArgs e)
        {
            var myForm = new SingUP();
            myForm.Show();
        }

        private void timer_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string Demodulation(string K) //복호화
        {
            string temp = "";

            int w;
            string str = K;
            char[] strArray = str.ToCharArray();

            for (w = 0; w < strArray.Length; w++)
            {
                if (strArray[w] == '!')
                {
                    temp += "!";
                }
                else
                {
                    if (strArray[w] == 'Z')
                    {
                        temp += "0";

                    }
                    else if (strArray[w] == 'O')
                    {
                        temp += "1";

                    }
                    else if (strArray[w] == 'T')
                    {
                        temp += "2";

                    }
                    else if (strArray[w] == 'H')
                    {
                        temp += "3";

                    }
                    else if (strArray[w] == 'F')
                    {
                        temp += "4";

                    }
                    else if (strArray[w] == 'I')
                    {
                        temp += "5";

                    }
                    else if (strArray[w] == 'S')
                    {
                        temp += "6";

                    }
                    else if (strArray[w] == 'V')
                    {
                        temp += "7";

                    }
                    else if (strArray[w] == 'E')
                    {
                        temp += "8";

                    }
                    else if (strArray[w] == 'N')
                    {
                        temp += "9";

                    }

                }
            }

            test1 ms = new test1();
            ms.a = new List<Int64>();
            string temp3 = "";
            string temp2 = "";
            string str2 = temp;

            char[] CodeArray = str2.ToCharArray();

            for (int i = 0; i < CodeArray.Length; i++)
            {
                if (CodeArray[i] == '!')
                {
                    ms.a.Add(Int64.Parse(temp2));
                    temp2 = "";
                }
                else
                {
                    temp2 += CodeArray[i];
                }

            }

            foreach (Int64 b in ms.a) //키값 해독완료
            {
                temp3 += Convert.ToChar(b);
            }
            return temp3;
        }

        void AccountEnter() //로그인 인증 함수
        {
            if (string.IsNullOrEmpty(Pass.Text))
            {
                MessageBox.Show("패스워드가 입력 되지 않았습니다.");
            }
            else
            {
                ReadINI();
                if (Pass.Text == Key)
                {
                    Return = "1";
                }
                else
                {
                    MessageBox.Show("입력된 패스워드가 맞지 않습니다.");
                }
            }

        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            AccountEnter();

            if (Return == "1")
            {
                Exit();
            }
        }

        void MailWAR() //메일발송(경고)
        {

            StringBuilder temp = new StringBuilder();

            Int64 ret = GetPrivateProfileString("E", "Key", "Erro:" + Environment.NewLine + "계정 정보를 불러올 수 없습니다.", temp, 255, "C:\\Windows\\E_Key.ini");
            string Temp = temp.ToString();


            string WARN = Demodulation(Temp);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            client.EnableSsl = true;  // SSL을 사용한다.
            client.DeliveryMethod = SmtpDeliveryMethod.Network; // 이걸 하지 않으면 Gmail에 인증을 받지 못한다.
            client.Credentials = new System.Net.NetworkCredential("kac4484@gmail.com", "wkdtjsgh2tlf@");

            MailAddress from = new MailAddress("kac4484@gmail.com", "[경고]비정상적 접근", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(WARN);

            MailMessage message = new MailMessage(from, to);

            message.Body = "누군가 컴퓨터에 접근했습니다!!" + Environment.NewLine + "[IP기반 위치추적]" + Environment.NewLine + GPS;

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "[경고]누군가 컴퓨터에 접근했습니다!!";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            Attachment attachment;
            attachment = new System.Net.Mail.Attachment(CAPTURE);
            message.Attachments.Add(attachment);

            try
            {
                // 동기로 메일을 보낸다.
                client.Send(message);

                // Clean up.
                message.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void Del(string dir) //파일 삭제부분
        {

            foreach (string name in Directory.GetFiles(dir))
            {
                File.Delete(name);
            }

            foreach (string name in Directory.GetDirectories(dir))
            {
                Del(name);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData))
            {
                if (keyData.Equals(Keys.Enter))
                {
                    LogIn.PerformClick();
                    return true;
                }
                if (keyData.Equals(Keys.Alt) || keyData.Equals(Keys.Tab))
                {
                    MessageBox.Show("Alt + TAB 사용불가");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        void ProcessKill() //"taskmgr"프로세스 사용불가 함수
        {
            while (Count != 1)
            {
                try
                {
                    Process[] ProcessList = Process.GetProcessesByName("taskmgr");


                    if (ProcessList.Length > 0)
                    {
                        ProcessList[0].Kill();
                    }
                }
                catch
                {

                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            MessageBox.Show("종료불가");
        }
    }
}

    class test1 //복호화 클래스
    {
        public List<Int64> a
        {
            get;
            set;
        }
    }