using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard1
{
    public static class ModalManager
    {
        private static List<Form> openModals = new List<Form>();

        public static void ShowModal(Form modal)
        {
            // Chiude tutte le modali aperti prima
            foreach (var form in openModals.ToList())
            {
                if (!form.IsDisposed)
                    form.Close();
            }
            openModals.Clear();
            openModals.Add(modal);
            modal.FormClosed += (s, e) => openModals.Remove(modal);
            modal.Show();
        }
    }

}
