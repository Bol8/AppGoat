namespace AppGoat.Domain.Constants
{
    public static class UserRoles
    {
        public static string ADMIN => "Administrator";
        public static string SUPERVISOR => "Supervisor";
        public static string OPERATOR => "Operator";

        public static string[] ROLES =
        {
            ADMIN,
            SUPERVISOR,
            OPERATOR
        };
    }
}