using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Projection_Library.Classes.Data.Xml
{
    public abstract class XObj
    {
        public abstract XObj FromNode();
        public abstract XmlNode ToNode();
        public XmlNode GetDottedNode(XmlNode node, string dotted_node)
        {
            string[] segments = null;
            XmlNode curNode = null;
            if (dotted_node.Contains("."))
                segments = dotted_node.Split('.');
            else
                segments = new string[] { dotted_node };
            for(int i = 0; i < segments.Length; i++)
            {
                curNode = GetNode(node, segments[i]);
                if (curNode == null) break;
            }
            return null;
        }
        private XmlNode GetNode(XmlNode node, string dotted_node)
        {            
            if (node.ChildNodes == null) return null;
            foreach (XmlNode child in node.ChildNodes)
                if (child.Name.Equals(dotted_node))
                    return child;            
            return null;
        }

    }
}
