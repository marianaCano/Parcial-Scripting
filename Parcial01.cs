using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node NodoA = new Node(1, -1);
            Node NodoB = new Node(2, -1);
            Node NodoC = new Node(4, -1);
            Node NodoD = new Node(2,-2 );
            Node NodoE = new Node(3, -2);
            Node NodoF = new Node(5, -2);
            Node NodoG = new Node(1, -3);
            Node NodoH = new Node(2, -3);
            Node NodoI = new Node(5, -3);
            Node NodoJ = new Node(2, -4);
            Node NodoK = new Node(3, -4);
            Node NodoL = new Node(4, -4);
            Node NodoM = new Node(4, -5);
            Node NodoN = new Node(5, -5);

            Node[] Maze = {NodoA,NodoB,NodoC,NodoD, NodoE, NodoF, NodoG ,NodoH, NodoI, NodoJ,
            NodoK, NodoL, NodoM, NodoN};

            Stopwatch s = new Stopwatch();
            s.Start();

            Searchepath.LoadAllBlocks(Maze);
            Searchepath.BFS(Maze[0], Maze [13]);
            Searchepath.CreatePath();
            s.Stop();

            Console.WriteLine("Tiempo del programa " + s.ElapsedMilliseconds + " ms");



        }
    }
}
