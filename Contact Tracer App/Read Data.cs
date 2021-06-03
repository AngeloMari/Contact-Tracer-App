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
            MessageBox.Show("Privacy and Terms\n\n" + "     We respect your privacy and protect any personal information that you share with us. " +
                "We commit to secure the individual’s right to privacy, and therefore, we strictly comply with RA 10173- Data Privacy Act of 2012. " +
                "Our goal is to protect your personal information regardless of how you able to use this service. " +
                "By using this contact tracing app, you consent to the collection, storage, processing, and transferring of data you have provided.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
