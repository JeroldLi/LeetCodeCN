/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
using leetcode;
public class Solution160 {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        //return function1(headA, headB);
        return function2(headA, headB);
    }

/*
解法一：暴力法：
遍历第一个链表，存储链表的所有节点在集合中
遍历第二个链表，若第二个链表的节点在集合中出现，则说明链表相交
时间复杂度：O(m+n) 需要遍历长度为m和n的两个链表
空间复杂度：O(m+n) 需要维护长度为m+n的集合
*/
    public ListNode function1(ListNode headA, ListNode headB){
        ISet<ListNode> nodeSet = new HashSet<ListNode>();
        while(headA!=null){
            nodeSet.Add(headA);
            headA = headA.next;
        }
        while(headB!=null){
            if(nodeSet.Contains(headB)){
                return headB;
            }
            headB = headB.next;
        }

        return null;
    }
/*
解法二：双指针
一个指针p1从A链表从头开始遍历，到A链表末尾后跳转至B链表头继续遍历
另一个指针p2从B链表头开始遍历，到B链表末尾后跳转至A链表头继续遍历
设链表A长度为m，链表B长度为n
设链表A不相交部分长度为a，链表B不相交部分长度为b，链表相交长度部分为c

若两链表相交
若a=b，则p1p2会遍历完不相交部分后相遇
若a!=b，
则p1移动的距离 = a+c+b
则p2移动的距离 = b+c+a
最终还是会相遇

若两链表不相交
若a=b，p1p2会同时变为null
若a!=b，
则p1移动m+n
p2移动n+m
最终还是同时为null

所以状态就是要么同时为null 要么相等

空间复杂度：O(1) 只需要维护两个指针
时间复杂度：O(m+n) 需要遍历长度为m和n的两个链表
*/
    public ListNode function2(ListNode headA, ListNode headB){
        if(headA == null || headB == null){
            return null;
        }
        ListNode node1 = headA;
        ListNode node2 = headB;
        while(!(node1 == null && node2 == null) &&
                !(node1 == node2)){
            if(node1 != null){
                node1 = node1.next;
            }else{
                node1 = headB;
            }

            if(node2 != null){
                node2 = node2.next;
            }else{
                node2 = headA;
            }

        }

        if(node1 == node2){
            return node1;
        }
        else{
            return null;
        }
    }
}
// @lc code=end

