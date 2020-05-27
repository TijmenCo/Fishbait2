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
        public List<INotificationDto> GetNotifications()
        {
            List<INotificationDto> follows = new List<INotificationDto>();

            using (MySqlCommand query = new MySqlCommand("select * from notification", con))
            {
                con.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    NotificationDto follow = new NotificationDto();
                    follow.id = reader.GetInt32(0);
                    follow.accountID = reader.GetInt32(1);
                    follow.postID = reader.GetInt32(2);
                    follows.Add(follow);
                }
                con.Close();
            }

            return follows;
        }
        public void DeleteNotification(int id)
        {
            using (MySqlCommand query = new MySqlCommand("DELETE FROM notification WHERE id=@id", con))
            {
                MySqlParameter param = new MySqlParameter("@id", id);
                query.Parameters.Add(param);
                con.Open();
                var reader = query.ExecuteReader();
            }
            con.Close();
        }
    }
}
