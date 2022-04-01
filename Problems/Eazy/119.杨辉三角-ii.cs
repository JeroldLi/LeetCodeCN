/*
 * @lc app=leetcode.cn id=119 lang=csharp
 *
 * [119] 杨辉三角 II
 */

// @lc code=start
public class Solution119 {
    public IList<int> GetRow(int rowIndex) {
        //return function1(rowIndex);
        return function2(rowIndex);
    }

/*
解法一：暴力法：
硬算，保存在list里
再提取对应的行
每计算一个节点，就要读上一行的节点
时间复杂度O(rowIndex²)
空间复杂度O(1)
*/
    public IList<int> function1(int rowIndex){
        List<List<int>> C = new List<List<int>>();
        for(int i = 0; i <= rowIndex; ++i){
            List<int> row = new List<int>();
            for(int j = 0; j <= i; ++j){
                if(j == 0 || j == i){
                    row.Add(1);
                }else{
                    row.Add(C[i-1][j-1] + C[i-1][j]);
                }
            }
            C.Add(row);
        }
        return C[rowIndex];
    }

    /*
    解法二：数学算法
    Cmn代表着第n行第m列的值 （m和n是索引值）
    C13就是第4行第2列的值 = 3
    */
    public IList<int> function2(int rowIndex){
        List<int> row = new List<int>();
        row.Add(1);
        for(int i = 1; i <= rowIndex; i++){
            row.Add((int)((long)row[i-1] * (rowIndex - i + 1) / i));
        }
        return row;
    }
}
// @lc code=end

