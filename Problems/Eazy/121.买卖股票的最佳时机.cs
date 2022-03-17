/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Problem121 {
    //暴力解法  会超时
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

    //动态规划
    public int function2(int[] prices){  //dp[i] = min(dp[i-1], prices[i])
        int max = 0;
        int[] dp = new int[prices.Length];
        dp[0] = prices[0];
        for(int i = 1; i < prices.Length; i++){
            dp[i] = (dp[i-1] < prices[i]) ? dp[i-1] : prices[i];
            max = (prices[i] - dp[i]) > max ? prices[i] - dp[i] : max;
        }

        return max;
    }

    public int function3(int[] prices){  //dp[i] = min(dp[i-1], prices[i])
        int minPrice = int.MaxValue;
        int maxProfit = 0;
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < minPrice){
                minPrice = prices[i];
            }else if(prices[i] - minPrice > maxProfit){
                maxProfit = prices[i] - minPrice;
            }
        }

        return maxProfit;
    }

    public int MaxProfit(int[] prices){
        return function1(prices);
        //return function2(prices);
        //return function3(prices);
    }

}
// @lc code=end

