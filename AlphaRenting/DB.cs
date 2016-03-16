using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaRenting
{
    public class DB
    {
        private static string DB_HOST { get { return "localhost"; } }
        private static string DB_USER { get { return "root"; } }
        private static string DB_NAME { get { return "AlphaRenting"; } }
        private static string DB_PASSWD { get { return "$1mN0tAw34kP4ssw0rd$"; } }
        private static MySqlConnection Open()
        {
            try
            {
                string login = string.Format("Server={0}; database={1}; UID={2}; password={3}", DB_HOST, DB_NAME, DB_USER, DB_PASSWD);
                MySqlConnection connexion = new MySqlConnection(login);
                connexion.Open();

                return connexion;
            }
            catch
            {
                return null;
            }
        }

        private static List<MySqlParameter> GetListParameters(params object[] param)
        {
            try
            {
                List<MySqlParameter> mpc = new List<MySqlParameter>();
                for (int i = 0; i <= param.Length - 1; i++)
                {
                    MySqlParameter sp = new MySqlParameter();
                    sp.ParameterName = "@p" + (i+1).ToString();
                    sp.Value = param[i];
                    switch (Type.GetTypeCode(param[i].GetType()))
                    {
                        case TypeCode.String:
                            sp.MySqlDbType = MySqlDbType.VarChar;
                            break;
                        case TypeCode.Int32:
                            sp.MySqlDbType = MySqlDbType.Int32;
                            break;
                        case TypeCode.Decimal:
                            sp.MySqlDbType = MySqlDbType.Decimal;
                            break;
                        default:
                            break;
                    }
                    mpc.Add(sp);
                }
                return mpc;
            }
            catch
            {
                return null;
            }
        }

        private static string GenerateParameters(int count)
        {
            string ret = null;
            for(int i=1; i<= count; i++)
            {
                ret += "@p" + i.ToString() + ",";
            }
            return ret.Remove(ret.Length-1);
        }

        private static string GenerateSetParameters(string setfields)
        {
            string[] split = setfields.Split(',');
            string newupdatefield = null;
            for (int i = 0; i <= split.Length - 1; i++)
            {
                newupdatefield += split[i] + "=@p" + (i + 1).ToString() + ",";
            }
            return newupdatefield.Remove(newupdatefield.Length - 1);
        }

        private static string GenerateWhereParameters(string wherefields)
        {
            return GenerateWhereParameters(wherefields, 0);
        }
        private static string GenerateWhereParameters(string wherefields, int offset)
        {
            string[] split = wherefields.Split(',');
            string newwherefields = null;
            for (int i = 0; i <= split.Length - 1; i++)
            {
                newwherefields += split[i] + "=@p" + (offset).ToString() + " AND ";
                offset++;
            }
            return newwherefields.Remove(newwherefields.Length - 4);
        }

        public static int ExecuteNonQuery(string sql, params object[] param)
        {
            try
            {
                MySqlConnection con = Open();
                if (con == null)
                    return 0;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Parameters.AddRange(GetListParameters(param).ToArray());

                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch
            {
                return 0;
            }
        }

        public static MySqlDataReader ExecuteReader(string sql, params object[] param)
        {
            try
            {
                MySqlConnection con = Open();
                if (con == null)
                    return null;

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Parameters.AddRange(GetListParameters(param).ToArray());

                MySqlDataReader mdr = cmd.ExecuteReader();

                return mdr;
            }
            catch
            {
                return null;
            }
        }

        public static MySqlDataReader Select(string tablename, string selectfields, string wherefields, params object[] param)
        {
            MySqlDataReader mdr = null;
            if (!string.IsNullOrWhiteSpace(tablename) && !string.IsNullOrWhiteSpace(wherefields))
            {
                string sql = "SELECT " + selectfields +  " FROM " + tablename + " WHERE " + GenerateWhereParameters(wherefields, param.Length);
                mdr = ExecuteReader(sql, param);
            }
            return mdr;
        }

        public static MySqlDataReader Select(string tablename, string selectfields, params object[] param)
        {
            MySqlDataReader mdr = null;
            if (!string.IsNullOrWhiteSpace(tablename))
            {
                string sql = "SELECT " + selectfields + " FROM " + tablename;
                mdr = ExecuteReader(sql, param);
            }
            return mdr;
        }

        public static bool Delete(string tablename, string wherefields, params object[] param)
        {
            int result = 0;
            if(!string.IsNullOrWhiteSpace(tablename))
            {
                string sql = "DELETE FROM " + tablename + " WHERE " + GenerateWhereParameters(wherefields);
                result = ExecuteNonQuery(sql, param);
            }
            return (result > 0);
        }

        public static bool Delete(string tablename, params object[] param)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(tablename))
            {
                string sql = "DELETE FROM " + tablename;
                result = ExecuteNonQuery(sql, param);
            }
            return (result > 0);
        }

        public static bool Insert(string tablename, string insertfield, params object[] param)
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(tablename))
            {
                string sql = "INSERT INTO " + tablename + "(" + insertfield + ") VALUES (" + GenerateParameters(param.Length) + ")";
                result = ExecuteNonQuery(sql, param);
            }
            return (result > 0);
        }

        public static bool Update(string tablename, string setfields, string wherefields, params object[] param)
        {
            int result = 0;
            if(!string.IsNullOrWhiteSpace(tablename))
            {
                string sql = null;
                if (!string.IsNullOrWhiteSpace(wherefields))
                    sql = "UPDATE " + tablename + " SET " + GenerateSetParameters(setfields) + " WHERE " + GenerateWhereParameters(wherefields, param.Length);
                else
                    sql = "UPDATE " + tablename + " SET " + GenerateSetParameters(setfields);

                result = ExecuteNonQuery(sql, param);
            }
            return (result>0);
        }
    }
}