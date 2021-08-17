using System.Collections.Generic;
using System.Linq;

namespace algo.model
{
    public class Tree<TValue, TNode> where TNode : TreeNode<TValue>
    {
        /// <summary>
        ///     根结点
        /// </summary>
        public TNode? Root { get; set; }


        /// <summary>
        ///     前序遍历
        /// </summary>
        /// <returns></returns>
        public TValue[] PreOrder()
        {
            return Root == null ? new TValue[0] : PreOrder(Root);
        }

        /// <summary>
        ///     前序遍历
        /// </summary>
        /// <returns></returns>
        private static TValue[] PreOrder(TNode root)
        {
            if (root.Data == null) return new TValue[0];
            var result = new List<TValue>
            {
                root.Data
            };
            if (root.Children.Count < 1) return result.ToArray();
            foreach (var child in root.Children.Where(child => child != null))
                result.AddRange(PreOrder((child as TNode)!));

            return result.ToArray();
        }

        /// <summary>
        ///     后序遍历
        /// </summary>
        /// <returns></returns>
        public TValue[] PostOrder()
        {
            return Root == null ? new TValue[0] : PostOrder(Root);
        }

        /// <summary>
        ///     后序遍历
        /// </summary>
        /// <returns></returns>
        private TValue[] PostOrder(TNode root)
        {
            if (root.Data == null) return new TValue[0];

            var result = new List<TValue>
            {
                root.Data
            };
            if (root.Children.Count < 1) return result.ToArray();
            foreach (var child in root.Children) result.InsertRange(0, PreOrder((child as TNode)!));

            return result.ToArray();
        }
    }
}