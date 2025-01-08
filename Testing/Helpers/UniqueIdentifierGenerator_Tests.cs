using ServicePattern.Helpers;

namespace Testing.Helpers;

public class UniqueIdentifierGenerator_Tests
{
  [Fact]
  public void GenerateUniqueId_ShouldReturnGuidofTypeString()
  {
    // act
    string id = UniqueIdentifierGenerator.GenerateUniqueId();

    // assert
    Assert.False(string.IsNullOrEmpty(id));
    Assert.True(Guid.TryParse(id, out _));
  }
}
