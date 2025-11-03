using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2.Models;
using Labb2.Services;

namespace Labb2.GUI
{  
        public class RegisterForm : Form
        {
            private readonly AuthService _auth;


            private readonly TextBox _txtName = new() { Left = 20, Top = 20, Width = 220, PlaceholderText = "Full name" };
            private readonly TextBox _txtEmail = new() { Left = 20, Top = 55, Width = 220, PlaceholderText = "Email" };
            private readonly TextBox _txtPassword = new() { Left = 20, Top = 90, Width = 220, PlaceholderText = "Password", UseSystemPasswordChar = true };
            private readonly Button _btnRegister = new() { Left = 20, Top = 125, Width = 220, Text = "Register" };


            public RegisterForm(FakeDb db, AuthService auth)
            {
                _auth = auth;
                Text = "Register Student"; Width = 280; Height = 220; FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;


                Controls.AddRange(new Control[] { _txtName, _txtEmail, _txtPassword, _btnRegister });
                _btnRegister.Click += (s, e) => { _auth.RegisterStudent(_txtName.Text, _txtEmail.Text, _txtPassword.Text); Close(); };


                Load += (s, e) => RefreshRooms();
            }


            private void RefreshRooms()
            {
                _lstRooms.Items.Clear();
                foreach (var r in _db.Rooms)
                    _lstRooms.Items.Add($"{r.Building.Name} {r.Number} [{r.Type}, {r.Status}]");
            }
        }
}
