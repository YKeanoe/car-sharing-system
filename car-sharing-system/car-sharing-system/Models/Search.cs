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
        private List<Car> cars;

		public Search(List<Car> cars) {
			this.cars = cars;
		}

        public void Setup()
        {
            tree = new KdTree<double, string>(2, new DoubleMath());

            testNodes = new List<KdTreeNode<double, string>>();

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
			List<Car> finalCars = new List<Car>();
			Setup();
            KdTreeNode<double, string>[] finalNodes = tree.GetNearestNeighbours(new double[] { lng, lat }, 50);
            foreach (KdTreeNode<double, string> noplate in finalNodes) 
                foreach (Car car in cars)
                    if (car.numberPlate.Equals(noplate.Value)) 
                        finalCars.Add(car);
            return finalCars;
        }
    }
}
