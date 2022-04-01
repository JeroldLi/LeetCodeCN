/*
 * @lc app=leetcode.cn id=215 lang=csharp
 *
 * [215] 数组中的第K个最大元素
 * 堆排序与快排
 */

// @lc code=start
public class Solution215 {
    public int FindKthLargest(int[] nums, int k) {
        //return function1(nums, k);
        return function2(nums, k);
    }

    /*
    解法一：堆排序
    */
    private int Parrent(int i)
    {
        return (i-1) / 2;
    }
    private int Left(int i){
        return i*2+1;
    }
    private int Right(int i){
        return i*2+2;
    }
    private void Swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    private void MaxHeapify(int[] nums, int i, int heapSize){
        int left = Left(i);
        int right = Right(i);
        int largest = i;
        if(left < heapSize && nums[left] > nums[i]){
            largest = left;
        }
        if(right < heapSize && nums[right] > nums[largest]){
            largest = right;
        }
        if(largest != i){
            Swap(nums, i, largest);
            MaxHeapify(nums, largest, heapSize);
        }
    }
    private void BuildMaxHeap(int[] nums){
        int start = nums.Length / 2 - 1;
        for(int i = start; i >= 0; i--){
            MaxHeapify(nums, i, nums.Length);
        }
    }
    private int function1(int[] nums, int k){
        if(nums == null || nums.Length == 0)
        {
            return 0;
        }
        BuildMaxHeap(nums);
        int heapSize = nums.Length;
        for(int i = nums.Length - 1; i >= nums.Length - k + 1; i--){
            Swap(nums, 0, i);
            heapSize--;
            MaxHeapify(nums, 0, heapSize);
        }
        return nums[0];
    }
    /*
    解法二：快速排序
    */
    private void QuickSort(int[] nums, int begin, int end){
        if(begin < end){
            int left = begin - 1;
            int right = end + 1;
            int middle = nums[(begin + end) / 2];
            while(true){
                while(nums[++left] < middle);
                while(nums[--right] > middle);
                if(left >= right){
                    break;
                }
                Swap(nums, left, right);
            }
            QuickSort(nums, begin, left - 1);
            QuickSort(nums, right + 1, end);
        }
    }
    private int function2(int[] nums, int k){
        QuickSort(nums, 0, nums.Length - 1);
        return nums[nums.Length - k];
    }
}
// @lc code=end

