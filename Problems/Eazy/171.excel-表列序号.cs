/*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel 表列序号
 */

// @lc code=start
public class Problem171 {
    public int function1(string columnTitle) {
        int ans = 0;
        for (int i = 0; i < columnTitle.Length; i++){
            ans = ans * 26 + (columnTitle[i] - 'A' + 1);
        }

        return ans;
    }

    public int TitleToNumber(string columnTitle) {
        return function1(columnTitle);
    }
}
// @lc code=end

