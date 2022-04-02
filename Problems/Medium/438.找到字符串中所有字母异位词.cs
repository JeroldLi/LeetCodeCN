/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 */

// @lc code=start
public class Solution438 {
    public IList<int> FindAnagrams(string s, string p) {
        //return function1(s, p);
        return function2(s, p);
    }
    /*
    解法一：滑动窗口
    */
    public IList<int> function1(string s, string p){
        Dictionary<char, int> dict = new Dictionary<char, int>(); //保存p的字母情况
        foreach(char c in p){
            if(dict.ContainsKey(c)){
                dict[c]++;
            }else{
                dict.Add(c, 1);
            }
        }
        Dictionary<char, int> dictCur = new Dictionary<char, int>(); //游标经过的字符
        IList<int> result = new List<int>();  //保存起始索引
        int start = 0;
        for(int end = 0; end < s.Length; end++){
            if(dictCur.ContainsKey(s[end])){
                dictCur[s[end]]++;
            }else{
                dictCur.Add(s[end], 1);
            }
            if(DictEquals(dict, dictCur)){
                result.Add(start);
            }

            if(end >= p.Length - 1){
                dictCur[s[start]]--;
                if(dictCur[s[start]] == 0){
                    dictCur.Remove(s[start]);
                }
                start++;
            }
        }
        return result;
    }

    public bool DictEquals(Dictionary<char, int> x, Dictionary<char, int> y)
    {
        if (x.Count != y.Count)
            return false;
        if (x.Keys.Except(y.Keys).Any())
            return false;
        if (y.Keys.Except(x.Keys).Any())
            return false;
        foreach (var pair in x)
            if (!pair.Value.Equals(y[pair.Key]))
                return false;
        return true;
    }

/*
解法二：滑动窗口 但是不用词典用数组
而且是定长窗口
*/
    public IList<int> function2(string s, string p){
        IList<int> result = new List<int>();
        int sLen = s.Length;
        int pLen = p.Length;
        if(sLen < pLen){
            return result;
        }
        int[] sArray = new int[26];
        int[] pArray = new int[26];
        for(int cur = 0; cur < pLen; cur++){
            sArray[s[cur] - 'a']++;
            pArray[p[cur] - 'a']++;
        }

        if(Enumerable.SequenceEqual(sArray, pArray)){
            result.Add(0);
        }

        for(int cur = 0; cur < sLen - pLen; cur++){
            sArray[s[cur] - 'a']--;
            sArray[s[cur + pLen] - 'a']++;
            if(Enumerable.SequenceEqual(sArray,pArray)){
                result.Add(cur+1);
            }
        }
        return result;
    }
}
// @lc code=end

