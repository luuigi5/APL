using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientRest;

namespace dashboard1
{
    public partial class StructuresList : BaseForm
    {
        //pannello che mi servirà per gestire la posizione delle card
        private FlowLayoutPanel panelContainer;

        public StructuresList(string token, User user) : base(token, user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;
            InitializeCardContainer();
            loadStructuresById(user.id);
            //estendo il titolo del baseform e lo modifico nelle varie pagine
            this.title.Text = "Strutture caricate";

        }

        private void InitializeCardContainer() {
            //instanzio il panelContainer di tipo FlowLayoutPanel definito prima
            panelContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(300, 50, 10, 0),
            };
            this.Controls.Add(panelContainer);
        }

        private async void loadStructuresById(int id) {
            await loadStructures(id);
        }

        private async Task loadStructures(int id) {
            ShowLoading();
            string apiurl = "http://localhost:8093/getStructureByUser?idUser=" + id;
            string response = await Client.CallApiGet(apiurl, token);
            ResponseData resp = JsonSerializer.Deserialize<ResponseData>(response);
            if (resp.status == 200)
            {
                Console.WriteLine("Utente loggato " + resp.structures);

                foreach (var structure in resp.structures)
                {
                    Console.WriteLine($"Name: {structure.name}");
                    Console.WriteLine($"Address: {structure.address}");
                    Console.WriteLine($"City: {structure.city}");
                    Console.WriteLine($"ID: {structure.id}");
                    Console.WriteLine($"User ID: {structure.idUser}");
                    Console.WriteLine($"Image Link: {structure.imglink}");
                    Console.WriteLine($"Rooms: {structure.rooms}");
                    Console.WriteLine($"Type: {structure.type}");
                    Console.WriteLine();
                }
                ManageCards(resp.structures);
            }
            else {
                ShowError();
            }
        }

        private void ShowLoading() {
            panelContainer.Controls.Clear();
            Utils utils = new Utils();
            var loadingPanel = utils.ShowLoading();
            panelContainer.Controls.Add(loadingPanel);
        }

        private void ShowError() {
            panelContainer.Controls.Clear();
            Utils utils = new Utils();
            var errorPanel = utils.ShowError();
            panelContainer.Controls.Add(errorPanel);
        }


        private void ManageCards(List<Structure> structures)
        {
            panelContainer.Controls.Clear();
            if (structures == null || structures.Count == 0) {
                //non è stato trovata alcuna struttura
                var emptyStructures = new Label
                {
                    Text = "Nessuna struttura trovata",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 14),
                    ForeColor = Color.FromArgb(102, 102, 102)
                };
                panelContainer.Controls.Add(emptyStructures);
                return;
            }

            foreach (var structure in structures) {
                //per ogni struttura trovata in memoria creo una card
                var card = CreateCard(structure);
                panelContainer.Controls.Add(card);
            }
            var spacer = new Panel { Height = 430, Width = 10 }; 
            panelContainer.Controls.Add(spacer);
        }

        private Panel CreateCard(Structure structure) {
            //proprietà card
            var cardPanel = new Panel
            {
                Size = new Size(320, 340),
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            //gestione immagine card
            var pictureBox = new PictureBox
            {
                Location = new Point(10,10),
                Size = new Size(300, 180),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(240, 240, 240),
                BorderStyle = BorderStyle.FixedSingle
            };
            //se presente carico l'immagine, altrimenti errore
            if (structure.imglink != null && !string.IsNullOrEmpty(structure.imglink))
            {
                try
                {

                    string relativePath = Path.Combine(@"..\..\..\..\immagini", structure.imglink);
                    string imagePath = Path.GetFullPath(Path.Combine(Application.StartupPath, relativePath));
                    if (!File.Exists(imagePath))
                    {
                        MessageBox.Show("File non trovato: " + imagePath);
                    }
                    else
                    {
                        pictureBox.LoadAsync(imagePath);
                    }
                    //pictureBox.LoadAsync(@"C:\Users\FNCLGU00B\source\repos\APL\APL\immagini\monarco.jpg");
                }
                catch
                {
                    var noImgLabel = new Label
                    {
                        Text = "Immagine non disponibile",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 10),
                        ForeColor = Color.Gray,
                        BackColor = Color.FromArgb(240, 240, 240)
                    };
                    pictureBox.Controls.Add(noImgLabel);
                }
            } else {
                var noImgLabel = new Label
                {
                    Text = "Immagine non disponibile",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10),
                    ForeColor = Color.Gray,
                    BackColor = Color.FromArgb(240, 240, 240)
                };
                pictureBox.Controls.Add(noImgLabel);
            }
            //cardPanel.Controls.Add(pictureBox);

            //nome struttura
            var nameStructureLabel = new Label
            {
                Text = structure.name,
                Location = new Point(10, 170),
                Size = new Size(330, 25),
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51)
            };
            //tipo struttura
            var typeStructureLabel = new Label
            {
                Text = structure.type,
                Location = new Point(10, 200),
                Size = new Size(150, 20),
                Font = new Font("Arial", 10),
                ForeColor = Color.FromArgb(51, 122, 183)
            };
            //indirizzo struttura
            var addressStructureLabel = new Label
            {
                Text = $" {structure.address}, {structure.city}",
                Location = new Point(10, 225),
                Size = new Size(330, 20),
                Font = new Font("Arial", 9),
                ForeColor = Color.FromArgb(108, 117, 125)
            };

            //AZIONI
            
            //PROPRIETA BOTTONE MODIFICA
            var btnEdit = new Button
            {
                Text = "✏ Modifica",
                Location = new Point(110, 275),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Tag = structure
            };
            btnEdit.FlatAppearance.BorderSize = 0;

            //PROPRIETA BOTTONE ELIMINA
            var btnDelete = new Button
            {
                Text = "🗑️ Elimina",
                Location = new Point(210, 275),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Tag = structure
            };
            btnDelete.FlatAppearance.BorderSize = 0;

            btnEdit.Click += (sender, e) => EditStructure((Structure)((Button)sender).Tag);
            btnDelete.Click += (sender, e) => DeleteStructure((Structure)((Button)sender).Tag);


            cardPanel.MouseEnter += (s, e) =>
            {
                cardPanel.BackColor = Color.FromArgb(248, 249, 250);
            };
            cardPanel.MouseLeave += (s, e) =>
            {
                cardPanel.BackColor = Color.White;
            };


            cardPanel.Controls.AddRange(new Control[]
            {
                pictureBox, nameStructureLabel, typeStructureLabel, addressStructureLabel, btnEdit, btnDelete
            });

            return cardPanel;
        }

        private void EditStructure(Structure structure) {
            Console.WriteLine("Modifica Struttura " + structure.name);
            
        }


        private void DeleteStructure(Structure structure) {
            Console.WriteLine("Elimina Struttura " + structure.name);
        }







    }
}
