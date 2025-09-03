using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public class Program
    {


   
        public static void P357()
        {
            int sum = 0;
            Console.WriteLine(sum);
            for (int md = 0; md < MAX; md++)
            {
                for (int mt = 0; mt < MAX; mt++)
                {
                    prod = mt * md;
                    sum = concat(concat(mt, md), prod);
                    if (IsPandigital(sum))
                    {
                        myHashSet.Add(sum);
                        product *= (ulong)prod;
                    }
                }
            }
        }
        public static void Main()
        {
            P357();
        
        }
    }

}				
