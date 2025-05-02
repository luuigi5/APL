using System;
using System.Windows.Forms;

namespace dashboard1
{
    public partial class Form1 : Form
    {
        public string token { get; set; }
        public User user { get; set; }

        public Form1(string token, User user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
            nome.Text = "Bentornato " + user.username;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
