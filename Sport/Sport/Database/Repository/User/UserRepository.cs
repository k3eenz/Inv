using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(SportDbContext context) : base(context) { }
    public async Task<User> SearchUser(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == username);

        if (user != null && HashManager.CheckPassword(password, user.Password))
        {
            return user;
        }
        return null;
    }
    public async Task<bool> SearchExistUser(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == username) != null;
    }
}