using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task.Business;

namespace Task.UI.Controllers
{
    public class TaskController : ApiController
    {
        [HttpGet]
        public List<TaskModel> GetAllTask()
        {
            TaskManager obj = new TaskManager();
            var result = obj.GetAllTask();
            return result;
        }
        [HttpGet]
        public TaskModel GetTaskById(int taskId)
        {
            TaskManager obj = new TaskManager();
            var result = obj.GetTaskById(taskId);
            return result;
        }
        [HttpPost]
        public bool AddTask(TaskModel taskModel)
        {
            TaskManager obj = new TaskManager();
            obj.AddTask(taskModel);
            return true;
        }
        [HttpPost]
        public bool UpdateTask(TaskModel taskModel)
        {
            TaskManager obj = new TaskManager();
            obj.UpdateTask(taskModel);
            return true;
        }
        [HttpPost]
        public bool DeleteTask(int taskId)
        {
            TaskManager obj = new TaskManager();
            obj.DeleteTask(taskId);
            return true;
        }
    }
}
