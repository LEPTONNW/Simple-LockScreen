namespace LockScreen_FN
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Pass = new System.Windows.Forms.TextBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.EX = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.Forgot = new System.Windows.Forms.Button();
            this.LogIn = new System.Windows.Forms.Button();
            this.SingUp = new System.Windows.Forms.Button();
            this.DelAccount = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Pass
            // 
            this.Pass.BackColor = System.Drawing.Color.White;
            this.Pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pass.ForeColor = System.Drawing.Color.Black;
            this.Pass.Location = new System.Drawing.Point(21, 83);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '●';
            this.Pass.Size = new System.Drawing.Size(292, 21);
            this.Pass.TabIndex = 22;
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Font = new System.Drawing.Font("한컴 바겐세일 M", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PassLabel.ForeColor = System.Drawing.Color.White;
            this.PassLabel.Location = new System.Drawing.Point(16, 41);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(119, 37);
            this.PassLabel.TabIndex = 30;
            this.PassLabel.Text = "패스워드 ";
            // 
            // EX
            // 
            this.EX.BackColor = System.Drawing.Color.Aqua;
            this.EX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EX.Font = new System.Drawing.Font("한양해서", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EX.ForeColor = System.Drawing.Color.Black;
            this.EX.Location = new System.Drawing.Point(272, -1);
            this.EX.Name = "EX";
            this.EX.Size = new System.Drawing.Size(60, 28);
            this.EX.TabIndex = 29;
            this.EX.Text = "종료";
            this.EX.UseVisualStyleBackColor = false;
            this.EX.Click += new System.EventHandler(this.EX_Click);
            // 
            // timer
            // 
            this.timer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(112)))), ((int)(((byte)(151)))));
            this.timer.Enabled = false;
            this.timer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.timer.Font = new System.Drawing.Font("한컴 바겐세일 M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.timer.ForeColor = System.Drawing.Color.White;
            this.timer.Location = new System.Drawing.Point(18, 304);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(297, 51);
            this.timer.TabIndex = 28;
            this.timer.Text = "시계";
            this.timer.UseVisualStyleBackColor = false;
            this.timer.Click += new System.EventHandler(this.timer_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("한컴 바겐세일 M", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Info.ForeColor = System.Drawing.Color.SkyBlue;
            this.Info.Location = new System.Drawing.Point(34, 275);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(258, 22);
            this.Info.TabIndex = 27;
            this.Info.Text = "먼저 로그인을해야 사용이 가능합니다.";
            // 
            // Forgot
            // 
            this.Forgot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(111)))));
            this.Forgot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Forgot.Font = new System.Drawing.Font("한컴 바겐세일 M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Forgot.ForeColor = System.Drawing.Color.White;
            this.Forgot.Location = new System.Drawing.Point(160, 127);
            this.Forgot.Name = "Forgot";
            this.Forgot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Forgot.Size = new System.Drawing.Size(153, 52);
            this.Forgot.TabIndex = 26;
            this.Forgot.Text = "준비중";
            this.Forgot.UseVisualStyleBackColor = false;
            // 
            // LogIn
            // 
            this.LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(205)))));
            this.LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogIn.Font = new System.Drawing.Font("한컴 바겐세일 M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LogIn.ForeColor = System.Drawing.Color.White;
            this.LogIn.Location = new System.Drawing.Point(16, 127);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(114, 52);
            this.LogIn.TabIndex = 25;
            this.LogIn.Text = "로그인";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // SingUp
            // 
            this.SingUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(111)))));
            this.SingUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SingUp.Font = new System.Drawing.Font("한컴 바겐세일 M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SingUp.ForeColor = System.Drawing.Color.White;
            this.SingUp.Location = new System.Drawing.Point(16, 199);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(297, 68);
            this.SingUp.TabIndex = 24;
            this.SingUp.Text = "아이디 등록";
            this.SingUp.UseVisualStyleBackColor = false;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // DelAccount
            // 
            this.DelAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(72)))), ((int)(((byte)(111)))));
            this.DelAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DelAccount.Font = new System.Drawing.Font("한컴 바겐세일 M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DelAccount.ForeColor = System.Drawing.Color.White;
            this.DelAccount.Location = new System.Drawing.Point(18, 371);
            this.DelAccount.Name = "DelAccount";
            this.DelAccount.Size = new System.Drawing.Size(297, 51);
            this.DelAccount.TabIndex = 23;
            this.DelAccount.Text = "계정삭제 및 자동실행 끄기";
            this.DelAccount.UseVisualStyleBackColor = false;
            this.DelAccount.Click += new System.EventHandler(this.DelAccount_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 바겐세일 M", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "계정 등록시 종료버튼이 사라집니다.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(333, 452);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.EX);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Forgot);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.DelAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Button EX;
        private System.Windows.Forms.Button timer;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Button Forgot;
        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.Button DelAccount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

