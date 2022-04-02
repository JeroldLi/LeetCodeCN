/*
 * @lc app=leetcode.cn id=1052 lang=csharp
 *
 * [1052] 爱生气的书店老板
 */

// @lc code=start
public class Solution1052 {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        return function1(customers, grumpy, minutes);
    }
    /*
    解法一：滑动窗口
    */
    public int function1(int[] customers, int[] grumpy, int minutes){
        int sum = 0; //记录窗口时间内的收益
        int maxSum = 0; //记录窗口时间内最大收益
        int maxIndex = 0; //记录最大收益的起始位置

        int start = 0;
        for(int cur = 0; cur < grumpy.Length; cur++){
            if(grumpy[cur] == 1){ //遇到生气就直接开技能
                sum += customers[cur];
            }
            if(sum > maxSum){
                maxSum = sum;
                maxIndex = start;
            }

            while(cur - start + 1 >= minutes){
                if(grumpy[start] == 1){
                    sum -= customers[start];
                }
                start++;
            }
        }

        for(int i = maxIndex; i < maxIndex + minutes; i++){
            grumpy[i] = 0;
        }
        int result = 0;
        for(int i = 0; i < grumpy.Length; i++){
            result += grumpy[i] == 0 ? customers[i] : 0;
        }
        return result;
    }
}
// @lc code=end

