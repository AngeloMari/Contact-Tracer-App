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
            else if (string.IsNullOrEmpty(txtboxTime.Text))
            {
                btnDone.Hide();
            }
            else if ((rbtnAM.Checked == false) && (rbtnPM.Checked == false))
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
                txtboxTime.Enabled = false;
                rbtnAM.Enabled = false;
                rbtnPM.Enabled = false;
            }

            int age;
            int.TryParse(txtboxAge.Text, out age);
            if (int.TryParse(txtboxAge.Text, out age))
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

            int temp;
            int.TryParse(txtboxTemp.Text, out temp);
            if (int.TryParse(txtboxTemp.Text, out temp))
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

        private void btnDone_Click(object sender, EventArgs e)
        {//To write and save the contact tracing details
            StreamWriter traceFile;
            string createDate = File.GetCreationTime("Contact_Tracing.txt").ToLongDateString();

            traceFile = File.AppendText(createDate);
            traceFile.WriteLine("Name: " + txtboxName.Text);
            traceFile.WriteLine("Age: " + txtboxAge.Text);
            traceFile.WriteLine("Address: " + txtboxAddress.Text);
            traceFile.WriteLine("Contact No.: " + txtboxContact.Text);
            traceFile.WriteLine("Email: " + txtboxEmail.Text);
            traceFile.WriteLine("Temperature: " + txtboxTemp.Text);
            traceFile.WriteLine("Time: " + txtboxTime.Text);
            traceFile.WriteLine("");
            traceFile.WriteLine("==================================================");
            traceFile.WriteLine("");
            traceFile.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {//To enable and allow editing in all fields
            txtboxAddress.Enabled = true;
            txtboxAge.Enabled = true;
            txtboxContact.Enabled = true;
            txtboxEmail.Enabled = true;
            txtboxName.Enabled = true;
            txtboxTemp.Enabled = true;
            txtboxTime.Enabled = true;
            rbtnAM.Enabled = true;
            rbtnPM.Enabled = true;

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
