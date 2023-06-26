using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public static class InputView
    {
        public static string ReadLine()
        {
            string? result = null;
            while( result is null )
                result = Console.ReadLine();
            return result;
        }
    }
}
