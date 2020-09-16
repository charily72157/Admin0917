using Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class RegisterController : Controller
    {
        public string connstr = $"Data Source=LCC;Initial Catalog=Orders;User ID=chen;password=123456";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult regcheck(string username, string password, string name, string mail)
        {
            userModel RegCheck = new userModel();  //呼叫userModel，叫做RegCheck
            if (RegCheck.registerCheck(username, mail)) //如果式true
            {
                return Redirect("~/Register");
            }
            else
            {
                connection = new SqlConnection(connstr);
                string sql = $"insert into dbo.account(username,password,name,mail) values ('{username}','{password}','{name}','{mail}')";

                connection.Open();
                command = new SqlCommand(sql, connection);
                try
                {
                    command.ExecuteNonQuery();//寫入
                    //Label1.Text = "註冊成功";
                    connection.Close();
                    //userModel.AutoSendmail(username, mail);
                    return Content(("<script>alert('註冊成功!');window.parent.location.href='sss';</script>"));
                }
                catch (Exception a)
                {
                    connection.Close();
                    // Label1.Text = "註冊失敗";
                    return Content(("<script>alert('註冊失敗!');window.parent.location.href='Index';</script>"));

                }
            }
        }
            public ActionResult sss()
            {
                return Redirect("~/Home");
            }
    }
}