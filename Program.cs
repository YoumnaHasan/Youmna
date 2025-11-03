using System;
using System.Windows.Forms;
using Labb2.Services;
using Labb2.Models;

namespace Labb2.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();


            var db = new Db();
            db.SeedDemoData();


            var auth = new Auth(db);
            var housing = new HousingService(db);


            Application.Run(new LoginForm(db, auth, housing));
        }
    }
    
}
