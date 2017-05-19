public class QuickSort {
  private static Random rnd;

  static QuickSort(){
    rnd = new Random();
  }

  private static void Swap(int[] array, int first, int second) {
    var temp = array[first];
    array[first] = array[second];
    array[second] = temp;
  }

  private static int ChoosePivot(int l, int r) {
    return rnd.Next(l, r);
  }

  private static int Partition(int[] array, int l, int r) {
    var q = l;
    Swap(array, r, ChoosePivot(l, r));
    for(var j = l; j < r; j++) {
      if(array[j] <= array[r]) {
        //swap
        Swap(array, j, q);
        q++;
      }
    }
    Swap(array, q, r);
    return q;
  }

  public static void Sort(int[] array, int l, int r) {
    if (l < r) {
      var pivot = Partition(array, l, r);
      Sort(array, l, pivot - 1);
      Sort(array, pivot + 1, r);
    }
  }
}

var test = new int[] { 4, 8, 2, 9, 3, 1};
QuickSort.Sort(test, 0, test.Length - 1);
Console.WriteLine("sorted array: " + String.Join(", ", test));
