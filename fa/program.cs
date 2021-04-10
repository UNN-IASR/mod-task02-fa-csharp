using System;

namespace fans
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "01111";

            var fa1 = new FA1();
            var result1 = fa1.Run(s);
            Console.WriteLine(result1);

            var fa2 = new FA2();
            var result2 = fa2.Run(s);
            Console.WriteLine(result2);
        }
    }
}
