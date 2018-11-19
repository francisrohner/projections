using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projection.Forms
{
    public partial class ScreenSelector : Form
    {
        string[] data;
        public ScreenSelector(List<string> screens)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Projection_Client.Properties.Resources.tv_screen.GetHicon());
            data = screens.ToArray();
            foreach (string screen in screens)
            {
                //Name,Resolution,IP
                string[] splData = screen.Split(',');
                cmbScreen.Items.Add(string.Format("{0} [{1}]", splData[0], splData[1]));
            }
            cmbScreen.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tag = data[cmbScreen.SelectedIndex];
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
