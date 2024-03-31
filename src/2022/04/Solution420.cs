using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 420
    /// title: 强密码检验器
    /// problems: https://leetcode-cn.com/problems/strong-password-checker/
    /// date: 20220402
    /// </summary>
    public static class Solution420
    {
        // 参考解答
        public static int StrongPasswordChecker(string password) {
            int n = password.Length;
            int hasLower = 0, hasUpper = 0, hasDigit = 0;
            foreach (char ch in password) {
                if (char.IsLower(ch)) {
                    hasLower = 1;
                } else if (char.IsUpper(ch)) {
                    hasUpper = 1;
                } else if (char.IsDigit(ch)) {
                    hasDigit = 1;
                }
            }
            int categories = hasLower + hasUpper + hasDigit;

            if (n < 6) {
                return Math.Max(6 - n, 3 - categories);
            } else if (n <= 20) {
                int replace = 0;
                int cnt = 0;
                char cur = '#';

                foreach (char ch in password) {
                    if (ch == cur) {
                        ++cnt;
                    } else {
                        replace += cnt / 3;
                        cnt = 1;
                        cur = ch;
                    }
                }
                replace += cnt / 3;
                return Math.Max(replace, 3 - categories);
            } else {
                // 替换次数和删除次数
                int replace = 0, remove = n - 20;
                // k mod 3 = 1 的组数，即删除 2 个字符可以减少 1 次替换操作
                int rm2 = 0;
                int cnt = 0;
                char cur = '#';

                foreach (char ch in password) {
                    if (ch == cur) {
                        ++cnt;
                    } else {
                        if (remove > 0 && cnt >= 3) {
                            if (cnt % 3 == 0) {
                                // 如果是 k % 3 = 0 的组，那么优先删除 1 个字符，减少 1 次替换操作
                                --remove;
                                --replace;
                            } else if (cnt % 3 == 1) {
                                // 如果是 k % 3 = 1 的组，那么存下来备用
                                ++rm2;
                            }
                            // k % 3 = 2 的组无需显式考虑
                        }
                        replace += cnt / 3;
                        cnt = 1;
                        cur = ch;
                    }
                }
                if (remove > 0 && cnt >= 3) {
                    if (cnt % 3 == 0) {
                        --remove;
                        --replace;
                    } else if (cnt % 3 == 1) {
                        ++rm2;
                    }
                }
                replace += cnt / 3;

                // 使用 k % 3 = 1 的组的数量，由剩余的替换次数、组数和剩余的删除次数共同决定
                int use2 = Math.Min(Math.Min(replace, rm2), remove / 2);
                replace -= use2;
                remove -= use2 * 2;
                // 由于每有一次替换次数就一定有 3 个连续相同的字符（k / 3 决定），因此这里可以直接计算出使用 k % 3 = 2 的组的数量
                int use3 = Math.Min(replace, remove / 3);
                replace -= use3;
                remove -= use3 * 3;
                return (n - 20) + Math.Max(replace, 3 - categories);
            }
        }

        /// 未通过的解答 > 20的处理不正确
        public static int StrongPasswordChecker_1(string password) {
            var chars = password.ToCharArray();
            var length = chars.Length;
            bool hasLower = false;
            bool hasUpper = false;
            bool hasDigit = false;


            void Judge(char c){
                hasLower = hasLower | char.IsLower(c);
                hasUpper = hasUpper | char.IsUpper(c);
                hasDigit = hasDigit | char.IsDigit(c);
            }

            int CalcValidCount()
                => (hasLower ? 0 : 1) + (hasUpper ? 0 : 1) + (hasDigit ?  0 : 1);

            int CalcReplaceCount(){
                var replaceCount = 0;
                var preChar = '?';
                var preCount = 0;

                foreach(var c in chars){
                    Judge(c);
                    
                    if(preChar == c){
                        preCount++;
                        if(preCount == 3){
                            replaceCount++;
                            preChar = '?';
                            preCount = 0;
                        }
                    }else{
                        preChar = c;
                        preCount = 1;
                    }
                }

                return replaceCount;
            }


            return length <= 20  
                ? Math.Max(Math.Max(Math.Max(0, 6 - length), CalcReplaceCount()), CalcValidCount())
                :  CheckerMore(chars);
        }


        private static int CheckerMore(char[] chars){
            int length = chars.Length;
            int minReplaceCount = 51;
            int lowerCount = 0;
            int upperCount = 0;
            int digitCount = 0;
            var replaceCount = 0;
            var preChar = '?';
            var preCount = 0;
 
            void CalcCount(char c, int delta){
                if(char.IsLower(c))
                    lowerCount += delta;
                else if(char.IsUpper(c))
                    upperCount += delta;
                else if(char.IsDigit(c))
                    digitCount += delta;
            }

            
            int CalcValidCount()
                => (lowerCount > 0 ? 0 : 1) + (upperCount > 0 ? 0 : 1) + (digitCount > 0 ?  0 : 1);

            for(int i = 0; i < 20; i++){
                CalcCount(chars[i], 1);
                
                if(preChar == chars[i]){
                    preCount++;
                    if(preCount == 3){
                        replaceCount++;
                        preChar = '?';
                        preCount = 0;
                    }
                }else{
                    preChar = chars[i];
                    preCount = 1;
                }
            }

            minReplaceCount = Math.Max(replaceCount, CalcValidCount());

            for(int i = 20; i < length; i++){
                var c = chars[i - 20];
                CalcCount(c, - 1);
                int count = 0;
                while(count < 19 && chars[i + count - 19] == c){
                    count++;
                }

                if(count % 3 == 2)
                    replaceCount--;
                
                c = chars[i];
                CalcCount(c, 1);
                count = 0;
                while(count < 19 && chars[i - count - 1] == c){
                    count++;
                }

                if(count % 3 == 2)
                    replaceCount++;
                
                minReplaceCount = Math.Min(minReplaceCount,  Math.Max(replaceCount, CalcValidCount()));
            }

            return length - 20 + minReplaceCount;
        }

    }
}