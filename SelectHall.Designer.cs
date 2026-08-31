
namespace ConferenceHallAPI
{
    partial class SelectHall
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
            this.HallComboBox = new System.Windows.Forms.ComboBox();
            this.HallSelectTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectRentButton = new System.Windows.Forms.Button();
            this.RentDateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.RentDateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateHallButton = new System.Windows.Forms.Button();
            this.EditHallButton = new System.Windows.Forms.Button();
            this.ExistRent = new System.Windows.Forms.Button();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HallSelectTable)).BeginInit();
            this.SuspendLayout();
            // 
            // HallComboBox
            // 
            this.HallComboBox.FormattingEnabled = true;
            this.HallComboBox.Location = new System.Drawing.Point(21, 43);
            this.HallComboBox.Name = "HallComboBox";
            this.HallComboBox.Size = new System.Drawing.Size(151, 28);
            this.HallComboBox.TabIndex = 0;
            this.HallComboBox.SelectedIndexChanged += new System.EventHandler(this.HallComboBox_SelectedIndexChanged_1);
            // 
            // HallSelectTable
            // 
            this.HallSelectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HallSelectTable.Location = new System.Drawing.Point(21, 104);
            this.HallSelectTable.Name = "HallSelectTable";
            this.HallSelectTable.RowHeadersWidth = 51;
            this.HallSelectTable.RowTemplate.Height = 29;
            this.HallSelectTable.Size = new System.Drawing.Size(1084, 188);
            this.HallSelectTable.TabIndex = 1;
            this.HallSelectTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.HallSelectTable_CellValueChanged);
            this.HallSelectTable.CurrentCellDirtyStateChanged += new System.EventHandler(this.HallSelectTable_CurrentCellDirtyStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Оберіть залу";
            // 
            // SelectRentButton
            // 
            this.SelectRentButton.Location = new System.Drawing.Point(21, 394);
            this.SelectRentButton.Name = "SelectRentButton";
            this.SelectRentButton.Size = new System.Drawing.Size(119, 29);
            this.SelectRentButton.TabIndex = 3;
            this.SelectRentButton.Text = "Орендувати";
            this.SelectRentButton.UseVisualStyleBackColor = true;
            this.SelectRentButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentDateTimeStart
            // 
            this.RentDateTimeStart.CustomFormat = "HH-mm dd-MMM-yyyy";
            this.RentDateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.RentDateTimeStart.Location = new System.Drawing.Point(12, 330);
            this.RentDateTimeStart.Name = "RentDateTimeStart";
            this.RentDateTimeStart.Size = new System.Drawing.Size(176, 27);
            this.RentDateTimeStart.TabIndex = 4;
            this.RentDateTimeStart.ValueChanged += new System.EventHandler(this.RentDateTimeStart_ValueChanged);
            // 
            // RentDateTimeEnd
            // 
            this.RentDateTimeEnd.CustomFormat = "HH-mm dd-MMM-yyyy";
            this.RentDateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.RentDateTimeEnd.Location = new System.Drawing.Point(231, 330);
            this.RentDateTimeEnd.Name = "RentDateTimeEnd";
            this.RentDateTimeEnd.Size = new System.Drawing.Size(177, 27);
            this.RentDateTimeEnd.TabIndex = 7;
            this.RentDateTimeEnd.ValueChanged += new System.EventHandler(this.RentDateTimeEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Початок оренди";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Кінець оренди";
            // 
            // CreateHallButton
            // 
            this.CreateHallButton.Location = new System.Drawing.Point(995, 4);
            this.CreateHallButton.Name = "CreateHallButton";
            this.CreateHallButton.Size = new System.Drawing.Size(110, 29);
            this.CreateHallButton.TabIndex = 10;
            this.CreateHallButton.Text = "Створення";
            this.CreateHallButton.UseVisualStyleBackColor = true;
            this.CreateHallButton.Click += new System.EventHandler(this.CreateHallButton_Click);
            // 
            // EditHallButton
            // 
            this.EditHallButton.Location = new System.Drawing.Point(995, 43);
            this.EditHallButton.Name = "EditHallButton";
            this.EditHallButton.Size = new System.Drawing.Size(110, 29);
            this.EditHallButton.TabIndex = 11;
            this.EditHallButton.Text = "Редагування";
            this.EditHallButton.UseVisualStyleBackColor = true;
            this.EditHallButton.Click += new System.EventHandler(this.EditHallButton_Click);
            // 
            // ExistRent
            // 
            this.ExistRent.Location = new System.Drawing.Point(968, 409);
            this.ExistRent.Name = "ExistRent";
            this.ExistRent.Size = new System.Drawing.Size(137, 29);
            this.ExistRent.TabIndex = 12;
            this.ExistRent.Text = "Існуюча оренда";
            this.ExistRent.UseVisualStyleBackColor = true;
            this.ExistRent.Click += new System.EventHandler(this.ExistRent_Click);
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(456, 331);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(0, 20);
            this.PriceLabel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Загальна ціна";
            // 
            // SelectHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.ExistRent);
            this.Controls.Add(this.EditHallButton);
            this.Controls.Add(this.CreateHallButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RentDateTimeEnd);
            this.Controls.Add(this.RentDateTimeStart);
            this.Controls.Add(this.SelectRentButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HallSelectTable);
            this.Controls.Add(this.HallComboBox);
            this.Name = "SelectHall";
            this.Text = "SelectHall";
            this.Load += new System.EventHandler(this.SelectHall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HallSelectTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox HallComboBox;
        private System.Windows.Forms.DataGridView HallSelectTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectRentButton;
        private System.Windows.Forms.DateTimePicker RentDateTimeStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateHallButton;
        private System.Windows.Forms.Button EditHallButton;
        private System.Windows.Forms.Button ExistRent;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker RentDateTimeEnd;
    }
}