namespace DictManage
{
    partial class FormFind
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
            this.label3 = new System.Windows.Forms.Label();
            this.posCtrl = new PosDisplayCtrl.PosCtrl();
            this.radioButtonByPos = new System.Windows.Forms.RadioButton();
            this.radioButtonByLength = new System.Windows.Forms.RadioButton();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "詞性";
            // 
            // posCtrl
            // 
            this.posCtrl.Location = new System.Drawing.Point(34, 105);
            this.posCtrl.Name = "posCtrl";
            this.posCtrl.Pos = 0;
            this.posCtrl.Size = new System.Drawing.Size(480, 270);
            this.posCtrl.TabIndex = 9;
            // 
            // radioButtonByPos
            // 
            this.radioButtonByPos.AutoSize = true;
            this.radioButtonByPos.Checked = true;
            this.radioButtonByPos.Location = new System.Drawing.Point(34, 27);
            this.radioButtonByPos.Name = "radioButtonByPos";
            this.radioButtonByPos.Size = new System.Drawing.Size(43, 16);
            this.radioButtonByPos.TabIndex = 11;
            this.radioButtonByPos.TabStop = true;
            this.radioButtonByPos.Text = "POS";
            this.radioButtonByPos.UseVisualStyleBackColor = true;
            this.radioButtonByPos.CheckedChanged += new System.EventHandler(this.radioButtonByPos_CheckedChanged);
            // 
            // radioButtonByLength
            // 
            this.radioButtonByLength.AutoSize = true;
            this.radioButtonByLength.Location = new System.Drawing.Point(139, 27);
            this.radioButtonByLength.Name = "radioButtonByLength";
            this.radioButtonByLength.Size = new System.Drawing.Size(56, 16);
            this.radioButtonByLength.TabIndex = 12;
            this.radioButtonByLength.Text = "Length";
            this.radioButtonByLength.UseVisualStyleBackColor = true;
            this.radioButtonByLength.CheckedChanged += new System.EventHandler(this.radioButtonByLength_CheckedChanged);
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Enabled = false;
            this.numericUpDownLength.Location = new System.Drawing.Point(105, 59);
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLength.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "長度";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(34, 364);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 21);
            this.buttonFind.TabIndex = 15;
            this.buttonFind.Text = "尋找";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(125, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 21);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 396);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.radioButtonByLength);
            this.Controls.Add(this.radioButtonByPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.posCtrl);
            this.Name = "FormFind";
            this.Text = "⩕Ң";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private PosDisplayCtrl.PosCtrl posCtrl;
        private System.Windows.Forms.RadioButton radioButtonByPos;
        private System.Windows.Forms.RadioButton radioButtonByLength;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonCancel;
    }
}