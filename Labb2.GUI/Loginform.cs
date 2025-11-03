using System;
using System.Drawing;
using System.Windows.Forms;
using Labb2.Services;
using Labb2.Models;

namespace Labb2.GUI
{
    public class LoginForm : Form
    {

        private readonly Db _db = null!;
        private readonly AuthService _auth = null!;
        private readonly HousingService _housing = null!;

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;


        public LoginForm()
        {
            InitializeComponent();


            textBox2.UseSystemPasswordChar = true; // password mask
            AcceptButton = button1;                // Enter submits login
            button1.Click += button1_Click;        // Login
            button2.Click += button2_Click;        // Register
        }


        public LoginForm(Db db, AuthService auth, HousingService housing) : this()
        {
            _db = db;
            _auth = auth;
            _housing = housing;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // button1
            button1.BackColor = SystemColors.ControlDark;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(176, 173);
            button1.Name = "button1";
            button1.Size = new Size(125, 23);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = false; 
            // button2
            button2.BackColor = SystemColors.ControlDark;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(176, 202);
            button2.Name = "button2";
            button2.Size = new Size(125, 23);
            button2.TabIndex = 1;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = false;
            // textBox1
            textBox1.Location = new Point(176, 96);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // textBox2
            textBox2.Location = new Point(176, 144);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(175, 31);
            textBox2.TabIndex = 3; 
            // label1
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(176, 78);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "Email";
            label1.Click += label1_Click; 
            // label2 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(176, 122);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 5;
            label2.Text = "password"; 
            // pictureBox1
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-99, -39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // LoginForm
            AccessibleRole = AccessibleRole.TitleBar;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(529, 325);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Name = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) { }
        private void fontDialog1_Apply(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object? sender, EventArgs e)   // Login
        {
            var u = _auth.Login(textBox1.Text, textBox2.Text);
            if (u is Admin a) new AdminForm(_db, _housing, a).ShowDialog();
            else if (u is Student s) new StudentForm(_db, _housing, s).ShowDialog();
        }

        private void button2_Click(object? sender, EventArgs e)   // Register
        {
            new RegisterForm(_db, _auth).ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
