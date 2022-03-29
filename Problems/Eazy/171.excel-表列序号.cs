/*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel 表列序号
 */

// @lc code=start
public class Problem171 {
    /*
    解法一：暴力法 高到低
    进制转换，从高位向低位（从左至右）计算其幂值和
    */
    public int function1(string columnTitle) {
        int ans = 0;
        for (int i = 0; i < columnTitle.Length; i++){
            ans = ans * 26 + (columnTitle[i] - 'A' + 1);
        }

        return ans;
    }
    /*
    解法一：暴力法 低到高
    进制转换，从低位向高位（从右至左）计算其幂值和
    */
    public int function2(string columnTitle){
        double ans = 0;
        double n = 0;
        for(int i = columnTitle.Length - 1; i >= 0; i--){
            ans += (Math.Pow(26, n) * (columnTitle[i] - 'A' + 1));
            n++;
        }
        return Convert.ToInt32(ans);
    }

    public int TitleToNumber(string columnTitle) {
        return function2(columnTitle);
    }
}
// @lc code=end

