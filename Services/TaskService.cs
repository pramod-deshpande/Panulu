using Microsoft.AspNetCore.Components;
using Panulu.Data;
using Panulu.Entities;

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


        //Get all pending tasks 
        public async Task<List<TaskItem>> GetAllIncompleteTasks()
        {
            var items = await _db.GetItemsAsync();
            await AssignDateForTasksWithoutDateAsync(items, DateTime.Now.Date);
            return items.Where(x => !x.IsCompleted).OrderBy(x => x.TaskDateTime).ToList();
        }



        //Get today's tasks 

        public async Task<List<TaskItem>> GetTasksForToday()
        {
            var items = await _db.GetItemsAsync();
            await AssignDateForTasksWithoutDateAsync(items, DateTime.Now.Date);
            return items.Where(x => x.TaskDateTime.Value.Date == DateTime.Now.Date && !x.IsCompleted).ToList();
        }




        //Assign date to tasks without a date
        private async Task AssignDateForTasksWithoutDateAsync(List<TaskItem> items, DateTime date)
        {
            var tasksToUpdate = items.Where(x => !x.TaskDateTime.HasValue).ToList();
            foreach (var item in tasksToUpdate)
            {
                item.TaskDateTime = date;
            }

            if (tasksToUpdate.Any())
            {
                foreach (var item in tasksToUpdate)
                {
                    await SaveTaskAsync(item);
                }
            }
        }

        //Save task 
        public async Task SaveTaskAsync(TaskItem taskItem)
        {
            await _db.SaveItemAsync(taskItem);
        }

        public async Task RevertTaskAsync(TaskItem taskItem)
        {
            taskItem.IsCompleted = !taskItem.IsCompleted;
            taskItem.TaskDateTime = DateTime.Now;
            taskItem.CompletionDateTime = new DateTime();
            await SaveTaskAsync(taskItem);
        }

    }
}
