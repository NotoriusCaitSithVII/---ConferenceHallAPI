
namespace ConferenceHallAPI
{
    partial class CreateHall
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
            this.HallNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HallSizeCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RentBase = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.HallCreate = new System.Windows.Forms.Button();
            this.AvaliableServices = new System.Windows.Forms.DataGridView();
            this.HallEditMove = new System.Windows.Forms.Button();
            this.RentMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HallSizeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvaliableServices)).BeginInit();
            this.SuspendLayout();
            // 
            // HallNameTextBox
            // 
            this.HallNameTextBox.Location = new System.Drawing.Point(12, 41);
            this.HallNameTextBox.Name = "HallNameTextBox";
            this.HallNameTextBox.Size = new System.Drawing.Size(125, 27);
            this.HallNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Назва зали";
            // 
            // HallSizeCount
            // 
            this.HallSizeCount.Location = new System.Drawing.Point(12, 105);
            this.HallSizeCount.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.HallSizeCount.Name = "HallSizeCount";
            this.HallSizeCount.Size = new System.Drawing.Size(150, 27);
            this.HallSizeCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кількість осіб (макс. 150)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Базова вартість оренди за годину";
            // 
            // RentBase
            // 
            this.RentBase.Location = new System.Drawing.Point(12, 172);
            this.RentBase.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.RentBase.Name = "RentBase";
            this.RentBase.Size = new System.Drawing.Size(150, 27);
            this.RentBase.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Послуги";
            // 
            // HallCreate
            // 
            this.HallCreate.Location = new System.Drawing.Point(145, 385);
            this.HallCreate.Name = "HallCreate";
            this.HallCreate.Size = new System.Drawing.Size(166, 71);
            this.HallCreate.TabIndex = 9;
            this.HallCreate.Text = "Створити залу";
            this.HallCreate.UseVisualStyleBackColor = true;
            this.HallCreate.Click += new System.EventHandler(this.HallCreate_Click);
            // 
            // AvaliableServices
            // 
            this.AvaliableServices.AllowUserToAddRows = false;
            this.AvaliableServices.AllowUserToDeleteRows = false;
            this.AvaliableServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvaliableServices.Location = new System.Drawing.Point(12, 240);
            this.AvaliableServices.Name = "AvaliableServices";
            this.AvaliableServices.ReadOnly = true;
            this.AvaliableServices.RowHeadersWidth = 51;
            this.AvaliableServices.RowTemplate.Height = 29;
            this.AvaliableServices.Size = new System.Drawing.Size(435, 139);
            this.AvaliableServices.TabIndex = 10;
            this.AvaliableServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // HallEditMove
            // 
            this.HallEditMove.Location = new System.Drawing.Point(371, 13);
            this.HallEditMove.Name = "HallEditMove";
            this.HallEditMove.Size = new System.Drawing.Size(94, 29);
            this.HallEditMove.TabIndex = 11;
            this.HallEditMove.Text = "Редагувати";
            this.HallEditMove.UseVisualStyleBackColor = true;
            this.HallEditMove.Click += new System.EventHandler(this.HallEditMove_Click);
            // 
            // RentMove
            // 
            this.RentMove.Location = new System.Drawing.Point(370, 49);
            this.RentMove.Name = "RentMove";
            this.RentMove.Size = new System.Drawing.Size(94, 29);
            this.RentMove.TabIndex = 12;
            this.RentMove.Text = "Оренда";
            this.RentMove.UseVisualStyleBackColor = true;
            this.RentMove.Click += new System.EventHandler(this.RentMove_Click);
            // 
            // CreateHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 473);
            this.Controls.Add(this.RentMove);
            this.Controls.Add(this.HallEditMove);
            this.Controls.Add(this.AvaliableServices);
            this.Controls.Add(this.HallCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RentBase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HallSizeCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HallNameTextBox);
            this.Name = "CreateHall";
            this.Text = "Створити залу";
            this.Load += new System.EventHandler(this.CreateHall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HallSizeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RentBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvaliableServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HallNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown HallSizeCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RentBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button HallCreate;
        private System.Windows.Forms.DataGridView AvaliableServices;
        private System.Windows.Forms.Button HallEditMove;
        private System.Windows.Forms.Button RentMove;
    }
}

