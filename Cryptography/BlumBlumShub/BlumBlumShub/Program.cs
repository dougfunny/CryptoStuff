using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Security.Cryptography;

namespace BlumBlumShub
{

    // Blum Blum will return random number by first generating random bits and converting to an Integer...
    //the number is then tested with MillerRobinTest2...because MillerRobinTest isnt working after it used
    //test the initial P and Q for Blum Blum Shub..not sure why maybe to do with variable reintialization


    class Program
    {
        static Random _r = new Random();
        static long newPrime;
        static double power;
        static double factor = newPrime;
        static bool couldBePrime;
        static Int64 RanPrimeBits01;
        static int loop;
        static int primeCount2 = 0; static int primeCount = 0;
        static Int64 x = 0;
        static Int64 e = 0;
        static Int64 y = 1;
        static String strResult;
        static String RanPrimestring;

        static Int64 FastExponentiation(Int64 a, Int64 b, Int64 c)
        {
            y = 1;
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


        //Test P and Q for intial "Random Prime for Blum Blum"

        public static bool MillerRabinTest(Int64 n, Int64 k)
        {
            k--;

            if (k != 0 && (n % 2 != 0))
            {
                Int64 num = _r.Next() % n;
                Int64 prime = n;
                Int64 x = 1;
                newPrime = prime - 1;

                while ((newPrime / 2) % 2 == 0)
                {
                    ++x;
                    newPrime = newPrime / 2;
                }

                long[] block = new long[x];

                factor = (Math.Pow(2, x));
                double factorbase = (prime - 1) / factor;

                for (loop = 0; loop < x; loop++)
                {

                    power = Math.Pow(2, loop) * factorbase;
                    block[loop] = FastExponentiation(num, Convert.ToInt64(power), prime);
                }

                int c = 0;

                do
                {
                    try
                    {
                        if (primeCount > 250)
                        {

                            //Console.WriteLine(prime + "Prime" + primeCount + " " + n);
                            return true;


                        }
                    }
                    catch (StackOverflowException f)
                    {

                        throw f;
                        //Console.WriteLine(prime + " Prime " + primeCount);
                    }
                    c++;
                    try
                    {
                        if ((block[c - 1] == prime - 1))
                        {

                            couldBePrime = true;
                            primeCount++;
                            // Console.WriteLine("Witness to Primality");
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        //throw (e);
                        //Console.WriteLine("Error..." + prime + " " + primeCount);

                    }




                    if (c == block.Length && couldBePrime)
                    {

                        MillerRabinTest(n, k);


                    }
                    else if (c == block.Length && !couldBePrime)
                    {

                        //Console.WriteLine("NOT PRIME!");
                        return false;

                    }
                    else
                    {
                        if (couldBePrime && k == 0) { return true; }
                        else if (!couldBePrime && k == 0) { return false; }

                    }


                } while (c < block.Length || primeCount > 250);

            }
            if (n % 2 == 0)
            {
                return false;

            }


            return false;

        }

       //Test Random Blum Blum numbers only

        public static bool MillerRabinTest2(Int64 n, Int64 k)
        {
            k--;

            if (k != 0 && (n % 2 != 0))
            {
                Int64 num = _r.Next() % n;
                Int64 prime = n;
                Int64 x = 1;
                newPrime = prime - 1;

                while ((newPrime / 2) % 2 == 0)
                {
                    ++x;
                    newPrime = newPrime / 2;
                }

                long[] block = new long[x];

                factor = (Math.Pow(2, x));
                double factorbase = (prime - 1) / factor;

                for (loop = 0; loop < x; loop++)
                {

                    power = Math.Pow(2, loop) * factorbase;
                    block[loop] = FastExponentiation(num, Convert.ToInt64(power), prime);
                }

                int c = 0;

                do
                {
                    try
                    {
                        if (primeCount2 > 250)
                        {

                            // Console.WriteLine(prime + "Prime" + primeCount + " " + n);
                            return true;


                        }
                    }
                    catch (StackOverflowException f)
                    {

                        throw f;
                        //Console.WriteLine(prime + " Prime " + primeCount);
                    }
                    c++;
                    try
                    {
                        if ((block[c - 1] == prime - 1))
                        {

                            couldBePrime = true;
                            primeCount2++;
                            //Console.WriteLine("Witness to Primality");
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {

                        //throw (e);
                        Console.WriteLine("Error..." + prime + " " + primeCount2);
                        Console.ReadLine();



                    }

                    if (c == block.Length && couldBePrime)
                    {

                        MillerRabinTest2(n, k);


                    }
                    else if (c == block.Length && !couldBePrime)
                    {

                        //Console.WriteLine("NOT PRIME!");
                        return false;

                    }
                    else
                    {
                        if (couldBePrime && k == 0) { return true; }
                        else if (!couldBePrime && k == 0) { return false; }

                    }


                } while (c < block.Length || primeCount2 > 250);

            }
            if (n % 2 == 0)
            {
                return false;

            }


            return false;

        }

       //Generate random Bits ex" 0101010101010101000010101..." then return decimal value

        static Int64 BlumBlumShub()
        {
            // randomly select two large prime num (p & q) such that p = 3 mod 4 and q = 3 mod 4
            //generate random numbers
            Random rndNumbers = new Random();
            int rndNumberP = 4705;

            bool PrimeTrueP;
            do
            {
                rndNumberP = rndNumbers.Next();
                //test random number will Miller Rabin until return prime mod 4 = 3
                PrimeTrueP = MillerRabinTest(rndNumberP, Convert.ToInt32(Math.Sqrt(rndNumberP / 100)));

            } while (!PrimeTrueP && rndNumberP % 4 <= 3);//loops until this is true


            //generate random numbers
            Random rndNumbersQ = new Random();
            int rndNumberQ = 5451505;

            bool PrimeTrueQ;
            do
            {
                rndNumberQ = rndNumbers.Next();
                //test random number will Miller Rabin until return prime mod 4 = 3
                PrimeTrueQ = MillerRabinTest(rndNumberQ, Convert.ToInt32(Math.Sqrt(rndNumberQ / 100)));

            } while (!PrimeTrueQ && rndNumberQ % 4 <= 3);//loops until this is true

            long p = rndNumberP; // prime p
            long q = rndNumberQ; // prime q

            ulong unsignedValue = UInt64.MaxValue;
            BigInteger number = new BigInteger(unsignedValue);

            number = p * q;
            //Console.WriteLine(number);


            //generate random number in p * q = number

            ///////////////////////////////////////////////////////////
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[8];
            rng.GetBytes(bytes);
            BigInteger prime = new BigInteger(bytes);

            //randomly pick a number between 1 and p* q and make sure its not negative 
            // if its is add number to it.

            BigInteger randomNumberInZx = prime % number;
            if (randomNumberInZx < 0) { randomNumberInZx += number; }

            ///////////////////////////////////////////////////////////
            //Console.WriteLine(  randomNumberInZx  );



            // compute n = p * q
            // choose any number in Z(n) = S0


            //ughhh define 31 BigInts 

            ///

            ///this could def be improved,.,but its last minute result is the same,,,code is not efficient for professional use

            ///
            // compute S1     = S0^2 % N
            //          S2     = S1^2 % N
            //           S3     = S2^2 % N
            //....

            BigInteger s0 = randomNumberInZx;

            BigInteger s1 = BigInteger.Pow(s0, 2) % number; ;
            BigInteger s2 = BigInteger.Pow(s1, 2) % number; ;
            BigInteger s3 = BigInteger.Pow(s2, 2) % number; ;
            BigInteger s4 = BigInteger.Pow(s3, 2) % number; ;
            BigInteger s5 = BigInteger.Pow(s4, 2) % number; ;
            BigInteger s6 = BigInteger.Pow(s5, 2) % number; ;
            BigInteger s7 = BigInteger.Pow(s6, 2) % number; ;
            BigInteger s8 = BigInteger.Pow(s7, 2) % number; ;
            BigInteger s9 = BigInteger.Pow(s8, 2) % number; ;
            BigInteger s10 = BigInteger.Pow(s9, 2) % number; ;
            BigInteger s11 = BigInteger.Pow(s10, 2) % number; ;
            BigInteger s12 = BigInteger.Pow(s11, 2) % number; ;
            BigInteger s13 = BigInteger.Pow(s12, 2) % number; ;
            BigInteger s14 = BigInteger.Pow(s13, 2) % number; ;
            BigInteger s15 = BigInteger.Pow(s14, 2) % number; ;
            BigInteger s16 = BigInteger.Pow(s15, 2) % number; ;
            BigInteger s17 = BigInteger.Pow(s16, 2) % number; ;
            BigInteger s18 = BigInteger.Pow(s17, 2) % number; ;
            BigInteger s19 = BigInteger.Pow(s18, 2) % number; ;
            BigInteger s20 = BigInteger.Pow(s19, 2) % number; ;
            BigInteger s21 = BigInteger.Pow(s20, 2) % number; ;
            BigInteger s22 = BigInteger.Pow(s21, 2) % number; ;
            BigInteger s23 = BigInteger.Pow(s22, 2) % number; ;
            BigInteger s24 = BigInteger.Pow(s23, 2) % number;
            BigInteger s25 = BigInteger.Pow(s24, 2) % number; ;
            BigInteger s26 = BigInteger.Pow(s25, 2) % number; ;
            BigInteger s27 = BigInteger.Pow(s26, 2) % number; ;
            BigInteger s28 = BigInteger.Pow(s27, 2) % number; ;
            BigInteger s29 = BigInteger.Pow(s28, 2) % number; ;
            BigInteger s30 = BigInteger.Pow(s29, 2) % number; ;
            BigInteger s31 = BigInteger.Pow(s30, 2) % number; ;


            // find random 31bits //B0 = S0 % 2   B1 = S1 % 2   B2 = S2 % 2 ETC....
            BigInteger b0 = s0 % 2; BigInteger b6 = s6 % 2; BigInteger b12 = s12 % 2; BigInteger b18 = s18 % 2; BigInteger b24 = s24 % 2; BigInteger b29 = s29 % 2;
            BigInteger b1 = s1 % 2; BigInteger b7 = s7 % 2; BigInteger b13 = s13 % 2; BigInteger b19 = s19 % 2; BigInteger b25 = s25 % 2; BigInteger b30 = s30 % 2;
            BigInteger b2 = s2 % 2; BigInteger b8 = s8 % 2; BigInteger b14 = s14 % 2; BigInteger b20 = s20 % 2; BigInteger b26 = s26 % 2; BigInteger b31 = s31 % 2;
            BigInteger b3 = s3 % 2; BigInteger b9 = 9 % 2; BigInteger b15 = s15 % 2; BigInteger b21 = s21 % 2; BigInteger b27 = s27 % 2;
            BigInteger b4 = s4 % 2; BigInteger b10 = s10 % 2; BigInteger b16 = s16 % 2; BigInteger b22 = s22 % 2; BigInteger b28 = s28 % 2;
            BigInteger b5 = s5 % 2; BigInteger b11 = s11 % 2; BigInteger b17 = s17 % 2; BigInteger b23 = s23 % 2;

            StringBuilder sb = new StringBuilder();
            sb.Append(b0);
            sb.Append(b1);
            sb.Append(b2);
            sb.Append(b3);
            sb.Append(b4);
            sb.Append(b5);
            sb.Append(b6);
            sb.Append(b7);
            sb.Append(b8);
            sb.Append(b9);
            sb.Append(b10);
            sb.Append(b11);
            sb.Append(b12);
            sb.Append(b13);
            sb.Append(b14);
            sb.Append(b15);
            sb.Append(b16);
            sb.Append(b17);
            sb.Append(b18);
            sb.Append(b19);
            sb.Append(b20);
            sb.Append(b21);
            sb.Append(b22);
            sb.Append(b23);
            sb.Append(b24);
            sb.Append(b25);
            sb.Append(b26);
            sb.Append(b27);
            sb.Append(b28);
            sb.Append(b29);
            sb.Append(b30);
            sb.Append(b31);


///gladd that is over lol...
///

            strResult = sb.ToString();


            BigInteger RandomPrime = 0;
            // RandomPrimeBits.ToString();
            //Console.WriteLine(strResult.ToCharArray());

            //48 = 0 49 =1
            if (Convert.ToInt16(strResult[0]) == 49) { RandomPrime += 1; }
            for (int index = 1; index < 32; index++)
            {
                if (Convert.ToInt16(strResult[index]) == 48) { RandomPrime += 0; } else { RandomPrime += BigInteger.Pow(2, index); }
            }

            // Console.WriteLine(RandomPrime);
            RanPrimestring = (RandomPrime.ToString());
            long RanPrim = Convert.ToInt64(RanPrimestring);



            return RanPrim;
        }

        static void Main(string[] args)
        {
            bool randomPrime = false;


            do
            {// Blum Blum will return random number by first generating random bits and converting to an Integer...
             //the number is then test with MillerRobinTest2...because MillerRobinTest isnt working after it used
             //test the initial P and Q for Blum Blum Shub..not sure why maybe to do with variable reintialization
                RanPrimeBits01 = BlumBlumShub();

                randomPrime = MillerRabinTest2(RanPrimeBits01, Convert.ToInt64(Math.Sqrt(RanPrimeBits01 / 1000)));
                if (randomPrime)///YAY we found a Blum Blum random Prime#
                {
                    Console.WriteLine(RanPrimeBits01);
                    Console.ReadLine();
               

                }
            }
            while (!randomPrime);

          
        }

    }
}





