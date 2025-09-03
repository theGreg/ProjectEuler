using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public static class Utils
    {
        public static double CalculateRectangleArea(double length, double width)
        {
            return length * width;
        }

        private static readonly int[] fact = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

        public static int Factorial(int n)
        {
            return Enumerable.Range(1, n).Aggregate(1, (x, y) => x * y);
        }

        public static bool IsPerm(int a, int b)
        {
            return string.Concat(a.ToString().OrderBy(c => c)) == string.Concat(b.ToString().OrderBy(c => c));
        }

        public static bool IsPalindromic(int n)
        {
            string s = n.ToString();
            return s == new string(s.Reverse().ToArray());
        }

        public static bool IsPandigital(int n, int s = 9)
        {
            string str = n.ToString();
            return str.Length == s && !string.Concat(Enumerable.Range(1, s).Select(i => (char)(i + '0'))).Any(c => !str.Contains(c));
        }
            public static int D(int n)
        {
            int s = 1;
            double t = Math.Sqrt(n);
            for (int i = 2; i <= (int)t; i++)
            {
                if (n % i == 0)
                    s += i + n / i;
            }
            if (t == (int)t)
                s -= (int)t;
            return s;
        }

                public static int SofDigits(int n)
        {
            int s = 0;
            while (n > 0)
            {
                s += fact[n % 10];
                n /= 10;
            }
            return s;
        }

        public static BigInteger Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Negative arguments not implemented");
            return FibonacciHelper(n).Item1;
        }

        private static Tuple<BigInteger, BigInteger> FibonacciHelper(int n)
        {
            if (n == 0)
                return new Tuple<BigInteger, BigInteger>(0, 1);
            BigInteger a = 0;
            BigInteger b = 0;
            var nnn = new Tuple<BigInteger, BigInteger>(a,b);
            nnn = FibonacciHelper(n / 2);
            BigInteger c = a * (2 * b - a);
            BigInteger d = b * b + a * a;
            return n % 2 == 0 ? new Tuple<BigInteger, BigInteger>(c, d) : new Tuple<BigInteger, BigInteger>(d, c + d);
        }

        public static int SosDigits(int n)
        {
            int s = 0;
            while (n > 0)
            {
                s += (int)Math.Pow(n % 10, 2);
                n /= 10;
            }
            return s;
        }

        public static int PowDigits(int n, int e)
        {
            int s = 0;
            while (n > 0)
            {
                s += (int)Math.Pow(n % 10, e);
                n /= 10;
            }
            return s;
        }

        public static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;
            if (n < 2 || n % 2 == 0)
                return false;
            if (n < 9)
                return true;
            if (n % 3 == 0)
                return false;
            int r = (int)Math.Sqrt(n);
            int f = 5;
            while (f <= r)
            {
                if (n % f == 0)
                    return false;
                if (n % (f + 2) == 0)
                    return false;
                f += 6;
            }
            return true;
        }

        public static bool MillerRabin(int n)
        {
            int d = n - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d >>= 1;
                s += 1;
            }
            for (int repeat = 0; repeat < 20; repeat++)
            {
                int a;
                do
                {
                    a = new Random().Next(n);
                } while (a == 0);
                if (!MillerRabinPass(a, s, d, n))
                    return false;
            }
            return true;
        }

        private static bool MillerRabinPass(int a, int s, int d, int n)
        {
            BigInteger aToPower = BigInteger.ModPow(a, d, n);
            if (aToPower == 1)
                return true;
            for (int i = 0; i < s - 1; i++)
            {
                if (aToPower == n - 1)
                    return true;
                aToPower = aToPower * aToPower % n;
            }
            return aToPower == n - 1;
        }
        
     // public static List<int> PalList(int k)
    // {
    //    if (k == 1)
        //        return Enumerable.Range(1, 9).ToList();

    //        List<int> result = new List<int>();
    //        for (int x = 1; x < 10; x++)
    //        {
    //            IEnumerable<int> ys = Enumerable.Range(0, k / 2 - 1).SelectMany(_ => Enumerable.Range(0, 10));
    //            IEnumerable<int> zs = k % 2 != 0 ? Enumerable.Range(0, 10) : Enumerable.Empty<int>();
    //            foreach (var ysCombination in ys)
    //            {
    //                foreach (int z in zs)
    //                {
    //                    int[] digits = new int[k];
    //                    digits[0] = x;
                        
    //                    ysCombination.ToArray().CopyTo(digits, 1);
        //                   if (k % 2 != 0)
        //                       digits[k / 2] = z;
    //                    Array.Copy(digits, 1, digits, k / 2 + 1, k / 2 - (k % 2 == 0 ? 1 : 0));
    //                    digits[k - 1] = x;
    //                    result.Add(digits.Aggregate(0, (acc, val) => acc * 10 + val));
    //                }
    //            }
    //        }
        //    return result;
        //}
        

        
    /*     public static List<(int, int)> Factor(int n)
        {
            // if (n == -1 || n == 0 || n == 1)
                // return new List<(int, int)>();
            // if (n < 0)
                // n = -n;
            List<(int, int)> F = new List<(int, int)>();
            while (n != 1)
            {
                int p = TrialDivision(n);
                int e = 1;
                n /= p;
                while (n % p == 0)
                {
                    e++;
                    n /= p;
                }
                F.Add((p, e));
            }
            F.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            return F;
        } */

        private static int TrialDivision(int n, int? bound = null)
        {
            if (n == 1)
                return 1;
            foreach (int p in new[] { 2, 3, 5 })
            {
                if (n % p == 0)
                    return p;
            }
            int b = bound ?? n;
            int[] dif = { 6, 4, 2, 4, 2, 4, 6, 2 };
            int m = 7, i = 1;
            while (m <= b && m * m <= n)
            {
                if (n % m == 0)
                    return m;
                m += dif[i % 8];
                i++;
            }
            return n;
        }

        public static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0)
                return b;
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static int Binomial(int n, int k)
        {
            if (k == 0 || n == k)
                return 1;
            int nt = 1;
            for (int i = 1; i <= k; i++)
            {
                nt = nt * (n - i + 1) / i;
            }
            return nt;
        }

        public static int CatalanNumber(int n)
        {
            int nm = 1, dm = 1;
            for (int k = 2; k <= n; k++)
            {
                nm = nm * (n + k);
                dm *= k;
            }
            return nm / dm;
        }

        public static List<int> PrimeSieve(int n)
        {
            bool[] sieve = Enumerable.Repeat(true, n / 2).ToArray();
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (sieve[i / 2])
                {
                    for (int j = i * i / 2; j < n / 2; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }
            return new[] { 2 }.Concat(Enumerable.Range(1, n / 2).Where((i, j) => sieve[j]).Select(i => 2 * i + 1)).ToList();
        }

    /*     public static (int, int, int) Bezout(int a, int b)
        {
            int u = 1, v = 0, s = 0, t = 1;
            while (b != 0)
            {
                int q = a / b;
                int r = a % b;
                a = b;
                b = r;
                int uTemp = s;
                s = u - q * s;
                u = uTemp;
                int vTemp = t;
                t = v - q * t;
                v = vTemp;
            }
            return (u, v, a);
        } */
        
        // Function to return GCD of a and b
        public static int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }
        
        // A simple method to evaluate
        // Euler Totient Function
        static int phi(int n)
        {
            int result = 1;
            for (int i = 2; i < n; i++)
                if (gcd(i, n) == 1)
                    result++;
            return result;
        }
        
        public static int getMaxDigs(int n, out int digsDec)
        {
            if (n < 10)
            {
                digsDec = 10;
                return 1;
            }
            if (n < 100)
            {
                digsDec = 100;
                return 2;
            }
            else if (n < 1000) 
            {
                digsDec = 1000;
                return 3;
            }
            else if (n < 10000) 
            {
                digsDec = 10000;
                return 4;
            }
            else if (n < 100000) 
            {
                digsDec = 100000;
                return 5;
            }
            digsDec = 1000000;
            return 6;
        }

        public static int rotateNum(int n, int MaxNUM)
        {
            int units = n % 10;
            int rest = n /10;
            int digs = getMaxDigs(n, out MaxNUM);
            n = MaxNUM/10 * units + rest;
            
            return n;
        }
        
        public static bool IsCircularPrime(int num)
        {
            
            int nextDecPower = 0;
            int max = getMaxDigs(num, out nextDecPower);
            for (int i =0; i< max; i++)
            {
                if (!(IsPrime(num))) return false;
                num = rotateNum(num, nextDecPower);
            }
            return true;
        }
        public static int P34()
        {
            int sum =0;
            
            
            
            
            
            
            return sum;
        }
        public static void P216()
        {
                    //sum = 0;
            int count = 0; // for the value 3
            int N = 50000000;
            int currSn=0; //current value
            int currAn=0;	//current arithmetic series additional term
            int S1 = 7;
            int A1=6;
            int d = 4;
            int prevAn = A1;
            int prevSn = S1;
            count ++; // Count is one due to the first term, 7
            for (int i =3;i<=N;i++)
            {
                currAn = prevAn + 1*d;
                currSn = prevSn + currAn;
                //Console.WriteLine(i + " , " + prevAn + " , " + prevSn + " , " + currAn + " : " + currSn);
                if(IsPrime(currSn))
                {
                    count++;
                }
                prevSn = currSn;
                prevAn = currAn;
            }
            Console.WriteLine("N = " + N + " ; count = " + count);
        }
        public static void unknown()
        {
                    BigInteger num = (BigInteger)Math.Pow(2,1000);
            //BigInteger a = (BigInteger)Math.Pow(2,250);
            //BigInteger a = (BigInteger)Math.Pow(2,250);
            //BigInteger a = (BigInteger)Math.Pow(2,250);
            //int q = BigInteger;
            int sum = 0;
            int len = num.ToString().Length;
            char[] numL = num.ToString().ToCharArray();
            for (int i =0;i<len;++i)
            {
                int cnum = numL[i]-48;
            //	Console.WriteLine(sum + " + " + cnum + " = " + (sum+cnum));
                //Console.WriteLine(numL[i] + " = " + (sum+ Convert.ToInt32(numL[i])));
                sum = sum + cnum;//numL[i]-48;
            //	num += num/10;
                //Console.WriteLine(sum + " + " + numL[i] + " = " + sum);
            }
            //char[] numl = new char[num.ToString().Length];
            List<int> listing = new List<int>();
            int count = 1;
            //int num = 179;
            //Console.WriteLine(IsCircularPrime(2));
            int k =3;
            while (k < 1000000)
            {
                if (IsCircularPrime(k))
                {
                    //Console.WriteLine(k);
                    count++;
                }
                k+=2;
            }
            
            //Console.WriteLine(count);
            //Console.WriteLine(sum); 
        }
        static int concat(int a, int b)
        {
            if (b < 10) return 10 * a + b;
            if (b < 100) return 100 * a + b;
            if (b < 1000) return 1000 * a + b;
            if (b < 10000) return 10000 * a + b;
            if (b < 100000) return 100000 * a + b;
            if (b < 1000000) return 1000000 * a + b;
            if (b < 10000000) return 10000000 * a + b;
            if (b < 100000000) return 100000000 * a + b;
            return 1000000000 * a + b;
        }
        public static void P32()
        {
            int sum = 0;
            int MAX = (int) Math.Sqrt(1000000000);
            int prod = 1;
            ulong product = 1;
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            HashSet<int> myHashSet = new HashSet<int>();
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
            Console.WriteLine("Final Product is : " +  product);
        }
        public List<int> Factor(int number) 
        {
            var factors = new List<int>();
            int max = (int)Math.Sqrt(number);  // Round down

            for (int factor = 1; factor <= max; ++factor) // Test from 1 to the square root, or the int below it, inclusive.
            {  
                if (number % factor == 0) 
                {
                    factors.Add(factor);
                    if (factor != number/factor) // Don't add the square root twice!  Thanks Jon
                        factors.Add(number/factor);
                }
            }
            return factors;
        }
    }
}
