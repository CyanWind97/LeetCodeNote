using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2288
/// title: 价格减免
/// problems: https://leetcode.cn/problems/apply-discount-to-prices
/// date: 20240618
/// </summary>
public static class Solution2288
{
    public static string DiscountPrices(string sentence, int discount) {
        var multiplier = 1 - discount / 100.0;
        var sequence = new ReadOnlySequence<char>(sentence.AsMemory());
        var reader = new SequenceReader<char>(sequence);
        var writer = new ArrayBufferWriter<char>();

        void WriteWord(ReadOnlySpan<char> word){
            if (word[0] == '$' && word.Length > 1
            && long.TryParse(word[1..], out var price)){
                var discoutPrice = price * multiplier;
                writer.Write($"${discoutPrice:0.00}");
            }else{
                writer.Write(word);
            }
        }

        while(!reader.End){
            if(!reader.TryReadTo(out ReadOnlySpan<char> word, ' '))
              break;
            
            WriteWord(word);
            writer.Write(" ");
        }

        if (reader.Remaining > 0)
            WriteWord(reader.UnreadSpan);
        
        return new string(writer.WrittenSpan);
    }
}
