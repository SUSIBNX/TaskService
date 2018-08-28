using Contract;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Business
{
    public class TaskManager
    {
        public List<TaskModel> GetAllTask()
        {
            TaskRepository obj = new TaskRepository();
            var result = obj.GetAllTask();
            return result;
        }
        public List<TaskModel> SearchTask(TaskModel taskModel)
        {
            TaskRepository obj = new TaskRepository();
            var result = obj.SearchTask(taskModel);
            return result;
        }
        public TaskModel GetTaskById(int taskId)
        {
            TaskRepository obj = new TaskRepository();
            var result = obj.GetTaskById(taskId);
            return result;
        }
        public bool AddTask(TaskModel taskModel)
        {
            TaskRepository obj = new TaskRepository();
            obj.AddTask(taskModel);
            return true;
        }
        public bool UpdateTask(TaskModel taskModel)
        {
            TaskRepository obj = new TaskRepository();
            obj.UpdateTask(taskModel);
            return true;
        }
        public bool DeleteTask(int taskId)
        {
            TaskRepository obj = new TaskRepository();
            obj.DeleteTask(taskId);
            return true;
        }
    }
}
