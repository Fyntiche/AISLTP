using AISLTP.Context;
using AISLTP.Entities;
using System;

namespace AISLTP
{
    public static class StaticFunctions
    {
        public static User GetUser(string name)
        {
            int userID = Convert.ToInt32(name);
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Users.Find(userID);
        }
    }
}