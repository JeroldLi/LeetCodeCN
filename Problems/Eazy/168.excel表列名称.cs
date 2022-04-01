/*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 */

// @lc code=start
using System.Text;
public class Solution168 {
    public string ConvertToTitle(int columnNumber) {
        return function1(columnNumber);
    }

/*
解法一：暴力法
另一种形式的进制转换，但是要注意0是不存在的 从1开始
1=A
所以每次数字要先-1再取模
在将0转化为字符时(+'A')不用再位移
*/
    public string function1(int columnNumber){
        StringBuilder sb = new StringBuilder();
        while(columnNumber > 0){
            columnNumber--;
            int ans = columnNumber % 26;
            sb.Append((char)(ans + 'A'));
            columnNumber /= 26;
        }
        StringBuilder columnTitle = new StringBuilder();
        for(int i = sb.Length - 1; i >= 0; i--){
            columnTitle.Append(sb[i]);
        }
        return columnTitle.ToString();
    }
}
// @lc code=end

