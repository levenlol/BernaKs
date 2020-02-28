namespace BernaKs
{
    partial class QueryMemoryForm
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
            this.dataPickerBox = new System.Windows.Forms.ComboBox();
            this.roundComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataPickerBox
            // 
            this.dataPickerBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataPickerBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataPickerBox.FormattingEnabled = true;
            this.dataPickerBox.Location = new System.Drawing.Point(35, 12);
            this.dataPickerBox.Name = "dataPickerBox";
            this.dataPickerBox.Size = new System.Drawing.Size(195, 21);
            this.dataPickerBox.TabIndex = 0;
            // 
            // roundComboBox
            // 
            this.roundComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roundComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.roundComboBox.FormattingEnabled = true;
            this.roundComboBox.Location = new System.Drawing.Point(35, 67);
            this.roundComboBox.Name = "roundComboBox";
            this.roundComboBox.Size = new System.Drawing.Size(195, 21);
            this.roundComboBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(95, 284);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // QueryMemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 363);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.roundComboBox);
            this.Controls.Add(this.dataPickerBox);
            this.MaximumSize = new System.Drawing.Size(287, 402);
            this.MinimumSize = new System.Drawing.Size(287, 402);
            this.Name = "QueryMemoryForm";
            this.Text = "QueryMemoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox dataPickerBox;
        private System.Windows.Forms.ComboBox roundComboBox;
        private System.Windows.Forms.Button okButton;
    }
}