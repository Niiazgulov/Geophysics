namespace Geophysics
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            btnL = new Button();
            txtL = new TextBox();
            labelL = new Label();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(961, 556);
            dataGridView1.TabIndex = 0;
            // 
            // btnL
            // 
            btnL.Location = new Point(209, 577);
            btnL.Name = "btnL";
            btnL.Size = new Size(94, 29);
            btnL.TabIndex = 1;
            btnL.Text = "Ввод";
            btnL.UseVisualStyleBackColor = true;
            btnL.Click += btnL_Click;
            // 
            // txtL
            // 
            txtL.Location = new Point(97, 579);
            txtL.Name = "txtL";
            txtL.Size = new Size(95, 27);
            txtL.TabIndex = 2;
            txtL.KeyPress += txtL_KeyPress;
            // 
            // labelL
            // 
            labelL.AutoSize = true;
            labelL.Location = new Point(12, 582);
            labelL.Name = "labelL";
            labelL.Size = new Size(79, 20);
            labelL.TabIndex = 3;
            labelL.Text = "Введите L:";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(774, 577);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(199, 29);
            btnNext.TabIndex = 4;
            btnNext.Text = "Следующий шаг";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 615);
            Controls.Add(btnNext);
            Controls.Add(labelL);
            Controls.Add(txtL);
            Controls.Add(btnL);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnL;
        private TextBox txtL;
        private Label labelL;
        private Button btnNext;
    }
}
