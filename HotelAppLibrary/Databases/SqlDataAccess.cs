﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Dapper;

using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Databases
{
	public class SqlDataAccess : ISqlDataAccess
	{
		private readonly IConfiguration _config;

		public SqlDataAccess(IConfiguration config)
		{
			_config = config;
		}

		public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure = false)
		{
			string connectionstring = _config.GetConnectionString(connectionStringName);
			CommandType commandtype = CommandType.Text;

			if ( isStoredProcedure == true )
			{
				commandtype = CommandType.StoredProcedure;
			}

			using ( IDbConnection connection = new SqlConnection(connectionstring) )
			{
				List<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandtype).ToList();
				return rows;
			}
		}

		public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure = false)
		{
			string connectionstring = _config.GetConnectionString(connectionStringName);
			CommandType commandtype = CommandType.Text;

			if ( isStoredProcedure == true )
			{
				commandtype = CommandType.StoredProcedure;
			}

			using ( IDbConnection connection = new SqlConnection(connectionstring) )
			{
				_ = connection.Execute(sqlStatement, parameters, commandType: commandtype);
			}
		}
	}
}
