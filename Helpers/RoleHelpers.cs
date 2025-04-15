namespace Winterra.Helpers
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string User = "User";

        // Optional grouped roles
        public const string AdminOrModerator = Admin + "," + Moderator;
    }
}