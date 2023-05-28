using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","N","N","H","H","j","j",
            "l","l","v","v","b","b","y","y"
        };
        Label firstClicked;
        Label secondClicked;    

        public Form1()
        {
            InitializeComponent();
            AssignIconToSquares();
        }

        
        private void AssignIconToSquares()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i]; 
                }

                else 
                {
                    continue; 
                }
                   
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);

            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
            {
                return;
            }
            Label clickLabel = sender as Label;
            if (clickLabel == null)
            {
                return;
            }
            if (clickLabel.ForeColor == Color.Black)
            {
                return;
            }
            if (firstClicked == null)
            {
                firstClicked = clickLabel;
                firstClicked.ForeColor = Color.Black;   
                return;
            }
            secondClicked = clickLabel;
            secondClicked.ForeColor = Color.Black;
            CheckForWinner();
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                timer1.Start();
            }

        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("Wygrałeś. Gratulacje!");
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
           

            firstClicked = null;
            secondClicked = null;

        }
       /* private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }*/


    }
}
