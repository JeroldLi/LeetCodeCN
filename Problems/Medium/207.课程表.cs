/*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 */

// @lc code=start
public class Solution207 {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        //return function1(numCourses, prerequisites);
        return function2(numCourses, prerequisites);
    }
    /*
    解法一：拓扑排序
    广度优先搜索 维护入度表
    使用队列
    */
    public bool function1(int numCourses, int[][] prerequisites){
        LinkedList<int>[] outDegree = new LinkedList<int>[numCourses];
        //初始化出度表
        for(int i = 0; i < outDegree.Length; i++){
            outDegree[i] = new LinkedList<int>();
        }
        //记录每门课程的入度数量
        int inDegreeCount = 0;
        int[] inDegree = new int[numCourses];
        foreach(var item in prerequisites){ // prerequisites[i] = [ai, bi] item[1]是item[0]的先修课程
            outDegree[item[1]].AddLast(item[0]);//出度表
            inDegree[item[0]]++;//科目的入度+1
            inDegreeCount++;//边的数量
        }
        //使用队列遍历图
        //先将入度为0的课程进队
        //即不需要先修课程便可上课
        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(inDegree[i] == 0){
                queue.Enqueue(i);
            }
        }
        while(queue.Count > 0){
            int cur = queue.Dequeue(); //头部出队 上某一门课
            LinkedListNode<int> node = outDegree[cur].First; //找到以这门课作为前置课程的链表
            while(node != null){
                int course = node.Value;
                inDegree[course]--;  //以这门课为前置课程的课的入度都-1
                inDegreeCount--;  //边的长度-1
                if(inDegree[course] == 0){ //如果某一门课的入度为0 则加入队列准备上课
                    queue.Enqueue(course);
                    /*
                    当一门课程的入度为0时才会加入队列
                    当图中出现环时，终会遇到某些节点的入度不为0
                    此后队列为空跳出循环 不会导致死循环
                    并且跳出循环后图中边的值不为0
                    因此判断边的值是否为0（完全消除）可以确定图中有没有环
                    */
                }
                node = node.Next; //遍历链表 将所有以这门课为前置课程的课都计算一次
            }
        }
        return inDegreeCount == 0;
    }
    /*
    解法二：深度优先搜索
    */
    List<IList<int>> edges;//边组成的列表 保存前置课程的关系
    int[] visited;//状态数列 0=未计算 1=计算中 2=已计算
    bool valid = true; //环状态 false代表遇到自己(计算中) 即经过环回到自身
    public bool function2(int numCourses, int[][] prerequisites){
        edges = new List<IList<int>>();
        for(int i = 0; i < numCourses; i++){ //初始化课程列表
            edges.Add(new List<int>());
        }
        foreach(int[] info in prerequisites){ //初始化前置课程关系
            edges[info[0]].Add(info[1]); //1是0的前置课程
        }
        visited = new int[numCourses]; //初始化每门课程的计算(学习)情况

        for(int i = 0; i < numCourses; i++){ //遍历每门课程
            if(visited[i] == 0){ //如果该课程没有上过
                DFS(i); //从该课程开始深度优先遍历
            }
        }
        return valid;
    }
    public void DFS(int u){
        visited[u] = 1; //先将本课程置为计算中
        foreach(int v in edges[u]){ //遍历本课程所需要的前置课程
            if(visited[v] == 0){ //如果前置课程没有上过
                DFS(v);//就先去上前置课程
                if(!valid){//如果上前置课程的过程中出现了环就跳出
                    return;
                }
            }else if(visited[v] == 1){//如果前置课程已经处于正在计算的状态 说明出现了环 跳出
                valid = false;
                return;
            }
        }
        visited[u] = 2;//本课程的前置课程都上完后 本课程记为上过(计算完成)
    }

}
// @lc code=end

