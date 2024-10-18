namespace Ordering_taxi
{
    partial class UserOrders
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.car = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выборToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(527, 315);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(547, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(154, 28);
            this.nameLabel.TabIndex = 35;
            this.nameLabel.Text = "Дата и время:";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(547, 46);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 28);
            this.date.TabIndex = 36;
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.price.ForeColor = System.Drawing.Color.White;
            this.price.Location = new System.Drawing.Point(547, 84);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(70, 28);
            this.price.TabIndex = 37;
            this.price.Text = "Цена:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(547, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 38;
            this.label1.Text = "Машина:";
            // 
            // car
            // 
            this.car.AutoSize = true;
            this.car.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.car.ForeColor = System.Drawing.Color.White;
            this.car.Location = new System.Drawing.Point(547, 162);
            this.car.Name = "car";
            this.car.Size = new System.Drawing.Size(0, 28);
            this.car.TabIndex = 39;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выборToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выборToolStripMenuItem
            // 
            this.выборToolStripMenuItem.Name = "выборToolStripMenuItem";
            this.выборToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.выборToolStripMenuItem.Text = "Выбор";
            this.выборToolStripMenuItem.Click += new System.EventHandler(this.выборToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // UserOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(154)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(800, 339);
            this.Controls.Add(this.car);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.price);
            this.Controls.Add(this.date);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserOrders";
            this.Text = "Мои заказы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label car;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выборToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
    }
}