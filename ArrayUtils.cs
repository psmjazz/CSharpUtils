using System;
using System.Diagnostics;
using System.Text;

namespace PJ.Utils
{
    public interface SubSequence<T>
    {
        T Get(int index);
    }

    
    public static class ArrayUtils
    {
        private class RestrictionSequence<T> : SubSequence<T>
        {
            private readonly T[] sub;
            private int restriction;

            public RestrictionSequence(T[] arr)
            {
                sub = arr;
                restriction = 0;
            } 

            public void StepUp()
            {
                restriction++;
            }

            public T Get(int index)
            {
                if(restriction <= index) throw new InvalidOperationException("Can't access element bigger than ith");
                return sub[index];
            }
        }
        public static string ArrayToString<T>(this T[] arr)
        {
            StringBuilder sb = new StringBuilder("[");
            foreach(var e in arr)
            {
                sb.Append($"{e}, ");
            }
            sb.Replace(", ", "]", sb.Length-2, 2);
            return sb.ToString();
        }

        public static string ArrayToString<T>(this T[,] arr)
        {
            int rowCount = arr.GetLength(0);
            int colCount = arr.GetLength(1);
            StringBuilder sb = new StringBuilder("[");

            for(int i = 0; i<rowCount; i++)
            {
                sb.Append("[");
                for(int j = 0; j <colCount; j++)
                {
                    sb.Append($"{arr[i, j]}, ");
                }
                sb.Replace(", ", "],\n", sb.Length-2, 2);
            }
            sb.Replace(",\n", "]", sb.Length-2, 2);

            
            return sb.ToString();
        }

        public static void MakeSequence<T>(this T[] arr, Func<int, T> nthTerm)
        {
            for(int i = 0; i<arr.Length; i++)
            {
                arr[i] = nthTerm.Invoke(i);
            }
        }

        public static void MakeSequence<T>(this T[] arr, Func<int, SubSequence<T>, T> recurrence)
        {
            var restrictionSequence = new RestrictionSequence<T>(arr);
            for(int i = 0; i<arr.Length; i++)
            {
                arr[i] = recurrence.Invoke(i, restrictionSequence);
                restrictionSequence.StepUp();
            }
        }
    }
}