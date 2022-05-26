using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optim_nthRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* root_n(b) = x where x^n = b 
             * <==> x^n -b = 0 ==> f(x) = x^n -b
             * the result of root_n(b) is the solution to the equation f(x) = x^n -b = 0
             * We can use Newton's method iterratively to find the best approximation 
             * the derivative of f(x) -> f'(x) = n*x^(n-1)
             * we need to guess an x1 and x2 for which f(x1)<0<f(x2)
             * this means that the root_n(b) is somwhere between x1 and x2
             */

        }
    }
}
