using Projection_Library.Classes;
using Projection_Library.Classes.Networking;
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
    public partial class ProjectionViewer : Form
    {
        DisplayClient client;
        public ProjectionViewer(DisplayClient client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
