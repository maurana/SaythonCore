using System;
using MongoDB.Driver;

/// <summary>
/// Saython MongoDB Executor Class
/// </summary>
namespace SaythonFramework.DataAccess
{
    public class SaythonMongoDbExecutor
    {
        public string ConnectionString;
        MongoClient _connection;
        CommandDocument _command;

        public SaythonMongoDbExecutor(string conString)
        {
            this.ConnectionString = conString;
        }

        public MongoClient Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (ConnectionString == "")
                        throw new Exception("Connection string must be defined before using connection, command or data adapter");

                    _connection = new MongoClient(ConnectionString);
                }

                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        public CommandDocument Command
        {
            get
            {
                if (_command == null)
                {
                    _command = new CommandDocument();
                }

                return _command;
            }
            set
            {
                _command = value;
            }
        }
    }
}
