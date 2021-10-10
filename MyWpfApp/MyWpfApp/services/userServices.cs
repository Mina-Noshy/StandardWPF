using Dapper;
using MyWpfApp.data;
using MyWpfApp.mvvm.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.services
{
    public interface iUserServices
    {
        public Task<IEnumerable<user>> getAll();
        public Task<user> getOne(int id);
        public Task<bool> add(user model);
        public Task<bool> update(user model);
        public Task<bool> delete(int id);

    }
    public class userServices : iUserServices
    {
        private dapperHelper dapper;
        public userServices(dapperHelper _dapper)
        {
            dapper = _dapper;
        }

        public async Task<bool> add(user model)
        {
            string query = $"insert into users" +
                           $" values ('{model.username}', '{model.password}', '{model.loginDate.ToString("yyyy-MM-dd")}') ;";

            return await dapper.excute(query);
        }

        public async Task<bool> delete(int id)
        {
            string query = $"delete from user where id = {id} ;";

            return await dapper.excute(query);
        }

        public async Task<IEnumerable<user>> getAll()
        {
            string query = "select * from users ;";
            return await dapper.getMulti(query, new user());
        }

        public async Task<user> getOne(int id)
        {
            string query = $"select * from users where id = {id} ;";
            return await dapper.getSingle(query, new user());
        }

        public async Task<bool> update(user model)
        {
            string query = $"update users set username = {model.username}, password = {model.password}," +
                           $" loginDate = {model.loginDate} where id = {model.id} ;";

            return await dapper.excute(query);
        }
    }
}
