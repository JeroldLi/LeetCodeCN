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

/*
解法一：
用两个游标遍历数组，当俩游标之和等于目标值时， 返回游标
时间复杂度为O(n²) 要遍历整个数组
空间复杂度为O(1) 只赋值两个游标
*/
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

/*
解法二：
使用哈希表来存储已遍历过的数
哈希表的键值对为<numValue, numPosition>
当target - numValue1 == numValue2时 返回两个数的Position
当numValue2不在哈希表中时，将其存入哈希表
时间复杂度O(n) 只遍历一次数组
空间复杂度O(n) 保存数组的哈希表
*/
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

