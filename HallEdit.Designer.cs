
namespace ConferenceHallAPI
{
    partial class RedactHall
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
            this.HallEditTable = new System.Windows.Forms.DataGridView();
            this.HallSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.HallCreateMove = new System.Windows.Forms.Button();
            this.EditSave = new System.Windows.Forms.Button();
            this.RemoveHall = new System.Windows.Forms.Button();
            this.RentMakeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HallEditTable)).BeginInit();
            this.SuspendLayout();
            // 
            // HallEditTable
            // 
            this.HallEditTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HallEditTable.Location = new System.Drawing.Point(3, 104);
            this.HallEditTable.Name = "HallEditTable";
            this.HallEditTable.RowHeadersWidth = 51;
            this.HallEditTable.RowTemplate.Height = 29;
            this.HallEditTable.Size = new System.Drawing.Size(998, 216);
            this.HallEditTable.TabIndex = 0;
            // 
            // HallSelectorComboBox
            // 
            this.HallSelectorComboBox.FormattingEnabled = true;
            this.HallSelectorComboBox.Location = new System.Drawing.Point(13, 13);
            this.HallSelectorComboBox.Name = "HallSelectorComboBox";
            this.HallSelectorComboBox.Size = new System.Drawing.Size(151, 28);
            this.HallSelectorComboBox.TabIndex = 1;
            this.HallSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.HallSelectorComboBox_SelectedIndexChanged);
            // 
            // HallCreateMove
            // 
            this.HallCreateMove.Location = new System.Drawing.Point(999, 13);
            this.HallCreateMove.Name = "HallCreateMove";
            this.HallCreateMove.Size = new System.Drawing.Size(94, 29);
            this.HallCreateMove.TabIndex = 2;
            this.HallCreateMove.Text = "Створення";
            this.HallCreateMove.UseVisualStyleBackColor = true;
            this.HallCreateMove.Click += new System.EventHandler(this.HallCreateMove_Click);
            // 
            // EditSave
            // 
            this.EditSave.Location = new System.Drawing.Point(13, 398);
            this.EditSave.Name = "EditSave";
            this.EditSave.Size = new System.Drawing.Size(170, 29);
            this.EditSave.TabIndex = 3;
            this.EditSave.Text = "Зберегти зміни";
            this.EditSave.UseVisualStyleBackColor = true;
            this.EditSave.Click += new System.EventHandler(this.EditSave_Click);
            // 
            // RemoveHall
            // 
            this.RemoveHall.Location = new System.Drawing.Point(237, 398);
            this.RemoveHall.Name = "RemoveHall";
            this.RemoveHall.Size = new System.Drawing.Size(156, 29);
            this.RemoveHall.TabIndex = 4;
            this.RemoveHall.Text = "Видалити залу";
            this.RemoveHall.UseVisualStyleBackColor = true;
            this.RemoveHall.Click += new System.EventHandler(this.RemoveHall_Click);
            // 
            // RentMakeButton
            // 
            this.RentMakeButton.Location = new System.Drawing.Point(999, 49);
            this.RentMakeButton.Name = "RentMakeButton";
            this.RentMakeButton.Size = new System.Drawing.Size(94, 29);
            this.RentMakeButton.TabIndex = 5;
            this.RentMakeButton.Text = "Оренда";
            this.RentMakeButton.UseVisualStyleBackColor = true;
            this.RentMakeButton.Click += new System.EventHandler(this.RentMakeButton_Click);
            // 
            // RedactHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 450);
            this.Controls.Add(this.RentMakeButton);
            this.Controls.Add(this.RemoveHall);
            this.Controls.Add(this.EditSave);
            this.Controls.Add(this.HallCreateMove);
            this.Controls.Add(this.HallSelectorComboBox);
            this.Controls.Add(this.HallEditTable);
            this.Name = "RedactHall";
            this.Text = "Редагування зали";
            this.Load += new System.EventHandler(this.RedactHall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HallEditTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HallEditTable;
        private System.Windows.Forms.ComboBox HallSelectorComboBox;
        private System.Windows.Forms.Button HallCreateMove;
        private System.Windows.Forms.Button EditSave;
        private System.Windows.Forms.Button RemoveHall;
        private System.Windows.Forms.Button RentMakeButton;
    }
}