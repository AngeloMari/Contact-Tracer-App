using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Tracer_App
{
    public partial class Contact_Tracing : Form
    {
        public Contact_Tracing()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            txtboxAddress.Enabled = false;
            txtboxAge.Enabled = false;
            txtboxContact.Enabled = false;
            txtboxEmail.Enabled = false;
            txtboxName.Enabled = false;
            txtboxTemp.Enabled = false;
            txtboxTime.Enabled = false;
            rbtnAM.Enabled = false;
            rbtnPM.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtboxAddress.Enabled = true;
            txtboxAge.Enabled = true;
            txtboxContact.Enabled = true;
            txtboxEmail.Enabled = true;
            txtboxName.Enabled = true;
            txtboxTemp.Enabled = true;
            txtboxTime.Enabled = true;
            rbtnAM.Enabled = true;
            rbtnPM.Enabled = true;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
