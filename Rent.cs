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
    public partial class Rent : Form
    {
        public Rent()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private bool isPickingUp, isDroppingOff;
        private DateTime pickupDate, dropOffDate;

        private void button1_Click(object sender, EventArgs e)
        {
            CarDetails carDetails = new CarDetails();
            carDetails.ShowDialog();
        }

        private void rentCalendar_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPickingUp || isDroppingOff)
            {
                MessageBox.Show("Please confirm the other date first.");
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                pickupDate = rentCalendar.SelectionRange.Start;
                isPickingUp = true;
                rentCalendar.SelectionStart = pickupDate;
                // Highlight or indicate visually that pickup date is selected
            }
            else if (e.Button == MouseButtons.Right) // Optional: right-click for drop-off
            {
                dropOffDate = rentCalendar.SelectionRange.End;
                isDroppingOff = true;
                rentCalendar.SelectionStart = dropOffDate;
                // Highlight or indicate visually that drop-off date is selected
            }
        }

        private void rentCalendar_SelectedRangeChanged(object sender, EventArgs e)
        {
            if (isPickingUp && isDroppingOff)
            {
                if (dropOffDate < pickupDate)
                {
                    MessageBox.Show("Drop-off date cannot be before pickup date.");
                    isPickingUp = false;
                    isDroppingOff = false;
                    pickupDate = DateTime.MinValue;
                    dropOffDate = DateTime.MinValue;
                    rentCalendar.SelectionStart = DateTime.MinValue;
                    // Clear any visual cues on the calendar
                    return;
                }

                int rentalDays = (dropOffDate - pickupDate).Days - 1; // Exclude both days
                                                                      // Use rentalDays to calculate price with Car object and show it in UI

                // Reset flags and selection
                isPickingUp = false;
                isDroppingOff = false;
                pickupDate = DateTime.MinValue;
                dropOffDate = DateTime.MinValue;
                rentCalendar.SelectionStart = DateTime.MinValue;
                // Clear any visual cues on the calendar
            }
        }



    }
}
