/*
 * @lc app=leetcode.cn id=210 lang=csharp
 *
 * [210] 课程表 II
 */

// @lc code=start
public class Solution210 {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        //return function1(numCourses, prerequisites);
        return function2(numCourses, prerequisites);
    }
    /*
    解法一：广度优先+入度表
    */
    public int[] function1(int numCourses, int[][] prerequisites){
        List<List<int>> edges = new List<List<int>>(); //保存图中边的表
        List<int> result = new List<int>();
        //int[] outDegree = new int[numCourses];
        int[] inDegree = new int[numCourses];
        int inDegreeCount = 0; //边的个数
        for(int i = 0; i < numCourses; i++){ //初始化每一门课程对应的前置课程
            edges.Add(new List<int>());
        }
        foreach(int[] edge in prerequisites){
            edges[edge[1]].Add(edge[0]); //完成课程1之后就可以学习课程0
            inDegree[edge[0]]++; //课程0的入度+1
            inDegreeCount++;//边的个数+1
        }
        Queue<int> queue = new Queue<int>(); //用队列来保存上课的顺序
        for(int i = 0; i < numCourses; i++){ //将可以直接上的课加入队列
            if(inDegree[i] == 0){
                queue.Enqueue(i);
            }
        }
        while(queue.Count > 0){
            int cur = queue.Dequeue(); //对于当前课程
            List<int> courses = edges[cur]; //取出该课程所需的前置课程
            foreach(int course in courses){
                inDegree[course]--;
                inDegreeCount--;
                if(inDegree[course] == 0){
                    queue.Enqueue(course);
                }
            }
            result.Add(cur);
        }
        return inDegreeCount == 0 ? result.ToArray() : new int[0];
    }

    /*
    解法二：深度优先
    */
    List<List<int>> edges2;
    int[] visited;
    bool valid = true;
    public int[] function2(int numCourses, int[][] prerequisites){
        List<int> result = new List<int>();
        Stack<int> stack = new Stack<int>();
        edges2 = new List<List<int>>();
        for(int i = 0; i < numCourses; i++){  //初始化课程列表
            edges2.Add(new List<int>());
        }
        foreach(int[] edge in prerequisites){ //初始化前置课程关系
            edges2[edge[1]].Add(edge[0]);
        }
        visited = new int[numCourses];
        for(int i = 0; i < numCourses; i++){
            if(visited[i] == 0){
                DFS(i, stack);
            }
        }
        while(stack.Count != 0){
            result.Add(stack.Pop());
        }
        return valid ? result.ToArray() : new int[0];
    }
    public void DFS(int u, Stack<int> stack){
        visited[u] = 1;
        foreach(int v in edges2[u]){
            if(visited[v] == 0){
                DFS(v, stack);
                if(!valid){
                    return;
                }
            }else if(visited[v] == 1){
                valid = false;
                return;
            }
        }
        visited[u] = 2;
        stack.Push(u);
    }
}
// @lc code=end

