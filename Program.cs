using System;
using System.Text;
namespace leetcode
{
    class Program
    {
        static void Main(String[] args)
        {
            Random random = new Random();
            int len = 10;
            int[] randomIntArray = new int[len];
            for(int i = 0; i < len; i++){
                randomIntArray[i] = random.Next(1, len+1);
            }
            int testLen = 10;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < testLen; i++){
                sb.Append(randomIntArray[i] + " ");
            }
            Console.WriteLine($"排序前：{sb.ToString()}");
            PublicFunction.HeapDesSort(randomIntArray);
            sb.Clear();
            for(int i = 0; i < testLen; i++){
                sb.Append(randomIntArray[i] + " ");
            }
            Console.WriteLine($"排序后：{sb.ToString()}");
        }
    }
}
