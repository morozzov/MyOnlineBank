using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFClient.Controller;

namespace WFClient.View
{
    public partial class FormReg : Form
    {
        private ControllerFormReg controller;

        public FormReg()
        {
            InitializeComponent();
        }

        private async void buttonReg_Click(object sender, EventArgs e)
        {
            await controller.UsersGetUserByLoginAsync();
        }

        private void FormReg_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormReg(this);
        }
    }
}
