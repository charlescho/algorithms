public class RandomizedSelection
{
  static Random rand;

  static RandomizedSelection()
  {
    rand = new Random();
  }

  static void Swap(int[] array, int first, int second)
  {
    var temp = array[first];
    array[first] = array[second];
    array[second] = temp;
  }

  static int Partition(int[] array, int l, int r, int p)
  {
    var q = l;
    Swap(array, r, p);
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

  public static int Select(int[] array, int l, int r, int orderStatistic)
  {
    if(l < r)
    {
      int pivot = rand.Next(l, r);
      pivot = Partition(array, l, r, pivot);
      if(pivot == orderStatistic - 1)
      {
        return array[pivot];
      }
      else if(pivot < orderStatistic - 1)
      {
        return Select(array, pivot + 1, r, orderStatistic);
      }
      else
      {
        return Select(array, l, pivot - 1, orderStatistic);
      }
    }
    else
    {
      return array[l];
    }
  }
}

var test = new int[] { 4, 8, 2, 9, 3, 1};
int result = RandomizedSelection.Select(test, 0, test.Length - 1, 2);
Console.WriteLine("the answer: {0}", result);
