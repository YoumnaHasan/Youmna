using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2.Models;
using Labb2.Services;

namespace Labb2.GUI
{
    public class StudentForm : Form
    {
        private readonly Db db;
        private readonly HousingService_housing;
        private readonly Student student;


        private readonly Label _lblHello = new() { Left = 20, Top = 10, Width = 280 };
        private readonly ListBox _lstAvailable = new() { Left = 20, Top = 35, Width = 240, Height = 140 };
        private readonly Button _btnApply = new() { Left = 20, Top = 180, Width = 240, Text = "Apply for selected room" };


        private readonly ListBox _lstLeases = new() { Left = 20, Top = 220, Width = 240, Height = 110 };


        public StudentForm(FakeDb db, HousingService housing, Student student)
        {
            db = db; housing = housing; student = student;
            Text = "Student"; Width = 300; Height = 400; FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false;


            lblHello.Text = $"Hej, {_student.FullName}";


            Controls.AddRange(new Control[] { lblHello, lstAvailable, btnApply, lstLeases });


            Load += (s, e) => { RefreshAvailable(); RefreshLeases(); };
            btnApply.Click += (s, e) =>
            {
                if (_lstAvailable.SelectedItem is Room r)
                {
                    var lease = _housing.ApplyForRoom(_student, r);
                    if (lease is null) MessageBox.Show("Rummet är inte ledigt.");
                    RefreshAvailable();
                    RefreshLeases();
                }
            };
        }


        private void RefreshAvailable()
        {
            lstAvailable.Items.Clear();
            foreach (var r in _housing.GetAvailableRooms())
                _lstAvailable.Items.Add(r);
            lstAvailable.DisplayMember = nameof(Room.Number); 
        }


        private void RefreshLeases()
        {
            lstLeases.Items.Clear();
            foreach (var l in _student.Leases)
                lstLeases.Items.Add($"{l.Room.Building.Name} {l.Room.Number} (from {l.StartDate:d})");
        }
    }
}
