using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanGuConfig.Configurations;

namespace PanGuConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            PanGuConfiguration co =
                (PanGuConfiguration)ConfigurationManager.GetSection("panGuConfiguration");

            //Console.WriteLine(co.DictionaryPath);
            Console.WriteLine(co.CommandTwo.CommandText);

            Console.ReadKey();
        }
    }
}
