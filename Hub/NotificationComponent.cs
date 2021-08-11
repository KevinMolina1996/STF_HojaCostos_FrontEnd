using AppWebHojaCosto.Context;
using AppWebHojaCosto.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace AppWebHojaCosto
{
    public class NotificationComponent
    {
        public void RegisterNotification(DateTime currentTime)
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["bdHojaCostos"].ConnectionString;
                string sqlCommand = @"SELECT [AlCodigoN],[AlReferenciaS],[AlDescripcionS],[AlEstadoS],[AlAreaS],[AlFechaD],[AlCambioS],[AlUsuarioS] FROM [dbo].[TBL_ALERTA] WHERE [AlLeidoS] != 'X'";
                //you can notice here I have added table name like this [dbo].[Contacts] with [dbo], its mendatory when you use Sql Dependency
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlCommand, con);
                    //cmd.Parameters.AddWithValue("@AddedOn", currentTime);
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Notification = null;
                    SqlDependency sqlDep = new SqlDependency(cmd);
                    sqlDep.OnChange += sqlDep_OnChange;
                    //we must have to execute the command here
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // nothing need to add here now
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            try
            {
                if (e.Type == SqlNotificationType.Change)
                {
                    SqlDependency sqlDep = sender as SqlDependency;
                    sqlDep.OnChange -= sqlDep_OnChange;

                    //from here we will send notification message to client
                    var notificationHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                    notificationHub.Clients.All.notify("added");

                    //re-register notification
                    RegisterNotification(DateTime.Now);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public List<TBL_ALERTA> GetContacts(DateTime afterDate)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.TBL_ALERTA.OrderByDescending(a => a.AlCodigoN).Where(a => a.AlLeidoS != "X").Take(7).ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}