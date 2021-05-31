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
         

            int age;
            int.TryParse(txtboxAge.Text, out age);
            if ((age<18)||(age>65))
            {
                MessageBox.Show("Sorry you are not allowed to go outside based on your age.");
            }
            else if ((age !>= 18) || (age !<= 65))
            {
                MessageBox.Show("Please enter a number in the Age textbox!");
            }

            int temp;
            int.TryParse(txtboxTemp.Text, out temp);
            if (temp >= 37.4)
            {
                MessageBox.Show("Sorry, you are not allowed to enter." +
                    "\nYour body temperature is " + temp + "\nYou have a fever!");
            }
            else if ((temp !<= 37.4))
            {
                MessageBox.Show("Please enter a number in the Temperature textbox!");
            }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxAddress.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxAge.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxContact.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxEmail.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxName.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxTemp.Text))
            {
                btnDone.Enabled = false;
            }
            else if (string.IsNullOrEmpty(txtboxTime.Text))
            {
                btnDone.Enabled = false;
            }
            else if ((rbtnAM.Checked == false) && (rbtnPM.Checked == false))
            {
                btnDone.Enabled = false;
            }
            else
                btnDone.Enabled = true;
        }
    }
}
