namespace WFClient.View
{
    partial class FormMain
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
            this.labelUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCardsList = new System.Windows.Forms.DataGridView();
            this.buttonGetCards = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMoneyCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCurrentCard = new System.Windows.Forms.ComboBox();
            this.textBoxNumberToSend = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateNewCard = new System.Windows.Forms.Button();
            this.textBoxMoneyCount2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddMoney = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardsList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(13, 13);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(43, 17);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список ваших карт:";
            // 
            // dataGridViewCardsList
            // 
            this.dataGridViewCardsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCardsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCardsList.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewCardsList.Name = "dataGridViewCardsList";
            this.dataGridViewCardsList.RowHeadersWidth = 51;
            this.dataGridViewCardsList.RowTemplate.Height = 24;
            this.dataGridViewCardsList.Size = new System.Drawing.Size(479, 202);
            this.dataGridViewCardsList.TabIndex = 2;
            // 
            // buttonGetCards
            // 
            this.buttonGetCards.Location = new System.Drawing.Point(101, 13);
            this.buttonGetCards.Name = "buttonGetCards";
            this.buttonGetCards.Size = new System.Drawing.Size(165, 23);
            this.buttonGetCards.TabIndex = 3;
            this.buttonGetCards.Text = "Получить список карт";
            this.buttonGetCards.UseVisualStyleBackColor = true;
            this.buttonGetCards.Click += new System.EventHandler(this.buttonGetCards_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(500, 186);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(178, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Перевести";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер карты получателя:";
            // 
            // textBoxMoneyCount
            // 
            this.textBoxMoneyCount.Enabled = false;
            this.textBoxMoneyCount.Location = new System.Drawing.Point(500, 145);
            this.textBoxMoneyCount.Name = "textBoxMoneyCount";
            this.textBoxMoneyCount.Size = new System.Drawing.Size(178, 22);
            this.textBoxMoneyCount.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Сумма перевода:";
            // 
            // comboBoxCurrentCard
            // 
            this.comboBoxCurrentCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentCard.Enabled = false;
            this.comboBoxCurrentCard.FormattingEnabled = true;
            this.comboBoxCurrentCard.Location = new System.Drawing.Point(207, 276);
            this.comboBoxCurrentCard.Name = "comboBoxCurrentCard";
            this.comboBoxCurrentCard.Size = new System.Drawing.Size(141, 24);
            this.comboBoxCurrentCard.TabIndex = 9;
            // 
            // textBoxNumberToSend
            // 
            this.textBoxNumberToSend.Enabled = false;
            this.textBoxNumberToSend.Location = new System.Drawing.Point(500, 88);
            this.textBoxNumberToSend.Name = "textBoxNumberToSend";
            this.textBoxNumberToSend.Size = new System.Drawing.Size(178, 22);
            this.textBoxNumberToSend.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Используемая карта:";
            // 
            // buttonCreateNewCard
            // 
            this.buttonCreateNewCard.Enabled = false;
            this.buttonCreateNewCard.Location = new System.Drawing.Point(311, 13);
            this.buttonCreateNewCard.Name = "buttonCreateNewCard";
            this.buttonCreateNewCard.Size = new System.Drawing.Size(154, 23);
            this.buttonCreateNewCard.TabIndex = 11;
            this.buttonCreateNewCard.Text = "Создать карту";
            this.buttonCreateNewCard.UseVisualStyleBackColor = true;
            this.buttonCreateNewCard.Click += new System.EventHandler(this.buttonCreateNewCard_Click);
            // 
            // textBoxMoneyCount2
            // 
            this.textBoxMoneyCount2.Enabled = false;
            this.textBoxMoneyCount2.Location = new System.Drawing.Point(714, 88);
            this.textBoxMoneyCount2.Name = "textBoxMoneyCount2";
            this.textBoxMoneyCount2.Size = new System.Drawing.Size(178, 22);
            this.textBoxMoneyCount2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(711, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Сумма пополнения:";
            // 
            // buttonAddMoney
            // 
            this.buttonAddMoney.Enabled = false;
            this.buttonAddMoney.Location = new System.Drawing.Point(714, 129);
            this.buttonAddMoney.Name = "buttonAddMoney";
            this.buttonAddMoney.Size = new System.Drawing.Size(178, 23);
            this.buttonAddMoney.TabIndex = 12;
            this.buttonAddMoney.Text = "Пополнить";
            this.buttonAddMoney.UseVisualStyleBackColor = true;
            this.buttonAddMoney.Click += new System.EventHandler(this.buttonAddMoney_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 327);
            this.Controls.Add(this.textBoxMoneyCount2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAddMoney);
            this.Controls.Add(this.buttonCreateNewCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCurrentCard);
            this.Controls.Add(this.textBoxMoneyCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumberToSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonGetCards);
            this.Controls.Add(this.dataGridViewCardsList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUserName);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonGetCards;
        public System.Windows.Forms.DataGridView dataGridViewCardsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonSend;
        public System.Windows.Forms.TextBox textBoxMoneyCount;
        public System.Windows.Forms.TextBox textBoxNumberToSend;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBoxCurrentCard;
        public System.Windows.Forms.Button buttonCreateNewCard;
        public System.Windows.Forms.TextBox textBoxMoneyCount2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button buttonAddMoney;
    }
}