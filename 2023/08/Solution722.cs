using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 722
    /// title: 删除注释
    /// problems: https://leetcode.cn/problems/remove-comments/
    /// date: 20230803
    /// </summary>
    public static class Solution722
    {
        public static IList<string> RemoveComments(string[] source) {
            var result = new List<string>();
            int length = source.Length;
            bool isBlock = false;
            string str = "";
            for(int i = 0; i < length; i++){
                string line = source[i];
                int index = 0;
                int lineLength = line.Length;
                while(index < lineLength){
                    if(!isBlock){
                        if(index + 1 < lineLength && line[index] == '/' && line[index + 1] == '*'){
                            isBlock = true;
                            index++;
                        }else if(index + 1 < lineLength && line[index] == '/' && line[index + 1] == '/'){
                            break;
                        }else{
                            str += line[index];
                        }
                    }else{
                        if(index + 1 < lineLength && line[index] == '*' && line[index + 1] == '/'){
                            isBlock = false;
                            index++;
                        }
                    }
                    index++;
                }

                if(!isBlock && str != ""){
                    result.Add(str);
                    str = "";
                }
            }

            return result;
        }
    }
}