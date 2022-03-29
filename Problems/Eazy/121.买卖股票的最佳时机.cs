/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Problem121 {
    /*
    解法一：暴力解
    遍历数组中每一个数，计算他们的差值，保存最大值
    时间复杂度：O(n²)
    空间复杂度：O(1)
    */
    public int function1(int[] prices) {
        int maxProfit = 0;
        for(int x = 0; x < prices.Length; x++){
            for(int y = x+1; y < prices.Length; y++){
                if(prices[y] - prices[x] > maxProfit){
                    maxProfit = prices[y] - prices[x];
                }
            }
        }
        return maxProfit;
    }

    /*
    解法二：动态规划
    dp的意义：截至第i天时的最低价格
    dp的变化：要么是dp[i-1] 要么是 当前价格 二者取最小
    dp方程： dp[i] = min(dp[i-1], prices[i])
    遍历方向：i从小到大
    题目需要的值：max(price[i])-min(dp[i]) 最大的价格减去之前i天中最低的价格
    */
    public int function21(int[] prices){
        //空间不优化版
        int max = 0;
        int[] dp = new int[prices.Length];
        dp[0] = prices[0];
        for(int i = 1; i < prices.Length; i++){
            dp[i] = (dp[i-1] < prices[i]) ? dp[i-1] : prices[i];
            max = (prices[i] - dp[i]) > max ? prices[i] - dp[i] : max;
        }

        return max;
    }

    public int function22(int[] prices){  //dp[i] = min(dp[i-1], prices[i])
    //空间优化版
        int minPrice = int.MaxValue;  //初始设置为最大值
        int maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < minPrice){ //找出前i天的最低点
                minPrice = prices[i];
            }else if(prices[i] - minPrice > maxProfit){
                //如果大于最低点，判断此时卖出是否是最大盈利，是最大盈利则更新max值
                maxProfit = prices[i] - minPrice;
            }
        }

        return maxProfit;
    }

    public int MaxProfit(int[] prices){
        return function1(prices);
        //return function21(prices);
        //return function22(prices);
    }

}
// @lc code=end

