using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientRest;



namespace dashboard1
{
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
            usernameField.Text = "Al";
            passwordField.Text = "apartamentPwdSyd";
        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }

        private void pictureBox3_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e) {
            passwordField.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e) {
            passwordField.UseSystemPasswordChar = true;
        }

        private async Task LoginButton_Click_Async() {
            if (usernameField.Text != "" && passwordField.Text != "")
            {
                string apiUrl = "http://localhost:8093/login";
                string payload = JsonSerializer.Serialize(new { username = usernameField.Text, password = passwordField.Text });
                string response = await Client.CallApiPost(apiUrl, payload, null);

                ResponseData resp = JsonSerializer.Deserialize<ResponseData>(response);
                if (resp.status == 200 && resp.token != null && resp.user != null)
                {
                    Console.WriteLine("Utente loggato " + resp.token);
                    AddStructure addStructure = new AddStructure(resp.token, resp.user);
                    ModalManager.ShowModal(addStructure);
                    /*addStructure.Show();*/
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenziali non valide");
                }
            }
            else {
                MessageBox.Show("Inserire username e password");

            }


        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            await LoginButton_Click_Async();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
