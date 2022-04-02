/*
 * @lc app=leetcode.cn id=1004 lang=csharp
 *
 * [1004] 最大连续1的个数 III
 */

// @lc code=start
public class Solution1004 {
    public int LongestOnes(int[] nums, int k) {
        return function1(nums, k);
    }
    /*
    解法一：滑动窗口
    */
    public int function1(int[] nums, int k){
        int zeroCount = 0;
        int maxLength = 0;
        int start = 0;
        for(int cur = 0; cur < nums.Length; cur++){
            if(nums[cur] == 0){
                zeroCount++;
            }
            if(zeroCount <= k){
                maxLength = Math.Max(maxLength, cur - start + 1);
            }

            while(zeroCount > k){
                if(nums[start] == 0){
                    zeroCount--;
                }
                start++;
            }
        }
        return maxLength;
    }
}
// @lc code=end

