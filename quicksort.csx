public class QuickSort {
  private static void Swap(int[] array, int first, int second) {
    var temp = array[first];
    array[first] = array[second];
    array[second] = temp;
  }
  private static int Partition(int[] array, int p, int r) {
    var q = p;
    for(var j = p; j < r; j++) {
      if(array[j] <= array[r]) {
        //swap
        Swap(array, j, q);
        q++;
      }
    }
    Swap(array, q, r);
    return q;
  }

  public static void Sort(int[] array, int p, int r) {
    if (p < r) {
      var pivot = Partition(array, p, r);
      Sort(array, p, pivot - 1);
      Sort(array, pivot + 1, r);
    }
  }
}

var test = new int[] { 4, 8, 2, 9, 3, 1};
QuickSort.Sort(test, 0, test.Length - 1);
Console.WriteLine("sorted array: " + String.Join(", ", test));
