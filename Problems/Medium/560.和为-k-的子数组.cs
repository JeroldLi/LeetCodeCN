/*
 * @lc app=leetcode.cn id=560 lang=csharp
 *
 * [560] 和为 K 的子数组
 */

// @lc code=start
public class Solution560 {
    public int SubarraySum(int[] nums, int k) {
        //return function1(nums, k);
        //return function2(nums, k);
        return function3(nums, k);
    }

    /*
    解法一：暴力法
    固定左边界 枚举右边界
    */
    public int function1(int[] nums, int k){
        int len = nums.Length;
        int count = 0;
        for(int left = 0; left < len; left++){
            int sum = 0;
            for(int right = left; right < len; right++){
                sum += nums[right];
                if(sum == k){
                    count++;
                    //break; //不能跳出循环 因为有可能会有多余的0
                }
            }
        }
        return count;
    }
    /*
    解法二：前缀和
    */
    public int function2(int[] nums, int k){
        int len = nums.Length;
        int[] preSum = new int[len + 1];
        preSum[0] = 0;
        for(int i = 0; i < len; i++){
            preSum[i + 1] = preSum[i] + nums[i];
        }

        int count = 0;
        for(int left = 0; left < len; left++){
            for(int right = left; right < len; right++){
                if(preSum[right + 1] - preSum[left] == k){
                    count++;
                }
            }
        }
        return count;
    }
    /*
    解法三：前缀和+哈希表
    */
    public int function3(int[] nums, int k){
        //key:前缀和；value:对应的前缀和的个数
        Dictionary<int, int> preSumDict = new Dictionary<int, int>();
        preSumDict.Add(0,1);
        int preSum = 0;
        int count = 0;
        foreach(int num in nums){
            preSum += num;
            if(preSumDict.ContainsKey(preSum - k)){
                count += preSumDict[preSum - k];
            }
            int outValue = 0;
            preSumDict.TryGetValue(preSum, out outValue);
            preSumDict[preSum] = outValue + 1;
        }
        return count;
    }
}
// @lc code=end

