using Dapper;
using MyWpfApp.mvvm.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.data
{
    public class dapperHelper
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        public async Task<IEnumerable<T>> getMulti<T>(string query, T model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();


                    var result = await db.QueryAsync<T>(query);
                    db.Close();
                    return result;
                }
            }
            catch
            {
                return new List<T>();
            }
        }

        public async Task<T> getSingle<T>(string query, T model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();


                    var result = await db.QueryFirstOrDefaultAsync<T>(query);
                    db.Close();
                    return result;
                }
            }
            catch
            {
                return model;
            }
        }

        public async Task<bool> excute(string query)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();


                    int result = await db.ExecuteAsync(query);

                    db.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
