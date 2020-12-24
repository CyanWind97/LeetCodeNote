using System.Security.Cryptography;
using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 135
    /// title: 分发糖果
    /// problems: https://leetcode-cn.com/problems/candy/
    /// date: 20201224
    /// </summary>
    public static class Solution135
    {
        public static int Candy(int[] ratings) {
            int length = ratings.Length;
            if(length <= 1)
                return length;
            
            int sum = 1;
            int sign = ratings[0] > ratings[1] ? -1 : 1;
            int pre = 1;
            int top = 2;
            for(int i = 1; i < length; i++){
                if(ratings[i] > ratings[i - 1]) {
                    if(pre < 0){
                        if(top + pre - 1 < 0)
                            sum += -(top + pre - 1);
                        pre = 1;
                        sign = 1;
                    }
                    pre++;
                }else if(ratings[i] < ratings[i - 1]){
                    if(pre > 0) {
                        top = pre;
                        pre =  0;
                        sign = -1;
                    }
                    pre--;
                }else{
                    if(top + pre - 1 < 0)
                        sum += -(top + pre - 1);
                    pre = 1;
                    sign = 1;
                    top = 1;
                }

                sum += sign * pre;
            }
            if(top + pre - 1 < 0)
                sum += -(top + pre - 1);

            return sum;
        }

        // 参考题解
        public static int Candy_1(int[] ratings) {
            int sum = 0;
            int n = ratings.Length;
            int[] LeftToRight = new int[n];
            int[] RightToLeft = new int[n];
            for(int i = 0; i < n; i++){
                LeftToRight[i]=1;
                RightToLeft[i]=1;
            }
            for(int i=1; i<n; i++){
                if(ratings[i]>ratings[i-1]){
                    LeftToRight[i]=LeftToRight[i-1]+1;
                }
            }
            for(int i=n-2;i>=0;i--){
                if(ratings[i]>ratings[i+1]){
                    RightToLeft[i]=RightToLeft[i+1]+1;
                }
            }
            for(int i=0;i<n;i++){
                sum+=Math.Max(LeftToRight[i],RightToLeft[i]);
            }
            return sum;
        }

        // 官方题解 空间复杂度为O(1)
        // 没有自己实现的快
        public static int Candy_2(int[] ratings) {
            int length = ratings.Length;
            if(length <= 1)
                return length;
            
            int sum = 1;
            int inc = 1, dec = 0, pre = 1;
            for(int i = 1; i < length; i++){
                if(ratings[i] >= ratings[i - 1]) {
                    dec = 0;
                    if(ratings[i] == ratings[i-1])
                        pre = 0;
                    pre++;
                    sum += pre;
                    inc = pre;
                }else{
                    dec++;
                    if(dec == inc)
                        dec++;
                    
                    sum+= dec;
                    pre = 1;
                }
            }

            return sum;
        }

        // 参考题解 优化自己的代码
        public static int Candy_3(int[] ratings) {
            int length = ratings.Length;
            
            int sum = 1;
            int pre = 1;
            int desCount = 0;
            for(int i = 1; i < length; i++){
                if(ratings[i] >= ratings[i - 1]) {
                    if(desCount > 0){
                        sum += ((desCount + 1) * desCount) /2;
                        if(desCount >= pre)
                            sum += (desCount - pre + 1);
                        
                        pre = 1;
                        desCount = 0;
                    }
                    pre = ratings[i] == ratings[i-1] ? 1 : pre + 1;
                    sum += pre;
                }else
                    desCount++;
            }
            if(desCount > 0){
                sum += ((desCount + 1) * desCount) /2;
                if(desCount >= pre)
                    sum += (desCount - pre + 1);   
            }

            return sum;
        }
    }
}