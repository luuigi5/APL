using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using dashboard1.ClientRest;

namespace dashboard1
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Chiamo il client...");

            await Client.CallApi();
        }
    }
}
