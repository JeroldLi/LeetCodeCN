/*
 * @lc app=leetcode.cn id=706 lang=csharp
 *
 * [706] 设计哈希映射
 */

// @lc code=start
public class MyHashMap {
    private int N1 = 1000009;
    private int N2 = 1009;
    private int INF = int.MaxValue;
    private int[] function1Nodes = null; //new int[1000009];
    private Node[] function2Nodes = null;
    private int baseMod = 769;
    public MyHashMap() {
        MyHashMap2();
        //MyHashMap1();
    }
    public void Put(int key, int value) {
        Put2(key, value);
        //Put1(key, value);
    }
    public int Get(int key) {
        return Get2(key);
        //return Get1(key);
    }
    public void Remove(int key) {
        Remove2(key);
        //Remove1(key);
    }

    /*
    解法一：暴力法：
    */
    private void MyHashMap1(){
        function1Nodes = new int[N1];
        Array.Fill(function1Nodes, INF);
    }
    private void Put1(int key, int value){
        function1Nodes[key] = value;
    }
    private int Get1(int key){
        return function1Nodes[key] == INF ? -1 : function1Nodes[key];
    }
    private void Remove1(int key){
        function1Nodes[key] = INF;
    }

    /*
    解法二：链表法
    */
    public class Node{
        public int _key;
        public int _value;
        public Node next;
        public Node(int key, int value){
            _key = key;
            _value = value;
            next = null;
        }
    }
    private void MyHashMap2(){
        function2Nodes = new Node[N2];
    }
    private int hash(int key){
        return key % baseMod;
    }
    private void Put2(int key, int value){
        int index = hash(key);
        if(function2Nodes[index] == null){
            function2Nodes[index] = new Node(key, value);
        }else{
            Node temp = function2Nodes[index];
            Node prev = null;
            while(temp != null){
                if(temp._key == key){
                    temp._value = value;
                    return;
                }else{
                    prev = temp;
                    temp = temp.next;
                }
            }
            temp = prev;
            Node newNode = new Node(key, value);
            temp.next = newNode;
        }
    }
    private int Get2(int key){
        int index = hash(key);
        Node temp = function2Nodes[index];
        if(temp != null){
            while(temp != null){
                if(temp._key == key){
                    return temp._value;
                }
                temp = temp.next;
            }
        }
        return -1;
    }
    private void Remove2(int key){
        int index = hash(key);
        if(function2Nodes[index] != null){
            Node temp = function2Nodes[index];
            Node prev = null;
            while(temp != null){
                if(temp._key == key){
                    if(prev == null){
                        function2Nodes[index] = temp.next;
                    }else{
                        prev.next = temp.next;
                    }
                    return;
                }
                prev = temp;
                temp = temp.next;
            }
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
// @lc code=end

