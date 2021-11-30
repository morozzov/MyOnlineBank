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
    public class ControllerFormAuth
    {
        private AuthenForm form = null;
        private APIWorker API = null;

        public ControllerFormAuth(AuthenForm form)
        {
            this.form = form;
            API = APIWorker.GetInstance();
        }

        public async Task UsersGetUserByLoginPasswordAsync()
        {
            form.buttonAuth.Enabled = false;

            string login = form.textBoxLogin.Text;
            string password = form.textBoxPassword.Text;

            IHash hash =  HashFactory.Crypto.CreateSHA512();
            HashResult passwordHashed = hash.ComputeString(password, Encoding.Unicode);

            Response response = await API.UsersGetUserByLoginPasswordAsync(login, passwordHashed.ToString());

            if (response.Status == Response.StatusList.OK)
            {
                User user = JsonConvert.DeserializeObject<User>(response.Data);

                MessageBox.Show("Success");

                DataStorage.Add("user", user);

                form.Hide();
                new FormMain().Show();
            }
            else
            {
                form.buttonAuth.Enabled = true;

                form.textBoxResult.Text = $"Error: {response.Data}";
            }
        }
    }
}
