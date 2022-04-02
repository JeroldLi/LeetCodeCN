/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 */

// @lc code=start
public class Solution3
{
    public int LengthOfLongestSubstring(string s)
    {
        //return function1(s);
        return function2(s);
    }
    /*
    解法一：暴力法
    直接双重循环遍历
    出现重复的字符就跳出
    超时
    */
    public int function1(string s)
    {
        int len = s.Length;
        int max = 0;
        for (int cur1 = 0; cur1 < len; cur1++)
        {
            if (max < len - cur1)
            {
                List<char> sb = new List<char>();
                int count = 0;
                for (int cur2 = cur1; cur2 < len; cur2++)
                {
                    if (!sb.Contains(s[cur2]))
                    {
                        sb.Add(s[cur2]);
                        count++;
                    }
                    else
                    {
                        max = Math.Max(max, count);
                        sb.Clear();
                        count = 0;
                    }
                }
                max = Math.Max(max, count);
            }
        }
        return max;
    }
    /*
    解法二：滑动窗口
    */
    public int function2(string s)
    {
        int maxLength = 0;
        int start = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int cur = start; cur < s.Length; cur++)
        {
            if (!dict.ContainsKey(s[cur]))
            {
                dict.Add(s[cur], 1);
            }
            else
            {
                dict[s[cur]]++;
            }

            if (dict.Count == cur - start + 1)
            {
                maxLength = Math.Max(maxLength, cur - start + 1);
            }
            while (cur - start + 1 > dict.Count)
            {
                dict[s[start]]--;
                if (dict[s[start]] == 0)
                {
                    dict.Remove(s[start]);
                }
                start++;
            }
        }
        return maxLength;
    }
}
// @lc code=end

