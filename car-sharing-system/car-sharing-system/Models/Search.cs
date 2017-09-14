using System;
using System.Collections.Generic;
using System.Linq;
using KdTree.Math;
using KdTree;
using System.Diagnostics;

namespace car_sharing_system.Models
{
    public class Search
    {
        private KdTree<double, string> tree;
        private List<KdTreeNode<double, string>> testNodes;
        private List<KdTreeNode<double, string>> finalNodes;
        private List<Car> cars;
        private List<Car> finalCars = new List<Car>();

        public void Setup()
        {
            tree = new KdTree<double, string>(2, new DoubleMath());

            testNodes = new List<KdTreeNode<double, string>>();
            cars = DatabaseReader.carQuery(null);

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

        public List<Car> find(double lng, double lat) {
            Setup();
            KdTreeNode<double, string>[] finalNodes = tree.GetNearestNeighbours(new double[] { lng, lat }, 10);
            foreach (KdTreeNode<double, string> noplate in finalNodes) {
                foreach (Car car in cars)
                {
                    Debug.WriteLine(noplate.Value);
                    if (car.numberPlate.Equals(noplate.Value)) 
                        finalCars.Add(car);
                }
            }
            return finalCars;
        }
    }
}
