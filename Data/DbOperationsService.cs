namespace Panulu.Data;

using CloudKit;
using Panulu.Entities;
using SQLite;
public class DbOperationsService {

    SQLiteAsyncConnection Connection;

    public DbOperationsService() {

    }

    private async Task Init() {
        if (Connection is not null) {
            return;
        }

        Connection = new SQLiteAsyncConnection(DatabaseConfig.DatabasePath, DatabaseConfig.Flags);
        _ = await Connection.CreateTableAsync<TaskItem>();
    }


    public async Task<List<TaskItem>> GetItemsAsync() {
        await Init();
        return await Connection.Table<TaskItem>().ToListAsync();
    }


    public async Task<TaskItem> GetItemAsync(int id) {
        await Init();
        return await Connection.Table<TaskItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(TaskItem item) {
        await Init();
        if (item.Id != 0)
            return await Connection.UpdateAsync(item);
        else
            return await Connection.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(TaskItem item) {
        await Init();
        return await Connection.DeleteAsync(item);
    }


}
