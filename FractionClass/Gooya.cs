using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionClass
{
    class Gooya
    {
        //متغیرهای خصوصی درنظر گرفته شده اند تا مقداردهی مستقیم خارج از کلاس نشوند 
        private int a;
        private int b;
        //تابع سازنده متغیرهای کلاس را طوری مقدار دهی می کند که کسر مبهم نباشد
        public Gooya()
        {
            a = 0;
            b = 1;
        }
        //تابع سارنده با پارامتر
        public Gooya(int x)
        {
            a = x;
            b = 1;
        }
        //تابع سارنده با پارامتر
        public Gooya(int x, int y)
        {
            a = x;
            if (y == 0)
                b = 1;
            else 
                b = y;
        }
        public void Print()
        {
            Console.WriteLine(a + "/" + b);
        }
        // توابع محاسباتی کسر را تغییر نمی دهند بلکه حاصل را بعنوان خروجی برمیگرداند
        public Gooya Reverse()
        {
            // Go through the constructor so the "denominator must not be 0" guard still
            // applies. Assigning the private fields directly would let b become 0 here
            // whenever the fraction being reversed has a 0 numerator.
            return new Gooya(b, a);
        }
        public Gooya Add(Gooya g)
        {
            Gooya x = new Gooya();
            x.a = a * g.b + b * g.a;
            x.b = b * g.b;
            x.Simple();
            return x;
        }
        public Gooya Sub(Gooya g)
        {
            Gooya x = new Gooya();
            x.a = a * g.b - b * g.a;
            x.b = b * g.b;
            x.Simple();
            return x;
        }
        public Gooya Mul(Gooya g)
        {
            Gooya x = new Gooya();
            x.a = a * g.a;
            x.b = b * g.b;
            x.Simple();
            return x;
        }
        public Gooya div(Gooya g)
        {
            Gooya x = Mul(g.Reverse());
            x.Simple();
            return x;
        }

        public float Result()
        {
            float f = (float)a / b;
            return f;
        }
        //تابع ساده سازی بصورت خصوصی تعریف شده است زیرا فقط توسط توابع کلاس مورد استفاده واقع می شود
        private void Simple()
        {
            // When the numerator is 0 the search below would start at 0 and divide by zero.
            // 0 has only one canonical form, so return 0/1 straight away.
            if (a == 0)
            {
                b = 1;
                return;
            }
            int x = a;
            if (a > b)
                x = b;
            int j;
            for (j = x; j >= 1; j--)
            {
                if (a % j == 0 && b % j == 0)
                    break;
            }
            a = a / j;
            b = b / j;
        }
    }
}
