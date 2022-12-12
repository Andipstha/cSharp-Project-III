namespace LMS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LOGIN = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.loginButton = new System.Windows.Forms.Button();
            this.usrTxt = new System.Windows.Forms.TextBox();
=======
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(149, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "username";
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(146, 266);
            this.passTxt.Name = "passTxt";
<<<<<<< HEAD
            this.passTxt.Size = new System.Drawing.Size(168, 23);
=======
            this.passTxt.PasswordChar = '*';
            this.passTxt.PlaceholderText = "Enter password";
            this.passTxt.Size = new System.Drawing.Size(165, 23);
>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3
            this.passTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(146, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // LOGIN
            // 
            this.LOGIN.AutoSize = true;
            this.LOGIN.BackColor = System.Drawing.Color.MintCream;
            this.LOGIN.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LOGIN.ForeColor = System.Drawing.Color.Black;
            this.LOGIN.Location = new System.Drawing.Point(149, 119);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(102, 39);
            this.LOGIN.TabIndex = 8;
            this.LOGIN.Text = "LOGIN";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(146, 305);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(168, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usrTxt
            // 
            this.usrTxt.Location = new System.Drawing.Point(149, 207);
            this.usrTxt.Name = "usrTxt";
            this.usrTxt.Size = new System.Drawing.Size(165, 23);
            this.usrTxt.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button2.Location = new System.Drawing.Point(857, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(343, 410);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 458);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usrTxt);
            this.Controls.Add(this.label1);
<<<<<<< HEAD
=======
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox passTxt;
        private Label label2;
        private Label LOGIN;
<<<<<<< HEAD
        private Button loginButton;
        private TextBox usrTxt;
=======
        private Button button1;
        private Button button2;
>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3
    }
}