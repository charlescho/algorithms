using System.Collections.Generic;

public class MergeSort {
  private static void Merge(int[] array, int p, int q, int r) {

      var leftArray = new List<int>();
      for(var x = p; x <= q; x++) {
        leftArray.Add(array[x]);
      }

      var rightArray = new List<int>();
      for(var x = q + 1; x <= r; x++) {
        rightArray.Add(array[x]);
      }

      var k = p;
      int i = 0;
      int j = 0;

      while(i < leftArray.Count && j < rightArray.Count) {
        if(leftArray[i] < rightArray[j]) {
          array[k] = leftArray[i];
          i++;
        } else {
          array[k] = rightArray[j];
          j++;
        }

        k++;
      }

      while(i < leftArray.Count) {
        array[k] = leftArray[i];
        i++;
        k++;
      }

      while(j < rightArray.Count) {
        array[k] = rightArray[j];
        j++;
        k++;
      }
  }

  public static void Sort(int[] array, int p, int r) {
    if(p < r) {
      var q = Convert.ToInt32(Math.Floor((p + r) / 2.0));
      Sort(array, p, q);
      Sort(array, q + 1, r);
      Merge(array, p, q, r);
    }
  }
}

var test = new int[] {4, 12, 6, 9, 13, 23, 1, 5, 35};
MergeSort.Sort(test, 0, test.Length - 1);
Console.WriteLine("Sorted array: " + String.Join(", ", test));
