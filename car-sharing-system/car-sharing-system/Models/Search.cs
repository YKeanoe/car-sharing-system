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
        private List<KdTreeNode<float, string>> finalNodes;
        private List<String> noPlates;

        public void Setup()
        {
            tree = new KdTree<float, string>(2, new FloatMath());

            testNodes = new List<KdTreeNode<float, string>>();
            List<Car> cars = DatabaseReader.carQuery(null);

            foreach (Car car in cars) 
                testNodes.Add( new KdTreeNode<float, string>(
                    new float[] { (float)car.latlong.lat,
                        (float)car.latlong.lng }, car.numberPlate));
           
            AddTestNodes();
        }
        private void AddTestNodes()
        {
            foreach (var node in testNodes)
                if (!tree.Add(node.Point, node.Value)) { }
                    //throw new Exception(" adding in data ");
            
        }

        public List<String> find() {
            noPlates = new List<string>();
            Setup();
            KdTreeNode<float, string>[] finalNodes = tree.GetNearestNeighbours(new float[] { -33.8674869f, 151.2069902f }, 10);
            foreach (KdTreeNode<float, string> noplate in finalNodes) {
                noPlates.Add(noplate.Value);
            }
            return noPlates;
        }
    }
}
