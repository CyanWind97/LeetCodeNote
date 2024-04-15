using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeetCodeNote.Test._2024._04;

[TestClass]
public class Test924
{
    [TestMethod]
    [DataRow("[[1,0,0,0,0,0],[0,1,1,0,0,0],[0,1,1,0,0,0],[0,0,0,1,1,1],[0,0,0,1,1,1],[0,0,0,1,1,1]]", "[2,3]")]
    public void Case1(string graphStr, string initialStr)
    {
        var graph = JsonSerializer.Deserialize<int[][]>(graphStr);
        var initial = JsonSerializer.Deserialize<int[]>(initialStr);
        int result = Solution924.MinMalwareSpread(graph, initial);
        Assert.AreEqual(3, result);
    }
}
