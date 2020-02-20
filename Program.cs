using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating entry to table
            Console.WriteLine((UserRepo.CreateEntity("test","tester1",AzureRepo.AuthTable()))?"user created":"User failed to create") ;

            //Retrieving entry from table
            foreach (var item in UserRepo.RetrieveUsers(AzureRepo.AuthTable()))
            {
                Console.WriteLine(item.RowKey);
            }

            Console.ReadLine();
        }
    }
}
