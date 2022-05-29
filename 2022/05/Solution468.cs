namespace LeetCodeNote
{
    /// <summary>
    /// no: 468
    /// title:  验证IP地址
    /// problems: https://leetcode.cn/problems/validate-ip-address/
    /// date: 20220528
    /// </summary>    
    public class Solution468
    {
        public static string ValidIPAddress(string queryIP) {
            
            bool ValidIPV4(string IP){
                var addresses = IP.Split(".");
                if(addresses.Length != 4)
                    return false;
                
                foreach(var address in addresses){
                    if(address.Length == 0 || address.Length > 3)
                        return false;

                    if(!int.TryParse(address, out var value))
                        return false;
                    
                    if(value > 255)
                        return false;

                    if(address[0] == '0' && address.Length != 1)
                        return false;
                }

                return true;
            }

            bool ValidIPV6(string IP){
                var addresses = IP.Split(":");
                if(addresses.Length != 8)
                    return false;
                
                foreach(var address in addresses){
                    if(address.Length == 0 || address.Length > 4)
                        return false;
                    
                    if(!int.TryParse(address, System.Globalization.NumberStyles.HexNumber, null, out var value))
                        return  false;
                }

                return true;
            }

            return ValidIPV4(queryIP) 
                ? "IPv4"
                : ValidIPV6(queryIP)
                    ? "IPv6"
                    : "Neither";
        }
    }
}