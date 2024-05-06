using System;
using System.IO;
using System.Windows.Forms;

namespace Asqrd
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRentCar_Click_1(object sender, EventArgs e)
        {
            string storedEmail="";
            string storedPassword="";

            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "userdata.txt")))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        storedEmail = reader.ReadLine()?.Replace("Email: ", "");
                        storedPassword = reader.ReadLine()?.Replace("Password: ", "");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading user data: " + ex.Message);
                return;
            }


            string enteredEmail = txtEmail.Text;
            string enteredPassword = txtPassword.Text;

            if (enteredEmail == storedEmail && enteredPassword == storedPassword)
            {
                MessageBox.Show("Login successful!");
              CarDetails carDetails = new CarDetails();
                carDetails.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }

        }

        private void SaveCredentials(string username, string password)
        {
            try
            {
                // Get the "Documents" folder path of the current user
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Combine it with the file name to get the full path
                string filePath = Path.Combine(documentsPath, "credentials.txt");

                // Write username and password to the file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Username: {username}, Password: {password}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving credentials: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            PersonalInfoDesign form2 = new PersonalInfoDesign();
            form2.ShowDialog();

        }
    }
}
