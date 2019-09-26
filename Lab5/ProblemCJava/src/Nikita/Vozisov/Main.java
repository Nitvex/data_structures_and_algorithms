package Nikita.Vozisov;

import java.io.*;
import java.util.*;

public class Main {
    static private class Edge {
        private short end;
        private short number;
        private int flow;
        private int throughput;
        private short ri; //index of reverse edge

        private Edge(short end, short number, int throughput, short ri) {
            this.end = end;
            this.number = number;
            this.flow = 0;
            this.throughput = throughput;
            this.ri = ri;
        }
    }

    static private ArrayList<Edge>[] edges;
    static private short[] distances;
    static private short[] ptr;
    static private short n;
    static private short dest;

    public static void main(String[] args) throws IOException {
        BufferedReader in = new BufferedReader(
                new FileReader(".idea/decomposition.in")
        );
        PrintWriter pw = new PrintWriter(new File("decomposition.out"));
        String[] t = in.readLine().split(" ");
        n = Short.parseShort(t[0]);
        short m = Short.parseShort(t[1]);
        edges = new ArrayList[n];
        for (short i = 0; i < n; i++) {
            edges[i] = new ArrayList<>();
        }
        short u, v;
        int f;
        for (short i = 1; i <= m; i++) {
            t = in.readLine().split(" ");
            u = (short) (Short.parseShort(t[0]) - 1);
            v = (short) (Short.parseShort(t[1]) - 1);
            f = Integer.parseInt(t[2]);
            edges[u].add(new Edge(v, i, f, (short) edges[v].size()));
            edges[v].add(new Edge(u, (short) 0, 0, (short) (edges[u].size() - 1)));
        }

        /*
         * MaxFlow (Dinic algorithm)
         */

        dest = (short) (n - 1);
        distances = new short[n];
        ptr = new short[n];
        int curflow = 1;
        while (BFS()) {
            for (short i = 0; i < n; i++) {
                ptr[i] = 0;
            }
            do curflow = DFS((short) 0, Integer.MAX_VALUE);
            while (curflow > 0);
        }

        /*
         * Decomposition
         */

        short pathscount = 0;
        path = new LinkedList<>();
        StringBuilder answer = new StringBuilder();
        while (true) {
            curflow = GetPath((short)0, Integer.MAX_VALUE);
            if (curflow == 0)
                break;
            ++pathscount;
            answer.append(curflow).append(" ");
            answer.append(path.size()).append(" ");
            for (Short e : path)
                answer.append(e).append(" ");
            answer.append("\n");
            path = new LinkedList<>();
        }
        pw.println(pathscount);
        pw.print(answer.toString());
        pw.close();
    }

    static private boolean BFS() {
        short u;
        for (u = 0; u < n; ++u) {
            distances[u] = Short.MAX_VALUE;
        }
        distances[0] = 0;
        short[] queue = new short[n];
        queue[0] = 0;
        short head = 0, tail = 1;
        while (head < tail) {
            u = queue[head++];
            for (Edge e : edges[u]) {
                if (distances[e.end] == Short.MAX_VALUE && e.flow < e.throughput) {
                    queue[tail++] = e.end;
                    distances[e.end] = (short) (distances[u] + 1);
                }
            }
        }
        return distances[dest] != Short.MAX_VALUE;
    }

    static private int DFS(short u, int flow) {
        if (flow == 0 || u == dest) {
            return flow;
        }
        for (; ptr[u] < edges[u].size(); ++ptr[u]) {
            if (distances[edges[u].get(ptr[u]).end] == distances[u] + 1 && edges[u].get(ptr[u]).flow < edges[u].get(ptr[u]).throughput) {
                int diff = edges[u].get(ptr[u]).throughput - edges[u].get(ptr[u]).flow;
                int delta = DFS(edges[u].get(ptr[u]).end, flow < diff ? flow : diff);
                if (delta > 0) {
                    edges[u].get(ptr[u]).flow += delta;
                    edges[edges[u].get(ptr[u]).end].get(edges[u].get(ptr[u]).ri).flow -= delta;
                    return delta;
                }
            }
        }
        return 0;
    }

    static private LinkedList<Short> path;
    static private int GetPath(short u, int flow)
    {
        if (u == dest) {
            return flow;
        }
        for (short i = 0; i < edges[u].size(); i++) {
            if (edges[u].get(i).flow > 0) {
                path.add(edges[u].get(i).number);
                flow = GetPath(edges[u].get(i).end, flow < edges[u].get(i).flow ? flow : edges[u].get(i).flow);
                edges[u].get(i).flow -= flow;
                return flow;
            }
        }
        return 0;
    }
}
