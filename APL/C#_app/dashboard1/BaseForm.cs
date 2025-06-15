using System;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace dashboard1
{
    public partial class BaseForm : Form
    {
        public string token { get; set; }
        public User user { get; set; }

        // Costanti WinAPI
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        // Importa i metodi WinAPI
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public BaseForm(string token, User user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;

            setButtonIcon(dashboardButton, Properties.Resources.dashboard);
            setButtonIcon(structuresButton, Properties.Resources.home);
            setButtonIcon(reservationsButton, Properties.Resources.prenotazioni);
            setButtonIcon(addStructureButton, Properties.Resources.add);
            setButtonIcon(trendsButton, Properties.Resources.trends);
            setButtonIcon(logoutButton, Properties.Resources.logout);
        
        }

        public BaseForm()
        {
            InitializeComponent();
        }


        private void dashboardButton_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
            
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        private void trendsButton_Click(object sender, EventArgs e)
        {
;
        }

        private void addStructureButton_Click(object sender, EventArgs e)
        {
            AddStructure addStructure = new AddStructure(token, user);
            ModalManager.ShowModal(addStructure);
            //addStructure.Show()
        }

        private void structuresButton_Click(object sender, EventArgs e)
        {
            StructuresList structuresList = new StructuresList(token, user);
            ModalManager.ShowModal(structuresList);
            //structuresList.Show();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            ModalManager.ShowModal(login);
            //login.Show();
            //this.Hide();
        }

        private void reservationsButton_Click(object sender, EventArgs e)
        {

        }


        private void setButtonIcon(Button button, System.Drawing.Image resourceImage)
        {
            var resized = new System.Drawing.Bitmap(resourceImage, new System.Drawing.Size(30, 30));
            button.Image = resized;
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;  
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;   
            button.Padding = new Padding(10, 0, 0, 0);
        }


        public string TitleLabelText
        {
            get { return title.Text; }
            set { title.Text = value; }
        }


    }
}
