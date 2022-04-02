/*
 * @lc app=leetcode.cn id=151 lang=csharp
 *
 * [151] 翻转字符串里的单词
 */

// @lc code=start
using System.Text;
public class Solution151 {
    public string ReverseWords(string s) {
        //return function1(s);
        //return function2(s);
        return function3(s);
    }
    /*
    解法一：暴力法
    使用语言自带api
    */
    public string function1(string s){
        //1、删除前后空格
        s = s.Trim();
        //2、拆分空格
        string[] temp = s.Split(' ',StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(temp);
        //拼接字符串
        s = string.Join(" ", temp);
        return s;
    }

    /*
    解法二：自己实现暴力法的代码
    C#中string是不变的字符串
    要使用stringbuilder来操作
    */
    //去除空格
    public StringBuilder TrimSpace(string s){
        //去除首尾空格
        int left = 0;
        int right = s.Length - 1;
        while(left <= right && s[left] == ' '){
            left++;
        }
        while(left <= right && s[right] == ' '){
            right--;
        }
        //去除字符中空格
        StringBuilder sb = new StringBuilder();
        while(left <= right){
            char c = s[left];
            if(c != ' '){
                sb.Append(c);
            }else if(sb[sb.Length - 1] != ' '){
                sb.Append(c);
            }
            left++;
        }
        return sb;
    }
    //反转整个字符串
    public void MyReverse(StringBuilder s, int left, int right){
        while(left < right){
            char temp = s[left];
            s[left++] = s[--right];
            s[right] = temp;
            // left++;
            // right--;
        }
    }
    //反转每个单词
    //其实就是对每个单词再使用一遍翻转字符串
    public void MyReverseEachWord(StringBuilder s){
        int len = s.Length;
        int wordStart = 0;
        int wordEnd = 0;
        while(wordStart < len){
            while(wordEnd < len && s[wordEnd] != ' '){
                wordEnd++;
            }
            MyReverse(s, wordStart, wordEnd); //去掉word末尾的空格
            wordStart = wordEnd + 1;
            wordEnd++;
        }
    }

    public string function2(string s){
        StringBuilder sb = TrimSpace(s);
        MyReverse(sb, 0, sb.Length);
        MyReverseEachWord(sb);
        s = sb.ToString();
        return s;
    }
    /*
    解法三：使用栈的先进后出特性来翻转单词
    */
    public string function3(string s){
        int len = s.Length;
        int left = 0;
        int right = len - 1;
        //去除首尾空格
        while(left <= right && s[left] == ' '){
            left++;
        }
        while(left <= right && s[right] == ' '){
            right--;
        }

        Stack<string> stack = new Stack<string>();
        StringBuilder aWord = new StringBuilder();
        while(left <= right){
            if(aWord.Length != 0 && s[left] == ' '){
                stack.Push(aWord.ToString());
                aWord.Clear();
            }else if(s[left] != ' '){
                aWord.Append(s[left]);
            }
            left++; //跳过遇到的空格
        }
        stack.Push(aWord.ToString());
        return string.Join(" ",stack);
    }
}
// @lc code=end

