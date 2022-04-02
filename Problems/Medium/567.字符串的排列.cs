/*
 * @lc app=leetcode.cn id=567 lang=csharp
 *
 * [567] 字符串的排列
 */

// @lc code=start
public class Solution567 {
    public bool CheckInclusion(string s1, string s2) {
        return function1(s1, s2);
    }
    /*
    解法一：定长滑动窗口
    */
    public bool function1(string s1, string s2){
        int s1Len = s1.Length;
        int s2Len = s2.Length;
        if(s1Len > s2Len){
            return false;
        }
        int[] s1Array = new int[26];
        int[] s2Array = new int[26];

        for(int cur = 0; cur < s1Len; cur++){
            s1Array[s1[cur] - 'a']++;
            s2Array[s2[cur] - 'a']++;
        }

        if(Enumerable.SequenceEqual(s1Array, s2Array)){
            return true;
        }

        for(int cur = 0; cur < s2Len - s1Len; cur++){
            s2Array[s2[cur] - 'a']--;
            s2Array[s2[cur + s1Len] - 'a']++;
            if(Enumerable.SequenceEqual(s1Array, s2Array)){
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

