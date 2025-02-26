using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2296
/// title: 设计一个文本编辑器
/// problems: https://leetcode.cn/problems/design-a-text-editor
/// date: 20250227
/// </summary>
public static class Solution2296
{
    public class Node {
        public char Val;
        public Node Prev, Next;

        public Node(char val) {
            Val = val;
        }

        public void Insert(char val) {
            Node node = new Node(val);
            node.Next = this;
            node.Prev = this.Prev;
            if (this.Prev != null) {
                this.Prev.Next = node;
            }
            this.Prev = node;
        }

        public void Remove() {
            Node node = this.Prev;
            this.Prev = node.Prev;
            if (node.Prev != null) {
                node.Prev.Next = this;
            }
        }

        public string Range(Node end) {
            StringBuilder sb = new StringBuilder();
            Node node = this;
            while (node != end) {
                sb.Append(node.Val);
                node = node.Next;
            }
            return sb.ToString();
        }
    }

    // 参考解答
    public class TextEditor {
        private Node cursor;

        public TextEditor() {
            cursor = new Node('\0');
        }

        public void AddText(string text) {
            foreach (char c in text) {
                cursor.Insert(c);
            }
        }

        public int DeleteText(int k) {
            int count = 0;
            while (k > 0 && cursor.Prev != null) {
                cursor.Remove();
                k--;
                count++;
            }
            return count;
        }

        public string CursorLeft(int k) {
            while (k > 0 && cursor.Prev != null) {
                cursor = cursor.Prev;
                k--;
            }
            Node head = cursor;
            for (int i = 0; i < 10 && head.Prev != null; i++) {
                head = head.Prev;
            }
            return head.Range(cursor);
        }

        public string CursorRight(int k) {
            while (k > 0 && cursor.Next != null) {
                cursor = cursor.Next;
                k--;
            }
            Node head = cursor;
            for (int i = 0; i < 10 && head.Prev != null; i++) {
                head = head.Prev;
            }
            return head.Range(cursor);
        }
    }

}
