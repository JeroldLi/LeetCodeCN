/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
using System.Collections;
public class Problem20 {

/*
解法一：
使用栈的后进先出特性
将每个符号与栈顶元素进行对比
如果能配对则将栈顶元素抛出
如果不能配对则将新括号入栈
当所有元素比较完成后，栈为空则配对成功
栈不为空则配对不成功
*/
    public bool function1(string s) {
        char[] charArray = s.ToCharArray();  //C#中将string直接转变为char字符数组的方法
        Stack<char> st = new Stack<char>();
        bool flag = false;
        foreach(char c in charArray){
            if(st.Count == 0){
                st.Push(c);
            }else{
                char top = st.Peek();  //返回栈顶数值，并不抛出栈
                if((top.Equals('(') && c.Equals(')')) ||
                (top.Equals('{') && c.Equals('}')) ||
                (top.Equals('[') && c.Equals(']'))){
                    st.Pop();  //将栈顶抛出
                    flag = true;
                }else{
                    st.Push(c);
                    flag = false;
                }
            }
        }
        if(st.Count != 0){
            flag = false;
        }
        return flag;
    }
    public bool IsValid(string s) {
        return function1(s);
    }
}
// @lc code=end

