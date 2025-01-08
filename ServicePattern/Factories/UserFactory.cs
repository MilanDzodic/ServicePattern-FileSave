using ServicePattern.Helpers;
using ServicePattern.Models;

namespace ServicePattern.Factories;

public static class UserFactory
{
  public static UserRegistrationForm Create() => new();

  public static UserEntity Create(UserRegistrationForm form)
  {
    return new UserEntity()
    {
      FirstName = form.FirstName,
      LastName = form.LastName,
      Email = form.Email
    };
  }
  public static User Create(UserEntity entity) => new()
  {
    Id = entity.Id,
    FirstName = entity.FirstName,
    LastName = entity.LastName,
    Email = entity.Email
  };
 
}
