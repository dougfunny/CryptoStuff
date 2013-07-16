using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace EuclideanAlgorithm
{
    class Program
    
    {

        static Int64[] var3 = new Int64[20000];
        static Int64[] xArray = new Int64[2000];
        static Int64[] yArray = new Int64[2000];
        static Int64 remainder;
        static Stack mystack = new Stack();
        static Int64 i = 0;
        static Int64 top = 0;
        static Int64[] sVar = new Int64[20];
        static Int64 iVar = 0;
        static Int64[] tVar = new Int64[20]; 
        static Int64 temp = 1;
        static Int64 lastx = 1;
        static Int64 lasty = 1;
        static Int64 x = 1;
        static Int64 y = 1;    
        static Int64   qoutient = 0;
        static Int64   newRemainder = 1;

        static Int64 modFunction(Int64 a, Int64 b)
        {
            if (b > 0)
            {
                Int64 answer = (a - (b * (a / b)));
                return answer;
            }
            else { return a; }
        }

        static Int64 FindSmallerInput(Int64 InputToInt64One, Int64 InputToInt64Two)
        {
            if (InputToInt64One < InputToInt64Two)
                return InputToInt64One;
            else return InputToInt64Two;
        }

        static Int64 FindLargerInput(Int64 InputToInt64One, Int64 InputToInt64Two)
        {
            if (InputToInt64One > InputToInt64Two)
                return InputToInt64One;
            else return InputToInt64Two;
        }

        public static void PrInt64Values(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
          
            Console.WriteLine();
        }

        static Int64 recursive(Int64 x, Int64 y)
        {           
            if (x == 0 || y == 0) { return x ; }
            var3[i] = x / y;
            remainder = x % y; 
            if (remainder > 0)
            {
                xArray[i] = x;
                yArray[i] = y;
                mystack.Push(1 + " * " + x + " " + -var3[i] + " * " + " " + y + " = " + remainder + " " + "\r\n");              
                i++;
                top++;



            }
            
        return recursive( FindSmallerInput( x, y ), modFunction( x, y ) );
        }
     
        static Int64 FindXandY(Int64 a, Int64 b)
        {
            if (x == 0 || y == 0) 
            { return x; }

                x = 0 ;
            lastx = 1;
                y = 1;
            lasty = 0;

    while( b != 0 ){
        temp = b;
        qoutient = Convert.ToInt64 ( a / b );
        b = a % b;
        a = temp;
        
        temp = x;
        x = lastx - qoutient * x;
        lastx = temp;
        
        temp = y;
        y = lasty - qoutient * y;
        lasty = temp;
    }
      
    return (lastx);
                
        }

        static void Main(string[] args)
        {
           

                //variables
                string UserInputOne = "1";
                string UserInputTwo = "1";

                Console.WriteLine("                         Euclidean Algorithm Program                      ");

                //Grab User Input
                Console.WriteLine(" Please Enter First Number: ");
                UserInputOne = Console.ReadLine();

                Console.WriteLine(" Please Enter Second Number: ");
                UserInputTwo = Console.ReadLine();

                Int64 InputToInt64One = Convert.ToInt64(UserInputOne);
                Int64 InputToInt64Two = Convert.ToInt64(UserInputTwo);

                Int64 answer = recursive(FindLargerInput(InputToInt64One, InputToInt64Two), FindSmallerInput(InputToInt64One, InputToInt64Two));

                Console.WriteLine("GCD( " + InputToInt64One + ", " + InputToInt64Two + " )" + " = " + answer);
                Console.WriteLine(".....................................................................");
                Console.WriteLine(".....................................................................");
                Console.WriteLine(".....................................................................");
                PrInt64Values(mystack);


                Int64 prInt64 = FindXandY(InputToInt64One, InputToInt64Two);
                Console.WriteLine(lastx + " * " + InputToInt64One + " + " + InputToInt64Two + " * " + lasty);
                Console.ReadLine();
            
        }

    }

}


 /*   if (top > -1 && top != 0)
            {
                Console.WriteLine(1 + " * " + xArray[top] + " - " + " " + var3[top] + " * " + xArray[top - 1] + " - " + var3[top - 1] + " * " + yArray[top - 1]);
                Console.WriteLine(1 + " * " + xArray[top] + " - " + " " + var3[top] + " * " + xArray[top - 1] + " + " + -var3[top] * -var3[top - 1] + " * " + yArray[top - 1]);
                Console.WriteLine(-var3[top] + " * " + xArray[top - 1] + " + " + (1 + (-var3[top] * -var3[top - 1])) + " * " + yArray[top - 1]);
                if (top - 2 >= 0)
                {
                    Console.WriteLine(-var3[top] + " * " + xArray[top - 1] + " + " + (1 + (-var3[top] * -var3[top - 1])) + " * " + xArray[top - 2] + " - " + var3[top - 2] + " * " + yArray[top - 2]);
                    Console.WriteLine((1 + (-var3[top] * -var3[top - 1])) + " * " + xArray[top - 2] + " - " + ((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + yArray[top - 2]);
                }
                if (top - 3 >= 0)
                {
                    Console.WriteLine((1 + (-var3[top] * -var3[top - 1])) + " * " + xArray[top - 2] + " - " + ((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top])
                        + " * " + xArray[top - 3] + " - " + var3[top - 3] + " * " + yArray[top - 3]);
                    Console.WriteLine((((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + xArray[top - 3] + " + " + (((1
                        + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + (1 + (-var3[top] * -var3[top - 1]))) + " * " + yArray[top - 3]));
                }
                    if (top - 4 >= 0)
                    {
                    Console.WriteLine(((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + xArray[top - 3] + " + " + (((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3]
                        + ((1 + (-var3[top] * -var3[top - 1]))) + " * " + xArray[top - 4] + " - " + var3[top - 4] + " * " + yArray[top - 4]))));

                    Console.WriteLine(((((((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + (1 + (-var3[top] * -var3[top - 1])))
                        + " * " + xArray[top - 4] + " - " + (((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + ((1 + (-var3[top]
                        * -var3[top - 1])))) * ((var3[top - 4] + 0)) + (((1 + -var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + yArray[top - 4])))));
                     }
                    if (top - 5 >= 0)
                    {
                    Console.WriteLine(((((((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + (1 + (-var3[top] * -var3[top - 1])))
                            + " * " + xArray[top - 4] + " - " + (((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + ((1 + (-var3[top] * -var3[top - 1])))) * ((var3[top - 4] + 0))
                            + (((1 + -var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + xArray[top - 5]
                            + " - " + var3[top - 5] + " * " + yArray[top - 5])))));


                    }
                    
                    Console.WriteLine((((((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + ((1 + (-var3[top] * -var3[top - 1])))) * ((var3[top - 4] + 0))
                               + (((1 + -var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) + " * " + xArray[top - 5]
                               + " - " + ((((1 + ((-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3] + ((1 + (-var3[top] * -var3[top - 1])))) * ((var3[top - 4] + 0))
                               + (((1 + -var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * (var3[top - 5]) + ((((1 + (-var3[top] * -var3[top - 1])) * var3[top - 2] + var3[top]) * var3[top - 3]
                               + (1 + (-var3[top] * -var3[top - 1])))) + " * " + xArray[top - 5]
                               + " - " + var3[top - 5] + " * " + yArray[top - 5]))))));
                    
                 

                
            }
          
 
 */



   
 