using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.BL
{
    public class LoginFailureEx : Exception
    {
        public LoginFailureEx() : base("Wrong Username Or Password")
        {
        }

        public LoginFailureEx(string message) : base(message)
        {
        }
    }

    public static class UserManager
    {
        public static async Task<int> Insert(User user, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (LN7Entities dc = new LN7Entities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser newrow = new tblUser();
                    newrow.Id = Guid.NewGuid();
                    newrow.Username = user.Username;
                    newrow.First_Name = user.First_Name;
                    newrow.Last_Name = user.Last_Name;
                    newrow.Is_Admin = user.Is_Admin;
                    newrow.Date_Created = DateTime.Now;
                    newrow.Email = user.Email;
                    newrow.Password = user.Password;

                    user.Id = newrow.Id;

                    dc.tblUsers.Add(newrow);
                    int results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<int> Delete(Guid Id, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (LN7Entities dc = new LN7Entities())
                {
                    tblUser userToDelete = dc.tblUsers.FirstOrDefault(c => c.Id == Id);

                    if (userToDelete != null)
                    {
                        if (rollback)
                            transaction = await dc.Database.BeginTransactionAsync().ConfigureAwait(false);

                        dc.tblUsers.Remove(userToDelete);
                        int results = await dc.SaveChangesAsync().ConfigureAwait(false);

                        if (rollback)
                            await transaction.RollbackAsync().ConfigureAwait(false);

                        return results;
                    }
                    else
                    {
                        throw new Exception("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<int> Update(User user, bool rollback = false)
        {
            try
            {
                IDbContextTransaction? transaction = null;
                using (LN7Entities dc = new LN7Entities())
                {
                    tblUser row = await dc.tblUsers.FirstOrDefaultAsync(c => c.Id == user.Id);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback)
                            transaction = await dc.Database.BeginTransactionAsync().ConfigureAwait(false);

                        row.Id = user.Id;
                        row.Username = user.Username;
                        row.Password = user.Password;
                        row.First_Name = user.First_Name;
                        row.Last_Name = user.Last_Name;
                        row.Is_Admin = user.Is_Admin;
                        row.Email = user.Email;
                        row.Date_Created = user.Date_Created;

                        results = await dc.SaveChangesAsync().ConfigureAwait(false);
                        if (transaction != null)
                            await transaction.RollbackAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                    return results;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<User> LoadById(Guid id)
        {
            try
            {
                using (LN7Entities dc = new LN7Entities())
                {
                    tblUser tblUser = await dc.tblUsers.Where(c => c.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                    User user = new User();

                    if (tblUser != null)
                    {
                        user.Id = tblUser.Id;
                        user.Username = tblUser.Username;
                        user.Password = tblUser.Password;
                        user.First_Name = tblUser.First_Name;
                        user.Last_Name = tblUser.Last_Name;
                        user.Is_Admin = tblUser.Is_Admin;
                        user.Date_Created = tblUser.Date_Created;

                        return user;
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<IEnumerable<User>> Load()
        {
            try
            {
                List<User> users = new List<User>();
                using (LN7Entities dc = new LN7Entities())
                {
                    (await dc.tblUsers
                        .ToListAsync().ConfigureAwait(false))
                        .ForEach(c => users.Add(new User
                        {
                            Id = c.Id,
                            Username = c.Username,
                            Password = c.Password,
                            First_Name = c.First_Name,
                            Last_Name = c.Last_Name,
                            Is_Admin = c.Is_Admin,
                            Email = c.Email,
                            Date_Created = c.Date_Created
                        }));
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (LN7Entities dc = new LN7Entities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.Username == user.Username);

                            if (tblUser != null)
                            {
                                if (tblUser.Password == (user.Password))
                                {
                                    user.Id = tblUser.Id;
                                    user.Password = tblUser.Password;
                                    user.First_Name = tblUser.First_Name;
                                    user.Last_Name = tblUser.Last_Name;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}