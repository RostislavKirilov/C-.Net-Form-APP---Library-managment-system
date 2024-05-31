namespace LibraryManagmentSystem
{
    partial class AddBooks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addBook_ImpBtn = new System.Windows.Forms.Button();
            this.addBooks_ClearBtn = new System.Windows.Forms.Button();
            this.addBooks_DeleteBtn = new System.Windows.Forms.Button();
            this.addBooks_Status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addBooks_Published = new System.Windows.Forms.DateTimePicker();
            this.addBooks_UpdateBtn = new System.Windows.Forms.Button();
            this.addBooks_btn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.addBooks_Author = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addBooks_Title = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addBooks_picture = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBooks_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(333, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 533);
            this.panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(405, 443);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Всички заети книги";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.addBook_ImpBtn);
            this.panel1.Controls.Add(this.addBooks_ClearBtn);
            this.panel1.Controls.Add(this.addBooks_DeleteBtn);
            this.panel1.Controls.Add(this.addBooks_Status);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.addBooks_Published);
            this.panel1.Controls.Add(this.addBooks_UpdateBtn);
            this.panel1.Controls.Add(this.addBooks_btn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.addBooks_Author);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.addBooks_Title);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.addBooks_picture);
            this.panel1.Location = new System.Drawing.Point(18, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 533);
            this.panel1.TabIndex = 2;
            // 
            // addBook_ImpBtn
            // 
            this.addBook_ImpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            this.addBook_ImpBtn.FlatAppearance.BorderSize = 0;
            this.addBook_ImpBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.addBook_ImpBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.addBook_ImpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBook_ImpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBook_ImpBtn.ForeColor = System.Drawing.Color.White;
            this.addBook_ImpBtn.Location = new System.Drawing.Point(99, 116);
            this.addBook_ImpBtn.Name = "addBook_ImpBtn";
            this.addBook_ImpBtn.Size = new System.Drawing.Size(101, 29);
            this.addBook_ImpBtn.TabIndex = 22;
            this.addBook_ImpBtn.Text = "КАЧИ";
            this.addBook_ImpBtn.UseVisualStyleBackColor = false;
            this.addBook_ImpBtn.Click += new System.EventHandler(this.addBook_ImpBtn_Click);
            // 
            // addBooks_ClearBtn
            // 
            this.addBooks_ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            this.addBooks_ClearBtn.FlatAppearance.BorderSize = 0;
            this.addBooks_ClearBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_ClearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBooks_ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_ClearBtn.ForeColor = System.Drawing.Color.White;
            this.addBooks_ClearBtn.Location = new System.Drawing.Point(169, 458);
            this.addBooks_ClearBtn.Name = "addBooks_ClearBtn";
            this.addBooks_ClearBtn.Size = new System.Drawing.Size(114, 40);
            this.addBooks_ClearBtn.TabIndex = 21;
            this.addBooks_ClearBtn.Text = "ИЗЧИСТИ";
            this.addBooks_ClearBtn.UseVisualStyleBackColor = false;
            this.addBooks_ClearBtn.Click += new System.EventHandler(this.addBooks_ClearBtn_Click);
            // 
            // addBooks_DeleteBtn
            // 
            this.addBooks_DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            this.addBooks_DeleteBtn.FlatAppearance.BorderSize = 0;
            this.addBooks_DeleteBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_DeleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBooks_DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.addBooks_DeleteBtn.Location = new System.Drawing.Point(18, 458);
            this.addBooks_DeleteBtn.Name = "addBooks_DeleteBtn";
            this.addBooks_DeleteBtn.Size = new System.Drawing.Size(109, 40);
            this.addBooks_DeleteBtn.TabIndex = 20;
            this.addBooks_DeleteBtn.Text = "ИЗТРИЙ";
            this.addBooks_DeleteBtn.UseVisualStyleBackColor = false;
            this.addBooks_DeleteBtn.Click += new System.EventHandler(this.addBooks_DeleteBtn_Click);
            // 
            // addBooks_Status
            // 
            this.addBooks_Status.FormattingEnabled = true;
            this.addBooks_Status.Items.AddRange(new object[] {
            "Available",
            "Not available"});
            this.addBooks_Status.Location = new System.Drawing.Point(129, 319);
            this.addBooks_Status.Name = "addBooks_Status";
            this.addBooks_Status.Size = new System.Drawing.Size(154, 24);
            this.addBooks_Status.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Статус:";
            // 
            // addBooks_Published
            // 
            this.addBooks_Published.Location = new System.Drawing.Point(129, 277);
            this.addBooks_Published.Name = "addBooks_Published";
            this.addBooks_Published.Size = new System.Drawing.Size(154, 22);
            this.addBooks_Published.TabIndex = 17;
            // 
            // addBooks_UpdateBtn
            // 
            this.addBooks_UpdateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            this.addBooks_UpdateBtn.FlatAppearance.BorderSize = 0;
            this.addBooks_UpdateBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_UpdateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBooks_UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_UpdateBtn.ForeColor = System.Drawing.Color.White;
            this.addBooks_UpdateBtn.Location = new System.Drawing.Point(169, 389);
            this.addBooks_UpdateBtn.Name = "addBooks_UpdateBtn";
            this.addBooks_UpdateBtn.Size = new System.Drawing.Size(114, 40);
            this.addBooks_UpdateBtn.TabIndex = 16;
            this.addBooks_UpdateBtn.Text = "ОБНОВИ";
            this.addBooks_UpdateBtn.UseVisualStyleBackColor = false;
            this.addBooks_UpdateBtn.Click += new System.EventHandler(this.addBooks_UpdateBtn_Click);
            // 
            // addBooks_btn
            // 
            this.addBooks_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            this.addBooks_btn.FlatAppearance.BorderSize = 0;
            this.addBooks_btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.addBooks_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBooks_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_btn.ForeColor = System.Drawing.Color.White;
            this.addBooks_btn.Location = new System.Drawing.Point(18, 389);
            this.addBooks_btn.Name = "addBooks_btn";
            this.addBooks_btn.Size = new System.Drawing.Size(109, 40);
            this.addBooks_btn.TabIndex = 15;
            this.addBooks_btn.Text = "ДОБАВИ";
            this.addBooks_btn.UseVisualStyleBackColor = false;
            this.addBooks_btn.Click += new System.EventHandler(this.addBooks_btn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Публикувана:";
            // 
            // addBooks_Author
            // 
            this.addBooks_Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_Author.Location = new System.Drawing.Point(128, 222);
            this.addBooks_Author.Name = "addBooks_Author";
            this.addBooks_Author.Size = new System.Drawing.Size(155, 28);
            this.addBooks_Author.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(25, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Автор:";
            // 
            // addBooks_Title
            // 
            this.addBooks_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBooks_Title.Location = new System.Drawing.Point(128, 179);
            this.addBooks_Title.Name = "addBooks_Title";
            this.addBooks_Title.Size = new System.Drawing.Size(155, 28);
            this.addBooks_Title.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(14, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Заглавие:";
            // 
            // addBooks_picture
            // 
            this.addBooks_picture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.addBooks_picture.Location = new System.Drawing.Point(99, 17);
            this.addBooks_picture.Name = "addBooks_picture";
            this.addBooks_picture.Size = new System.Drawing.Size(101, 93);
            this.addBooks_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addBooks_picture.TabIndex = 8;
            this.addBooks_picture.TabStop = false;
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddBooks";
            this.Size = new System.Drawing.Size(1000, 610);
            this.Load += new System.EventHandler(this.AddBooks_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addBooks_picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addBooks_UpdateBtn;
        private System.Windows.Forms.Button addBooks_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addBooks_Author;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox addBooks_Title;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox addBooks_picture;
        private System.Windows.Forms.ComboBox addBooks_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker addBooks_Published;
        private System.Windows.Forms.Button addBooks_ClearBtn;
        private System.Windows.Forms.Button addBooks_DeleteBtn;
        private System.Windows.Forms.Button addBook_ImpBtn;
    }
}
