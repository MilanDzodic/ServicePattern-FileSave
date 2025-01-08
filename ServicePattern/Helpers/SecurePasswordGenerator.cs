using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
namespace ServicePattern.Helpers;

public static class SecurePasswordGenerator
{
  private static readonly byte[] _key = Encoding.UTF8.GetBytes("Zwajasdjfasdifnis");

  public static string Generate(string password)
  {
    try
    {
      using var hmac = new HMACSHA256();
      var key = hmac.Key;
      var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      var encoded = Convert.ToBase64String(hash);
      return encoded;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null!;
    }
  }

  public static bool Validate(string password, string expectedHashPassword)
  {
    try
    { 
    using var hmac = new HMACSHA256(_key);
    var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    var encoded = Convert.ToBase64String(hash);
    return encoded == expectedHashPassword;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return false!;
    }
  }
}
