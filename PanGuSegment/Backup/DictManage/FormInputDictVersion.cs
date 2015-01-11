using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DictManage
{
    public partial class FormInputDictVersion : Form
    {
        DialogResult _Result = DialogResult.Cancel;

        public FormInputDictVersion()
        {
            InitializeComponent();
        }

        public string Version
        {
            get
            {
                return textBoxVersion.Text;
            }

            set
            {
                textBoxVersion.Text = value;
            }
        }

        new public DialogResult ShowDialog()
        {
            base.ShowDialog();

            return _Result;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            textBoxVersion.Text = textBoxVersion.Text.Trim();
            if (textBoxVersion.Text == "")
            {
                MessageBox.Show("版本號不能為空", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxVersion.Text.Length > 8)
            {
                MessageBox.Show("版本號字符串長度不能大於8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Result = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
