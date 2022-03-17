/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

// @lc code=start
public class Problem70 {
    //动态规划
    public int function1(int n) {
        int p = 0, q = 0,r =1;
        for(int i = 1; i<=n; i++){
            p = q;
            q = r;
            r = p+q;
        }
        return r;
    }

    //递归+查表,递归会超时
    int[] ClimbPlan = new int[50];
    public int function2(int n){
        if(n == 0 || n == 1){
            ClimbPlan[n] = 1;
            return ClimbPlan[n];
        }
        if(ClimbPlan[n] != 0){
            return ClimbPlan[n];
        }
        int sub1 =  ClimbPlan[n-1] != 0 ? ClimbPlan[n-1] : ClimbStairs(n-1);
        int sub2 =  ClimbPlan[n-2] != 0 ? ClimbPlan[n-2] : ClimbStairs(n-2);
        ClimbPlan[n] = sub1 + sub2;

        return ClimbPlan[n];
    }

    public int ClimbStairs(int n){
        return function1(n);
        //return function2(n);
    }
}
// @lc code=end

