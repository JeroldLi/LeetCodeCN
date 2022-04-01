/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Solution69
{
    public int MySqrt(int x)
    {
        //return function1(x);
        //return function2(x);
        return function3(x);
    }
    /*
    方法一：数学计算法
    将x开根号写成x的二分之一次幂
    再用自然对数进行换底
    变成e的lnx次的二分之一次幂
    等于e的二分之一lnx次幂
    但是最后有误差 边界是ans 和 ans+1
    最后要确认哪个才是正确值
    */
    public int function1(int x)
    {
        if (x == 0 || x == 1)
        {
            return x;
        }

        int ans = (int)Math.Exp(0.5 * Math.Log(x));  //取整
        return (long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
    }
    /*
    解法二：二分查找
    因为要找k的平方<=x，而且k一般是小于x的一半的
    因此在x中对k进行二分查找

    */
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
            if (mid > x / mid)  //用除法防止爆int
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
    /*
    解法三：牛顿法
    设y=x²-C -> 当x=根号C时 y = 0
    因此将y作为二次函数进行分析
    过某点xi做斜率k为2xi的直线
    根据点斜式:y-yi = k(x-xi)
    所以直线方程为y=2xi(x-xi) + xi² — C
    =2x·xi - (xi²+C)
    令该直线与x轴有交点xi+1 即 y = 0，又可算出新的xi+1
    再过该点做斜率为2xi+1的直线
    以此类推，经过n次后 xn将逼近根号C
    当两次迭代的距离非常小，小于一个很小的数时，我们可以判断迭代来到了终点
    */
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

