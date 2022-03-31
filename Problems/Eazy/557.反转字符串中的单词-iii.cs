/*
 * @lc app=leetcode.cn id=557 lang=csharp
 *
 * [557] 反转字符串中的单词 III
 */

// @lc code=start
public class Problem557 {
    public string ReverseWords(string s) {
        return function1(s);
    }

/*
解法一：暴力法
遍历每个字符
读取到空格就记录当前词的起始、结束位、长度
用char数组保存反转后的单词和空格
最后拼接字符数组
*/
    public string function1(string s){
        List<char> tempList = new List<char>();
        int i = 0;
        while(i < s.Length){
            int start = i;
            while(i < s.Length && s[i] != ' '){
                i++;
            }
            for(int j = start; j < i; j++){
                tempList.Add(s[start+i-1-j]);
            }
            while(i < s.Length && s[i] == ' '){
                i++;
                tempList.Add(' ');
            }
        }
        return string.Join("", tempList);
    }
}
// @lc code=end

