using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace EuclideanAlgorithm
{
    class Program
    {



        static void Main(string[] args)
        {

           

            Console.WriteLine("                         Is 3 a Generator in Zx131                     ");

                    
            for (int x = 0; x < 71; x++)
            {

               double power = Math.Pow(x, 2);


               // Console.WriteLine( Convert.ToInt32(power % 71) +" = " + x + " ^" + 2 + " mod 71 = " );
               Console.WriteLine(x + " ^" + 2 + " mod 71 = " + Convert.ToInt32(power % 71));
               Console.WriteLine(Convert.ToInt32(power % 71));



            }
            Console.ReadLine();

      

            

        }

    }

}


