/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
using leetcode;
public class Solution88 {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        function1(nums1, m, nums2, n);
        //function2(nums1, m, nums2, n);
        //function3(nums1, m, nums2, n);
    }

    /*
    解法一：暴力法：
    先合并数组，再利用快排
    时间复杂度O((m+n)log(m+n))
    空间复杂度O(m+n)
    */
    public int[] function1(int[] nums1, int m, int[] nums2, int n){
        for(int i = 0; i < n; i++){
            nums1[m+i] = nums2[i];
        }
        PublicFunction.QuickSort(nums1, 0, m+n-1);
        return nums1;
    }
    /*
    解法二：双指针
    两个变量保存数组的头元素，比较后将较小的保存至新数组
    时间复杂度O(m+n) 要遍历m+n的元素
    空间复杂度O(m+n) 存储m+n的元素
    */
    public void function2(int[] nums1, int m, int[] nums2, int n){
        int p1 = 0;
        int p2 = 0;
        int[] sortedNums = new int[m+n];
        int cur = -1;
        while(p1 < m || p2 < n){
            if(p1 == m){
                cur = nums2[p2++];
            }else if(p2 == n){
                cur = nums1[p1++];
            }else if(nums1[p1] < nums2[p2]){
                cur = nums1[p1++];
            }else if(nums1[p1] >= nums2[p2]){
                cur = nums2[p2++];
            }
            sortedNums[p1+p2-1] = cur;
        }
        for(int i = 0; i != m+n; ++i){
            nums1[i] = sortedNums[i];
        }
        //return sortedNums;
    }

    /*
    解法三：双指针优化版
    因为nums1的尾部空间是空闲的，所以考虑两个数组从尾部开始遍历
    将大的值插入nums1尾部
    设游标p1和p2(索引值)
    任意时刻nums1有m-p1-1个值被移动至nums1尾部
    nums2有n-p2-1个值被移动至nums1尾部
    如p1=2(nums1中最后一个非0) 此时3-2-1=0 没有元素被移动
    而p1=2时nums1尾部的空间为m+n-p1-1（3+3-2-1=3)
    p1=0（nums1中第一个非0）此时3-0-1=2 有2个元素被移动
    p2=2（nums2中最后一个）此时3-2-1=0 没有元素被移动
    以此类推
    要使已移动的元素小于可用空间
    即m-p1-1+n-p2-1 <= m+n-p1-1
    即p2 >= -1 恒成立
    因此空间是一定足够的
    */
    public void function3(int[] nums1, int m, int[] nums2, int n){
        int p1 = m - 1;
        int p2 = n - 1;
        int pTail = m + n - 1;
        int cur = -1;
        while(p1 >= 0 || p2 >= 0){
            if(p1 == -1){
                cur = nums2[p2--];
            }else if(p2 == -1){
                cur = nums1[p1--];
            }else if(nums1[p1] >= nums2[p2]){
                cur = nums1[p1--];
            }else if(nums1[p1] < nums2[p2]){
                cur = nums2[p2--];
            }
            nums1[pTail] = cur;
            pTail--;
        }
    }
}
// @lc code=end

