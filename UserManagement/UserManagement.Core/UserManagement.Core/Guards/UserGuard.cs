using UserManagement.Core.Exceptions;

namespace UserManagement.Core.Guards
{
    public static class UserGuard
    {
        public static void ParameterNotNull(object parameter, string paramaterName)
        {
            if (parameter == null) throw new UserInvalidDataException();
        }

        public static void IdParameterValid(int id, string parameterName)
        {
            if (id <= 0) throw new UserInvalidDataException();
        }
    }
}