/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * [21] 合并两个有序链表
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
public class Problem21 {
    public ListNode MergeTwoLists1(ListNode list1, ListNode list2) {
        ListNode cursorNode1 = list1;
        ListNode cursorNode2 = list2;
        ListNode head = null;
        ListNode tail = null;

        if(head == null){
            if(cursorNode1 == null){
                return cursorNode2;
            }else if(cursorNode2 == null){
                return cursorNode1;
            }
        }

        while(cursorNode1 != null && cursorNode2 != null){
            if(cursorNode1.val <= cursorNode2.val){
                if(head == null){
                    head = tail = cursorNode1;
                }else{
                    tail.next = cursorNode1;
                    tail = tail.next;
                }
                cursorNode1 = cursorNode1.next;
            }else{
                if(head == null){
                    head = tail = cursorNode2;
                }else{
                    tail.next = cursorNode2;
                    tail = tail.next;
                }
                cursorNode2 = cursorNode2.next;
            }
        }

        if(cursorNode1 == null){
            tail.next = cursorNode2;
        }else if(cursorNode2 == null){
            tail.next = cursorNode1;
        }
        return head;
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null){
            return list2;
        }else if(list2 == null){
            return list1;
        }
        else if(list1.val <= list2.val){
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }else{
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
// @lc code=end

