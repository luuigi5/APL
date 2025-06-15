using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientRest;
using static System.Net.WebRequestMethods;

namespace dashboard1
{
    public partial class AddStructure : BaseForm
    {
        /*public string token { get; set; }
        public User user { get; set; }*/
        
        public AddStructure(string token, User user) : base(token, user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;
            //estendo il titolo del baseform e lo modifico nelle varie pagine
            this.title.Text = "Aggiungi struttura";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (nameInput.Text != "" && cityInput.Text != "" && addressInput.Text != "" && typeInput.Text != "" && roomsInput.Text != "" && imglink.Text != "")
            {
                await AddStructureButton();
            }
            else {
                MessageBox.Show("Popola tutti i campi di input!");
            }
        }

        private async Task AddStructureButton()
        {
           string apiurl = "http://localhost:8093/addStructure";
           var structure = new 
             {
                 name = nameInput.Text,
                 idUser = user.id,
                 city = cityInput.Text,
                 address = addressInput.Text,
                 type = typeInput.Text, 
                 rooms = int.Parse(roomsInput.Text), 
                 imglink = imglink.Text,
             };
           string payload = JsonSerializer.Serialize(structure);
           string response = await Client.CallApiPost(apiurl, payload, token);
           //string decodedJson = JsonSerializer.Deserialize<string>(response);
           ResponseData resp = JsonSerializer.Deserialize<ResponseData>(response);
            //controlli sulla risposta
            if (resp.status == 200 && resp.structure != null)
            {
                nameInput.Text = "";
                cityInput.Text = "";
                addressInput.Text = "";
                typeInput.Text = "";
                roomsInput.Text = "";
                imglink.Text = "";
                MessageBox.Show("Struttura aggiunta!");
            }
            else {
                MessageBox.Show("Errore durante l'aggiunta della struttura");
            }
        }

    }
}
