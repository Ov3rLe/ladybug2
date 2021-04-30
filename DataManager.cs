using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ladybug.EF;

namespace ladybug
{
    static public class DataManager
    {
        static private LessonAKYLAEntities context = new LessonAKYLAEntities();

        public enum OperationState
        {
            Success,
            Duplicate,
            NoUserFound
        }

        static public OperationState AddUser(User user)
        {
            if (!IsDuplicate(user))
            {
                context.User.Add(user);
                context.SaveChanges();
                return OperationState.Success;
            }

            else
                return OperationState.Duplicate;
        }

        static public OperationState RemoveUser(string login)
        {
            User user = GetUserList().Find((e) => e.Login == login);

            if (user == null)
                return OperationState.NoUserFound;

            else
            {
                context.User.Remove(user);
                context.SaveChanges();
                return OperationState.Success;
            }
                
        }

        static private bool IsDuplicate(User user)
        {
            return GetUserList().Find((e) => e.Login == user.Login) != null;
        }

        static public List<User> GetUserList()
        {
            return context.User.ToList();
        }
    }
}
