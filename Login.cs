using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2.Models;
using Labb2.Services;

namespace Labb2.GUI
{
    public class Login : Form
    {
        private readonly Db db;
        private readonly Auth auth;
        private readonly HousingService housing;


        private readonly TextBox _txtEmail = new() { Left = 20, Top = 30, Width = 220, PlaceholderText = "Email" };
        private readonly TextBox _txtPassword = new() { Left = 20, Top = 65, Width = 220, PlaceholderText = "Password", UseSystemPasswordChar = true };
        private readonly Button _btnLogin = new() { Left = 20, Top = 100, Width = 220, Text = "Login" };
        private readonly LinkLabel _lnkRegister = new() { Left = 20, Top = 135, Text = "Register as student" };


        public LoginForm(FakeDb db, AuthService auth, HousingService housing)
        {
            db = db; auth = auth; housing = housing;
            Text = "BoBo Housing – Login"; Width = 280; Height = 220; FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;


            Controls.AddRange(new Control[] { _txtEmail, _txtPassword, _btnLogin, _lnkRegister });
            _btnLogin.Click += OnLogin;
            _lnkRegister.Click += OnRegister;
        }


        private void OnLogin(object? sender, EventArgs e)
        {
            var user = _auth.Login(_txtEmail.Text, _txtPassword.Text);
            if (user is null) return;


            Hide();
            if (user is Admin a)
            {
                using var f = new AdminForm(_db, _housing, a);
                f.ShowDialog();
            }
            else if (user is Student s)
            {
                using var f = new StudentForm(_db, _housing, s);
                f.ShowDialog();
            }
            Show();
        }


        private void OnRegister(object? sender, EventArgs e)
        {
            using var f = new RegisterForm(_db, _auth);
            f.ShowDialog();
        }
}
}
