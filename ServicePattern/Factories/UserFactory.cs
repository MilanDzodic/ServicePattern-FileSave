using ServicePattern.Helpers;
using ServicePattern.Models;

namespace ServicePattern.Factories;

public static class UserFactory
{
  public static UserRegistrationForm Create()
  {
    return new UserRegistrationForm();
  }
  
  public static UserEntity Create(UserRegistrationForm form)
  {
    return new UserEntity()
    {
      FirstName = form.FirstName,
      LastName = form.LastName,
      Email = form.Email
    };
  }
  public static User Create(UserEntity entity)
  {
    return new User()
    {
      Id = entity.Id,
      Firstname = entity.FirstName,
      LastName = entity.LastName,
      Email = entity.Email
    };
  }
}
