using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 273
    /// title:  整数转换英文表示
    /// problems: https://leetcode-cn.com/problems/integer-to-english-words/
    /// date: 20220512
    /// priority: 0073
    /// time: 00:25:58.06
    public static class CodeTop273
    {
        private static string[] _numberMaps = new string[]
            { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", 
              "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
              "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        
        private static string[] _tensMaps = new string[] 
            { "Zero", "Ten", "Twenty", "Thirty", "Forty", 
              "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static string[] _unitMaps = new string[]
            { "Hundred",  "Thousand", "Million", "Billion" };

        public static string NumberToWords(int num) {
            if (num == 0)
                return "Zero";
            
            var result = new List<string>();
            var numbers = new List<int>();

            while(num != 0){
                numbers.Add(num % 1000);
                num /= 1000;
            }

            for(int i = numbers.Count - 1; i >= 0; i--){
                if (numbers[i] == 0)
                    continue;
                
                result.AddRange(GetNums(numbers[i]));
                if (i != 0)
                    result.Add(_unitMaps[i]);
            }

            return string.Join(" ", result);
        }

        /// <summary>
        /// 获取千以内的数
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static IList<string> GetNums(int number){
            var result = new List<string>();
            
            int hundred = number / 100; 
            if (hundred > 0){
                result.Add(_numberMaps[hundred]);
                result.Add("Hundred");
            }
            
            number -= hundred * 100;

            if (number < 20 && number > 0){
                result.Add(_numberMaps[number]);
            }else{
                int ten = number / 10;
                if(ten > 1)
                    result.Add(_tensMaps[ten]);
                
                number -= 10 * ten;
                
                if (number > 0)
                    result.Add(_numberMaps[number]);
            }

            return result;
        }
    }
}