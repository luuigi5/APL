using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace dashboard1 { 
    internal static class Program {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
            /*string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzZXIiOjYsInVzZXJuYW1lIjoiQWwiLCJpYXQiOjE3NDYyNjY0NzcsImV4cCI6MTc0NjM1Mjg3N30.BSb4vlLi0SAPvqRGYl5EeLMtraNbBPQp3LNhHEaZUwQ";
            User user = new User(6, "Al", "al@renthouse.it");
            Application.Run(new AddStructure(token, user));*/
        }
    }
}
