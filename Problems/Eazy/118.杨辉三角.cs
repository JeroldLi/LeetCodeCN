/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 */

// @lc code=start
public class Problem118 {
    public IList<IList<int>> Generate(int numRows) {
        return function1(numRows);
    }

    public IList<IList<int>> function1(int numRows){
        int[][] dp = new int[numRows][];
        for(int i = 0; i < numRows; i++){
            dp[i] = new int[i+1];
            for(int j = 0; j <= i; j++){
                if(j == 0 || j == i){
                    dp[i][j] = 1;
                }else{
                    dp[i][j] = dp[i-1][j-1] + dp[i-1][j];
                }
            }
        }

        IList<IList<int>> p = new List<IList<int>>();
        for(int i = 1; i <= numRows; i++){
            var list = dp[i-1].ToList();
            p.Add(list);
        }
        return p;
    }
}
// @lc code=end

