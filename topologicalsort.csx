using System.Collections.Generic;

public class TopologicalSort
{
  private static Dictionary<int, bool> explored = new Dictionary<int,bool>();
  private static List<int> ordered = new List<int>();
  private static int current_label;

  public static List<int> Sort(int[][] graph)
  {
    for(int i = 0; i < graph.Length; i++)
    {
      explored.Add(i, false);
    }

    //current_label = graph.Length - 1;

    for(int i = graph.Length - 1; i >= 0; i--)
    {
      if(!explored[i])
      {
        DepthFirstSearch(graph, i);
      }
    }

    return ordered;
  }

  private static void DepthFirstSearch(int[][] graph, int vertex)
  {
    explored[vertex] = true;
    for(int i = 0; i < graph[vertex].Length; i++)
    {
      if(!explored[graph[vertex][i]])
      {
        DepthFirstSearch(graph, graph[vertex][i]);
      }
    }

    ordered.Insert(0, vertex);
    //current_label--;
  }
}

var adjList = new int[][] {
  new int[] {2},
  new int[] {3},
  new int[] {1,3},
  new int[] {}
};
var result = TopologicalSort.Sort(adjList);
Console.WriteLine("sorted: " + String.Join(", ", result));
