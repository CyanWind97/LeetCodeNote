using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 591
    /// title: 标签验证器
    /// problems: https://leetcode-cn.com/problems/tag-validator/
    /// date: 20220502
    /// </summary>
    public static class Solution591
    {
        public static bool IsValid(string code) {
            var stack = new Stack<string>();
            var length = code.Length;
            var index = 0;
            var cdata = "[CDATA[";

            bool Validate(ReadOnlySpan<char> span){
                while(index < length){
                    if(span[index++] != '<'){
                        if(stack.Count == 0)
                            return false;
                        
                        continue;
                    }
                    
                    if(index == length)
                        return false;
                    
                    if(span[index] == '!'){
                        if(!MatchData(span))
                            return false;
                    }else if(span[index] == '/'){
                        if(!MatchEndTag(span))
                            return false;
                        else if(stack.Count == 0 && index < length)
                            return false;
                            
                    }else{
                        if(!MatchTag(span))
                            return false;
                    }
                }

                return stack.Count == 0;
            }

            bool MatchTag(ReadOnlySpan<char> span){
                if(!TryGetTag(span, out string tag))
                    return false;
                
                stack.Push(tag);

                return true;
            }

            bool MatchEndTag(ReadOnlySpan<char> span){
                index++;
                if(!TryGetTag(span, out string tag))
                    return false;

                return stack.Count > 0 && stack.Pop() == tag;
            }

            bool TryGetTag(ReadOnlySpan<char> span, out string tag){
                var count = 0;
                tag = null;

                while(index + count < length && span[index + count] != '>'){
                    if(!char.IsUpper(span[index + count]))
                        return false;

                    count++;
                }

                if(count == 0 || count > 9)
                    return false;

                tag = span.Slice(index, count).ToString();
                index += count + 1;

                return true;
            }

            bool MatchData(ReadOnlySpan<char> span){
                if(stack.Count == 0)
                    return false;

                index++;
                int count = 0;
                while(count < 7){
                    if(index == length || span[index + count] != cdata[count])
                        return false;
                    
                    count++;
                }
                
                count = 0;
                while(index + count < length - 2 
                    && !(span[index + count] == ']' 
                        && span[index + count + 1] == ']'
                        && span[index + count + 2] == '>')){
                            count++;
                }

                if(index + count == length - 2)
                    return false;

                index += count + 3; 

                return true;
            }


            return Validate(code.AsSpan());
        }
    }
}