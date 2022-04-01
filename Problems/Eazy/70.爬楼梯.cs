/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Solution70
{
    //public class Solution70 {
    /*
    解法一：动态规划
    动态规划五部曲：
    1、确定dp[i]的下标以及dp值的含义:爬到楼梯第i层楼梯，有dp[i]种方法
    2、确定动态规划的递推公式：dp[i] = dp[i-1] + dp[i-2]
    3、dp数组的初始化，因为题目中可知一次上1或2层，因此：
    上1层：dp[1]=1
    上2层：dp[2]=2 (走2次1层或走1次2层)
    4、确定遍历顺序：分析递推公式可知当前值以来前两个值来确定，所以递推顺序应该是i从小到大
    5、打印dp数组看看自己写的对不对
    */
    public int function11(int n)
    {
        /*
        空间优化版
        因为dp[n] = dp[n-1] + dp[n-2]
        所以只需要记录这三个变量即可
        所以使用一个滚动数组保存三个变量
        不断的用新的值替换旧的值，直到最终结果
        */
        int p = 0, q = 0, r = 1;
        for (int i = 1; i <= n; i++)
        {
            p = q;
            q = r;
            r = p + q;
        }
        return r;
    }

    public int function12(int n)
    {
        //空间不优化版
        int[] dp = new int[n + 1];
        dp[0] = 1;  //边界判断
        if (n == 1)
        {
            dp[1] = 1;
        }
        if (n > 1)
        {
            dp[1] = 1; //上1层的方法数
            dp[2] = 2; //上2层的方法数
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
        }
        return dp[n];
    }

    //递归+查表,递归会超时
    int[] ClimbPlan = new int[50];
    public int function2(int n)
    {
        if (n == 0 || n == 1)
        {
            ClimbPlan[n] = 1;
            return ClimbPlan[n];
        }
        if (ClimbPlan[n] != 0)
        {
            return ClimbPlan[n];
        }
        int sub1 = ClimbPlan[n - 1] != 0 ? ClimbPlan[n - 1] : ClimbStairs(n - 1);
        int sub2 = ClimbPlan[n - 2] != 0 ? ClimbPlan[n - 2] : ClimbStairs(n - 2);
        ClimbPlan[n] = sub1 + sub2;

        return ClimbPlan[n];
    }

    public int ClimbStairs(int n)
    {
        return function12(n);
        //return function2(n);
    }
}
// @lc code=end

