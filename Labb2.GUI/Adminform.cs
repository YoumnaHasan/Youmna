using System;
using System.Drawing;
using System.Windows.Forms;
using Labb2.Services;
using Labb2.Models;

namespace Labb2.GUI
{
    public class AdminForm : Form
    {
        private readonly Db _db = null!;
        private readonly HousingService _housing = null!;
        private readonly Admin _admin = null!;

        private Button button1;         // Add
        private ComboBox comboBox1;     // Building
        private ComboBox comboBox2;     // RoomType
        private TextBox textBox1;       // Room #
        private NumericUpDown numericUpDown1; // Area m²
        private NumericUpDown numericUpDown2; // Floor
        private ListBox listBox1;       // Rooms list
        private Label label1;           // "Building"
        private Label label2;           // "Type"
        private Label label3;           // "Room #"
        private Label label4;           // "Area (m²)"
        private Label label5;           // "Floor"
        private PictureBox pictureBox1;

        public AdminForm()
        {
            InitializeComponent();

            Load += AdminForm_Load;
            button1.Click += button1_Click;
        }

        public AdminForm(Db db, HousingService housing, Admin admin) : this()
        {
            _db = db;
            _housing = housing;
            _admin = admin;
            Text = $"Admin – {_admin.FullName}";
        }

        private void AdminForm_Load(object? sender, EventArgs e)
        {
            comboBox1.DataSource = _db.Buildings;
            comboBox1.DisplayMember = nameof(Building.Name);

            comboBox2.DataSource = Enum.GetValues(typeof(RoomType));

            RefreshRooms();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Building b && comboBox2.SelectedItem is RoomType t)
            {
                var room = _housing.AddRoom(b, textBox1.Text, t);
                room.AreaM2 = (int)numericUpDown1.Value; 
                room.Floor = (int)numericUpDown2.Value;

                RefreshRooms();
            }
        }

        private void RefreshRooms()
        {
            listBox1.Items.Clear();
            foreach (var r in _db.Rooms)
                listBox1.Items.Add($"{r.Building.Name} • {r.Number} • {r.Type} • {r.Status} • {r.AreaM2} m² • Floor {r.Floor}");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            button1 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
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
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            // comboBox1
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Location = new Point(176, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 23);
            comboBox1.TabIndex = 0;
            // comboBox2
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Location = new Point(176, 114);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(175, 23);
            comboBox2.TabIndex = 2;
            // textBox1
            textBox1.Location = new Point(176, 158);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 3;
            // numericUpDown1 
            numericUpDown1.Location = new Point(176, 202);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(80, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // numericUpDown2
            numericUpDown2.Location = new Point(271, 202);
            numericUpDown2.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(80, 23);
            numericUpDown2.TabIndex = 5;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // listBox1
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(176, 234);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(330, 34);
            listBox1.TabIndex = 7;
            // label1
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(176, 52);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 8;
            label1.Text = "Building";
            // label2
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(176, 96);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 9;
            label2.Text = "Type";
            // label3
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlDarkDark;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(176, 140);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 10;
            label3.Text = "Room #";
            // label4
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlDarkDark;
            label4.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(176, 184);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 11;
            label4.Text = "Area (m²)";
            // label5
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlDarkDark;
            label5.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(271, 184);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 12;
            label5.Text = "Floor";
            // pictureBox1
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-92, -25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // AdminForm
            AccessibleRole = AccessibleRole.TitleBar;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(529, 325);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
