using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
 


namespace CRYPTO
{
    public partial class CRYPTO : Form
    {
        public CRYPTO()
        {
            InitializeComponent();
        }
   
    
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

        static long xp = 0;
        static long ep = 0;
        static long y = 1;


        static long FastExponentiation(long a, long b, long c)
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

        static long BinarySearch(long[] exp, long size, long ans)
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

            long[] exponent     = new long[m];
            long[] yArray       = new long[m];
            long[] yArrayCopy   = new long[m];
            long[] exponentCopy = new long[m];


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
          long fastExp       =   FastExponentiation(inverseOfbase, m, modNum);
          long inverse       =   inverseOfbase;
            
             // Console.WriteLine(inverse + " " + fastExp );
             // Console.ReadLine();
              long   iValue = 0;
              long[] answer = new long[m];
              answer[1]     = userA * Convert.ToInt64(Math.Pow(fastExp,1)) % modNum;
              
            
            
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


         return (iValue * m + yArrayCopy[Found]);
                  
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
           
        long answer = 0;

      answer = BabyStepGiantStepCalc(Convert.ToInt64( Dlog.Text  ), Convert.ToInt64( baseDlog.Text ), Convert.ToInt64( modDlog.Text ));

      String DlogAns = Convert.ToString(answer);
      DlogAnswer.Text = DlogAns;
        }

        private void Dlog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {


            long answer = 0;

            answer = FastExponentiation(Convert.ToInt64(FastBase.Text), Convert.ToInt64(FastPower.Text), Convert.ToInt64(FastMod.Text));

            String FastBaseAns   = Convert.ToString(answer);
            FastBaseAnswer.Text  = FastBaseAns;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

           long InverseAnswerLong   =  FindXandY(Convert.ToInt64(InverseX.Text), Convert.ToInt64(InverseY.Text));
           String InverseXString    = Convert.ToString(InverseAnswerLong);
           InverseAnswer.Text       = InverseXString;




        }

    
    }
}
