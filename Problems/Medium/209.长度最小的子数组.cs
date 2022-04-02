/*
 * @lc app=leetcode.cn id=209 lang=csharp
 *
 * [209] 长度最小的子数组
 */

// @lc code=start
public class Solution209 {
    public int MinSubArrayLen(int target, int[] nums) {
        return function1(target, nums);
    }
    /*
    解法一：滑动窗口
    */
    public int function1(int target, int[] nums){
        int minLength = nums.Length + 1;
        int start = 0;
        int sum = 0;
        for(int end = start; end < nums.Length; end++){
            sum += nums[end];
            if(sum >= target){
                minLength = Math.Min(minLength, end - start + 1);
            }

            while(sum >= target){
                sum -= nums[start];
                minLength = Math.Min(minLength, end - start + 1);
                start++;
            }
        }
        return minLength == nums.Length + 1 ? 0 : minLength;
    }
}
// @lc code=end

