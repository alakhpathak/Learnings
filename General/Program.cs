using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void GroupBy()
        {
            List<string> names = new List<string>();
            names.Add("Alakh");
            names.Add("Vikas");
            names.Add("Aman");
            names.Add("Vijay");
            names.Add("Akash");

            names.GroupBy(x => x[0]).ToList().ForEach(x =>
            {
                Console.WriteLine(x.Key);
                x.ToList().ForEach(y => Console.WriteLine(y));
            });

            var y = (from z in names
                     group z by z[0] into result
                     select new
                     {
                         Key = result.Key,
                         Names = result,
                     });
        }
    }
}
