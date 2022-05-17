using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 912
    /// title:  排序数组
    /// problems: https://leetcode.cn/problems/sort-an-array/
    /// date: 20220517
    /// priority: 0079
    /// time: 00:19:13.70 timeout
    /// </summary>
    public static class CodeTop912
    {
        public static int[] SortArray(int[] nums) {
            // Array.Sort(nums);

            HeapSort(nums);

            return nums;
        }


        // 快排都忘了？ 还要再练习练习
        public static void QuickSort(int[] nums){
            var random = new Random();

            int Partition(int left, int right){
                int num = nums[right];
                int index = left - 1;

                for(int j = left; j < right; j++){
                    if(nums[j] <= num){
                        index++;
                        (nums[index], nums[j]) = (nums[j], nums[index]);
                    }
                }

                (nums[index + 1], nums[right]) = (nums[right] , nums[index + 1]);
                
                return index + 1;
            }

            int RandomPartition(int left, int right){
                var index = random.Next(right - left + 1) + left;
                (nums[index], nums[right]) = (nums[right], nums[index]);

                return Partition(left, right);
            }

            void RandomQuickSort(int left, int right){
                if(left >= right)
                    return;
                
                int pos = RandomPartition(left, right);
                RandomQuickSort(left, pos - 1);
                RandomQuickSort(pos + 1, right);
            }

            RandomQuickSort(0, nums.Length - 1);
        }

        
        // 堆排序
        public static void HeapSort(int[] nums){
            int length = nums.Length;

            void ShiftDown(int index){
                while((index << 1)  < length - 1){
                    int leftChild = (index << 1) + 1;
                    int rightChild = (index << 1) + 2;
                    int large = index;

                    if(leftChild < length && nums[leftChild] > nums[index])
                        large = leftChild;
                    
                    if(rightChild < length && nums[rightChild] > nums[large])
                        large = rightChild;
                    
                    if(large == index)
                        break;
                    
                    (nums[index], nums[large]) = (nums[large], nums[index]);
                    index = large;
                }
            }

            for(int i = (length - 1) >> 1; i >= 0; i--){
                ShiftDown(i);
            }

            for(int i = length - 1; i >= 1; i--){
                (nums[i], nums[0]) = (nums[0], nums[i]);
                length--;
                ShiftDown(0);
            }
        }
    }
}