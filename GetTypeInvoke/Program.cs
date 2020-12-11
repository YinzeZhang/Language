using System;

namespace GetTypeInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Object obj = new
            {
                Name = "小明",
                Num = 1
            };

            Console.WriteLine("Name: \t" + obj.GetType().GetProperty("Name").GetValue(obj));
            Console.WriteLine("Num: \t" + obj.GetType().GetProperty("Num").GetValue(obj));
            */
            ReflectionTest.test();
        }
    }
}
