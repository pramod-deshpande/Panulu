using Panulu.Data;

namespace Panulu.Services {
    public class TaskService {
        private readonly DbOperationsService _db;

        public TaskService(DbOperationsService db) {
            _db = db;
        }

        public async Task CarryOverIncompleteTasksAsync() {
            var date = DateTime.Now;
            var tasks = await _db.GetItemsAsync();
            var incompleteTasks = tasks.Where(x => !x.IsCompleted && x.TaskDateTime < date);
            foreach (var task in incompleteTasks) {
                task.TaskDateTime = date;
                await _db.SaveItemAsync(task);
            }
        }


    }
}
