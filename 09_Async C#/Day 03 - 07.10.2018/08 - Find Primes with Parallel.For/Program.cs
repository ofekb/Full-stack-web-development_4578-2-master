using System;
using System.Threading.Tasks;

namespace Find_Primes
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;

            if (n == 2) return true;

            if (n % 2 == 0) return false;

            int limit = (int)Math.Sqrt(n);

            for (int i = 3; i <= limit; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            // Prime Number = מספר ראשוני = מספר שמתחלק בעצמו ובאחד בלבד

            // הציגו את כל המספרים הראשוניים, בין 1 ל-1000, כאשר הסדר לא חשוב
            Parallel.For(2, 1000, i => Console.Write(IsPrime(i) ? i + " " : ""));

        }
    }
}
