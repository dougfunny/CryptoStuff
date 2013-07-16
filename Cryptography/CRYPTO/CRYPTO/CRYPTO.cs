using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
 
using System.Numerics;
using System.Security.Cryptography;


namespace CRYPTO
{
    public partial class CRYPTO : Form
    {
        public CRYPTO()
        {
            InitializeComponent();
        }

        static BigInteger GCD;
        static bool found;
        static BigInteger[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private static double gcd(double a, Int64 b)
        {
            Int64 t;

            // Ensure B > A
            if (Convert.ToInt64(a) > b)
            {
                t = b;
                Convert.ToDouble(b);
                b = Convert.ToInt32(a);
                a = Convert.ToDouble(t);
            }

            // Find 
            while (b != 0)
            {
                t = Convert.ToInt64(a) % b;
                a = (double)b;
                b = t;
            }

            return a;
        }



        static BigInteger Pollard(BigInteger p)
        {



            Random rand = new Random();
            // Generate and display 5 random byte (integer) values. 
            byte[] bytes = new byte[4];
            rand.NextBytes(bytes);

            BigInteger[] BaseArray = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 
31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73,79,83,89,97,101,103,107,109,113};
            BigInteger[] L = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            BigInteger[] expBaseArray = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            BigInteger[] checkGCD = { };
            L[0] = (BigInteger)(BigInteger.Log(p) / BigInteger.Log(2));
            for (int loop = 0; loop < 29; loop++)
            {
                L[loop] = (BigInteger)(BigInteger.Log(p) / BigInteger.Log(BaseArray[loop]));
                L[loop] = (BigInteger)Math.Floor((double)L[loop]);

                expBaseArray[loop] = BigInteger.ModPow(BaseArray[loop], L[loop], p);


            }
            BigInteger[] exp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            BigInteger[] checkGcd = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            do
            {
                int randomA = rand.Next(2, 1000000000);
                checkGcd[0] = BigInteger.ModPow(randomA, expBaseArray[0], p);


                exp[0] = BigInteger.ModPow(BaseArray[1], L[1], p);

                try
                {
                    GCD = BigInteger.GreatestCommonDivisor((BigInteger)checkGcd[0] - 1, p);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Unable to calculate the greatest common divisor:");
                    Console.WriteLine("   {0} is an invalid value for {1}",
                                      e.ActualValue, e.ParamName);

                }


                //////
                if ((GCD) == 1)
                {
                    result[0] = BigInteger.ModPow(checkGcd[0], BigInteger.ModPow(BaseArray[1], L[1], p), p);

                }

                else
                {

                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)checkGcd[0] - 1, p);
                    Console.WriteLine(factor);
                    found = true;

                }

                //////

                //////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[0] - 1, p) == 1)
                {
                    exp[1] = BigInteger.ModPow(BaseArray[2], L[2], p);


                    result[1] = BigInteger.ModPow(result[0], (BigInteger)exp[1], p);

                }
                else
                {

                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[0] - 1, p);

                    Console.WriteLine(factor);
                    found = true;
                }
                //////

                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[1] - 1, p) == 1)
                {
                    exp[2] = BigInteger.ModPow(BaseArray[3], L[3], p);


                    result[2] = BigInteger.ModPow(result[1], (BigInteger)exp[2], p);

                }

                else
                {


                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[1] - 1, p);
                    Console.WriteLine(factor);
                    found = true;
                }
                //////



                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[2] - 1, p) == 1)
                {
                    exp[3] = BigInteger.ModPow(BaseArray[4], L[4], p);


                    result[3] = BigInteger.ModPow(result[2], (BigInteger)exp[3], p);

                }

                else
                {


                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[2] - 1, p);
                    Console.WriteLine(factor);
                    found = true;
                }
                //////


                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[3] - 1, p) == 1)
                {
                    exp[4] = BigInteger.ModPow(BaseArray[5], L[5], p);


                    result[4] = BigInteger.ModPow(result[3], (BigInteger)exp[4], p);

                }

                else
                {


                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[3] - 1, p);
                    Console.WriteLine(factor);
                    found = true;
                }
                //////


                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[4] - 1, p) == 1)
                {
                    exp[5] = BigInteger.ModPow(BaseArray[6], L[6], p);
                    result[5] = BigInteger.ModPow(result[4], (BigInteger)exp[5], p);

                }

                else
                {


                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[4] - 1, p);
                    Console.WriteLine(factor);

                }
                //////

                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[5] - 1, p) == 1)
                {
                    exp[6] = BigInteger.ModPow(BaseArray[7], L[7], p);


                    result[6] = BigInteger.ModPow(result[5], (BigInteger)exp[6], p);

                }

                else
                {

                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[5] - 1, p);
                    Console.WriteLine(factor);
                    found = true;
                }
                //////
                /////
                if (BigInteger.GreatestCommonDivisor((BigInteger)result[6] - 1, p) == 1)
                {
                    exp[7] = BigInteger.ModPow(BaseArray[8], L[8], p);
                    result[6] = BigInteger.ModPow(result[6], (BigInteger)exp[7], p);

                }

                else
                {


                    BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[6] - 1, p);
                    Console.WriteLine(factor);
                    found = true;
                }


                for (int x = 1; x < 16; x++)
                {

                    if (BigInteger.GreatestCommonDivisor((BigInteger)result[6 + x] - 1, p) == 1)
                    {
                        exp[7 + x] = BigInteger.ModPow(BaseArray[8 + x], L[8 + x], p);


                        result[6 + x] = BigInteger.ModPow(result[6 + x], (BigInteger)exp[7 + x], p);

                    }

                    else
                    {


                        BigInteger factor = BigInteger.GreatestCommonDivisor((BigInteger)result[6 + 1] - 1, p);
                        Console.WriteLine(factor);
                        found = true;
                    }
                }

            }
            while (found == false);
            return 1;
        }
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
      
        static String strResult;
        static String RanPrimestring;
        static Boolean located = false; 
        static long Found;       
        static long l = 1;
        static long u = 1;
        static long temp = 1;
        static long lastx = 1;
        static long lasty = 1;
        static long qoutient = 0;       
        static long position = -1;
        static long t = 0;

        static long FindXandY(long a, long b)
        {

            if (l == 0 || u == 0)
            {

                if (l < 0)
                { l = (l * -1) + 1; }

                return -l * -1;
            }

            l = 0;
            u = 1;
            lasty = 1;
            lastx = 1;


            while (b != 0)
            {
                temp = b;
                qoutient = a / b;
                b = a % b;
                a = temp;
                
                temp = l;
                l = lastx - qoutient * l;
                lastx = temp;

                temp = u;
                u = lasty - qoutient * u;
                lasty = temp;
            }
          
                return (lastx);
         
        }

        static BigInteger xp = 0;
        static BigInteger ep = 0;
        static BigInteger y = 1;
        private bool randomPrime;


        static BigInteger FastExponentiation(BigInteger a, BigInteger b, BigInteger c)
        {
            y = 1;
            xp = 0;
            ep = 0;
            xp = a;
            ep = b;

            while (ep != 0)
            {
                if (ep % 2 == 0)
                {
                    ep = ep / 2;
                   xp = ((xp * xp) % c);

                }
                else if (ep % 2 != 0)
                {
                    ep = ep - 1;
                    y = (xp * y )% c;
                }

            }

            return y;
        }

        static long BinarySearch(BigInteger[] exp, long size, BigInteger ans)
        {
        

            long first = 0,
            last = size - 1;
            long middle = -1;
            bool found = false;

            while (!found && first <= last)
            {
                middle = (first + last) / 2;
                if (exp[middle] == ans)
                {
                    found = true;
                    
                   position = middle;
                   located = true;
                }
                else if (exp[middle] > ans)
                    last = middle - 1;
                else
                    first = middle + 1;
            }

            return position;
        }
             
        public static long BabyStepGiantStepCalc(long userA, long userB, long userC)
        {
     
            long a = userA;
            long b = userB;
            long modNum = userC;
            long m = Convert.ToInt64(Math.Sqrt(modNum-1));

            BigInteger[] exponent     = new BigInteger[m];
            long[] yArray       = new long[m];
            long[] yArrayCopy   = new long[m];
            BigInteger[] exponentCopy = new BigInteger[m];


            for (int xl = 0; xl < m; xl++)
            {

               //exponent[x]     =  Convert.ToInt64(((Math.Pow(b, x))) % modNum);
                 
                exponent[xl]     =  FastExponentiation(b, xl, modNum);


            }
           
            
            for (long x = 0; x < m; x++)
            {

                yArray[x] = x;
                yArrayCopy[x] = x;
                exponentCopy[x] = exponent[x];
            }
            
          long inverseOfbase =   FindXandY(userB, modNum);
          if (inverseOfbase < 0)
          {
              inverseOfbase = inverseOfbase + modNum;
        }
          BigInteger fastExp       =   FastExponentiation(inverseOfbase, m, modNum);
          long inverse       =   inverseOfbase;
            
             // Console.WriteLine(inverse + " " + fastExp );
             // Console.ReadLine();
              long   iValue = 0;
              BigInteger[] answer = new BigInteger[m];
              answer[1]     = userA * BigInteger.Pow(fastExp,1) % modNum;
              
            
            
             Array.Sort(exponent,yArray);

            
            Found = BinarySearch(exponent,1, answer[1]);

            
                  for (long i = 2; i < m; ++i)
                  {
                      answer[i] = (answer[i - 1] * fastExp ) % modNum;

                      if (!located)
                      {
                          Found = BinarySearch(exponent, m, answer[i]);

                          iValue = i;
                      }

                      
                      
                  }
              
                 
              Array.Sort(exponentCopy, yArrayCopy);

              if (located)
              {

                  return (iValue * m + yArrayCopy[Found]);
              }
              else
              {
                  return (1);
              }
           }
      
    
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BABYstep_Click(object sender, EventArgs e)
        {
            if (Dlog.Text != "" && baseDlog.Text != "" && modDlog.Text != "")
            {
                long answer = 0;

                answer = BabyStepGiantStepCalc(Convert.ToInt64(Dlog.Text), Convert.ToInt64(baseDlog.Text), Convert.ToInt64(modDlog.Text));

                String DlogAns = Convert.ToString(answer);
                DlogAnswer.Text = DlogAns;
            }
        }
        private void Dlog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (FastBase.Text != "" && FastPower.Text != "" && FastMod.Text != "")
            {

                BigInteger answer = 0;

                answer = FastExponentiation(BigInteger.Parse(FastBase.Text), BigInteger.Parse(FastPower.Text), BigInteger.Parse(FastMod.Text));

                String FastBaseAns = Convert.ToString(answer);
                FastBaseAnswer.Text = FastBaseAns;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (InverseX.Text != "" && InverseY.Text != "")
            {

                long InverseAnswerLong = FindXandY(Convert.ToInt64(InverseX.Text), Convert.ToInt64(InverseY.Text));
                String InverseXString = Convert.ToString(InverseAnswerLong);
                InverseAnswer.Text = InverseXString;



            }
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

                BigInteger[] block = new BigInteger[x];

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

                BigInteger[] block = new BigInteger[x];

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


  





        private void button3_Click(object sender, EventArgs e)
        {
            
            pBar1.Minimum = 1;
            pBar1.Maximum = 6;
            pBar1.Value = 1;
            pBar1.Step = 2;
            pBar1.PerformStep();
           // pBar1.MarqueeAnimationSpeed = 10;
            do
            {// Blum Blum will return random number by first generating random bits and converting to an Integer...
                //the number is then test with MillerRobinTest2...because MillerRobinTest isnt working after it used
                //test the initial P and Q for Blum Blum Shub..not sure why maybe to do with variable reintialization
                RanPrimeBits01 = BlumBlumShub();
                pBar1.PerformStep();
                randomPrime = MillerRabinTest2(RanPrimeBits01, Convert.ToInt64(Math.Sqrt(RanPrimeBits01 / 1000)));
                if (randomPrime)///YAY we found a Blum Blum random Prime#
                {
                    pBar1.PerformStep();
                    blumblum.Text = Convert.ToString(RanPrimeBits01);
                    pBar1.MarqueeAnimationSpeed = 0;
                }
                else { pBar1.PerformStep()
                    ; }
            }
            while (!randomPrime);


 

    }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //needs to be g^x mod G

            if (xBox.Text != "")
            {

                BigInteger Findh = FastExponentiation(BigInteger.Parse(gBox.Text), BigInteger.Parse(xBox.Text), BigInteger.Parse(Group.Text));

                String FindhStrg = Convert.ToString(Findh);
                hBox.Text = FindhStrg;
                xLabel.Text = hBox.Text;


            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Instantiate random number generator using system-supplied value as seed.
            Random rand = new Random();
            // Generate and display 5 random byte (integer) values. 
            byte[] bytes = new byte[4];
            rand.NextBytes(bytes);
            

           String RandomY = Convert.ToString( rand.Next(15898056, 326456758));
           yBox.Text = RandomY;


           if (yBox.Text != null && hBox.Text != null)
           {

               if (mBox.Text != "")
               {
                   BigInteger FindS = FastExponentiation(BigInteger.Parse(hBox.Text), BigInteger.Parse(yBox.Text), BigInteger.Parse(Group.Text));

                   String FindSStrg = Convert.ToString(FindS);

                   Sbox.Text = FindSStrg;

                   BigInteger FindC1 = FastExponentiation(BigInteger.Parse(gBox.Text), BigInteger.Parse(yBox.Text), BigInteger.Parse(Group.Text));

                   String FindC1Strg = Convert.ToString(FindC1);

                   C1.Text = FindC1Strg;

                   BigInteger message = BigInteger.Parse(mBox.Text);

                   BigInteger C2value = BigInteger.Multiply(FindS, message) % BigInteger.Parse(Group.Text);

                   string c2String = Convert.ToString(C2value);
                   C2.Text = c2String;
               }

           }
         



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c1Box.Text != "" && encrypted.Text != "")
            {
                BigInteger FindShared = FastExponentiation(BigInteger.Parse(c1Box.Text), BigInteger.Parse(xBox.Text), BigInteger.Parse(Group.Text));

                String FindSharedStrg = Convert.ToString(FindShared);

                sharedBox.Text = FindSharedStrg;
            }

            



        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            //mPrime.text = Mult1 * Mult2;

            if (mult1.Text != "" && mult2.Text != "")
            {
                BigInteger multOne;
                BigInteger multTwo;



                multOne = BigInteger.Parse(mult1.Text);
                multTwo = BigInteger.Parse(mult2.Text);

                BigInteger mPrimeResult = BigInteger.Multiply(multOne, multTwo) % BigInteger.Parse(Group.Text);
                String myPrimeResultstring = Convert.ToString(mPrimeResult);

                mPrime.Text = myPrimeResultstring;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (rsaPrime.Text != "")
            {
                BigInteger rsaPrimeNum = BigInteger.Parse(rsaPrime.Text);

                BigInteger factorResult = Pollard(rsaPrimeNum);



                String rsaFactorString = Convert.ToString(factorResult);

                factorOne.Text = rsaFactorString;



                            }


        }

        }

    
    }

