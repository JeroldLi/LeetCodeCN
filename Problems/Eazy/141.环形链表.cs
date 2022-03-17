/*
 * @lc app=leetcode.cn id=141 lang=csharp
 *
 * [141] 环形链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
using leetcode;
public class Problem141 {
    public bool HasCycle(ListNode head) {
        return function1(head);
        //return function2(head);
    }

    public bool function1(ListNode node){
        ISet<ListNode> nodeSet = new HashSet<ListNode>();
        while(node != null){
            if(nodeSet.Contains(node.next)){
                return true;
            }else{
                nodeSet.Add(node);
            }
            node = node.next;
        }
        return false;
    }

    public bool function2(ListNode node){
        if(node == null || node.next == null){
            return false;
        }
        ListNode slowNode = node;
        ListNode fastNode = node.next;

        while(slowNode != fastNode){
            if(fastNode.next == null || fastNode.next.next == null){
                return false;
            }
            slowNode = slowNode.next;
            fastNode = fastNode.next.next;
        }
        return true;
    }
}
// @lc code=end

