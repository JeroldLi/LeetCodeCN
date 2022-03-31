/*
 * @lc app=leetcode.cn id=705 lang=csharp
 *
 * [705] 设计哈希集合
 */

// @lc code=start
public class MyHashSet
{

    bool[] function1Nodes = null; //new bool[1000009];
    public MyHashSet()
    {
        //MyHashSet1();
        MyHashSet2();
    }

    public void Add(int key)
    {
        //Add1(key);
        Add2(key);
    }

    public void Remove(int key)
    {
        //Remove1(key);
        Remove2(key);
    }

    public bool Contains(int key)
    {
        //return Contains1(key);
        return Contains2(key);
    }

    /*
    解法一：暴力法
    用简单的bool数组存储数据，只有在数量级不大的情况下适用
    */
    private void MyHashSet1()
    {
        function1Nodes = new bool[1000009];
    }

    private void Add1(int key)
    {
        function1Nodes[key] = true;
    }

    private void Remove1(int key)
    {
        function1Nodes[key] = false;
    }
    private bool Contains1(int key)
    {
        return function1Nodes[key];
    }

    /*
    解法二：链表法：
    用一个数组作为hash的定位
    在hash完毕后的每一个位置都是一个链表，当出现hash值冲突时能够保存多个值
    */
    private class Node
    {
        public int key = -1;
        public Node next = null;
        public override string ToString()
        {
            return key.ToString();
        }
    }

    private Node[] function2Nodes = null;
    private int capacity;
    private int capacity_mod;
    private int capacity_ext;
    private int size;
    private int size_max;
    private int size_ext;
    private void MyHashSet2()
    {
        resize(8);
    }
    private void Add2(int key)
    {
        insert(new Node() { key = key });
    }
    private void Remove2(int key)
    {
        int index = key % capacity_mod;
        Node node = function2Nodes[index];
        if (node == null)
        {
            return;
        }
        else if (node.key == key)
        {
            function2Nodes[index] = node.next;
        }
        else
        {
            while (node.next != null)
            {
                if (node.next.key == key)
                {
                    node.next = node.next.next;
                    return;
                }
                else
                {
                    node = node.next;
                }
            }
        }
    }
    private bool Contains2(int key)
    {
        Node node = function2Nodes[key % capacity_mod];
        while (node != null)
        {
            if (node.key == key)
            {
                return true;
            }
            else
            {
                node = node.next;
            }
        }
        return false;
    }
    private void insert(Node node)
    {
        if (size >= size_max || size_ext >= capacity_ext)
        {
            resize(capacity * 2);
        }
        int index = node.key % capacity_mod;
        if (function2Nodes[index] == null)
        {
            function2Nodes[index] = node;
        }
        else
        {
            Node parent = function2Nodes[index];
            if (parent.key == node.key)
            {
                return;
            }
            else
            {
                while (parent.next != null)
                {
                    if (parent.next.key == node.key)
                    {
                        return;
                    }
                    else
                    {
                        parent = parent.next;
                    }
                }
                parent.next = node;
                node.next = null;
            }
        }
    }
    private void resize(int capacity_new)
    {
        capacity = capacity_new;
        capacity_mod = capacity - 1;
        capacity_ext = (int)(capacity * 0.75f);
        size = 0;
        size_max = capacity - capacity_ext;
        size_ext = 0;

        Node[] nodes_old = function2Nodes;
        function2Nodes = new Node[capacity];
        if (nodes_old != null)
        {
            for (int i = 0; i != nodes_old.Length; i++)
            {
                Node node = nodes_old[i];
                while(node != null){
                    insert(node);
                    node = node.next;
                }
            }
        }
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
// @lc code=end

