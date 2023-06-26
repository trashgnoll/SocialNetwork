using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories.SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(FriendAddData friendAddData)
        {
            var friends = friendRepository.FindAllByUserId(friendAddData.user_id);
            if (friends.Any(friend => friend.friend_id == friendAddData.friend_id))
                throw new FriendExistsException();

            if (friendAddData.user_id == friendAddData.friend_id)
                throw new InvalidArgumentException();

            if (this.userRepository.FindById(friendAddData.user_id) is null)
                throw new UserNotFoundException();

            if (this.userRepository.FindById(friendAddData.friend_id) is null)
                throw new UserNotFoundException();

            FriendEntity friend = new()
            {
                user_id = friendAddData.user_id,
                friend_id = friendAddData.friend_id
            };
            friendRepository.Create(friend);
        }
    }
}
