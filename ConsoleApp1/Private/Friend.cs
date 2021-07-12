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


        public static void Run()
        {
            /*Question 1*/
            Friend a = new Friend("A");
            Friend b = new Friend("B");
            Friend c = new Friend("C");
            Friend d = new Friend("D");
            Friend e = new Friend("E");
            Friend f = new Friend("F");
            Friend g = new Friend("G");

            a.AddFriendship(b);
            b.AddFriendship(c);
            c.AddFriendship(d);
            d.AddFriendship(e);
            e.AddFriendship(f);

            var teste = f.CanBeConnected(a);
            Console.WriteLine(a.CanBeConnected(c));
        }
    }
}
