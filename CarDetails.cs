using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asqrd
{
    public partial class CarDetails : Form
    {
        public CarDetails()
        {
            InitializeComponent();
        }
        Dictionary<string, string[]> carModels = new Dictionary<string, string[]>()
{
    { "Hyundai", new string[] {
        "Elantra", "Tucson", "Verna", "Creta", "Accent",
    } },
    { "Kia", new string[] {
        "Sportage", "Cerato", "Sorento", "XCeed", "Rio",
    } },
    { "Toyota", new string[] {
        "Corolla", "Camry", "RAV4", "Yaris", "Hilux",
    } },
    { "Nissan", new string[] {
        "Sentra", "Altima", "Sunny", "Frontier", "Leaf",
    } },
    { "Mazda", new string[] {
        "CX-5", "CX-3", "Mazda3", "CX-9", "Mazda6",
    } },
    { "Suzuki", new string[] {
        "Swift", "Jimny", "Alto", "Baleno", "Ertiga",
    } },
    { "Mitsubishi", new string[] {
        "Outlander", "Mirage", "Eclipse Cross", "Lancer", "Pajero",
    } },
};

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedMake = makeComboBox.SelectedItem.ToString();

            if (carModels.ContainsKey(selectedMake))
            {
                modelComboBox.Items.Clear(); // Clear existing items

                foreach (string model in carModels[selectedMake])
                {
                    modelComboBox.Items.Add(model); 
                }

                modelComboBox.Enabled = true; 
            }
            else
            {
                modelComboBox.Enabled = false; 
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string imageURL = string.Format("{0}_{1}.jpg",
                makeComboBox.SelectedItem.ToString(), modelComboBox.SelectedItem.ToString());
            pictureBox2.ImageLocation = imageURL;

        }

        private void Submit_Click(object sender, EventArgs e)
        {
          
            Car car = new Car();
          
            car.Make = makeComboBox.SelectedItem.ToString();
            car.Model = modelComboBox.SelectedItem.ToString();
            car.Color = colorComboBox.SelectedItem.ToString();

            MessageBox.Show("Car details saved successfully!");
            

        }
    }
}



