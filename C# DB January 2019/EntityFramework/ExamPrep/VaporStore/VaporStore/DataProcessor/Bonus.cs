namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            var user = context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                return $"User {username} not found";
            }

            var isEmailValid = context.Users.Any(x => x.Email == newEmail);

            if (isEmailValid)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;

            context.SaveChanges();

            return $"Changed {user.Username}'s email successfully";
        }
    }
}
