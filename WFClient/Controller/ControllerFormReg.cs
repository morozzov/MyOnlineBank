using CommunicationEntities;
using DBEntities;
using HashLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFClient.Model;
using WFClient.View;

namespace WFClient.Controller
{
    public class ControllerFormReg
    {
        private FormReg form = null;
        private APIWorker API = null;

        public ControllerFormReg(FormReg form)
        {
            this.form = form;
            API = APIWorker.GetInstance();
        }

        public async Task UsersGetUserByLoginAsync()
        {
            form.buttonReg.Enabled = false;

            string login = form.textBoxLogin.Text;

            Response response = await API.UsersGetUserByLoginAsync(login);

            if (response.Status == Response.StatusList.OK)
            {
                MessageBox.Show("Create new login");
                form.buttonReg.Enabled = true;
            }
            else
            {
                await CreateUserAsync();
            }
        }

        public async Task CreateUserAsync()
        {
            form.buttonReg.Enabled = false;

            if (form.textBoxName.Text != "" && form.textBoxLogin.Text != "" && form.textBoxPassword.Text != "" && form.textBoxRepeatPassword.Text != "")
            {
                if (form.textBoxPassword.Text == form.textBoxRepeatPassword.Text)
                {
                    string login = form.textBoxLogin.Text;
                    string name = form.textBoxName.Text;
                    string password = form.textBoxPassword.Text;

                    IHash hash = HashFactory.Crypto.CreateSHA512();
                    HashResult passwordHashed = hash.ComputeString(password, Encoding.Unicode);

                    Response response = await API.UsersGetUserByLoginAsync(login);

                    if (response.Status == Response.StatusList.OK)
                    {
                        MessageBox.Show("Create new login");
                        form.buttonReg.Enabled = true;
                    }
                    else
                    {
                        response = await API.CreateUser(name, login, passwordHashed.ToString());

                        if (response.Status == Response.StatusList.OK)
                        {
                            MessageBox.Show("Success");
                            form.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                            form.buttonReg.Enabled = true;
                        }
                        //new FormMain().Show();
                    } 
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                    form.buttonReg.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Not all data entered");
                form.buttonReg.Enabled = true;
            }
        }
    }
}
