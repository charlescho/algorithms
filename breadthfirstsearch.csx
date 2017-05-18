using System.Collections.Generic;
using System.Collections;

public class Info {
  public int Distance { get; set; }
  public int Predecessor{ get; set; }
}

public class BreadthFirstSearch {
  public static List<Info> Search(int[][] graph, int source) {
    var queue = new Queue<int>();
    //Tuple.item1: distance, Tuple.itme2: predecessor
    var bfsInfo = new List<Info>();

    for (int i = 0; i < graph.Length; i++) {
      bfsInfo.Add(new Info {Distance = -1, Predecessor = -1});
    }

    bfsInfo[source].Distance = 0;
    queue.Enqueue(source);

    while(queue.Count > 0) {
      var u = queue.Dequeue();
      for (int i = 0; i < graph[u].Length; i++) {
        var v = graph[u][i];
        if(bfsInfo[v].Distance == -1) {
          bfsInfo[v].Distance = bfsInfo[u].Distance + 1;
          bfsInfo[v].Predecessor = u;
          queue.Enqueue(v);
        }
      }
    }

    return bfsInfo;
  }
}

var adjList = new int[][] {
    new int[] {1},
    new int[] {0, 4, 5},
    new int[] {3, 4, 5},
    new int[] {2, 6},
    new int[] {1, 2},
    new int[] {1, 2, 6},
    new int[] {3, 5},
    new int[] {}
  };
Console.WriteLine(adjList);
var bfsInfo = BreadthFirstSearch.Search(adjList, 3);
for (var i = 0; i < adjList.Length; i++) {
    Console.WriteLine("vertex " + i + ": distance = " + bfsInfo[i].Distance + ", predecessor = " + bfsInfo[i].Predecessor);
}
