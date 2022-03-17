/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
public class Problem1 {
    public int[] TwoSum(int[] nums, int target) {
        return function1(nums, target);
        //return function2(nums, target);
    }

    public int[] function1(int[] nums, int target) {
        int len = nums.Length;
        for(int x = 0; x < len; x++){
            for(int y = x+1; y < len; y++){
                if(nums[x] + nums[y] == target){
                    return new int[] {x,y};
                }
            }
        }
        return new int[] {-1, -1};
    }

    public int[] function2(int[] nums, int target) {
        int len = nums.Length;
        Dictionary<int, int> hashmap = new Dictionary<int, int>();
        for(int i = 0; i < len; i++){
            if(hashmap.ContainsKey(target - nums[i])){
                return new int[] {hashmap[target- nums[i]], i};
            }
            if(!hashmap.ContainsKey(nums[i])){
                hashmap.Add(nums[i], i);
            }
        }
        return new int[] {-1, -1};
    }
}
// @lc code=end

