// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Text;

namespace A9;
public class ppp

{
    public static void Main()
    {
        Q2MergingTables ml = new Q2MergingTables("lsj");
        var path = @"E:\DS\Assignments\A9\TestData\A9.TD2\In_01.txt";
        string[] lines = File.ReadAllLines(path, Encoding.UTF8);
        
        var l0 = lines[0].Split();
        long[] tableSize = new long[l0.Count()];
        for (int i = 0; i < l0.Count(); i++)
        {
            tableSize[i] = long.Parse(l0[i]);
        }

        long[] targetTables = new long[lines.Count() - 1];
        long[] sourceTables = new long[lines.Count() - 1];

        for (int i = 1; i < lines.Count(); i++)
        {
            var v = lines[i].Split();
            int j = 0;
            targetTables[i - 1] = long.Parse(v[j]);
            sourceTables[i - 1] = long.Parse(v[j + 1]);
        }
        var result = ml.Solve(tableSize, targetTables, sourceTables);
        // foreach (var item in result)
        // {
        //     System.Console.WriteLine(item);
        // }
        // Console.WriteLine(result);
    }

    // public static void Main()
    // {
    //     Q4LCSOfTwo ml = new Q4LCSOfTwo("lsj");
    //     var path = @"E:\DS\Assignments\A6\A6.Tests\bin\Debug\net6.0\TestData\A6.TD4\In_12.txt";
    //     string[] lines = File.ReadAllLines(path, Encoding.UTF8);
    //     var n = lines[0].Split();
    //     var n2 = lines[1].Split();
    //     long[] seq1 = new long[n.Length];
    //     long[] seq2 = new long[n2.Length];

    //     for (int i = 0; i < n.Length; i++)
    //     {
    //         // var v = n.Split();
    //         seq1[i] = long.Parse(n[i]);
    //     }
    //     for (int i = 0; i < n2.Length; i++)
    //     {
    //         // var v = n2.Split();
    //         seq2[i] = long.Parse(n2[i]);
    //     }
    //     var result = ml.Solve(seq1, seq2);
    //     Console.WriteLine(result);
    // }
}