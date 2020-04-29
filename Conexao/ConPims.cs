﻿using System;
using System.Data;
using System.Data.OracleClient;

namespace CONFERENCIAS
{

	public class ConPims
	{

		static string pathDataBase = "Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP";

		static OracleConnection Conn = null;

		public static OracleConnection getConnection()
		{

			Conn = new OracleConnection(pathDataBase);

			try
			{
				Conn.Open();
			}
			catch (Exception ex)
			{
				Conn = null;
				throw ex;

			}
			return Conn;
		}


		public DataTable getDataTable(string strSQL)
		{

			DataTable dt = new DataTable();

			using (OracleConnection conn = ConPims.getConnection())
			{

				OracleDataAdapter da = new OracleDataAdapter(strSQL, conn);

				da.Fill(dt);

				return dt;

			}


		}

	}



}
