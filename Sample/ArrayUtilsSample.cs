using System;
using System.Text;
using PJ.Utils;

public class ArrayUtilsSample
{
    public static void Test()
    {
        int[] intArr = new int[10];
        
        // fill all elements with -1
        intArr.MakeSequence((ith) => -1);
        Console.WriteLine(intArr.ArrayToString());
        // > [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1]
        
        // sequence of odd numbers
        intArr.MakeSequence((ith) => ith * 2 + 1);
        Console.WriteLine(intArr.ArrayToString());
        // > [1, 3, 5, 7, 9, 11, 13, 15, 17, 19]
        
        // fibonacci sequence
        intArr.MakeSequence((ith, sub) => 
        {
            if(ith == 0) return 1;
            else if(ith == 1) return 1;
            else return sub.Get(ith - 1) + sub.Get(ith - 2);
        });
        Console.WriteLine(intArr.ArrayToString());
        // > [1, 1, 2, 3, 5, 8, 13, 21, 34, 55]

        string[] strArr = new string[10];
        
        // sequence which ith elements repeats 'a' i times;
        strArr.MakeSequence((ith, sub) => 
        {
            if(ith == 0) return "a";
            else return $"{sub.Get(ith-1)}a";
        });
        Console.WriteLine(strArr.ArrayToString());
        // > [a, aa, aaa, aaaa, aaaaa, aaaaaa, aaaaaaa, aaaaaaaa, aaaaaaaaa, aaaaaaaaaa]
    }
}