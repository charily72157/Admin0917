using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class userModel
    {
        //public string connstr = $"Data Source=LCC;Initial Catalog=Orders;User ID=chen;password=123456";
        public string connstr = $"https://admin20200916100734.azurewebsites.net";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;


        public userModel()
        {
            connection = new SqlConnection(connstr);

        }
        /// <summary>
        /// 登入判斷
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true=成功</returns>
        public bool loginCheck(string username, string password)
        {
            connection.Open();
            string commandStr = $"select * from dbo.account where username='" + username + "'";
            command = new SqlCommand(commandStr, connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (password == reader["password"].ToString())
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
            else
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return false;
        }
        /// <summary>
        /// 註冊成功
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns>true=有資料，無法註冊</returns>
        public bool registerCheck(string username, string mail)
        {
            bool isOK = false;
            connection.Open();
            string commandStr = $"select * from dbo.account where username='" + username + "' OR mail='" + mail + "'";
            command = new SqlCommand(commandStr, connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (mail == reader["mail"].ToString())
                    {
                        connection.Close();
                        isOK = true;
                    }
                }
            }
            connection.Close();
            return isOK;
        }
        public static void AutoSendmail(string username, string mail)
        {
            System.Net.Mail.MailMessage MyMail = new System.Net.Mail.MailMessage();
            MyMail.From = new System.Net.Mail.MailAddress("chen0972312099@gmail.com");
            MyMail.To.Add(mail); //設定收件者Email
            //MyMail.Bcc.Add("密件副本的收件者Mail"); //加入密件副本的Mail          
            MyMail.Subject = "Email Test";
            MyMail.Body = "<h1>" + username + "</h1>"; //設定信件內容
            MyMail.IsBodyHtml = true; //是否使用html格式
            //
            System.Net.Mail.SmtpClient MySMTP = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            MySMTP.Credentials = new System.Net.NetworkCredential("chen0972312099@gmail.com", "charily72157");
            try
            {

                MySMTP.EnableSsl = true;
                MySMTP.Send(MyMail);
                MyMail.Dispose(); //釋放資源
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }

}