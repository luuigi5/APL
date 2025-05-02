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

            //Application.Run(new Login());
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZFVzZXIiOjYsInVzZXJuYW1lIjoiQWwiLCJpYXQiOjE3NDYxNzY1NTksImV4cCI6MTc0NjI2Mjk1OX0.ZpLSy6lcVKUlyEpb2Ozf0kXCRum6JqZcNUvMR6w6KTE";
            User user = new User(6, "Al", "al@renthouse.it");
            Application.Run(new Form1(token, user));
        }
    }
}
