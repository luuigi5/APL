using System;
using System.Windows.Forms;

namespace dashboard1
{
    public partial class BaseForm : Form
    {
        public string token { get; set; }
        public User user { get; set; }

        public BaseForm(string token, User user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;
        }

        public BaseForm()
        {
            InitializeComponent();
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
            //nome.Text = "Bentornato " + user.username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStructure addStructure = new AddStructure(token, user);
            ModalManager.ShowModal(addStructure);
            //addStructure.Show()
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StructuresList structuresList = new StructuresList(token, user);
            ModalManager.ShowModal(structuresList);
            //structuresList.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            ModalManager.ShowModal(login);
            //login.Show();
            //this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
