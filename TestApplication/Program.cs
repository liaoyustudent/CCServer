using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.Manage.Redies;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper.Set_Add("aaa", "1");
            RedisHelper.Item_Get<string>("aaa");
            Console.ReadKey();
        }
    }
}
