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
public class Problem160 {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        //return function1(headA, headB);
        return function2(headA, headB);
    }

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

