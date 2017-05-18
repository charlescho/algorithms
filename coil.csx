using System.Collections.Generic;

public class Coil {
  public static void Unroll(int[,] array) {
    //var ret = new List<int>();

    var maxIndex = array.GetUpperBound(0);
    var minIndex = 0;
    Console.WriteLine("Size of array {0} x {0}", maxIndex + 1);
    while(minIndex <= maxIndex) {
      for (int i = minIndex; i < maxIndex; i++) {
        Console.WriteLine(array[minIndex, i]);
        //ret.Add(array[0, i]);
      }

      for(int y = minIndex; y < maxIndex; y++) {
        Console.WriteLine(array[y, maxIndex]);
        //ret.Add(array[y, size]);
      }

      for(int j = maxIndex; j > minIndex; j--) {
        Console.WriteLine(array[maxIndex, j]);
      }

      for(int z = maxIndex; z > minIndex; z--) {
        Console.WriteLine(array[z, minIndex]);
      }

      if(minIndex == maxIndex) {
        Console.WriteLine(array[minIndex, maxIndex]);
      }

      maxIndex--;
      minIndex++;
    }
  }
}


var test = new int[4,4] { {1, 2, 3, 10}, {4, 5, 6, 11}, {7, 8, 9, 12}, {13, 14, 15, 16}};
for (int x = 0; x <= test.GetUpperBound(0); x++) {
  for (int y = 0; y <= test.GetUpperBound(1); y++) {
    Console.Write(" " + test[x, y]);
  }
  Console.WriteLine("");
}
Coil.Unroll(test);
//Console.WriteLine("result: " + String.Join(", ", result));
