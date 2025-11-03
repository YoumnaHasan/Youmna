using System;
using System.Drawing;
using System.Windows.Forms;
using Labb2.Services;

namespace Labb2.GUI
{
    public class RegisterForm : Form
    {
       
        private readonly Db _db = null!;
        private readonly AuthService _auth = null!;

        
        private Button button1;         // Create account
        private TextBox textBox1;       // Email
        private TextBox textBox2;       // Password
        private TextBox textBox3;       // Name
        private Label label1;           // "Email"
        private Label label2;           // "password"
        private Label label3;           // "Name"
        private PictureBox pictureBox1;

       
        public RegisterForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;  // mask password
            AcceptButton = button1;               
            button1.Click += button1_Click;
        }

        // Runtime ctor
        public RegisterForm(Db db, AuthService auth) : this()
        {
            _db = db;
            _auth = auth;
        }

        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            // button1 
            button1.BackColor = SystemColors.ControlDark;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(176, 232);
            button1.Name = "button1";
            button1.Size = new Size(125, 23);
            button1.TabIndex = 0;
            button1.Text = "Create account";
            button1.UseVisualStyleBackColor = false;
            // textBox1
            textBox1.Location = new Point(176, 118);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 2;
            // textBox2
            textBox2.Location = new Point(176, 166);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(175, 23);
            textBox2.TabIndex = 3;
            // textBox3
            textBox3.Location = new Point(176, 70);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(175, 23);
            textBox3.TabIndex = 1;
            // label1
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(176, 100);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 5;
            label1.Text = "Email";
            // label2 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDarkDark;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(176, 144);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "password";
            // label3 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlDarkDark;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(176, 52);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // pictureBox1
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-96, -37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(348, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // RegisterForm
            AccessibleRole = AccessibleRole.TitleBar;
            BackColor = SystemColors.ControlDarkDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(529, 325);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        
        private void button1_Click(object? sender, EventArgs e)
        {
            
            _auth.RegisterStudent(textBox3.Text, textBox1.Text, textBox2.Text);
            Close(); 
        }
    }
}

