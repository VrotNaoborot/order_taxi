namespace Ordering_taxi
{
    partial class Auth
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 28);
            this.label4.TabIndex = 45;
            this.label4.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(60, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 28);
            this.label3.TabIndex = 44;
            this.label3.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 13.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(132, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 26);
            this.label2.TabIndex = 43;
            this.label2.Text = "Регистрация";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Sitka Small", 13.25F);
            this.password.Location = new System.Drawing.Point(111, 233);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(220, 30);
            this.password.TabIndex = 42;
            this.password.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(374, 43);
            this.button1.TabIndex = 41;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Sitka Small", 13.25F);
            this.login.Location = new System.Drawing.Point(111, 127);
            this.login.Multiline = true;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(220, 45);
            this.login.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 23.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 45);
            this.label1.TabIndex = 37;
            this.label1.Text = "Вход в аккаунт";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Ordering_taxi.Properties.Resources.icons8_пароль_64__1_;
            this.pictureBox2.Location = new System.Drawing.Point(65, 233);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Ordering_taxi.Properties.Resources.icons8_пользователь_100;
            this.pictureBox1.Location = new System.Drawing.Point(65, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(154)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(398, 392);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Name = "Auth";
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label1;
    }
}