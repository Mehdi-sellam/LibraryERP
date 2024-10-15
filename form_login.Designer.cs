
namespace Library_Managment_System_VDW
{
    partial class form_login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_login));
            this.panel_Registration = new System.Windows.Forms.Panel();
            this.link_register = new System.Windows.Forms.LinkLabel();
            this.label_question = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.PictureBox();
            this.button_login = new System.Windows.Forms.Button();
            this.panel_password = new System.Windows.Forms.Panel();
            this.text_password = new System.Windows.Forms.TextBox();
            this.panel_username = new System.Windows.Forms.Panel();
            this.text_username = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.label_sublogo = new System.Windows.Forms.Label();
            this.label_logo = new System.Windows.Forms.Label();
            this.picture_logo = new System.Windows.Forms.PictureBox();
            this.panel_Registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_close)).BeginInit();
            this.panel_password.SuspendLayout();
            this.panel_username.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Registration
            // 
            this.panel_Registration.Controls.Add(this.link_register);
            this.panel_Registration.Controls.Add(this.label_question);
            this.panel_Registration.Controls.Add(this.button_close);
            this.panel_Registration.Controls.Add(this.button_login);
            this.panel_Registration.Controls.Add(this.panel_password);
            this.panel_Registration.Controls.Add(this.panel_username);
            this.panel_Registration.Controls.Add(this.label_password);
            this.panel_Registration.Controls.Add(this.label_username);
            this.panel_Registration.Controls.Add(this.label_login);
            this.panel_Registration.Location = new System.Drawing.Point(339, 3);
            this.panel_Registration.Name = "panel_Registration";
            this.panel_Registration.Size = new System.Drawing.Size(422, 440);
            this.panel_Registration.TabIndex = 5;
            // 
            // link_register
            // 
            this.link_register.AutoSize = true;
            this.link_register.Location = new System.Drawing.Point(163, 396);
            this.link_register.Name = "link_register";
            this.link_register.Size = new System.Drawing.Size(72, 21);
            this.link_register.TabIndex = 24;
            this.link_register.TabStop = true;
            this.link_register.Text = "Register";
            this.link_register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_register_LinkClicked);
            // 
            // label_question
            // 
            this.label_question.AutoSize = true;
            this.label_question.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_question.Location = new System.Drawing.Point(102, 362);
            this.label_question.Name = "label_question";
            this.label_question.Size = new System.Drawing.Size(200, 19);
            this.label_question.TabIndex = 23;
            this.label_question.Text = "Don\'t have an Account ?";
            // 
            // button_close
            // 
            this.button_close.Image = ((System.Drawing.Image)(resources.GetObject("button_close.Image")));
            this.button_close.Location = new System.Drawing.Point(389, 3);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(30, 30);
            this.button_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button_close.TabIndex = 22;
            this.button_close.TabStop = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.Tan;
            this.button_login.FlatAppearance.BorderSize = 0;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(106, 306);
            this.button_login.Margin = new System.Windows.Forms.Padding(0);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(185, 35);
            this.button_login.TabIndex = 21;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // panel_password
            // 
            this.panel_password.BackColor = System.Drawing.Color.Tan;
            this.panel_password.Controls.Add(this.text_password);
            this.panel_password.ForeColor = System.Drawing.Color.White;
            this.panel_password.Location = new System.Drawing.Point(59, 228);
            this.panel_password.Name = "panel_password";
            this.panel_password.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel_password.Size = new System.Drawing.Size(300, 30);
            this.panel_password.TabIndex = 19;
            // 
            // text_password
            // 
            this.text_password.BackColor = System.Drawing.Color.White;
            this.text_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_password.ForeColor = System.Drawing.Color.Black;
            this.text_password.Location = new System.Drawing.Point(0, 0);
            this.text_password.Multiline = true;
            this.text_password.Name = "text_password";
            this.text_password.PasswordChar = '*';
            this.text_password.Size = new System.Drawing.Size(300, 27);
            this.text_password.TabIndex = 0;
            // 
            // panel_username
            // 
            this.panel_username.BackColor = System.Drawing.Color.Tan;
            this.panel_username.Controls.Add(this.text_username);
            this.panel_username.Controls.Add(this.textBox2);
            this.panel_username.ForeColor = System.Drawing.Color.White;
            this.panel_username.Location = new System.Drawing.Point(59, 138);
            this.panel_username.Name = "panel_username";
            this.panel_username.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel_username.Size = new System.Drawing.Size(300, 30);
            this.panel_username.TabIndex = 20;
            // 
            // text_username
            // 
            this.text_username.BackColor = System.Drawing.Color.White;
            this.text_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_username.ForeColor = System.Drawing.Color.Black;
            this.text_username.Location = new System.Drawing.Point(0, 0);
            this.text_username.Multiline = true;
            this.text_username.Name = "text_username";
            this.text_username.Size = new System.Drawing.Size(300, 27);
            this.text_username.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.ForeColor = System.Drawing.Color.Tan;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 27);
            this.textBox2.TabIndex = 0;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(55, 204);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(80, 19);
            this.label_password.TabIndex = 14;
            this.label_password.Text = "Password";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.Location = new System.Drawing.Point(55, 114);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(93, 19);
            this.label_username.TabIndex = 15;
            this.label_username.Text = "User Name";
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login.Location = new System.Drawing.Point(20, 18);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(99, 38);
            this.label_login.TabIndex = 16;
            this.label_login.Text = "Login";
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.Tan;
            this.panel_logo.Controls.Add(this.label_sublogo);
            this.panel_logo.Controls.Add(this.label_logo);
            this.panel_logo.Controls.Add(this.picture_logo);
            this.panel_logo.Location = new System.Drawing.Point(9, 3);
            this.panel_logo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(327, 440);
            this.panel_logo.TabIndex = 4;
            // 
            // label_sublogo
            // 
            this.label_sublogo.AutoSize = true;
            this.label_sublogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_sublogo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sublogo.ForeColor = System.Drawing.Color.White;
            this.label_sublogo.Location = new System.Drawing.Point(50, 275);
            this.label_sublogo.Name = "label_sublogo";
            this.label_sublogo.Size = new System.Drawing.Size(194, 46);
            this.label_sublogo.TabIndex = 1;
            this.label_sublogo.Text = "Library \r\nManagment System";
            this.label_sublogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_logo
            // 
            this.label_logo.AutoSize = true;
            this.label_logo.ForeColor = System.Drawing.Color.White;
            this.label_logo.Location = new System.Drawing.Point(86, 209);
            this.label_logo.Name = "label_logo";
            this.label_logo.Size = new System.Drawing.Size(116, 21);
            this.label_logo.TabIndex = 1;
            this.label_logo.Text = "Insight Library";
            // 
            // picture_logo
            // 
            this.picture_logo.Image = ((System.Drawing.Image)(resources.GetObject("picture_logo.Image")));
            this.picture_logo.Location = new System.Drawing.Point(90, 87);
            this.picture_logo.Margin = new System.Windows.Forms.Padding(0);
            this.picture_logo.Name = "picture_logo";
            this.picture_logo.Size = new System.Drawing.Size(100, 110);
            this.picture_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_logo.TabIndex = 0;
            this.picture_logo.TabStop = false;
            // 
            // form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 447);
            this.Controls.Add(this.panel_Registration);
            this.Controls.Add(this.panel_logo);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.Tan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "form_login";
            this.Text = "Form1";
            this.panel_Registration.ResumeLayout(false);
            this.panel_Registration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_close)).EndInit();
            this.panel_password.ResumeLayout(false);
            this.panel_password.PerformLayout();
            this.panel_username.ResumeLayout(false);
            this.panel_username.PerformLayout();
            this.panel_logo.ResumeLayout(false);
            this.panel_logo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Registration;
        private System.Windows.Forms.LinkLabel link_register;
        private System.Windows.Forms.Label label_question;
        private System.Windows.Forms.PictureBox button_close;
        private System.Windows.Forms.Button button_login;
        public System.Windows.Forms.Panel panel_password;
        private System.Windows.Forms.TextBox text_password;
        public System.Windows.Forms.Panel panel_username;
        private System.Windows.Forms.TextBox text_username;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Label label_sublogo;
        private System.Windows.Forms.Label label_logo;
        private System.Windows.Forms.PictureBox picture_logo;
    }
}

