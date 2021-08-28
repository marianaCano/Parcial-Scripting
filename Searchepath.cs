using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Searchepath
    {
      
        public static Dictionary<(int, int), Node> _block = new Dictionary<(int, int), Node>();
        public static (int, int)[] _directions = { (0,1), (-1, 0), (1,0), (0,-1)};    
        public static Queue<Node> _queue = new Queue<Node>();      
        public static Node _searchingPoint;                          
        public static bool _isExploring = true;                       
        public static Node _startingPoint;
        public static Node _endingPoint;

        public static List<Node> _path = new List<Node>();            
        
        public static void LoadAllBlocks(Node[] nodes)
        {
           
            foreach (Node node in nodes)
            {
                (int, int) gridPos = (node.X, node.Y);

                if (_block.ContainsKey(gridPos) == false)
                {
                    _block.Add(gridPos, node);
                   // Console.WriteLine("agregado" + node.X + ", " + node.Y);
                    //Console.ReadKey();
                }
            }

        }

        public static void BFS(Node StartPoint, Node EndPoint)
        {
            _startingPoint = StartPoint;
            _endingPoint= EndPoint;
            _queue.Enqueue(_startingPoint);
            while (_queue.Count > 0 && _isExploring)
            {
                _searchingPoint = _queue.Dequeue();
               // Console.WriteLine(_searchingPoint.X + ", " + _searchingPoint.Y);
                OnReachingEnd();
                ExploreNeighbourNodes();
             //   Console.WriteLine("holaa" + _queue.Count + _isExploring);
               // Console.ReadLine();
            }
        }

        public static void OnReachingEnd()
        {
            if (_searchingPoint == _endingPoint)
            {
                _isExploring = false;
            }
            else
            {
                _isExploring = true;
            }
        }

        public static void ExploreNeighbourNodes()
        {
            if (!_isExploring) { return; }

            foreach ((int, int) direction in _directions)
            {
                (int, int) neighbourPos =( _searchingPoint.X + direction.Item1, _searchingPoint.Y + direction.Item2 );
              //  Console.WriteLine("compañerito" + neighbourPos.Item1 + ", " + neighbourPos.Item2);
                //Console.ReadKey();
                if (_block.ContainsKey(neighbourPos))               
                {
                    Node node = _block[neighbourPos];

                    if (!node.isExplored)
                    {
                        _queue.Enqueue(node);                       
                        node.isExplored = true;
                      //  Console.WriteLine("explorando");
                        node.isExploredFrom = _searchingPoint;      
                    }
                }
            }
        }

        public static void CreatePath()
        {
            SetPath(_endingPoint);
            Node previousNode = _endingPoint.isExploredFrom;

            while (previousNode != _startingPoint)
            {
                SetPath(previousNode);
                previousNode = previousNode.isExploredFrom;
            }

            SetPath(_startingPoint);
            _path.Reverse();
            for (int i = 0; i < _path.Count; i++)
            {
                Console.WriteLine(_path[i].X.ToString() + "," + _path[i].Y);
            }

        }
        public static void SetPath(Node node)
        {
            _path.Add(node);
        }

    }
    class Node
    {
        public bool isExplored = false;
        public Node isExploredFrom = null;

        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
