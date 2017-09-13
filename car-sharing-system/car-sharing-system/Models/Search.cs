using System;
using System.Collections.Generic;
using System.Linq;
using KdTree.Math;
using KdTree;

namespace car_sharing_system.Models
{
    public class Search
    {
        private KdTree<float, string> tree;
        private List<KdTreeNode<float, string>> testNodes;

        public void Setup()
        {
            tree = new KdTree<float, string>(2, new FloatMath());

            testNodes = new List<KdTreeNode<float, string>>();
            testNodes.AddRange(new KdTreeNode<float, string>[]
            {
                new KdTreeNode<float, string>(new float[] { -27.5829487f, 151.8643252f }, "Root"),

                new KdTreeNode<float, string>(new float[] { -27.4710107f, 153.0234489f }, "Root-Left"),
                new KdTreeNode<float, string>(new float[] { -28.0172605f, 153.4256987f }, "Root-Right"),

                new KdTreeNode<float, string>(new float[] { -27.3748288f, 153.0554193f }, "Root-Left-Left"),

                new KdTreeNode<float, string>(new float[] { -37.814107f, 144.96328f }, "Root-Right-Right")
            });
            AddTestNodes();
        }
        private void AddTestNodes()
        {
            foreach (var node in testNodes)
                if (!tree.Add(node.Point, node.Value))
                  throw new Exception("Failed to add node to tree");
        }


        public String find() {
            Setup();
            String test = tree.GetNearestNeighbours(new float[] { -33.8674869f, 151.2069902f }, 2)[1].Value.ToString();
            return test;
        }
    }
}
