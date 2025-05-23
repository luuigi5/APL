﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientRest;

namespace dashboard1
{
    public partial class StructuresList : BaseForm
    {
        public StructuresList(string token, User user) : base(token, user)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;
            loadStructuresById(user.id);
        }


        private async void loadStructuresById(int id) {

            await loadStructures(id);
        
        }

        private async Task loadStructures(int id) {
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

            }


        }

    }

}
