using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Test._2024;

[TestClass]
public class Test2810
{
    [TestMethod]
    [DataRow("string", "rtsng")]
    [DataRow("poiinter", "ponter")]
    [DataRow("viwif", "wvf")]
    public void Test1(string s, string expected)
    {
        var result = Solution2810.FinalString(s);
        Assert.AreEqual(expected, result);
    }
}
