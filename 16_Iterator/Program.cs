using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                List<T> result = new List<T>();
                Stack<Node<T>> stack = new Stack<Node<T>>();
                stack.Push(this);

                while (stack.Count > 0)
                {
                    Node<T> current = stack.Pop();
                    result.Add(current.Value);

                    if (current.Right != null)
                        stack.Push(current.Right);
                    if (current.Left != null)
                        stack.Push(current.Left);
                }

                return result;
            }
        }
    }
}
