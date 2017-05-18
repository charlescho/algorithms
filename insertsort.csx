public class InsertSort {
  private static void Insert(int[] list, int rightIndex, int insertValue) {
    int key = rightIndex;
    for (int i = rightIndex - 1; i >= 0 && insertValue < list[i]; i--) {
      Console.WriteLine("comaparing " + insertValue + " with " + list[i]);
      key = i;
      list[i + 1] = list[i];
    }

    list[key] = insertValue;
  }

  public static void Sort(int[] list) {
    for (int i = 1; i < list.Length; i++) {
      Console.WriteLine("Index: {0}, Value: {1}", i, list[i]);
      Insert(list, i, list[i]);
      Console.WriteLine("Sorted list: " + String.Join(", ", list));
    }
  }
}


var test = new int[] {7, 6, 19, 13, 5, 9, 33, 17};
InsertSort.Sort(test);
