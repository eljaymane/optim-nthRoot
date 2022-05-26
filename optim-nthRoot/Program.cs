using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace optim_nthRoot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            /* root_n(b) = x where x^n = b 
             * <==> x^n -b = 0 ==> f(x) = x^n -b
             * the result of root_n(b) is the solution to the equation f(x) = x^n -b = 0
             * We can use Newton's method iterratively to find the best approximation 
             * the derivative of f(x) -> f'(x) = n*x^(n-1)
             * we need to guess an x1 and x2 for which f(x1)<0<f(x2)
             * this means that the root_n(b) is somwhere between x1 and x2
             * next more approximative result using newton's method would be : x4 = x3 - F(x3)/dF(x3) and so on...
             */
            string response;
            do
            {
                Console.Write("Number for which to calculate nth root ? ");
                double number = Double.Parse(Console.ReadLine().Replace('.',','));
                Console.Write("Value of n ? ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Calculating...");
                Console.WriteLine("The {0}Th root of {1} is : {2}", n, number, await GetNthRoot(number, n));
                Console.WriteLine("Type any key to try again or q to quit !");
                response = Console.ReadLine();
            } while (response != "q");

        }

        public static async Task<double> GetNthRoot(double number, int n)
        {
            //Newton method
            double initial = await findInitilZeroApprox(n, number);
            double result = initial - F(initial, n, number) / dF(initial, n);
            while (F(result,n,number) >= 0.00000000001)
            {
                result = result - F(result, n, number) / dF(result, n);
            }
            return result;

        }

        public static double F(double x, int n,double number)
        {
            double result=1.0;
            for (int i = 1; i <= n; i++)
            {
                result*=x;
            }

            return result - number;
        }

        public static double dF(double x, int n)
        {
            double result = 1.0;
            for (int i = 1; i < n; i++)
            {
                result *= x;
            }

            return n * result;
        }

        public static async Task<double> findInitilZeroApprox(int n, double number)
        {
            double initial = 0.0;
            double result;
            while (true)
            {
                initial += 0.0001;
                result = F(initial, n,number);
                if (result < 1 && result > 0) break;
            } 

            return result;
        }
    }
}
