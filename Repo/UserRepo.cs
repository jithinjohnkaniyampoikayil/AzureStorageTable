using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public  class UserRepo
    {
        public UserRepo() { }

        //Creating an entry to table
        public static bool CreateEntity(string email, string username, CloudTable table)
        {
            if(DoesUsernameExist(username, table))
            {
                return false;
            }

            var newEntity = new UserEntity()
            {
                PartitionKey = "Username",
                RowKey = username,
                Email = email
                
            };

            TableOperation insert = TableOperation.Insert(newEntity);
            try
            {

                table.Execute(insert);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //checking if user exist
        private static bool DoesUsernameExist(string username, CloudTable table)
        {
            TableOperation entity = TableOperation.Retrieve("Username", username);

            var result = table.Execute(entity);

            if (result.Result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Retrieve all users
        public static List<UserEntity> RetrieveUsers(CloudTable table)
        {
            var query = new TableQuery<UserEntity>();
            return table.ExecuteQuery(query).ToList(); //rerieve all users
        }

        
    }
}
