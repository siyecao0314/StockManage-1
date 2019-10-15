using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace nsStockManage
{
    class CommonFunction
    {
        //检查编码的合法性函数
        public static bool checkCodeLegality(String code)
        {
            if (code.Length > 10 && code.Contains("-") && code.Length < 30 )
            {
                String[] temp = code.Split('-');
                if (temp.Length == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //检查结尾编码的合法性函数
        public static bool checkEndCodeLegality(String startCode, String endCode)
        {
            if(checkCodeLegality(startCode) && checkCodeLegality(endCode))
            {
                String startNumber = startCode.Substring(startCode.Length - 4, 4);
                String endNumber = endCode.Substring(endCode.Length - 4, 4);
                if (int.Parse(startNumber) < int.Parse(endNumber))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        //检查字符串中是否包含中文
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }
    }
}
