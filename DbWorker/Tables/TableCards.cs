using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities;
using DbWorker.Tools;
using ExceptionEntities;
using MySql.Data.MySqlClient;

namespace DbWorker.Tables
{
    public class TableCards
    {
        // TODO 1) Перевод денег с карты на карту. 2) Создание новой карты клиенту(с уникальным номером(с помощью метода вернуть карту по номеру(GetCardByNumber))) 3) Пополнить карту по номеру.

        public List<Card> GetCardsByUserId(int userId)
        {
            try
            {
                List<Card> cards = new List<Card>();
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText =
                            $"SELECT c.id, c.number, c.balance FROM users_cards AS uc JOIN cards AS c ON uc.id_card = c.id WHERE id_user = {userId}; ";
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                cards.Add(new Card()
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    Number = mySqlDataReader.GetInt32("number"),
                                    Balance = mySqlDataReader.GetInt32("balance")
                                });
                            }
                        }
                    }
                }

                return cards;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Card GetCardByNumber(int number)
        {
            try
            {
                Card card = null;
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * FROM `cards` WHERE `number` = {number}";
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                mySqlDataReader.Read();
                                card = new Card()
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    Balance = mySqlDataReader.GetInt32("balance"),
                                    Number = mySqlDataReader.GetInt32("number")
                                };
                            }
                            else
                            {
                                throw new CardDoesNotExistException();
                            }

                        }
                    }
                }

                return card;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void CreateNewCard(int number, int userId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                    {
                        using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                        {
                            mySqlCommand.Transaction = mySqlTransaction;
                            try
                            {
                                mySqlCommand.CommandText = $"INSERT INTO `cards`(`number`,`balance`) VALUES({number},0);";
                                mySqlCommand.ExecuteNonQuery();

                                mySqlCommand.CommandText = "SELECT LAST_INSERT_ID();";
                                int cardId = Convert.ToInt32(mySqlCommand.ExecuteScalar());

                                mySqlCommand.CommandText = $"INSERT INTO `users_cards`(`id_user`,`id_card`) VALUES({userId},{cardId});";
                                mySqlCommand.ExecuteNonQuery();

                                mySqlTransaction.Commit();

                            }
                            catch (Exception e)
                            {
                                mySqlTransaction.Rollback();
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SendMoney(int numberCardFrom, int numberCardTo, int moneyCount)
        {
            try
            {
                Card cardFrom = GetCardByNumber(numberCardFrom);
                Card cardTo = GetCardByNumber(numberCardTo);

                if (cardFrom.Balance<moneyCount)
                {
                    throw new NotEnoughMoneyException();
                }

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                    {
                        using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                        {
                            mySqlCommand.Transaction = mySqlTransaction;
                            try
                            {
                                mySqlCommand.CommandText = $"UPDATE `cards` SET `balance` = `balance` - {moneyCount} WHERE `number`={cardFrom.Number};";
                                mySqlCommand.ExecuteNonQuery();

                                mySqlCommand.CommandText = $"UPDATE `cards` SET `balance` = `balance` + {moneyCount} WHERE `number`={cardTo.Number};";
                                mySqlCommand.ExecuteNonQuery();
                                
                                mySqlTransaction.Commit();
                            }
                            catch (Exception e)
                            {
                                mySqlTransaction.Rollback();
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public void AddMoney(int number, int moneyCount)
        {
            try
            {
                Card cardFrom = GetCardByNumber(number);

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                    {
                        using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                        {
                            mySqlCommand.Transaction = mySqlTransaction;
                            try
                            {
                                mySqlCommand.CommandText = $"UPDATE `cards` SET `balance` = `balance` + {moneyCount} WHERE `number`={cardFrom.Number};";
                                mySqlCommand.ExecuteNonQuery();

                                mySqlTransaction.Commit();
                            }
                            catch (Exception e)
                            {
                                mySqlTransaction.Rollback();
                                throw e;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
