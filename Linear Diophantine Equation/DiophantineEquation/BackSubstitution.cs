using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiophantineEquation
{
    class BackSubstitution
    {
        private int x0, x1, y0, y1;
        public string backSTT(int [,]td,int rows)
        {
            
            string str = "\nBack Substitution\n";
            int[,] arr = td;//use to store two number

            //rows is the one I need
            int count = rows-1;

            while (count >=0)
            {

               // Console.WriteLine(arr[rows - 1, 3] + "=" + arr[count, 0] + "("+ arr[count, 4] +") + " + arr[count, 2] + "(" + arr[count, 1] + ")");
                str += arr[rows - 1, 3] + "=" + arr[count, 0] + "(" + arr[count, 4] + ") + " + arr[count, 2] + "(" + arr[count, 1] + ")\n";
                x0 = arr[count, 0];
                x1 = arr[count, 4];
                y0 = arr[count, 2];
                y1 = arr[count, 1];
                if (count > 0)
                {
                   // Console.WriteLine(arr[rows - 1, 3] + "=" + arr[count, 0] + "(" + arr[count, 4] + ") + " + "[ "+arr[count-1, 0] + "(" + arr[count, 1] + ") + " + arr[count-1, 2] + "(" + arr[count-1, 1] + ") ]" + "(" + arr[count, 1] + ")");
                    str += arr[rows - 1, 3] + "=" + arr[count, 0] + "(" + arr[count, 4] + ") + " + "[ " + arr[count - 1, 0] + "(" + arr[count - 1, 4] + ") + " + arr[count - 1, 2] + "(" + arr[count - 1, 1] + ") ]" + "(" + arr[count, 1] + ")\n";
                    //Change values at position in array
                    arr[count - 1, 4] = (arr[count - 1, 4] * arr[count, 1]);
                    arr[count - 1, 1] = (arr[count - 1, 1] * arr[count, 1]) + arr[count, 4];
                }
                 
                count--;
               // Console.WriteLine("X : " + x + " Y : " + y);
              
            }

           
                return str;
        }

        public int getX0()
        {
            return x0;
        }

        public int getX1()
        {
            return x1;
        }

        public int getY0()
        {
            return y0;
        }

        public int getY1()
        {
            return y1;
        }


    }
}
