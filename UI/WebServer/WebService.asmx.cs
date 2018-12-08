﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MutualClasses;

namespace WebServer
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void Inserting(User user, List<User> Users)
        {
            var data = new DatabaseInfo();
            var connection = data.GetConfigInfo();
            data.InsertRow(user, connection);// Inesrt row to table  
            data.GetDataFromDatabase(Users, connection);
        }

    }
}
