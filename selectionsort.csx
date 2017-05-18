using System.Collections.Generic;

public class SelectionSort {
  private static int IndexOfMinimum(List<int> list, int startIndex) {
    var minValue = list[startIndex];
    var minIndex = startIndex;

    for(int i = minIndex + 1; i < list.Count; i++) {
      if (list[i] < minValue) {
        minValue = list[i];
        minIndex = i;
      }
    }
    return minIndex;
  }

  private static void Swap(List<int> list, int firstIndex, int secondIndex) {
    var temp = list[firstIndex];
    list[firstIndex] = list[secondIndex];
    list[secondIndex] = temp;
  }

  public static void Sort(List<int> list) {
    for (int i = 0; i < list.Count; i ++) {
      var minIndex = IndexOfMinimum(list, i);
      Swap(list, i, minIndex);
    }
  }
}

var array = new List<int> {18, 6, 66, 44, 9, 22, 14};
SelectionSort.Sort(array);

Console.WriteLine("array after sorting: " + String.Join(", ", array));
