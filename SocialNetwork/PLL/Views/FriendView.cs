using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        FriendService friendService;
        UserService userService;
        public FriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {

            Console.WriteLine("Для добавления друга введите его email:");
            string email = InputView.ReadLine();
            try
            {
                User friend = userService.FindByEmail(email);
                var friendAddData = new FriendAddData()
                {
                    user_id = user.Id,
                    friend_id = friend.Id
                };

                friendService.AddFriend(friendAddData);
                SuccessMessage.Show("Друг добавлен");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга.");
            }
        }
    }
}
