using CommunicationEntities;
using DBEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFClient.Model;
using WFClient.View;

namespace WFClient.Controller
{
    class ControllerFormMain
    {
        private FormMain form = null;
        private APIWorker API = null;
        private User user;
        private Random rnd = new Random();

        public ControllerFormMain(FormMain form)
        {
            this.form = form;
            API = APIWorker.GetInstance();
            user = (User)DataStorage.Get("user");
        }

        public void UpdateLabelUserName()
        {
            form.labelUserName.Text = user.Name;
        }

        public void CloseApp()
        {
            Application.Exit();
        }

        public async Task CardsGetCardsByUserId()
        {
            form.buttonGetCards.Enabled = false;

            Response response = await API.CardsGetCardsByUserId(user.Id);

            if (response.Status == Response.StatusList.OK)
            {
                List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(response.Data);

                form.dataGridViewCardsList.DataSource = null;
                form.dataGridViewCardsList.DataSource = cards;

                if (cards.Count != 0)
                {
                    form.comboBoxCurrentCard.Items.Clear();
                    for (int i = 0; i < cards.Count; i++)
                    {
                        form.comboBoxCurrentCard.Items.Add(cards[i].Number);
                    }
                    form.comboBoxCurrentCard.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show($"ERROR {response.Data}");
            }

            form.buttonGetCards.Enabled = true;

            form.buttonAddMoney.Enabled = true;
            form.buttonCreateNewCard.Enabled = true;
            form.buttonSend.Enabled = true;
            form.textBoxMoneyCount.Enabled = true;
            form.textBoxMoneyCount2.Enabled = true;
            form.textBoxNumberToSend.Enabled = true;
            form.comboBoxCurrentCard.Enabled = true;
        }

        public async Task SendMoney()
        {
            form.buttonSend.Enabled = false;

            Response response = await API.SendMoney(int.Parse(form.comboBoxCurrentCard.SelectedItem.ToString()), int.Parse(form.textBoxNumberToSend.Text), int.Parse(form.textBoxMoneyCount.Text));

            if (response.Status != Response.StatusList.OK)
            {
                MessageBox.Show($"ERROR {response.Data}");
            }

            form.buttonSend.Enabled = true;
        }

        public async Task CreateNewCard()
        {
            form.buttonCreateNewCard.Enabled = false;
            Response response;
            int number;
            // рандом на сервак
            do
            {
                number = rnd.Next(100000, 1000000);

                response = await API.GetCardByNumber(number);

                if (response.Status != Response.StatusList.OK)
                {
                    break;
                }

            } while (true);

            response = await API.CreateNewCard(number, user.Id);

            if (response.Status != Response.StatusList.OK)
            {
                MessageBox.Show($"ERROR {response.Data}");
            }

            form.buttonCreateNewCard.Enabled = true;
        }

        public async Task AddMoney()
        {
            form.buttonAddMoney.Enabled = false;

            Response response = await API.AddMoney(int.Parse(form.comboBoxCurrentCard.SelectedItem.ToString()), int.Parse(form.textBoxMoneyCount2.Text));

            if (response.Status != Response.StatusList.OK)
            {
                MessageBox.Show($"ERROR {response.Data}");
            }

            form.buttonAddMoney.Enabled = true;
        }
    }
}
