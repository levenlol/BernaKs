namespace BernaKs
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.layoutProcessHandle = new System.Windows.Forms.FlowLayoutPanel();
            this.memoryDataGridView = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryMemoryButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.layoutProcessHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scan Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(133, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 26);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Process: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(134, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "None";
            // 
            // layoutProcessHandle
            // 
            this.layoutProcessHandle.Controls.Add(this.memoryDataGridView);
            this.layoutProcessHandle.Location = new System.Drawing.Point(12, 55);
            this.layoutProcessHandle.Name = "layoutProcessHandle";
            this.layoutProcessHandle.Size = new System.Drawing.Size(776, 494);
            this.layoutProcessHandle.TabIndex = 2;
            this.layoutProcessHandle.Visible = false;
            // 
            // memoryDataGridView
            // 
            this.memoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Value,
            this.RawValue});
            this.memoryDataGridView.Location = new System.Drawing.Point(3, 3);
            this.memoryDataGridView.Name = "memoryDataGridView";
            this.memoryDataGridView.Size = new System.Drawing.Size(773, 491);
            this.memoryDataGridView.TabIndex = 0;
            this.memoryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.memoryDataGridView_CellEndEdit);
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 150;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // RawValue
            // 
            this.RawValue.HeaderText = "RawValue";
            this.RawValue.Name = "RawValue";
            // 
            // queryMemoryButton
            // 
            this.queryMemoryButton.Location = new System.Drawing.Point(344, 25);
            this.queryMemoryButton.Name = "queryMemoryButton";
            this.queryMemoryButton.Size = new System.Drawing.Size(104, 23);
            this.queryMemoryButton.TabIndex = 0;
            this.queryMemoryButton.Text = "Query Memory";
            this.queryMemoryButton.UseVisualStyleBackColor = true;
            this.queryMemoryButton.Click += new System.EventHandler(this.queryMemoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.queryMemoryButton);
            this.Controls.Add(this.layoutProcessHandle);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.layoutProcessHandle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FlowLayoutPanel layoutProcessHandle;
        private System.Windows.Forms.Button queryMemoryButton;
        private System.Windows.Forms.DataGridView memoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn RawValue;
    }
}

