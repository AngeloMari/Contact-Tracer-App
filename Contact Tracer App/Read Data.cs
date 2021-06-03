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
    public partial class Read_Data : Form
    {
        public Read_Data()
        {
            InitializeComponent();
        }

        private void Read_Data_Load(object sender, EventArgs e)
        {
            txtboxRead.Text = File.ReadAllText(DateTime.UtcNow.ToLongDateString() + ".txt");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkHere_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
