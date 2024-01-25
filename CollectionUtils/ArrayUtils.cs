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