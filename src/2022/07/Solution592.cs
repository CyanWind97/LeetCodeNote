using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 592
    /// title:  分数加减运算
    /// problems: https://leetcode.cn/problems/fraction-addition-and-subtraction/
    /// date: 20220727
    /// </summary>
    public static class Solution592
    {
        public static string FractionAddition(string expression) {
            var result = new Fraction(0, 1);
            int length = expression.Length;    
            int prev = 0;
            for(int i = 1; i < length; i++){
                if(expression[i] != '+' && expression[i] != '-')
                    continue;
                
                result += new Fraction(expression.Substring(prev, i - prev));
                prev = i;
            }

            result += new Fraction(expression.Substring(prev, length - prev));

            return result.ToString();
        }

        public class Fraction {
            public int Numerator { get; set; }
            
            public int Denominator { get; set; }

            public Fraction(int numerator, int denominator){
                Numerator = numerator;
                Denominator = denominator;
            }

            public Fraction(string s){
                var nums = s.Split("/");
                Numerator = int.Parse(nums[0]);
                Denominator = int.Parse(nums[1]);
            }


            public override string ToString()
                => $"{Numerator}/{Denominator}";
            
            
            static int GCD(int a, int b) 
                => b != 0 ? GCD(b, a % b) : a;


            public static Fraction operator +(Fraction f1, Fraction f2){
                int d = f1.Denominator * f2.Denominator;
                int n = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
                int gcd = GCD(Math.Abs(d), Math.Abs(n));

                d /= gcd;
                n /= gcd;

                return new Fraction(n, d);
            }
        }
    }
}