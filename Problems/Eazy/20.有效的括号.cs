/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
using System.Collections;
public class Problem20 {
    public bool function1(string s) {
        char[] charArray = s.ToCharArray();
        Stack<char> st = new Stack<char>();
        bool flag = false;
        foreach(char c in charArray){
            if(st.Count == 0){
                st.Push(c);
            }else{
                char top = st.Peek();
                if((top.Equals('(') && c.Equals(')')) ||
                (top.Equals('{') && c.Equals('}')) ||
                (top.Equals('[') && c.Equals(']'))){
                    st.Pop();
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

