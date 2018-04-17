using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiophantineEquation
{
    public partial class Form1 : Form
    {
        private GCD gcd;
        private BackSubstitution bcks;
        private bool noError = true;
        public Form1()
        {
            InitializeComponent();
            gcd = new GCD();
            bcks = new BackSubstitution();
        }

        //calculation button
        private void button1_Click(object sender, EventArgs e)
        {
            int gcdNum;
            int yDividedValue;
            //get two number from textboxes
            int numOne;
            int numTwo;
            int equals;

            if(!Int32.TryParse(textBox1.Text, out numOne))
            {
                noError = false;
                richTextBox1.Text = "Input error";
            }
            else
            {
                noError = true;
            }
            if(!Int32.TryParse(textBox2.Text, out numTwo))
            {
                noError = false;
                richTextBox1.Text = "Input error";
            }
            else
            {
                noError = true;
            }
            if (!Int32.TryParse(textBox3.Text, out equals))
            {
                noError = false;
                richTextBox1.Text = "Input error";
            }
            else
            {
                noError = true;
            }
            if (noError)
            {

                    gcdNum = gcd.getGCD(numOne, numTwo);
                    textBox6.Text = gcdNum + "";

                int yValue;
                Int32.TryParse(textBox3.Text, out yValue);
                yDividedValue = gcd.getYDivided(yValue, gcdNum);
                if (yDividedValue != 0)
                    label6.Text = "The equation has solution";
                else
                    label6.Text = "The equation has No solution";
                richTextBox1.Text = "Euclid's algorithm\n";
                richTextBox1.Text += gcd.getgcdStr();
                richTextBox1.Text += gcd.printBackSub();

                int dividedEqualsWithGCD;
                dividedEqualsWithGCD = equals / gcdNum;
                //back substitution start from here
                richTextBox1.Text += bcks.backSTT(gcd.gettdArray(), gcd.getRows());//pass array to backsubstitution method

                int newX, newY;

                numOne = bcks.getX0();
                newX = bcks.getX1();
                numTwo = bcks.getY0();
                newY = bcks.getY1();
                richTextBox1.Text += "\n" + dividedEqualsWithGCD + "(" + numOne + "(" + newX + ")+" + numTwo + "(" + newY + ")=" + gcdNum + "(" + dividedEqualsWithGCD + ")";
 
                richTextBox1.Text += "\n" + numOne + "(" + newX * dividedEqualsWithGCD + ")+" + numTwo + "(" + newY * dividedEqualsWithGCD + ")=" + equals+ "\n";

                int tOne, tTwo;
           
                //X = newX + t(numOne/gcd)
                tOne = (numOne / gcdNum);
                newY = newY * dividedEqualsWithGCD;
                richTextBox1.Text += "Y = " + newY + " - " + tOne + "t\n";

                //Y = newY + t(numTwo/gcd)
                tTwo = (numTwo / gcdNum);
                newX = newX * dividedEqualsWithGCD;
                richTextBox1.Text += "X = " + newX + " + " + tTwo + "t\n";
                //find all solutions
                //move newX to far side so *-1
                double x, y;
                x = newX * -1;
                x = x / tTwo;

                y = newY * -1;
                y = y / tOne;

                richTextBox1.Text += "X = " + x + " Y = " + y;

                textBox4.Text = x + "";
                textBox5.Text = y + "";

            }
        }
    }
}
