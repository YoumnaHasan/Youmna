
using Labb2.Services;
using static Labb2.Services.AuthService;


namespace Labb2.GUI;


internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();


        var db = new Db();
        db.SeedDemoData();


        var auth = new AuthService(db);
        var housing = new HousingService(db);


        Application.Run(new LoginForm(db, auth, housing));
    }
}