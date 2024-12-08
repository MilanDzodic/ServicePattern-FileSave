using System.Diagnostics;
using ServicePattern.Factories;
using ServicePattern.Helpers;
using ServicePattern.Models;

namespace ServicePattern.Services;

public class UserServices
{
  private List<UserEntity> _users = [];
  private readonly FileService _fileService = new();
  public bool Create(UserRegistrationForm form)
  {
    try
    {
      UserEntity userEntity = UserFactory.Create(form);

      userEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();
      userEntity.Password = SecurePasswordGenerator.Generate(form.Password);

      _users.Add(userEntity);
      _fileService.SaveListToFile(_users);
      return true;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return false;
    }
  } 
  
  public IEnumerable<User> GetAll()
  {
    try
    {
      _users = _fileService.LoadListFromFile();
      return _users.Select(UserFactory.Create);
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
    }
  }
}
