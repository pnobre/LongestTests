using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().solution(new int[] {9, 4, 2, 10, 7, 8, 8, 1, 9}));
            Console.WriteLine(2 == new Solution().solution(new int[] {4, 8, 12, 16}));
            Console.WriteLine(1 == new Solution().solution(new int[] {100}));
            var a = new int[100000];
            for (var n = 1; n <= 100000; n++)
            {
                if (n % 2 == 0) a[n - 1] = 150;
                else a[n - 1] = 50;
            }

            Console.WriteLine(100000 == new Solution().solution(a));
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            var longest = 0;
            var current = 0;

            for (var i = 0; i < A.Length; i++)
            {
                if (i >= 2 && (A[i] < A[i - 1] && A[i - 1] > A[i - 2] ||
                               A[i] > A[i - 1] && A[i - 1] < A[i - 2])) current++;
                else if (i >= 1 && A[i] != A[i - 1]) current = 2;
                else current = 1;

                longest = Math.Max(longest, current);
            }

            return longest;
        }
    }
}