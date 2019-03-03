using System;
using System.Windows.Forms;

namespace LaundryApp
{
    public partial class TenantInfoForm : Form
    {
        public TenantInfoForm()
        {
            InitializeComponent();
            InitializeInfoFromProperties();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetInfoIntoProperties();
            InitializeInfoFromProperties();

            DialogResult result = MessageBox.Show("Application Setting Saved.", "LaundryApp Info!", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Dispose();
            }
        }

        public void InitializeInfoFromProperties()
        {
            txtName.Text = Properties.Settings.Default.TenantName;
            txtPhone.Text = Properties.Settings.Default.TenantPhone;
            txtAddress.Text = Properties.Settings.Default.TenantAddress;
        }

        public void SetInfoIntoProperties()
        {
            Properties.Settings.Default.TenantName = txtName.Text;
            Properties.Settings.Default.TenantPhone = txtPhone.Text;
            Properties.Settings.Default.TenantAddress = txtAddress.Text;

            Properties.Settings.Default.Save();
        }
    }
}
