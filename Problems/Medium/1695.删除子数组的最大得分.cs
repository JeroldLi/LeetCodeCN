/*
 * @lc app=leetcode.cn id=1695 lang=csharp
 *
 * [1695] 删除子数组的最大得分
 */

// @lc code=start
public class Solution1695 {
    public int MaximumUniqueSubarray(int[] nums) {
        return function1(nums);
    }

    /*
    解法一：滑动窗口
    */
    public int function1(int[] nums){
        int maxValue = 0;
        int start = 0;
        int value = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int end = start; end < nums.Length; end++){
            if(!dict.ContainsKey(nums[end])){
                dict.Add(nums[end], 1);
            }else{
                dict[nums[end]]++;
            }
            value += nums[end];
            if(dict.Count == end - start + 1){
                maxValue = Math.Max(maxValue, value);
            }
            while(end - start + 1 > dict.Count){
                value -= nums[start];
                dict[nums[start]]--;
                if(dict[nums[start]] == 0){
                    dict.Remove(nums[start]);
                }
                start++;
            }
        }
        return maxValue;
    }
}
// @lc code=end

