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
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(txtboxAge.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(txtboxContact.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(txtboxEmail.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (!txtboxEmail.Text.Contains("@"))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(txtboxName.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(txtboxTemp.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(cmbboxHour.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(cmbboxMinute.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (string.IsNullOrEmpty(cmbboxAMPM.Text))
            {
                btnRead.Hide();
                MessageBox.Show("Please answer all fields!");
            }
            else if (short.TryParse(txtboxAge.Text, out short age) && ((age < 18) || (age > 65))) //To check the appropriate age
            {
                btnRead.Hide();
                btnSave.Hide();
                MessageBox.Show("Sorry, you are not allowed to go outside based on your age.");
            }
            else if (!short.TryParse(txtboxAge.Text, out short ageNum))
            {//To not allow the user from entering letters or word
                btnRead.Hide();
                btnSave.Hide();
                MessageBox.Show("Please enter a number on the Age textbox!");
            }
            else if (float.TryParse(txtboxTemp.Text, out float temp) && (temp >= 37.4)) //To check the appropriate body temperature.
            {
                btnRead.Hide();
                btnSave.Hide();
                MessageBox.Show("Sorry, you should not be going outside." +
                    "\nYour body temperature is " + temp + "°C" + "." + "\nYou have a fever!");
            }
            else if (!float.TryParse(txtboxTemp.Text, out float tempNum))
            {
                btnRead.Hide();
                btnSave.Hide();
                MessageBox.Show("Please enter a number on the Temperature textbox!");
            }
            //If everything is working accordingly, the program will now write the file.
            else
            {
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
                traceFile.WriteLine("_______________________________________________");
                traceFile.WriteLine("");
                traceFile.Close();

                btnRead.Show();
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
        }

        private void btnRead_Click(object sender, EventArgs e)
        {//To show the second form
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

            StreamWriter traceFile;
            traceFile = File.CreateText("Contact_Tracing.txt");
            traceFile.WriteLine("You can find the contact tracing details here.");
            traceFile.WriteLine("Each file with the date as a name contains the information for each day.");
            traceFile.Close();
        }
    }
}
