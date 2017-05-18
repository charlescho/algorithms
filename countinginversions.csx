public class CountingInversions
{
  private static int MergeCount(int[] array, int p, int q, int r)
  {
      var leftArray = new int[q - p + 1];
      Array.Copy(array, p, leftArray, 0, q - p + 1);

      var rightArray = new int[r - q];
      Array.Copy(array, q + 1, rightArray, 0, r - q);

      var k = p;
      var i = 0;
      var j = 0;
      var count = 0;

      while(i < leftArray.Length && j < rightArray.Length) {
        if(leftArray[i] < rightArray[j]) {
          array[k] = leftArray[i];
          i++;
        } else {
          array[k] = rightArray[j];
          j++;
          count += leftArray.Length - i;
        }

        k++;
      }

      while(i < leftArray.Length) {
        array[k] = leftArray[i];
        i++;
        k++;
      }

      while(j < rightArray.Length) {
        array[k] = rightArray[j];
        j++;
        k++;
      }

      return count;
  }

  public static int Count(int[] array, int p, int r)
  {
    if(p < r)
    {
      var q = (int)Math.Floor((p + r) / 2.0);
      return Count(array, p, q) +  Count(array, q + 1, r) + MergeCount(array, p, q, r);
    }

    return 0;
  }
}


var test = new int[]{ 1, 3, 5, 2, 4 };
var count = CountingInversions.Count(test, 0, test.Length - 1);
Console.WriteLine("Expected: {0} Actual: {1}", 3, count);

var test2 = new int[]{ 1, 2, 3, 4, 5 };
var count2 = CountingInversions.Count(test2, 0, test2.Length - 1);
Console.WriteLine("Expected: {0} Actual: {1}", 0, count2);

var test3 = new int[]{ 6, 5, 4, 3, 2, 1 };
var count3 = CountingInversions.Count(test3, 0, test3.Length - 1);
Console.WriteLine("Expected: {0} Actual: {1}", 15, count3);
