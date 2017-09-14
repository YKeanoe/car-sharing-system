using System;
using System.Collections.Generic;
using System.Linq;
using KdTree.Math;
using KdTree;

namespace car_sharing_system.Models
{
    public class Search
    {
        private KdTree<double, string> tree;
        private List<KdTreeNode<double, string>> testNodes;
        private List<KdTreeNode<double, string>> finalNodes;
        private List<String> noPlates;

        public void Setup()
        {
            tree = new KdTree<double, string>(2, new DoubleMath());

            testNodes = new List<KdTreeNode<double, string>>();
            List<Car> cars = DatabaseReader.carQuery(null);

            foreach (Car car in cars) 
                testNodes.Add( new KdTreeNode<double, string>(
                    new double[] { (double)car.latlong.lat,
                        (double)car.latlong.lng }, car.numberPlate));
           
            AddTestNodes();
        }
        private void AddTestNodes()
        {
            foreach (var node in testNodes)
                if (!tree.Add(node.Point, node.Value)) 
                    throw new Exception(" adding in data ");
                    
            
        }

        public List<String> find(double lng, double lat) {
            noPlates = new List<string>();
            Setup();
            KdTreeNode<double, string>[] finalNodes = tree.GetNearestNeighbours(new double[] { lat, lng }, 10);
            foreach (KdTreeNode<double, string> noplate in finalNodes) {
                noPlates.Add(noplate.Value);
            }
            return noPlates;
        }
    }
}
