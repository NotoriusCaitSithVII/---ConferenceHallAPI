
namespace ConferenceHallAPI
{
    partial class SeeRent
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
            this.ExistRentViewer = new System.Windows.Forms.DataGridView();
            this.returnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExistRentViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // ExistRentViewer
            // 
            this.ExistRentViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExistRentViewer.Location = new System.Drawing.Point(1, 0);
            this.ExistRentViewer.Name = "ExistRentViewer";
            this.ExistRentViewer.RowHeadersWidth = 51;
            this.ExistRentViewer.RowTemplate.Height = 29;
            this.ExistRentViewer.Size = new System.Drawing.Size(801, 403);
            this.ExistRentViewer.TabIndex = 0;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(694, 409);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(94, 29);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Назад";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // SeeRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.ExistRentViewer);
            this.Name = "SeeRent";
            this.Text = "SeeRent";
            this.Load += new System.EventHandler(this.SeeRent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExistRentViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ExistRentViewer;
        private System.Windows.Forms.Button returnButton;
    }
}