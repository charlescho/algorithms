public class Palindrome {
  public static bool Check(string val) {
    if (val.Length <= 1) {
      return true;
    }
    if (val[0] != val[val.Length -1]) {
      return false;
    }

    return Palindrome.Check(val.Substring(1, val.Length - 2));
  }
}

Console.WriteLine("is the word: {0} a Palindrome? {1}", "rotor", Palindrome.Check("rotor"));
Console.WriteLine("is the word: {0} a Palindrome? {1}", "motor", Palindrome.Check("motor"));
Console.WriteLine("is the word: {0} a Palindrome? {1}", "me", Palindrome.Check("me"));
Console.WriteLine("is the word: {0} a Palindrome? {1}", "a", Palindrome.Check("a"));
