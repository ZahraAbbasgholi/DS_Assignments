// See https://aka.ms/new-console-template for more information
using System.Text;
using A4;
namespace A4;
using System;
using System.IO;
using System.Text;


public class ppp

{
    public static void Main()
    {
        Q4CollectingSignatures ml = new Q4CollectingSignatures("lsj");
        var path = @"E:\DS\Assignments\A4\A4.Tests\TestData\A4.TD4\In_8.txt";
        string[] lines = File.ReadAllLines(path, Encoding.UTF8);
        long tenantCount = long.Parse(lines[0]);
        var size = lines.Length - 1;
        long[] startTimes = new long[size];
        long[] endTimes = new long[size];
        for (int i = 1; i < lines.Length; i++)
        {
            var v = lines[i].Split();
            startTimes[i - 1] = long.Parse(v[0]);
            endTimes[i - 1] = long.Parse(v[1]);
        }
        var result = ml.Solve(tenantCount, startTimes, endTimes);
        Console.WriteLine(result);
    }
}


// public class ppp

// {
//     public static void Main()
//     {
//         Q6MaximizeSalary ml = new Q6MaximizeSalary("lsj");
//         var path = @"E:\DS\Assignments\A4\A4.Tests\TestData\A4.TD6\In_1.txt";
//         string[] lines = File.ReadAllLines(path, Encoding.UTF8);
//         long n = long.Parse(lines[0]);
//         var size = lines.Length - 1;
//         long[] numbers = new long[size];
//         for (int i = 1; i < lines.Length; i++)
//         {
//             var v = lines[i].Split();
//             numbers[i - 1] = long.Parse(v[0]);
//         }
//         var result = ml.Solve(n, numbers);
//         Console.WriteLine(result);
//     }
// }

// public class ppp

// {
//     public static void Main()
//     {
//         Q7MaxSubarraySum ml = new Q7MaxSubarraySum("lsj");
//         var path = @"E:\DS\Assignments\A4\A4.Tests\TestData\A4.TD7\In_01.txt";
//         string[] lines = File.ReadAllLines(path, Encoding.UTF8);
//         long n = long.Parse(lines[0]);
//         var size = lines.Length - 1;
//         long[] numbers = new long[size];
//         for (int i = 1; i < lines.Length; i++)
//         {
//             var v = lines[i].Split();
//             numbers[i - 1] = long.Parse(v[0]);
//         }
//         var result = ml.Solve(n, numbers);
//         Console.WriteLine(result);
//     }
// }