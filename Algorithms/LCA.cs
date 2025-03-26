using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class LCA
    {
        const int N = 11;
        public List<int>[] g;
        int[,] binup = new int[N, 21];
        int[] h = new int[N];
        public List<int>[] CreateTree(int size)
        {
            Random r = new Random();
            List<int>[] g = new List<int>[N];
            int[] par = new int[N];
            for (int i = 1; i <= size; ++i)
            {
                par[i] = r.Next(1, i);
            }
            for (int i = 1; i <= size; ++i)
            {
                g[i] = new List<int>();
            }
            for (int i = 1; i <= size; ++i)
            {
                if (i == par[i]) continue;
                g[i].Add(par[i]);
                g[par[i]].Add(i);
            }
            return g;
        }
        


        public int Lca(int u, int v)
        {
            if (h[u] < h[v])
            {
                (u, v) = (v, u);
            }
            for (int i = 20; i >= 0; --i)
            {
                int nu = binup[u, i];
                if (h[nu] >= h[v])
                {
                    u = nu;
                }
            }
            if (u == v)
            {
                return u;
            }
            for (int i = 20; i >= 0; --i)
            {
                int nu = binup[u, i], nv = binup[v, i];
                if (nu != nv)
                {
                    u = nu;
                    v = nv;
                }
            }
            return binup[u, 0];
        }

        public void Dfs(int v, int p = 0)
        {
            h[v] = h[p] + 1;
            binup[v, 0] = p;

            for (int i = 1; i <= 20; ++i)
            {
                binup[v, i] = binup[binup[v, i - 1], i - 1];
            }
            foreach (int to in g[v])
            {
                if (to != p)
                {
                    Dfs(to, v);
                }
            }
        }

        public LCA(int size)
        {
            g = CreateTree(size);
            Dfs(1, 0);
        }
    }
}
