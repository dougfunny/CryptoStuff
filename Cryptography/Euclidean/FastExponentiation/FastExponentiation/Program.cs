using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Security.Cryptography;


namespace FastExponentiation
{
    class Program
    {

         
            static BigInteger x = 0;
            static BigInteger e = 0;
            static BigInteger y = 1;
 


            static BigInteger FastExponentiation(BigInteger a, BigInteger b , BigInteger c)
            {

                x = a;
                e = b;
            
                while (e != 0)
                {
                    if (e % 2 == 0)
                    {
                        e = e / 2;
                        x = ((x * x) % c);

                    }
                    else if (e % 2 != 0)
                    {
                        e = e - 1;
                        y = x * y % c;
                    }

                }

                return y;
            }

        static void Main(string[] args)
        {
            //variables
            string UserInputBase  = "1";
            string UserInputMod   = "1";
            string UserInputPower = "1";

            Console.WriteLine("                         Fast Exponentation Program                      ");

            //Grab User Input
            Console.WriteLine(" Please Enter the Base: ");
            UserInputBase = Console.ReadLine();

            Console.WriteLine(" Please Enter the Power ");
            UserInputPower = Console.ReadLine();

            Console.WriteLine(" Please Enter the Modulo ");
            UserInputMod = Console.ReadLine();

            Int64 InputToInt64Base = Convert.ToInt64(UserInputBase);
            Int64 InputToInt64Power = Convert.ToInt64(UserInputPower);
            Int64 InputToInt64Mod = Convert.ToInt64(UserInputMod);

            Console.WriteLine(InputToInt64Base + "^" + InputToInt64Power + "%" + InputToInt64Mod);
            Console.ReadLine();
            BigInteger solution =  FastExponentiation(InputToInt64Base, InputToInt64Power, InputToInt64Mod);
            Console.WriteLine(solution);
            Console.ReadLine();

        }

    }

}




