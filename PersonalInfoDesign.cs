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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Asqrd
{
    public partial class PersonalInfoDesign : Form
    {

        public string FirstName;
        public string LastName;
        public string NationalID;
        public string LicenseNumber;
        public string Email;
        public string Password;
        public PersonalInfoDesign()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            NationalID = txtNationalID.Text;
            LicenseNumber = txtLicenseNumber.Text;
            Email = txtEmail.Text;
            Password = txtPassword.Text;

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "userdata.txt")))
                {

                 

                    writer.WriteLine("First Name: " + FirstName);
                    writer.WriteLine("Last Name: " + LastName);
                    writer.WriteLine("National ID: " + NationalID);
                    writer.WriteLine("License Number: " + LicenseNumber);

                    writer.WriteLine("Email: " + Email);
                    writer.WriteLine("Password: " + Password);

                }

                MessageBox.Show("Data saved to file successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving data to file: " + ex.Message);
            }
        }

        private void PersonalInfo_Load(object sender, EventArgs e)
        {

        }
    }

}

