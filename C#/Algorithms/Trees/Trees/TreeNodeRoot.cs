using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    internal class TreeNodeRoot
    {
        TreeNode root = new TreeNode();

        public void AddScore(int value)
        {
            TreeNode current = this.root;
            current = current.Add(value);
        }

        public bool ContainsScore(int value)
        {
            TreeNode current = this.root;
            current = current.Get(value);
            if(current == null)
            {
                return false;
            }

            return current != null;
        }
    }
}
