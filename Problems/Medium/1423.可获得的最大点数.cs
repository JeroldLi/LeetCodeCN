/*
 * @lc app=leetcode.cn id=1423 lang=csharp
 *
 * [1423] 可获得的最大点数
 */

// @lc code=start
public class Solution1423 {
    public int MaxScore(int[] cardPoints, int k) {
        return function1(cardPoints, k);
    }
    /*
    解法一：滑动窗口
    转换思路 求两端的最大值就是求中间的最小值
    */
    public int function1(int[] cardPoints, int k){
        int n = cardPoints.Length;
        int totalSum = SumArray(cardPoints);
        if(n == k){
            return totalSum;
        }

        int m = n - k;
        int sum = 0;
        int minSum = int.MaxValue;
        int start = 0;
        for(int cur = 0; cur < n; cur++){
            sum += cardPoints[cur];
            if(cur >= m - 1){
                minSum = Math.Min(minSum, sum);
                sum -= cardPoints[start];
                start++;
            }
        }
        return totalSum - minSum;
    }
    public int SumArray(int[] cardPoints){
        int sum = 0;
        foreach(int num in cardPoints){
            sum += num;
        }
        return sum;
    }

}
// @lc code=end

