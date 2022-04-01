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
public class Solution141 {
    public bool HasCycle(ListNode head) {
        return function1(head);
        //return function2(head);
    }

/*
解法一：暴力法
遍历链表节点，并用集合存储已遍历的节点
如果节点已在集合中，则表示有环存在
时间复杂度：O(n) 遍历n个节点
空间复杂度：O(n) 需要存储n个节点
*/
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

/*
解法二：快慢指针
时间复杂度：O(n) 遍历n个节点
空间复杂度：O(1) 只需要维护快慢指针的变量
设置一个慢指针一次移动1个节点
设置一个快指针一次移动2个节点
当快指针移动到与慢指针重叠，则说明有环存在
若快指针最终指向空，则说明环不存在
相信套圈终会重合【追及问题】

在面试中双指针的思路适用于
【获取倒数第k个元素】：先让其中一个指针前进k距离，使两个指针之间距离为k，再同时移动双指针使前一个指针指向空，此时后指针为倒数第k个元素
【获取中间位置的元素】：快指针一次移动2格，慢指针一次移动1格，双指针同时移动，当快指针无法继续向后移动两格时，慢指针就在链表中间（奇数），或链表中间节点的前1个（偶数）
【判断链表是否存在环】：追及问题，直到快慢指针第一次相遇
【判断环的长度】：追及问题，快慢指针每次移动，他们之间的距离都-1，当快慢指针第二次相遇时，移动的距离即是环的长度
*/
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

