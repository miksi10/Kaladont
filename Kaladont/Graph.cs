using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaladont
{
    class Graph
    {

        //adds edge u -> v
        public static void addEdge(Dictionary<string, LinkedList<string>> adj, string u, string v)
        {
            if (adj.ContainsKey(u)) {
                adj[u].AddLast(v);
            }
            else
            {
                adj.Add(u, new LinkedList<string>());
                adj[u].AddLast(v);
            }
        }

    }
}
