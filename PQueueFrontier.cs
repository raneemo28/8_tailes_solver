using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Tails_solver
{
    public class PQueueFrontier
    {
        private PriorityQueue<Node, int> frontier = new PriorityQueue<Node, int>();
        private HashSet<string> frontierStates = new HashSet<string>();
        public void Add(Node n)
        {
            if (n == null || n.State == null) return;
            string stateKey = n.GetStateKey();
            if (!frontierStates.Contains(stateKey))
            {
                frontier.Enqueue(n, n.FCost);
                frontierStates.Add(stateKey);
            }
        }
        public bool Empty()
        {
            return frontier.Count == 0;
        }
        public Node Remove()
        {
            if (this.Empty())
            {
                return null;
            }
            Node n = frontier.Dequeue();
            string stateKey = n.GetStateKey();
            frontierStates.Remove(stateKey);
            return n;
        }
        public bool ContainsState(char[,] s)
        {
            if (s == null) return false;
            string stateKey = Node.GetStateKeyFromMatrix(s);
            return frontierStates.Contains(stateKey);
        }
        public int Count
        {
            get { return frontier.Count; }
        }
    }
}
