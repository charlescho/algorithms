public class Karatsuba {
  public static long Multiply(long num1, long num2) {
    //base case
    if(num1 < 10 || num2 < 10) {
      return num1 * num2;
    }

    var length = (int) Math.Floor(Math.Log10(num1)+1);
    var mid = length / 2;

    var high1 = num1 / (long)Math.Floor(Math.Pow(10, mid));
    var low1 = num1 % (long)Math.Floor(Math.Pow(10, mid));
    var high2 = num2 / (long)Math.Floor(Math.Pow(10, mid));
    var low2 = num2 % (long)Math.Floor(Math.Pow(10, mid));

    var z0 = Karatsuba.Multiply(low1, low2);
    var z1 = Karatsuba.Multiply((low1 + high1), (low2 + high2));
    var z2 = Karatsuba.Multiply(high1, high2);

    return (z2 * (long)Math.Pow(10, 2 * mid)) + ((z1-z2-z0) * (long)Math.Pow(10, mid)) + z0;
  }
}
