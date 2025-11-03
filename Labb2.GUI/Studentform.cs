using System;
using System.Drawing;
using System.Windows.Forms;
using Labb2.Services;
using Labb2.Models;

namespace Labb2.GUI
{
    public class StudentForm : Form
    {
        private readonly Db _db = null!;
        private readonly HousingService _housing = null!;
        private readonly Student _student = null!;

        private Button button1;      // Apply
        private ListBox listBox1;    // Available rooms
        private ListBox listBox2;    // Chosen (leases)
        private Label label1;        // "Available"
        private Label label2;        // "My rooms"
        private PictureBox pictureBox1;

        public StudentForm()
        {
            InitializeComponent();

            button1.Click += button1_Click;    // Apply
            Load += StudentForm_Load;

            listBox1.FormattingEnabled = true;
            listBox2.FormattingEnabled = true;
            listBox1.Format += listBox1_Format;
            listBox2.Format += listBox2_Format;
        }

        public StudentForm(Db db, HousingService housing, Student student) : this()
        {
            _db = db;
            _housing = housing;
            _student = student;
            Text = $"Student – {_student.FullName}";
        }

        private void StudentForm_Load(object? sender, EventArgs e)
        {
            RefreshAvailable();
            RefreshChosen();
        }

        private void RefreshAvailable()
        {
            listBox1.Items.Clear();
            foreach (var r in _housing.GetAvailableRooms())
                listBox1.Items.Add(r);
        }

        private void RefreshChosen()
        {
            listBox2.Items.Clear();
            foreach (var l in _student.Leases)
                listBox2.Items.Add(l.Room);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Room r)
            {
                _housing.ApplyForRoom(_student, r);
                RefreshAvailable();
                RefreshChosen();
            }
        }

        private void listBox1_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Room r)
                e.Value = $"{r.Building.Name} • {r.Number} • {r.AreaM2} m² • Floor {r.Floor}";
        }
        private void listBox2_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Room r)
                e.Value = $"{r.Building.Name} • {r.Number} • {r.AreaM2} m² • Floor {r.Floor}";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            button1 = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // button1
            button1.BackColor = SystemColors.ControlDark;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(176, 280);
            button1.Name = "button1";
            button1.Size = new Size(125, 23);
            button1.TabIndex = 0;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = false; 
            // listBox1
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(176, 74);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(330, 79);
            listBox1.TabIndex = 1;
            // listBox2
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(176, 178);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(330, 79);
            listBox2.TabIndex = 2;
            // label1
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(176, 56);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 3;
            label1.Text = "Available rooms";
            // label2
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(176, 160);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 4;
            label2.Text = "My rooms";
            // pictureBox1
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-97, -34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // StudentForm
            AccessibleRole = AccessibleRole.TitleBar;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(529, 325);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
