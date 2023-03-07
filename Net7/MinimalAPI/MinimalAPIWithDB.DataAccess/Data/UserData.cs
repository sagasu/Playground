using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalAPIWithDB.DataAccess.DbAccess;
using MinimalAPIWithDB.DataAccess.Models;

namespace MinimalAPIWithDB.DataAccess.Data;

public class UserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() => _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new{});

    public async Task<UserModel> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) => _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) => _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) => _db.SaveData("dbo.spUser_delete", new { Id = id });
}