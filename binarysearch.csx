using System.Collections.Generic;

public class BinarySearch {
  public static int Do(List<int> list, int targetValue) {
    var min = 0;
    var max = list.Count - 1;
    var guess = -1;

    while(max >= min) {
      guess = Convert.ToInt32(Math.Floor((max + min) / 2.0));
      Console.WriteLine(guess);
      var guess_val = list[guess];
      if(guess_val == targetValue) {
        return guess;
      }
      else if( guess_val < targetValue) {
        min = guess + 1;
      }
      else {
        max = guess - 1;
      }
    }

    return guess;
  }
}

var primes = new List<int> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

var result = BinarySearch.Do(primes, 73);
Console.WriteLine(result);
