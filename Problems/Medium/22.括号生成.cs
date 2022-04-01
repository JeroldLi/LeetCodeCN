/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution22 {
    public IList<string> GenerateParenthesis(int n) {
        //return function1(n);
        //return function2(n);
        //return function3(n);
        //return function4(n);
        //return function5(n);
        return function6(n);
    }

    /*
    解法一：暴力法
    将一个完整的括号()作为整体
    依次在已完成的括号对中插入，每插入一个位置就保存一个新值
    */
    public IList<string> function1(int n){
        if(n == 1){
            return new List<string>() {"()"};
        }
        //List<string> resultList = new List<string>();
        HashSet<string> hs = new HashSet<string>();
        //resultList.Add("()");
        hs.Add("()");
        int index = 1;
        while(index < n){
            List<string> tempList = new List<string>();
            foreach(string temp in hs){
                for(int i = 0; i < temp.Length; i++){
                    string newString = $"{temp.Substring(0, i)}(){temp.Substring(i, temp.Length - i)}";
                    tempList.Add(newString);
                }
            }
            foreach(string temp in tempList){
                hs.Add(temp); //hashset自动去重
            }
            index++;
        }
        foreach(string del in hs){
            if(del.Length != n*2){
                hs.Remove(del);  //去除括号对数不满足条件的值
            }
        }
        return hs.ToList();
    }
    /*
    解法二：动态规划
    考虑 dp[i] 比 dp[i-1]增加的那一组括号()的位置
    新增的括号(a)b，将dp[i-1]的情况遍历后填入a和b
    "(" + A + ")" + B
    A=【i=p时所有括号的排列组合】
    B=【i=q时所有括号的排列组合】
    p+q = n - 1的意思是：第n-1对括号被新括号划分为p和q两部分 所以p和q的和等于n-1
    */
    List<string>[] cache;
    public IList<string> function2(int n){
        cache = new List<string>[2*n];
        return Generate(n);
    }
    public List<string> Generate(int num){
        if(cache[num] != null){  //动态规划 有f(n-1)的值就直接调用 避免过多的迭代
            return cache[num];
        }
        List<string> ans = new List<string>();
        //每次生成n对时才保存在局部变量中
        //不会出现其他解的结果
        if(num == 0){
            ans.Add("");
        }else{
            for(int i = 0; i < num; i++){
                List<string> left = Generate(i); //p
                List<string> right = Generate(num - 1 - i); //q = n-1-p
                foreach(string leftStr in left){
                    foreach(string rightStr in right){
                        ans.Add($"({leftStr}){rightStr}");
                    }
                }
            }
        }
        cache[num] = ans; //保存dp变化情况避免多余的运算
        return ans;
    }
    /*
    解法三：二叉树+深度遍历+做加法
    【记录使用了几个括号】
    生成分叉的条件是：
    1、左右括号的使用量不大于n
    2、生成左分叉需要左括号使用量不大于n
    3、生成右分叉需要右括号的使用量不大于左括号
    4、当左右括号的使用量等于n时结算
    */
    List<string> result = new List<string>();
    public void DFS_Add(string paths, int left, int right, int n){
        if(paths.Length == n * 2){ //等价于left==n && right==n
            result.Add(paths);
            return;
        }
        if(right > left){
            return;
        }
        if(left < n){
            DFS_Add(paths + "(", left + 1, right, n);
        }
        if(right < n){
            DFS_Add(paths + ")", left, right + 1, n);
        }
    }
    public List<string> function3(int n){
        if(n <= 0){
            return null;
        }
        DFS_Add("", 0, 0, n);
        return result;
    }

    /*
    解法四：二叉树+深度遍历+做减法
    【记录还剩余几个括号】
    生成分叉的条件是：
    1、左右括号的剩余数量都大于0
    2、产生左分叉需要左括号剩余量大于0
    3、产生右分叉需要右括号剩余量大于左括号剩余量才可以生成
    4、左右括号剩余量都等于0时结算
    */
    public void DFS_Sub(string curStr, int left, int right, List<string> res){
        if(left == 0 && right == 0){ //结算
            res.Add(curStr);
            return;
        }
        if(left > right){ //左大于右 不符合条件 不做操作(剪枝)
            return;
        }
        if(left > 0){
            //左括号大于0，可以发展左分支
            //左括号余量-1 递归计算
            DFS_Sub(curStr + "(", left - 1, right, res);
        }
        if(right > 0){
            //右括号余量大于0 且之前已经判断过左括号余量>右括号余量
            //右括号余量-1 递归计算
            DFS_Sub(curStr + ")", left, right - 1, res);
        }
    }

    public List<string> function4(int n){
        List<string> res = new List<string>();
        if(n == 0){
            return res;
        }
        DFS_Sub("", n, n, res);
        return res;
    }
    /*
    解法五：广度优先遍历
    */
    public class Node{  //BFS需要自己编写结构类
        public string res {get; set; } //当前得到的字符串
        public int left {get; set; } //左括号的剩余量
        public int right {get; set; } //右括号的剩余量
        public Node(string str, int left, int right){
            this.res = str;
            this.left = left;
            this.right = right;
        }
    }
    public List<string> function5(int n){
        List<string> res = new List<string>();
        if(n == 0){
            return res;
        }
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node("", n, n));  //初始节点进入队列
        //广度优先遍历就是对二叉树一层层地向下计算 所以未计算完的节点(因为不到叶子节点并不知道这一条路是否走得通)
        //都要存在队列里
        while(queue.Count > 0){  //遍历队列中的所有节点
            Node curNode = queue.Dequeue();
            if(curNode.left == 0 && curNode.right == 0){ //如果当前节点的左右括号均用完 则结算
                res.Add(curNode.res);
            }
            if(curNode.left > 0){ //当前节点还有左括号剩余 继续试着加入左括号
                queue.Enqueue(new Node(curNode.res + "(", curNode.left - 1, curNode.right));
            }
            if(curNode.right > 0 && curNode.left < curNode.right){ //右括号剩余不能大于左括号
                queue.Enqueue(new Node(curNode.res + ")", curNode.left, curNode.right - 1));
            }
        }
        return res;
    }
    /*
    解法六：严格的回溯算法：
    和解法4有什么区别？
    看完39-47题再来思考
    目前看来和解法四只是显性的操作了增加和删除这个[恢复现场][撤销选择]的操作
    */
    public List<string> function6(int n){
        List<string> res = new List<string>();
        if(n == 0){
            return res;
        }

        System.Text.StringBuilder path = new System.Text.StringBuilder();
        BackTrace(path, n, n, res);
        return res;
    }
    public void BackTrace(System.Text.StringBuilder path, int left, int right, List<string>res){
        if(left == 0 && right == 0){
            res.Add(path.ToString());
            return;
        }
        if(left > right){
            return;
        }
        if(left > 0){
            path.Append("(");
            BackTrace(path, left - 1, right, res);
            path.Remove(path.Length - 1, 1);  //移除最后一个？
        }
        if(right > 0){
            path.Append(")");
            BackTrace(path, left, right - 1, res);
            path.Remove(path.Length - 1, 1);
        }
    }
}
// @lc code=end

