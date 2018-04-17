using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiophantineEquation
{
    class GCD
    {
        private string gcdStr;
        private int[,] tdarr = new int[50,5];
        private int countrows;
        public int getGCD(int one, int two)
        {
            int gcdNumber = Int32.MaxValue;
            int reminder = Int32.MaxValue;
            int row = 0;
            int column = 0;
            countrows = 0;
            //values to display
            int times = 0;
            gcdStr = "";
            while (reminder > 0)
            {
                column = 0;
                //calculate how many times the number in the value and get reminder
                reminder = one % two;
                times = one / two;
               // Console.WriteLine(one + "=" + times + "*" + two + "+" +reminder);
              
                gcdStr += one + "=" + times + "*" + two + "+" + reminder + "\n";
                
                if (reminder > 0)
                {
                    tdarr[row, column] = one;
                    column++;
                    tdarr[row, column] = times*-1;
                    column++;
                    tdarr[row, column] = two;
                    column++;
                    tdarr[row, column] = reminder;
                    column++;
                    tdarr[row, column] = 1;
                    row++;

                    countrows++;
                    gcdNumber = reminder;
                }
                one = two;
                two = reminder;

            }


            return gcdNumber;
        }

        public string printBackSub()
        {
            string str = "\nSolve for Reminder\n";
            int count = 0;
            while(count != countrows)
            {
               // Console.WriteLine(tdarr[count, 3] + "="+ tdarr[count,0] + "("+ tdarr[count, 4] + ") + " + tdarr[count,2] +"("+tdarr[count,1]+")");
                str += tdarr[count, 3] + "=" + tdarr[count, 0] + "("+ tdarr[count, 4] + ") + " + tdarr[count, 2] + "(" + tdarr[count, 1] + ")\n";
                count++;
            }
            return str;
        }


        //use only on console print
     /*   public void printtdarr()
        {
            Console.WriteLine("Print function");
            for(int row=0;row<countrows;row++)
            {
                    Console.WriteLine(tdarr[row, 0] + "=" + tdarr[row, 1] + "*" + tdarr[row, 2] + "+" + tdarr[row, 3]);               
            }
           
        }*/
         
        public int getRows()
        {
            return countrows;
        }
        public int[,] gettdArray()
        {
            int[,] newtd = new int[countrows, 5];

            for(int i=0;i<countrows;i++)
            {
                newtd[i, 0] = tdarr[i, 0];
                newtd[i, 1] = tdarr[i, 1];
                newtd[i, 2] = tdarr[i, 2];
                newtd[i, 3] = tdarr[i, 3];
                newtd[i, 4] = tdarr[i, 4];
            }
            return newtd; 
        }

        public string getgcdStr()
        {
            return gcdStr;
        }


        public int getYDivided(int yValue , int gcd)
        {
            return yValue / gcd;
        }
    }
}
