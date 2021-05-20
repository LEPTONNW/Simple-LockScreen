using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LockScreen_FN
{
    public partial class DelAC : Form
    {
        public DelAC()
        {
            InitializeComponent();
        }

        private void DelAC_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "직접입력";
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string MD5Hash, UserInfo, DemodulationKey, Key, InputKey, SymmetricKey, Input, FilePath = "C:\\Windows\\AdminInfo.ini";

        protected override void WndProc(ref Message m) //FormboardStyle = None 일 경우 마우스 제어 함수
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Email.Text == string.Empty || Pass.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("값이 입력되지 않았습니다");
                return;
            }
            else
            {
                string mail = "";
                mail = Email.Text + comboBox1.Text;
                MD5Hash = getMd5Hash(Convert.ToString(mail + Pass.Text));
                UserInfo = MD5Hash;
                ReadINI();


                if (Key == textBox1.Text)
                {
                    Email.Text = "";
                    textBox1.Text = "";
                    Pass.Text = "";
                    comboBox1.Text = "직접입력";
                    File.Delete("C:\\Windows\\AdminInfo.ini");
                    File.Delete("C:\\Windows\\SC_Key.ini");
                    File.Delete("C:\\Windows\\E_Key.ini");


                    RegistryKey rkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                    if (File.Exists("C:\\Windows\\ENUMA_Key.ocx"))
                    {
                        rkey.DeleteValue("ProgramName", false);
                        MessageBox.Show("자동실행이 등록해제되었습니다.");
                        File.Delete("C:\\Windows\\ENUMA_Key.ocx");
                    }
                    MainForm frm2 = (MainForm)this.Owner; //Owner를 A폼으로 형변환한다.
                    //A폼의 TextBox1이 public으로 선언되어 있기 때문에 접근이 가능하다.
                    frm2.ownerkey = "1";

                    this.Close();
                }
                else
                {
                    Email.Text = "";
                    textBox1.Text = "";
                    Pass.Text = "";
                    comboBox1.Text = "직접입력";
                    MD5Hash = "";
                    Key = "";
                    UserInfo = "";
                    MessageBox.Show("스크린 패스워드가 올바르지 않습니다.");

                }

            }
        }

        void ReadINI()
        {
            StringBuilder temp = new StringBuilder();

            Int64 ret = GetPrivateProfileString(UserInfo, "Key", "입력된 메일과 패스워드가 틀립니다.", temp, 255, FilePath);
            DemodulationKey = temp.ToString();

            Demodulation();

        }

        string getMd5Hash(string input) //MD5
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();

        }

        void Demodulation()
        {
            string temp = "";

            int w;
            string str = DemodulationKey;
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

            foreach (Int64 b in ms.a) //키값 해독후 Key에 파라미터 저장
            {
                Key += Convert.ToChar(b);
            }

        }
    }
}
