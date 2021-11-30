using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFClient.Controller;

namespace WFClient.View
{
    public partial class AuthenForm : Form
    {
        private ControllerFormAuth controller;

        public AuthenForm()
        {
            InitializeComponent();
        }

        private void AuthenForm_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormAuth(this);
        }

        private async void buttonAuth_Click(object sender, EventArgs e)
        {
            await controller.UsersGetUserByLoginPasswordAsync();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            new FormReg().ShowDialog();
        }
    }
}
