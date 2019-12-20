using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspNetCoreTodo.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var users = new List<User>
            {
                new User {Name = "dorin"},
                new User {Name = "ionut"},
                new User {Name = "veruta"}
            };

            var filtered = users.Select(u => u).Where(u => u.Name.Length < 6).ToList();

            Assert.Equal(2, filtered.Count);
        }

        User[] users;

        private IEnumerable<User> Where(Func<User, bool> predicate)
        {
            var filteredUsers = new List<User>();

            foreach(var user in users)
            {
                bool shouldBeIncluded = predicate(user);
                if (shouldBeIncluded)
                {
                    filteredUsers.Add(user);
                }
            }

            return filteredUsers;
        }

        private bool SmallerThanSixChars(User u)
        {
            if (u.Name.Length < 6)
            {
                return true;
            }
            return false;
        }

        private class User
        {
            public string Name { get; internal set; }
        }
    }
}
