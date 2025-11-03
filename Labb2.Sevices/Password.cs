using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Services
{
    public class Password
    {
        public static string Store(string input) => input ?? string.Empty;
    }
}
