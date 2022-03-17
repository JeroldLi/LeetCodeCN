/*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 */

// @lc code=start
using System.Text;
public class Problem168 {
    public string ConvertToTitle(int columnNumber) {
        return function1(columnNumber);
    }

    public string function1(int columnNumber){
        StringBuilder sb = new StringBuilder();
        while(columnNumber > 0){
            int a0 = (columnNumber - 1) % 26 + 1;
            sb.Append((char)(a0 - 1 + 'A'));
            columnNumber = (columnNumber - a0) / 26;
        }
        StringBuilder columnTitle = new StringBuilder();
        for(int i = sb.Length - 1; i >= 0; i--){
            columnTitle.Append(sb[i]);
        }
        return columnTitle.ToString();
    }
}
// @lc code=end

