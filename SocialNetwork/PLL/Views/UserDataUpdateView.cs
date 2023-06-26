using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService userService;
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Меня зовут:");
            user.FirstName = InputView.ReadLine();

            Console.Write("Моя фамилия:");
            user.LastName = InputView.ReadLine();

            Console.Write("Ссылка на моё фото:");
            user.Photo = InputView.ReadLine();

            Console.Write("Мой любимый фильм:");
            user.FavoriteMovie = InputView.ReadLine();

            Console.Write("Моя любимая книга:");
            user.FavoriteBook = InputView.ReadLine();

            this.userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
