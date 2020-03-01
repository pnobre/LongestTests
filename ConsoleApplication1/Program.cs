using System;
using System.Globalization;
using System.IO;

namespace ConsoleApplication1
{
    class Tree
    {
        public Tree(int val, Tree l, Tree r)
        {
            x = val;
            this.l = l;
            this.r = r;
        }
        public int x;
        public Tree l;
        public Tree r;
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            // UsingArray();
            UsingBST();
        }

        private static void UsingBST()
        {
            // var t1 = new Tree 
            //     {x = 1, left = new Tree {x = 2, left = new Tree {x = 1}, right = new Tree { x = 2}}, right = new Tree {x = 2, left = new Tree { x = 4}, right = new Tree {x = 1}}};

            var t1 = new Tree(1, new Tree(2, new Tree(3, new Tree(2, null, null), null), new Tree(6, null, null)),
                new Tree(3, new Tree(3, null, null), new Tree(1, new Tree(5, null, null), new Tree(6, null, null))));
                
            // var t2 = new Tree 
            //     {x = 1, r = new Tree {x = 2, l = new Tree { x = 1}, r = new Tree {x = 1, l = new Tree { x = 4}}}};
            
            Console.WriteLine(3 == new Solution2().solution(t1));
            // Console.WriteLine(3 == new Solution2().solution(t2));

        }
        
        private static void UsingArray()
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

    class Solution2
    {
        private int Longest(Tree t, int current, int currentLongest)
        {
            if (t == null) return currentLongest;

            if (t.x <= current) currentLongest = 1;
            else currentLongest++;

            return Math.Max(Longest(t.l, t.x, currentLongest), Longest(t.r, t.x, currentLongest));
        }
        
        public int solution(Tree tree)
        {
            return Longest(tree, tree.x, 0);
        }
    }
}