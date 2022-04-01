/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
using leetcode;
public class Solution206 {
    public ListNode ReverseList(ListNode head) {
        //return function1(head);
        return function2(head);
    }

    /*
    解法一：双指针1
    设置三个游标节点 pre, cur, next
    用next暂存pre的next节点
    随后使用pre和cur进行局部反转
    局部反转完成后 pre和cur同时向后移动一个节点
    如此循环直至pre为null
    此时cur为反转完成后的链表头节点
    */
    public ListNode function1(ListNode head){
        ListNode cur = null;
        ListNode pre = head;
        while(pre != null){
            ListNode next = pre.next;  //暂存next节点 不然无法继续进行
            pre.next = cur; //pre节点进行反转
            cur = pre; //cur向前移动一节点
            pre = next; //pre向前移动一节点
        }
        return cur;
    }

    /*
    解法二：递归法
    递归到链表的最后一个节点，这就是反转后的头，记为ret
    */
    public ListNode function2(ListNode head) {
        if(head == null || head.next == null){  //边界
            return head;
        }
        ListNode newHead = ReverseList(head.next);  //递归
        head.next.next = head;  //在最后一个节点时 head.next 就是newhead
        //此时将newhead的next指向自己
        head.next = null;  //自己的next指向空
        return newHead;  //退出栈
    }

}
// @lc code=end

