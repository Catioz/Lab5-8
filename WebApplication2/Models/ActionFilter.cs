using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class ActionFilter : ActionFilterAttribute
    {
    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var Controller = filterContext.RouteData.Values["controller"];
            var Action = filterContext.RouteData.Values["action"];
            NoteBase(Controller.ToString(), Action.ToString(), DateTime.Now);
        }
        private void NoteBase(string Controller, string Action, DateTime Date)
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\NoteBase.mdf;Integrated Security=True;Connect Timeout=10"))
            {
                using (var db = connection.CreateCommand())
                {
                    db.CommandType = CommandType.Text;
                    db.CommandText = @"INSERT INTO [Log] (Controller, Action, Date) VALUES (@Controller, @Action, @Date);";

                    db.Parameters.AddWithValue("@Controller", Controller);
                    db.Parameters.AddWithValue("@Action", Action);
                    db.Parameters.AddWithValue("@Date", Date);

                    try
                    {
                        connection.Open();
                        db.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
        }
    }
}