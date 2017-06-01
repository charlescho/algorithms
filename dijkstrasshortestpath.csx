using System;
using System.Collections.Generic;

public class DijkstrasShortestPath
{
  public class DistancePair : IComparable<DistancePair>
  {
    public int Vertex { get; set; }
    public int Distance { get; set; }

    public int CompareTo(DistancePair compareTo)
    {
      if(this.Distance < compareTo.Distance)
        return -1;
      else if(this.Distance > compareTo.Distance)
        return 1;
      else
        return 0;
    }
  }
  // The graph is represented as a Dictionary with the key being some string
  // representing a vertex. Each vertext has a List of Tuples, with Item1
  // representing a vertex and Item2 representing the distance/
  public static Dictionary<int, int> Compute(Dictionary<int, List<Tuple<int, int>>> graph, int startingVertex)
  {
    var distances = new Dictionary<int, int>();
    var priorityQueue = new PriorityQueue<DistancePair>();

    //initialization
    // set distance of startingVertex to itself as 0
    distances[startingVertex] = 0;

    foreach(var item in graph)
    {
      if(item.Key != startingVertex)
      {
        distances.Add(item.Key, Int32.MaxValue);
      }
    }

    priorityQueue.Enqueue(new DistancePair{ Vertex = startingVertex, Distance = 0});

    while(priorityQueue.Count() > 0)
    {
      var bestVertex = priorityQueue.Dequeue();
      Console.WriteLine("Best Vertex: {0}, Distance: {1}", bestVertex.Vertex, bestVertex.Distance);
      var neighbors = graph[bestVertex.Vertex];
      foreach(var tuple in neighbors)
      {
        Console.WriteLine("Neighbor: " + tuple.Item1);
        Console.WriteLine("best distance so far: {0}", distances[tuple.Item1]);
        var alt = distances[bestVertex.Vertex] + tuple.Item2;
        Console.WriteLine("alt distance: {0}", alt);
        if(alt < distances[tuple.Item1])
        {
          distances[tuple.Item1] = alt;
          Console.WriteLine("Distance to {0}: {1}, ", tuple.Item1, alt);
          priorityQueue.Enqueue(new DistancePair { Vertex = tuple.Item1, Distance = alt });
        }
      }
    }

    return distances;
  }
}

public class PriorityQueue<T> where T : IComparable<T>
{
  private List<T> data;

  public PriorityQueue()
  {
    this.data = new List<T>();
  }

  public void Enqueue(T item)
  {
    data.Add(item);
    int ci = data.Count - 1; // child index; start at end
    while (ci > 0)
    {
      int pi = (ci - 1) / 2; // parent index
      if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
      T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
      ci = pi;
    }
  }

  public T Dequeue()
  {
    // assumes pq is not empty; up to calling code
    int li = data.Count - 1; // last index (before removal)
    T frontItem = data[0];   // fetch the front
    data[0] = data[li];
    data.RemoveAt(li);

    --li; // last index (after removal)
    int pi = 0; // parent index. start at front of pq
    while (true)
    {
      int ci = pi * 2 + 1; // left child index of parent
      if (ci > li) break;  // no children so done
      int rc = ci + 1;     // right child
      if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
        ci = rc;
      if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
      T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
      pi = ci;
    }
    return frontItem;
  }

  public T Peek()
  {
    T frontItem = data[0];
    return frontItem;
  }

  public int Count()
  {
    return data.Count;
  }

  public override string ToString()
  {
    string s = "";
    for (int i = 0; i < data.Count; ++i)
      s += data[i].ToString() + " ";
    s += "count = " + data.Count;
    return s;
  }

  public bool IsConsistent()
  {
    // is the heap property true for all data?
    if (data.Count == 0) return true;
    int li = data.Count - 1; // last index
    for (int pi = 0; pi < data.Count; ++pi) // each parent index
    {
      int lci = 2 * pi + 1; // left child index
      int rci = 2 * pi + 2; // right child index

      if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
      if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
    }
    return true; // passed all checks
  } // IsConsistent
} // PriorityQueue


var graph = new Dictionary<int, List<Tuple<int, int>>>();
graph.Add(0, new List<Tuple<int, int>>{ Tuple.Create(1, 2), Tuple.Create(2, 6) });
graph.Add(1, new List<Tuple<int, int>>{ Tuple.Create(2, 3), Tuple.Create(3, 4) });
graph.Add(2, new List<Tuple<int, int>>{ Tuple.Create(3, 1) });
graph.Add(3, new List<Tuple<int, int>>{});

var result = DijkstrasShortestPath.Compute(graph, 0);
foreach(var pair in result)
{
  Console.WriteLine("Vertex = {0}, Distance = {1}", pair.Key, pair.Value);
}
