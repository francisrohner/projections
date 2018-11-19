using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projection.Controls
{
    public partial class IP_Box : UserControl
    {
        public IP_Box()
        {
            InitializeComponent();
        }

        public string IP
        {
            get { return string.Format("{0}.{1}.{2}.{3}", txtSegment1.Text, txtSegment2.Text, txtSegment3.Text, txtSegment4.Text);  }

        }

    
    }
}
