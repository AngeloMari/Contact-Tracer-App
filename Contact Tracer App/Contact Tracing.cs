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
        inputParameters inputConditions = new();
        public Contact_Tracing()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {//To require all fields to be filled properly before writing a file.
            inputConditions.Address = txtboxAddress.Text;
            inputConditions.Age = txtboxAge.Text;
            inputConditions.Contact = txtboxContact.Text;
            inputConditions.Email = txtboxEmail.Text;
            inputConditions.Name = txtboxName.Text;
            inputConditions.Temp = txtboxTemp.Text;
            inputConditions.Hour = cmbboxHour.Text;
            inputConditions.Minute = cmbboxMinute.Text;
            inputConditions.AMPM = cmbboxAMPM.Text;
            inputConditions.Parameters();
            txtboxAddress.Text = inputConditions.Address;
            txtboxAge.Text = inputConditions.Age;
            txtboxContact.Text = inputConditions.Contact;
            txtboxEmail.Text = inputConditions.Email;
            txtboxName.Text = inputConditions.Name;
            txtboxTemp.Text = inputConditions.Temp;
            cmbboxHour.Text = inputConditions.Hour;
            cmbboxMinute.Text = inputConditions.Minute;
            cmbboxAMPM.Text = inputConditions.AMPM;

            if (!inputConditions.parameterPassed)
            {
                btnRead.Hide();
                MessageBox.Show(inputConditions.ErrorMessage);
            }
            else
            {
                btnSave.Hide();
                btnRead.Show();

                txtboxAddress.Enabled = false;
                txtboxAge.Enabled = false;
                txtboxContact.Enabled = false;
                txtboxEmail.Enabled = false;
                txtboxName.Enabled = false;
                txtboxTemp.Enabled = false;
                cmbboxAMPM.Enabled = false;
                cmbboxHour.Enabled = false;
                cmbboxMinute.Enabled = false;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {//To show the second form that will read the written file.
            Read_Data readForm = new();
            readForm.Show();

            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {//To enable editing in all fields
            txtboxAddress.Enabled = true;
            txtboxAge.Enabled = true;
            txtboxContact.Enabled = true;
            txtboxEmail.Enabled = true;
            txtboxName.Enabled = true;
            txtboxTemp.Enabled = true;
            cmbboxAMPM.Enabled = true;
            cmbboxHour.Enabled = true;
            cmbboxMinute.Enabled = true;
         //To allow saving again
            btnRead.Hide();
            btnSave.Show();
        }

        private void btnX_Click(object sender, EventArgs e)
        {//To exit the contact tracing app
            Application.Exit();
        }

        private void Contact_Tracing_Load(object sender, EventArgs e)
        {//To hide done button and fill all fields first.
            btnRead.Hide();
         //Creating an initial file that contains instruction.
            string path = Environment.CurrentDirectory + "/" + "Contact Tracing Data";
            DirectoryInfo newFolder;
            newFolder = Directory.CreateDirectory(path);
            StreamWriter traceFile;
            traceFile = File.CreateText(newFolder + "/Contact Tracing.txt");
            traceFile.WriteLine("You can find the contact tracing details here.");
            traceFile.WriteLine("Each file with the date as a name contains the information for each day.");
            traceFile.Close();
        }
    }
}
