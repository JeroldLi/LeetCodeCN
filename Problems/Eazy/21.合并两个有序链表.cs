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
public class Solution21 {
/*
解法一：递归法
两个链表分别新赋值两个链表游标节点
新建两个链表节点head和tail
1、若两个链表其中一个为空，则直接返回另一个链表的头节点
2、while循环迭代两个游标节点，对比游标节点值的大小，
若此时head为空，则将head，tail都设置为值更小的游标节点，
若此时head非空，则将tail的下一节点设置为值更小的游标节点，并将tail.next赋值给tail本身，即tail节点后移
相应的游标节点也后移
3、当其中一个链表完结后，将另一链表的剩余节点全部连接到tail.next上
时间复杂度O(m+n) 需要遍历两个链表
空间复杂度O(1) 新建节点
*/
    public ListNode function1(ListNode list1, ListNode list2) {
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
                    //连续赋值也可，分开赋值也可
                    //head = tail = cursorNode1;
                    head = cursorNode1;
                    tail = cursorNode1;
                }else{
                    tail.next = cursorNode1;
                    tail = tail.next;
                }
                cursorNode1 = cursorNode1.next;
            }else{
                if(head == null){
                    //head = tail = cursorNode2;
                    head = cursorNode2;
                    tail = cursorNode2;
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
/*
解法二：递归法
【重复做相同的事情就可以尝试递归思路】
【要优先考虑初始节点为null的特殊情况】
函数输入两个链表节点，返回更小的节点
并将返回的节点赋值给当前节点的next
时间复杂度O(n+m) 递归会遍历每个节点 所以是链表长度
空间复杂度O(n+m) 【每次递归调用函数会消耗栈空间】
递归的空间复杂度取决于调用深度，所以使用两个链表长度和的深度
*/
    public ListNode function2(ListNode list1, ListNode list2) {
        if(list1 == null){
            return list2;
        }else if(list2 == null){
            return list1;
        }
        else if(list1.val <= list2.val){
            list1.next = function2(list1.next, list2);
            return list1;
        }else{
            list2.next = function2(list1, list2.next);
            return list2;
        }
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        return function1(list1, list2);
        //return function2(list1, list2);
    }
}
// @lc code=end

