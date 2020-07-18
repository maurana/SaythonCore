﻿using System;
using System.Data;
using Npgsql;

namespace Saython.Framework.PostgreSQLDataAccess
{
    /// <summary>
    /// Saython PostgreSQL Executor Class
    /// </summary>
    public class SaythonPostgreSQLExecutor
    {
        public string ConnectionString;
        NpgsqlConnection _connection;
        NpgsqlCommand _command;
        NpgsqlDataAdapter _dataAdapter;

        public SaythonPostgreSQLExecutor(string conString)
        {
            this.ConnectionString = conString;
        }

        public DataTable Read(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection = new NpgsqlConnection(this.ConnectionString);
                _command = new NpgsqlCommand(sql);
                _command.Connection = _connection;
                _connection.Open();
                DataAdapter.SelectCommand = _command;
                DataAdapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.Close();
            }

            return dt;
        }

        public DataTable ReadAlive(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Command.CommandText = sql;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(dt);
            }
            finally
            { }

            return dt;
        }

        public Int32 ExecuteNonQuery(string sql)
        {
            try
            {
                _connection = new NpgsqlConnection(this.ConnectionString);
                _command = new NpgsqlCommand(sql);
                _command.Connection = _connection;
                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public NpgsqlDataReader ExecuteReader(string sql)
        {
            try
            {
                _connection = new NpgsqlConnection(this.ConnectionString);
                _command = new NpgsqlCommand(sql);
                _command.Connection = _connection;
                _connection.Open();

                return _command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public Int32 ExecuteNonQueryAlive(string sql)
        {
            try
            {
                Command.CommandText = sql;
                return Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            { }
        }

        public void Close()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                _connection = null;
            }
            if (_command != null)
            {
                _command.Dispose();
                _command = null;
            }
            if (_dataAdapter != null)
            {
                _dataAdapter.Dispose();
                _dataAdapter = null;
            }
        }

        protected NpgsqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    if (ConnectionString == "")
                        throw new Exception("Connection string must be defined before using connection, command or data adapter");

                    _connection = new NpgsqlConnection(ConnectionString);
                    _connection.Open();
                }

                return _connection;
            }
            set
            {
                _connection = value;
            }
        }

        internal NpgsqlCommand Command
        {
            get
            {
                if (_command == null)
                {
                    _command = new NpgsqlCommand();
                    _command.Connection = Connection;
                }
                if (_command.Connection.ConnectionString == string.Empty)
                {
                    _command.Connection.ConnectionString = this.ConnectionString;
                }

                return _command;
            }
            set
            {
                _command = value;
            }
        }

        protected NpgsqlDataAdapter DataAdapter
        {
            get
            {
                if (_dataAdapter == null)
                {
                    _dataAdapter = new NpgsqlDataAdapter();
                }

                return _dataAdapter;
            }
            set
            {
                _dataAdapter = value;
            }
        }

        public Object ExecuteScalar(String sql)
        {
            try
            {
                _connection = new NpgsqlConnection(this.ConnectionString);
                _command = new NpgsqlCommand(sql);
                _command.Connection = _connection;
                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
        }

        public Object ExecuteScalarAlive(String sql)
        {
            try
            {
                Command.CommandText = sql;
                return Command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { }
        }
    }
}
