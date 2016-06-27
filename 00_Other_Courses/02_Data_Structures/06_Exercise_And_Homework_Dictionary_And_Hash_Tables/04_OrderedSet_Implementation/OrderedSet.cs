namespace _04_OrderedSet_Implementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public OrderedSet()
        {
            this.Count = 0;
        }

        public int Count { get; set; }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (this.root == null)
            {
                this.root = newNode;
                this.Count++;
            }
            else
            {
                bool shouldIncreaseCount = this.FindPlace(newNode, this.root);
                if (shouldIncreaseCount)
                {
                    this.Count++;
                }
            }
        }

        public bool Contains(T item)
        {
            return this.Find(item, this.root);
        }

        public bool Remove(T item)
        {
            if (this.root.Value.CompareTo(item) == 0)
            {
                Node<T> left = this.root.LeftNode;
                this.root = this.root.RightNode;
                if (left != null)
                {
                    this.FindPlace(left, this.root);
                }
                this.Count--;
                return true;
            }
            bool shouldDecreaseCount = this.TryRemove(item, this.root);
            if (shouldDecreaseCount)
            {
                this.Count --;
            }
            return shouldDecreaseCount;


        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in this.Traversal(this.root))
            {
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Node<T>> Traversal(Node<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var leftNode in this.Traversal(node.LeftNode))
                {
                    yield return leftNode;
                }
            }

            yield return node;

            if (node.RightNode != null)
            {
                foreach (var rightNode in this.Traversal(node.RightNode))
                {
                    yield return rightNode;
                }
            }
        }

        private bool TryRemove(T item, Node<T> root)
        {
            if (this.root.Value.CompareTo(item) > 0)
            {
                if (root.LeftNode == null)
                {
                    return false;
                }
                if (root.LeftNode.Value.CompareTo(item) == 0)
                {
                    Node<T> leftOfLeft = root.LeftNode.LeftNode;
                    root.LeftNode = root.LeftNode.RightNode;
                    if (leftOfLeft != null)
                    {
                        this.FindPlace(leftOfLeft, root);
                    }
                    return true;
                }
                else
                {
                    return this.TryRemove(item, root.LeftNode);
                }
            }
            else if (root.Value.CompareTo(item) < 0)
            {
                if (root.RightNode == null)
                {
                    return false;
                }
                if (root.RightNode.Value.CompareTo(item) == 0)
                {
                    Node<T> leftOfRight = root.RightNode.LeftNode;
                    root.RightNode = root.RightNode.RightNode;
                    if (leftOfRight != null)
                    {
                        this.FindPlace(leftOfRight, root);
                    }
                    return true;
                }
                else
                {
                    return this.TryRemove(item, root.RightNode);
                }
            }
            return false;
        }

        private bool Find(T item, Node<T> root)
        {
            if (root.Value.CompareTo(item) == 0)
            {
                return true;
            }
            else if (root.Value.CompareTo(item) > 0)
            {
                if (root.LeftNode == null)
                {
                    return false;
                }
                return this.Find(item, root.LeftNode);
            }
            else if (root.Value.CompareTo(item) < 0)
            {
                if (root.RightNode == null)
                {
                    return false;
                }
                return this.Find(item, root.RightNode);
            }
            return false;
        }

        private bool FindPlace(Node<T> newNode, Node<T> root)
        {
            if (newNode.Value.CompareTo(root.Value) > 0)
            {
                if (root.RightNode == null)
                {
                    root.RightNode = newNode;
                    return true;
                }
                return this.FindPlace(newNode, root.RightNode);
            }
            else if (newNode.Value.CompareTo(root.Value) < 0)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = newNode;
                    return true;
                }
                return this.FindPlace(newNode, root.LeftNode);
            }
            return false;
        }
    }
}