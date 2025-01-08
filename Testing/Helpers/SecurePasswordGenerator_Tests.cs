using ServicePattern.Helpers;

namespace Testing.Helpers;

public class SecurePasswordGenerator_Tests
{
  [Fact]

  public void GenerateSecurePassword_ShouldReturnPasswordofTypeString()
  {
    // act
    string id = SecurePasswordGenerator.Generate();

    // assert
    Assert.False(string.IsNullOrEmpty(id));
    Assert.True(Guid.TryParse(id, out _));
  }
}
