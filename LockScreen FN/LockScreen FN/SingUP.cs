using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LockScreen_FN
{
    public partial class SingUP : Form
    {
        public SingUP()
        {
            InitializeComponent();
        }

        public static string Modulation, MD5Hash;
        public static string FilePath = "C:\\Windows\\AdminInfo.ini";
        public string[] shuffled;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void SingUP_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "직접입력";
        }

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
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("정보가 입력되지 않았습니다.");
                }
                else
                {
                    string Email = "";
                    Email = textBox1.Text + comboBox1.Text;

                    MD5Hash = getMd5Hash(Email + textBox2.Text);
                    Modulation = ModulationKey(Convert.ToString(textBox3.Text));
                    CreateINI();


                    if (!File.Exists("C:\\Windows\\ENUMA_Key.ocx"))
                    {
                        RegistryKey rkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        rkey.SetValue("ProgramName", Application.ExecutablePath.ToString());
                        MessageBox.Show("시작프로그램에 자동등록되었습니다.");
                        File.Create("C:\\Windows\\ENUMA_Key.ocx");
                    }
                    else
                    {
                        MessageBox.Show("계정은 최대 1개 까지만 생성이 가능합니다." + Environment.NewLine + "계정을 새로 등록하려면 삭제후 다시 만들어 주세요");
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "직접입력";
                this.Close();
            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "직접입력";
                Modulation = ""; MD5Hash = "";
                File.Delete("C:\\Windows\\AdminInfo.ini");
                File.Delete("C:\\Windowts\\SC_Key.ini");
                File.Delete("C:\\Windows\\E_Key.ini");

                if (File.Exists("C:\\Windows\\ENUMA_Key.ocx"))
                {
                    File.Delete("C:\\Windows\\ENUMA_Key.ocx");
                }
                else

                    MessageBox.Show("정상적으로 입력되지 않았습니다.");
            }
        }

        void CreateINI() //유저 정보파일 생성
        {
            WritePrivateProfileString(MD5Hash, "Key", Modulation, FilePath);
            WritePrivateProfileString("PASS", "Key", Modulation, "C:\\Windows\\SC_Key.ini");

            string E = "";
            E = ModulationKey(Convert.ToString(textBox1.Text + comboBox1.Text));
            WritePrivateProfileString("E", "Key", E, "C:\\Windows\\E_Key.ini");
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

        string ModulationKey(string K) //보안코드 암호화
        {
            string temp = "";

            int x;
            string str = K;
            char[] charcode = str.ToCharArray();
            for (x = 0; x < charcode.Length; x++)
            {
                temp += (int)charcode[x] + "!";
            }
            temp = (temp + (char)((int)10));

            string temp2 = "";
            int w;
            string str2 = temp;
            char[] strArray = str2.ToCharArray();

            for (w = 0; w < strArray.Length; w++)
            {
                if (strArray[w] == '!')
                {
                    temp2 += "!";
                }
                else
                {
                    if (strArray[w] == '0')
                    {
                        temp2 += "Z";

                    }
                    else if (strArray[w] == '1')
                    {
                        temp2 += "O";

                    }
                    else if (strArray[w] == '2')
                    {
                        temp2 += "T";

                    }
                    else if (strArray[w] == '3')
                    {
                        temp2 += "H";

                    }
                    else if (strArray[w] == '4')
                    {
                        temp2 += "F";

                    }
                    else if (strArray[w] == '5')
                    {
                        temp2 += "I";

                    }
                    else if (strArray[w] == '6')
                    {
                        temp2 += "S";

                    }
                    else if (strArray[w] == '7')
                    {
                        temp2 += "V";

                    }
                    else if (strArray[w] == '8')
                    {
                        temp2 += "E";

                    }
                    else if (strArray[w] == '9')
                    {
                        temp2 += "N";

                    }

                }
            }

            return temp2;
        }

    }
}
