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

        private void btnSave_Click(object sender, EventArgs e)
        {//To require all fields to be filled
            if (string.IsNullOrEmpty(txtboxAddress.Text))
            {
                btnDone.Hide();
            }
            else if (string.IsNullOrEmpty(txtboxAge.Text))
            {
                btnDone.Hide();
            }
            else if (string.IsNullOrEmpty(txtboxContact.Text))
            {
                btnDone.Hide();
            }
            else if (string.IsNullOrEmpty(txtboxEmail.Text))
            {
                btnDone.Hide();
            }
            else if (string.IsNullOrEmpty(txtboxName.Text))
            {
                btnDone.Hide();
            }
            else if (string.IsNullOrEmpty(txtboxTemp.Text))
            {
                btnDone.Hide();
            }
            else
            {
                btnDone.Show();
                btnSave.Hide();

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

            if (cmbboxHour.SelectedItem != null && !string.IsNullOrEmpty(cmbboxHour.SelectedItem.ToString()))
            {
                btnDone.Show();
                btnSave.Hide();
            }
            else
            {
                btnDone.Hide();
                btnSave.Show();
            }

            short age;
            short.TryParse(txtboxAge.Text, out age);
            if (short.TryParse(txtboxAge.Text, out age))
            {//To check the age
                if ((age < 18) || (age > 65))
                {
                    MessageBox.Show("Sorry you are not allowed to go outside based on your age.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number for your age!");
            }

            float temp;
            float.TryParse(txtboxTemp.Text, out temp);
            if (float.TryParse(txtboxTemp.Text, out temp))
            {//To check the temperature
                if (temp >= 37.4)
                {
                    MessageBox.Show("Sorry, you are not allowed to enter." +
                        "\nYour body temperature is " + temp + "\nYou have a fever!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number in the Temperature textbox!");
            }
        }

        private void cmbboxHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDone_Click(object sender, EventArgs e)
        {//To write and save the contact tracing details
            StreamWriter traceFile;
            string createDate = DateTime.UtcNow.ToLongDateString() + ".txt";
            string date = DateTime.UtcNow.ToLongDateString();
            
            traceFile = File.AppendText(createDate);
            traceFile.WriteLine("Name: " + txtboxName.Text);
            traceFile.WriteLine("Age: " + txtboxAge.Text);
            traceFile.WriteLine("Address: " + txtboxAddress.Text);
            traceFile.WriteLine("Contact No.: " + txtboxContact.Text);
            traceFile.WriteLine("Email: " + txtboxEmail.Text);
            traceFile.WriteLine("Temperature: " + txtboxTemp.Text + "°C");
            traceFile.WriteLine("Time: " + cmbboxHour.Text + ":" + cmbboxMinute.Text + " " + cmbboxAMPM.Text);
            traceFile.WriteLine("");
            traceFile.WriteLine("==================================================");
            traceFile.WriteLine("");
            traceFile.Close();

            Read_Data readForm = new Read_Data();
            readForm.Show();

            Contact_Tracing traceForm = new Contact_Tracing();
            traceForm.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {//To enable and allow editing in all fields
            txtboxAddress.Enabled = true;
            txtboxAge.Enabled = true;
            txtboxContact.Enabled = true;
            txtboxEmail.Enabled = true;
            txtboxName.Enabled = true;
            txtboxTemp.Enabled = true;
            cmbboxAMPM.Enabled = true;
            cmbboxHour.Enabled = true;
            cmbboxMinute.Enabled = true;

            btnDone.Hide();
            btnSave.Show();
        }

            private void btnX_Click(object sender, EventArgs e)
        {//To exit the contact tracing app
            Application.Exit();
        }

        private void Contact_Tracing_Load(object sender, EventArgs e)
        {//To hide done button and fill all fields first.
            btnDone.Hide();

            StreamWriter traceFile;
            traceFile = File.CreateText("Contact_Tracing.txt");
            traceFile.WriteLine("You can find the contact tracing details here.");
            traceFile.WriteLine("Each file with date as a name contains the information for each day.");
            traceFile.Close();
        }
    }
}
