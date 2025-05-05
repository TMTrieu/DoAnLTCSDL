using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using System.Data.SqlClient;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

namespace PresentationLayer
{
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private LoginBL loginBL;
        public FormDangNhap()
        {
            InitializeComponent();
            loginBL = new LoginBL();
        }

        private bool UserLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string User = txtTaiKhoan.Text.Trim();
            string Pass = txtMatKhau.Text;
            if (UserLogin(new Account(User, Pass)))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult result = MessageBox.Show("Sai tài khoản hoặc mật khẩu, bạn có muốn thử lại?", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtMatKhau.Clear();
                    txtTaiKhoan.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void chbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }
    }
}