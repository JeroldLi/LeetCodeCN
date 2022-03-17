/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Problem69
{
    //其他计算法
    public int MySqrt(int x)
    {
        //return function1(x);
        //return function2(x);
        return function3(x);
    }

    public int function1(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }

        int ans = (int)Math.Exp(0.5 * Math.Log(x));  //取整
        return (long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
    }
    //二分查找
    public int function2(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }

        int left = 1, right = x / 2;
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;  //这里是数值 不是索引
            if (mid > x / mid)
            {
                right = mid - 1;
            }
            else
            {
                left = mid;
            }
        }
        return left;
    }
    //牛顿法
    public int function3(int x){
        if (x == 0 || x == 1)
        {
            return x;
        }

        double C = x, x0 = x;
        while(true){
            double xi = 0.5 * (x0 + C / x0);
            if(Math.Abs(x0-xi) < 1e-7){
                break;
            }
            x0 = xi;
        }
        return (int) x0;
    }
}
// @lc code=end

