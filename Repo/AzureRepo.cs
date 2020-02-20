using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public static class AzureRepo
    {
        public static CloudTable AuthTable()
        {
            string _accountName = ""; //Azure storage account name 
            string _accountKey = ""; //Azure storage account key 
            string _table = ""; //Azure storage table name
            try
            {
                StorageCredentials creds = new StorageCredentials(_accountName, _accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

                CloudTableClient client = account.CreateCloudTableClient();

                CloudTable table = client.GetTableReference(_table);
                table.CreateIfNotExists();
                return table;
            }
            catch
            {
                return null;
            }
        }
    }
}
