namespace LeetCodeNote
{
    /// <summary>
    /// no: 1108
    /// title: IP 地址无效化
    /// problems: https://leetcode.cn/problems/defanging-an-ip-address/
    /// date: 20220621
    /// </summary>
    public static class Solution1108
    {
        public static string DefangIPaddr(string address) {
            return address.Replace(".","[.]");
        }
    }
}