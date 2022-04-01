/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
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
public class Solution2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return function1(l1, l2);
    }

    public ListNode function1(ListNode l1, ListNode l2){
        int carry = 0; //进位
        ListNode head = null, tail = null;
        while (l1 != null || l2 != null)
        {
            int val1 = l1 != null ? l1.val : 0;
            int val2 = l2 != null ? l2.val : 0;
            int sum = val1 + val2 + carry;
            carry = sum / 10;
            if (head == null)
            {
                head = tail = new ListNode(sum % 10);
                //连续赋值的定义要搞清楚
                //tail = new ListNode(sum % 10);
                //head.next = tail;
            }
            else
            {
                tail.next = new ListNode(sum % 10);
                tail = tail.next;
            }

            if (l1 != null)
            {
                l1 = l1.next;
            }
            if (l2 != null)
            {
                l2 = l2.next;
            }
        }
        if (carry > 0)
        {
            tail.next = new ListNode(carry);
        }

        return head;
    }
}
// @lc code=end

