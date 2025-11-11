using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trees
{
    public class TreeNode
    {
        public int value;
        Dictionary<int, TreeNode> dict;

        public TreeNode Add(int value)
        {
            if(this.dict == null)
            {
                this.dict = new Dictionary<int, TreeNode>();
            }

            TreeNode result;
            if(this.dict.TryGetValue(value, out result))
            {
                return result;
            }

            result = new TreeNode();
            this.dict[value] = result;
            return result;
        }

        public TreeNode Get(int value) 
        {
            if(this.dict == null)
            {
                return null;
            }
            TreeNode result;
            if (this.dict.TryGetValue(value,out result))
            {
                return result;
            }
            return null;
        }
    }
}
