using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace dashboard1 { 
    internal static class Program {
        [STAThread]
        static async Task Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
        }
    }
}
