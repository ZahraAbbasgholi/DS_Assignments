// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Text;

namespace A7;
public class c
{
    // public static void Main()
    // {
    //     Q2PartitioningSouvenirs ml = new Q2PartitioningSouvenirs("lsj");
    //     var path = @"E:\DS\Assignments\A7\TestData\A7.TD2\In_1.txt";
    //     string[] lines = File.ReadAllLines(path, Encoding.UTF8);
    //     long n = long.Parse(lines[0]);
    //     // var size = lines.Length - 1;
    //     var v = lines[1].Split();
    //     long[] nums = new long[v.Length];
    //     for (int i = 0; i < v.Length; i++)
    //     {
    //         nums[i] = long.Parse(v[i]);
    //     }
    //     var result = ml.Solve(n, nums);
    //     // foreach (var item in result)
    //     // {
    //     //     System.Console.WriteLine(item);
    //     // }
    //     Console.WriteLine(result);
    // }

    public static void Main()
    {
        Q3MaximizingArithmeticExpression ml = new Q3MaximizingArithmeticExpression("lsj");
        var path = @"E:\DS\Assignments\A7\TestData\A7.TD3\In_2.txt";
        string[] lines = File.ReadAllLines(path, Encoding.UTF8);
        // long n = long.Parse(lines[0]);
        // var size = lines.Length - 1;
        // var v = lines[1].Split();
        // long[] nums = new long[v.Length];
        // for (int i = 0; i < v.Length; i++)
        // {
        //     nums[i] = long.Parse(v[i]);
        // }
        var result = ml.Solve(lines[0]);
        // foreach (var item in result)
        // {
        //     System.Console.WriteLine(item);
        // }
        Console.WriteLine(result);
    }
}