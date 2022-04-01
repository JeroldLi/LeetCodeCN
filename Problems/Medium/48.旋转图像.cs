/*
 * @lc app=leetcode.cn id=48 lang=csharp
 *
 * [48] 旋转图像
 */

// @lc code=start
public class Solution48
{
    public void Rotate(int[][] matrix)
    {
        //function1(matrix);
        //function2(matrix);
        function3(matrix);
    }
    /*
    解法一：使用额外数组
    matrix[row][col] = matrix[col][n - row - 1];
    用另一个matrix保存值 最后返回另一个数组
    但是和题目要求不符
    */
    public void function1(int[][] matrix)
    {
        int n = matrix.Length;
        //初始化交错数组
        int[][] newMatrix = new int[n][];
        for (int row = 0; row < n; row++)
        {
            newMatrix[row] = new int[n];
        }
        //用新交错数组保存移动后的结果
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                newMatrix[col][n - row - 1] = matrix[row][col];
            }
        }
        //将交错数组的值覆盖回原数组
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row][col] = newMatrix[row][col];
            }
        }
    }
    /*
    解法二：原地旋转
    要使用一个额外变量保存值，但是每变动一个值会有4个值跟着一起动
    要有循环计算的概念，一次走4步
    不断用新坐标迭代入关键方程
    matrix[row][col] = matrix[col][n - row - 1];
    更关键的一点是选择哪几个点去旋转，不能遍历完所有节点 不然又转会去了
    分为偶数与奇数边长考虑
    偶数：因为一次旋转要改变4个点 所以只需要移动n²/4个点 展开给每行每列就是n/2个点
    奇数：因为中心不参与旋转，所以只需要移动(n²-1)/4 平方差展开每行(n-1)/2,每列(n+1)/2
    */
    public void function2(int[][] matrix)
    {
        int n = matrix.Length;
        if (n % 2 == 0)
        {
            for (int row = 0; row < n / 2; row++)
            {
                for (int col = 0; col < n / 2; col++)
                {
                    Swap2(matrix, n, row, col);
                }
            }
        }
        else
        {
            for (int row = 0; row < (n - 1) / 2; row++)
            {
                for (int col = 0; col < (n + 1) / 2; col++)
                {
                    Swap2(matrix, n, row, col);
                }
            }
        }
    }
    public void Swap2(int[][] matrix, int n, int row, int col){
        int temp = matrix[row][col];
        matrix[row][col] = matrix[n - col - 1][row];
        matrix[n - col - 1][row] = matrix[n - row - 1][n - col - 1];
        matrix[n - row - 1][n - col - 1] = matrix[col][n - row - 1];
        matrix[col][n - row - 1] = temp;
    }
    /*
    解法三：对称翻转旋转
    先进行水平方向的对称翻转 上2行变成下2行
    再进行主对角线（左上至右下）的翻转
    */
    public void Swap3(int[][] matrix, int row1, int col1, int row2, int col2){
        int temp = matrix[row1][col1];
        matrix[row1][col1] = matrix[row2][col2];
        matrix[row2][col2] = temp;
    }
    public void function3(int[][] matrix){
        int n = matrix.Length;
        //水平翻转 上下交换位置
        for(int row = 0; row < n / 2; row++){
            for(int col = 0; col < n; col++){
                Swap3(matrix, row, col, n-row-1, col);
            }
        }
        //对角线反转 斜着交换位置
        for(int row = 0; row < n; row++){
            for(int col = 0; col < row; col++){
                Swap3(matrix, row, col, col, row);
            }
        }
    }
}
// @lc code=end

