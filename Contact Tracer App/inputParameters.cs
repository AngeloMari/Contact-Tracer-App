using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Tracer_App
{
    class inputParameters
    {
        public string Address = "";
        public string Age = "";
        public string Contact = "";
        public string Email = "";
        public string Name = "";
        public string Temp = "";
        public string Hour = "";
        public string Minute = "";
        public string AMPM = "";
        public string ErrorMessage = "";
        public bool parameterPassed = true;

        public void Parameters()
        {//Conditions to be passed in order to write and save the user's data.
            if (string.IsNullOrEmpty(Address))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Age))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Contact))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Email))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Name))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Temp))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Hour))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(Minute))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (string.IsNullOrEmpty(AMPM))
            {
                parameterPassed = false;
                ErrorMessage = "Please answer all fields!";
            }
            else if (!Email.Contains("@"))
            {
                parameterPassed = false;
                ErrorMessage = "Please enter a valid email!";
            }
            else if (short.TryParse(Age, out short age) && ((age < 18) || (age > 65))) //To check the appropriate age
            {
                parameterPassed = false;
                ErrorMessage = "Sorry, you are not allowed to go outside based on your age.";
            }
            else if (!short.TryParse(Age, out short ageNum))
            {//To not allow the user from entering letters or word
                parameterPassed = false;
                ErrorMessage = "Please enter a number on the Age textbox!";
            }
            else if (float.TryParse(Temp, out float temp) && (temp >= 37.4)) //To check the appropriate body temperature.
            {
                parameterPassed = false;
                ErrorMessage = "Sorry, you should not be going outside." +
                    "\nYour body temperature is " + temp + "°C" + "." + "\nYou have a fever!";
            }
            else if (!float.TryParse(Temp, out float tempNum))
            {
                parameterPassed = false;
                ErrorMessage = "Please enter a number on the Temperature textbox!";
            }
            //If everything is working accordingly, the program will now write the file.
            else
            {
                parameterPassed = true;

                string path = Environment.CurrentDirectory + "/" + "Contact Tracing Data";
                DirectoryInfo newFolder;
                newFolder = Directory.CreateDirectory(path);
                StreamWriter traceFile;
                string createDate = DateTime.UtcNow.ToLongDateString() + ".txt";
                string date = DateTime.UtcNow.ToLongDateString();
                traceFile = File.AppendText(newFolder + "/" + createDate);
                traceFile.WriteLine("Name: " + Name);
                traceFile.WriteLine("Age: " + Age);
                traceFile.WriteLine("Address: " + Address);
                traceFile.WriteLine("Contact No.: " + Contact);
                traceFile.WriteLine("Email: " + Email);
                traceFile.WriteLine("Temperature: " + Temp + "°C");
                traceFile.WriteLine("Time: " + Hour + ":" + Minute + " " + AMPM);
                traceFile.WriteLine("");
                traceFile.WriteLine("_______________________________________________");
                traceFile.WriteLine("");
                traceFile.Close();
            }
        }
    }
}
