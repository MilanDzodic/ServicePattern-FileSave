using ServicePattern.Factories;
using ServicePattern.Models;

namespace Testing.Factories;

public class UserFactory_Tests
{
  [Fact]

  public void Create_ShouldMakeUserRegistrationForm()
  {
    // act
    var result = UserFactory.Create();
    
    // assert
    Assert.NotNull(result);
    Assert.IsType<UserRegistrationForm>(result);
  }


  [Theory]
  [InlineData("Milan", "Dzodic", "Trololololo@domain.com")]

  public void Create_ShouldMakeUserEntity_WhenUserRegistrationFormIsProvided(string FirstName, string LastName, string Email)
  {
    // arrange
    UserRegistrationForm userRegistrationForm = new() { FirstName = FirstName, LastName = LastName, Email = Email,};

    // act
    UserEntity form = UserFactory.Create(userRegistrationForm);

    // assert
    Assert.NotNull(form);
    Assert.IsType<UserEntity>(form);
    Assert.Equal(userRegistrationForm.FirstName, form.FirstName);
    Assert.Equal(userRegistrationForm.LastName, form.LastName);
    Assert.Equal(userRegistrationForm.Email, form.Email);
  }

  [Theory]
  [InlineData("Milan", "Dzodic", "Trololololo@domain.com")]

  public void Create_ShouldMakeUser_WhenUserEntityIsProvided(string FirstName, string LastName, string Email)
  {
    // arrange
    UserEntity userEntity= new() { FirstName = FirstName, LastName = LastName, Email = Email, };

    // act
    User form = UserFactory.Create(userEntity);

    // assert
    Assert.NotNull(form);
    Assert.IsType<User>(form);
    Assert.Equal(userEntity.FirstName, form.FirstName);
    Assert.Equal(userEntity.LastName, form.LastName);
    Assert.Equal(userEntity.Email, form.Email);
  }
}
