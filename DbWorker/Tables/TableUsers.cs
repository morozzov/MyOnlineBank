using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBEntities;
using DbWorker.Tools;
using ExceptionEntities;

namespace DbWorker.Tables
{
    public class TableUsers
    {
        public User GetUserByLoginPassword(string login, string password)
        {
            try
            {
                User user = null;

                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * FROM `users` WHERE `login`='{login}' AND `password`='{password}'";
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows == true)
                            {
                                mySqlDataReader.Read();

                                user = new User()
                                {
                                    Id = mySqlDataReader.GetInt32("id"),
                                    Name = mySqlDataReader.GetString("name"),
                                    Login = mySqlDataReader.GetString("login"),
                                    Password = mySqlDataReader.GetString("password")
                                };
                            }
                            else
                            {
                                throw new WrongLoginPasswordException();
                            }
                        }
                    }
                }

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GetUserByLogin(string login)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = $"SELECT * FROM `users` WHERE `login`='{login}'";
                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            if (mySqlDataReader.HasRows == true)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CreateUser(string name, string login, string password)
        {
            try
            {
                using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                            mySqlCommand.CommandText = $"INSERT INTO `users`(`name`,`login`,`password`) VALUES('{name}','{login}','{password}');";
                        try
                        {
                            mySqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            throw e;
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
