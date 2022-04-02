/*
 * @lc app=leetcode.cn id=1208 lang=csharp
 *
 * [1208] 尽可能使字符串相等
 */

// @lc code=start
public class Solution1208 {
    public int EqualSubstring(string s, string t, int maxCost) {
        return function1(s, t, maxCost);
    }
    /*
    解法一：滑动窗口
    */
    public int function1(string s, string t, int maxCost){
        int sLen = s.Length;
        int tLen = t.Length;
        int[] costArray = new int[sLen];
        for(int i = 0; i < sLen; i++){
            costArray[i] = Math.Abs(s[i] - t[i]);
        }

        int maxLen = 0;
        int costSum = 0;
        int start = 0;
        for(int cur = 0; cur < sLen; cur++){
           costSum += costArray[cur];
           if(costSum <= maxCost){
               maxLen = Math.Max(maxLen, cur - start + 1);
           }
           while(costSum > maxCost){
               costSum -= costArray[start];
               start++;
           }
        }
        return maxLen;
    }
}
// @lc code=end

