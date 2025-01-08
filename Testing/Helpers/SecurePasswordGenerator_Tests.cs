using ServicePattern.Helpers;

namespace Testing.Helpers;

public class SecurePasswordGenerator_Tests
{
  [Fact]
  public void Generate_ShouldReturnValidHash()
  {
    // Arrange
    string password = "SecurePassword123!";
    // Act
    string hash = SecurePasswordGenerator.Generate(password);
    // Assert
    Assert.NotNull(hash);
    Assert.NotEmpty(hash);
  }

  [Fact]
  public void Generate_ShouldReturnDifferentHashesForDifferentPasswords()
  {
    // Arrange
    string password1 = "Password1!";
    string password2 = "Password2!";
    // Act
    string hash1 = SecurePasswordGenerator.Generate(password1);
    string hash2 = SecurePasswordGenerator.Generate(password2);
    // Assert
    Assert.NotEqual(hash1, hash2);
  }
}
