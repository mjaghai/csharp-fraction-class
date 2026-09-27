using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Gooya g1 = new Gooya(6, 8);
            Gooya g2 = new Gooya(0, 4);
            Gooya g3= new Gooya();
            g3 = g1.Add(g2);
            g3.Print();
            g3 = g1.Sub(g2);
            g3.Print();
            g3 = g1.Mul(g2);
            g3.Print();
            g3 = g1.div(g2);
            g3.Print();
            Console.ReadLine();
        }
    }
}
