public class Factorial {

  public static int Calculate(int n) {
    if(n == 0) {
        return 1;
    }

    return n * Factorial.Calculate(n - 1);
  }
}

Console.WriteLine("the Factorial of {0} should be {1}", 3, 6);
Console.WriteLine("the Factorial of {0}: {1}", 3, Factorial.Calculate(3));
Console.WriteLine("the Factorial of {0} should be {1}", 4, 24);
Console.WriteLine("the Factorial of {0}: {1}", 4, Factorial.Calculate(4));
