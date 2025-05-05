using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dashboard1
{
    public class Structure
    {
        public int id { get; set; }
        public string name { get; set; }
        public int idUser { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public int rooms { get; set; }
        public string imglink { get; set; }

        public Structure(int id, string name, int idUser, string city, string address, string type, int rooms, string imglink) {
            this.id = id;
            this.name = name;
            this.idUser = idUser; 
            this.city = city;
            this.address = address;
            this.type = type;
            this.rooms = rooms;
            this.imglink = imglink;
        }

        public Structure() { }

    }
}
