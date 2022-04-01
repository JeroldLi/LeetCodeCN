namespace leetcode
{
    public class PublicFunction
    {
        #region 快速排序
        public static void QuickSort(int[] nums, int begin, int end){
            if(begin < end){
                int middle = nums[(begin + end) / 2];
                int i = begin - 1;
                int j = end + 1;
                while(true){
                    while(nums[++i] < middle);
                    while(nums[--j] > middle);
                    if(i >= j){
                        break;
                    }

                    Swap(nums, i, j);
                }
                QuickSort(nums, begin, i - 1);
                QuickSort(nums, j + 1, end);
            }
        }

        public static void Swap(int[] nums, int i, int j){
            int number = nums[i];
            nums[i] = nums[j];
            nums[j] = number;
        }
        #endregion
        #region 堆排序
        /*
        前提概念：查找一个二叉树形成的数组中第i位的父节点和左右节点位置
        */
        private static int Parrent(int i){  //父节点位置
            return (i - 1) / 2;
        }
        private static int Left(int i){ //左节点
            return 2 * i + 1;
        }
        private static int Right(int i){ //右节点
            return 2 * i + 2;
        }
        private static void MaxHeapify(int[] array, int i, int heapSize){
            int left = Left(i);
            int right = Right(i);
            int largest = i;
            if(left < heapSize && array[left] > array[i]){
                largest = left;
            }
            if(right < heapSize && array[right] > array[largest]){
                largest = right;
            }
            if(largest != i){
                Helper.Exchange(ref array[i], ref array[largest]);
                MaxHeapify(array, largest, heapSize);
            }
        }

        private static void MinHeapify(int[] array, int i, int heapSize){
            int left = Left(i);
            int right = Right(i);
            int smallest = i;
            if(left < heapSize && array[left] < array[i]){
                smallest = left;
            }

            if(right < heapSize && array[right] < array[smallest]){
                smallest = right;
            }

            if(smallest != i){
                Helper.Exchange(ref array[i], ref array[smallest]);
                MinHeapify(array, smallest, heapSize);
            }
        }
        private static void BuildMaxHeap(int[] array){
            for(int i = array.Length / 2 - 1; i >= 0; i--){
                MaxHeapify(array, i, array.Length);
            }
        }
        private static void BuildMinHeap(int[] array){
            for(int i = array.Length / 2 - 1; i >= 0; i--){
                MinHeapify(array, i, array.Length);
            }
        }

        public static void HeapSort(int[] array){
            BuildMaxHeap(array);
            for(int i = array.Length - 1; i > 0; i--){
                Helper.Exchange(ref array[i], ref array[0]);
                MaxHeapify(array, 0, i);
            }
        }

        public static void HeapDesSort(int[] array){
            BuildMinHeap(array);
            for(int i = array.Length - 1; i > 0; i--){
                Helper.Exchange(ref array[i], ref array[0]);
                MinHeapify(array, 0, i);
            }
        }
        #endregion
    }

    public class Helper
    {
        public static void Exchange<T>(ref T x, ref T y){
            T temp = x;
            x = y;
            y = temp;
        }
    }
}