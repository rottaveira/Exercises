using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public class Friend
    { 
        public string Email { get; private set; }

        public ICollection<Friend> Friends { get; private set; }

        public Friend(string email)
        {
            this.Email = email;
            this.Friends = new List<Friend>();
        }

        public void AddFriendship(Friend friend)
        {
            this.Friends.Add(friend);
            friend.Friends.Add(this);
        }

        List<string> verified = new List<string>();
        public bool CanBeConnected(Friend friend)
        {
            if (verified.Contains(this.Email))
                return false;
            else
                verified.Add(this.Email);

            var closestFriend = this.Friends.Any(x => x.Email == friend.Email);
            var friendOfFriend = this.Friends.Where(x => x.Friends.Any(y => y.Email == friend.Email)).Any();

            foreach (var item in friend.Friends.Where(x => x.CanBeConnected(friend)))
            {
                 return true;
            }
            return (closestFriend || friendOfFriend);

        }
         
    }
}
