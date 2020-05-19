using DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Data
{
    public class NotificationDBAccesLayer : INotificationDBAccesLayer
    {
        MySqlConnection con = new MySqlConnection("Server=localhost; Database=fishbait;Uid=Tijmen;Pwd=Suckmycred123");
        public string AddFollow(INotificationDto notification)
        {
            try
            {
                con.Open();
                string sql = "INSERT INTO notification (accountID, postID) VALUES('" + notification.accountID + "', '" + notification.postID + "');";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
