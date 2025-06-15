using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboard1
{
    public class Utils
    {
        public Panel ShowLoading()
        {
            var loadingPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245)
            };

            var loadingLabel = new Label
            {
                Text = "Caricamento in corso",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Regular),
                ForeColor = Color.FromArgb(102, 102, 102)
            };

            var spinner = new ProgressBar { 
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 50,
                Size = new Size(200, 20),
                Anchor = AnchorStyles.None
            };

            loadingPanel.Controls.Add(loadingLabel);
            return loadingPanel;
        }

        public Panel ShowError() {
            var errorPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245)
            };

            var errorLabel = new Label
            {
                Text = "Si e' verificato un errore",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12),
                ForeColor = Color.FromArgb(217, 83, 79)
            };

            errorPanel.Controls.Add(errorLabel);
            return errorPanel;
        }
    };
}
