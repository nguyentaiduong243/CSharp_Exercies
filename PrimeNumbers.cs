using System;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumbers();
            Console.ReadLine();
        }
        public static async Task PrimeNumbers()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            await Task.Run(() =>
            {
                
                int a = 2;
                while (a < n)
                {
                    bool isPrimeNumber = true;

                    if (a < 2)
                    {
                        isPrimeNumber = false;
                    }
                    else
                    {
                        int i = 2;

                        while (i <= Math.Sqrt(a))
                        {
                            if (a % i == 0)
                            {
                                isPrimeNumber = false;
                                break;
                            }
                            i = i + 1;
                        }
                    }
                    if (isPrimeNumber)
                        Console.WriteLine("{0}    ", a);
                    a++;
                    Task.Delay(50).Wait();
                }
            });
        }
    }
}
