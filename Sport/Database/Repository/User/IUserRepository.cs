public interface IUserRepository : IBaseRepository<User>
{
    Task<User> SearchUser(string username, string password);
    Task<bool> SearchExistUser(string username);
}