/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
using System;
public class Problem4 {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        return function1(nums1, nums2);
        //return function2(nums1, nums2);
        //return function3(nums1, nums2);
        //return function4(nums1, nums2);
    }

    //简单合并再计算
    //O(M+N);O(M+N)
    public double function1(int[] nums1, int[] nums2) {
        int m = 0, n = 0;
        List<int> intList = new List<int>();
        while(m < nums1.Length || n < nums2.Length){
            if(m < nums1.Length && n < nums2.Length){
                if(nums1[m] <= nums2[n]){
                    intList.Add(nums1[m]);
                    m++;
                }else if(nums1[m] >= nums2[n]){
                    intList.Add(nums2[n]);
                    n++;
                }
            }
            else{
                if(m == nums1.Length){
                    intList.Add(nums2[n]);
                    n++;
                }else if(n == nums2.Length){
                    intList.Add(nums1[m]);
                    m++;
                }
            }
        }
        int a = intList.Count / 2;
        if(intList.Count % 2 == 0){
            return (intList[a-1] + intList[a])*1.0 / 2;
        }else{
            return  intList[(intList.Count+1)/2 - 1];
        }
    }

    //只取下标对比 不用另开数组保存
    //O(M+N);O(1);
    public double function2(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        int len = m + n;

        int aCursor = 0, bCursor = 0;  //位置游标
        int left = 0, right = 0; //中位数

        for(int i = 0; i <= len/2; i++){
            left = right;
            if(aCursor < m && (bCursor >= n || nums1[aCursor] < nums2[bCursor])){
                right = nums1[aCursor++];
            }else{
                right = nums2[bCursor++];
            }
        }

        if(len % 2 == 0){
            return (left + right) / 2.0;
        }else{
            return right;
        }
    }

    //二分法查找计算
    //O(log(m+n)); O(1);
    public double function3(int[] nums1, int[] nums2) {
       int m = nums1.Length;
       int n = nums2.Length;
       int len = m + n;
       if(len % 2 == 1){  //odd
           int midIndex = len / 2;  
           // odd 7;midIndex = 3(012[3]456)
           // k = 4, the 4th Element in array;
           double median = GetKthElement(nums1, nums2, midIndex + 1);
           return median;
       }else{
           int midIndex1 = len / 2 - 1;
           int midIndex2 = len / 2;
           //even 8; midIndex = 3,4(012[34]567)
           //k = 4, 5; the 4th,5th Element in array;
           double median = (GetKthElement(nums1, nums2, midIndex1 + 1) + GetKthElement(nums1, nums2, midIndex2 + 1)) / 2.0;
           return median;
       }
    }

    public double GetKthElement(int[] nums1, int[] nums2, int k){
        int pivot1 = 0, pivot2 = 0; //value
        int length1 = nums1.Length, length2 = nums2.Length;
        int index1 = 0, index2 = 0; //cursor

        while(true){
            if(index1 == length1){
                return nums2[index2 + k - 1];
            }
            if(index2 == length2){
                return nums1[index1 + k - 1];
            }
            if(k == 1){
                return Math.Min(nums1[index1], nums2[index2]);
            }
            
            int half = k / 2;
            int newIndex1 = Math.Min(index1 + half, length1) - 1;
            int newIndex2 = Math.Min(index2 + half, length2) - 1;
            pivot1 = nums1[newIndex1]; pivot2 = nums2[newIndex2];
            if(pivot1 <= pivot2){
                k -= (newIndex1 - index1 + 1);  
                //delete (newIndex1 - index1 + 1) numbers
                index1 = newIndex1 + 1;
                //index add 1; cursor move 1 step;
            }else{
                k -= (newIndex2 - index2 + 1);
                index2 = newIndex2 + 1;
            }

            
        }
    }

    //划分计算
    //O(logmin(m,n)); O(1)
    public double function4(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return function4(nums2, nums1);  //要求m<n
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int left = 0;
        int right = m; //只在[0，m]区间遍历
        int leftMax = 0;
        int rightMin = 0;

        while (left <= right)
        {
            int i = (left + right) / 2;
            int j = (m + n + 1) / 2 - i;

            int nums1_subi = (i == 0 ? int.MinValue : nums1[i - 1]);
            int nums1_i = (i == m ? int.MaxValue : nums1[i]);

            int nums2_subj = (j == 0 ? int.MinValue : nums2[j - 1]);
            int nums2_j = (j == n ? int.MaxValue : nums2[j]);

            if (nums1_subi <= nums2_j)
            {
                leftMax = Math.Max(nums1_subi, nums2_subj);
                rightMin = Math.Min(nums1_i, nums2_j);
                left = left + 1;
            }
            else
            {
                right = right - 1;
            }
        }

        return (m + n) % 2 == 0 ? (leftMax + rightMin) / 2.0 : leftMax;
    }
}
// @lc code=end

