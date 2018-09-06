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
        public TaskModel GetTaskById(int id)
        {
            TaskManager obj = new TaskManager();
            var result = obj.GetTaskById(id);
            return result;
        }
        [HttpPost]
        public List<TaskModel> SearchTask(object taskModel)
        {
            TaskManager obj = new TaskManager();
            var result = obj.SearchTask(taskModel);
            return result;
        }
        [HttpPost]
        public bool AddTask(object taskModel)
        {
            TaskManager obj = new TaskManager();
            obj.AddTask(taskModel);
            return true;
        }
        [HttpPost]
        public bool UpdateTask(object taskModel)
        {
            TaskManager obj = new TaskManager();
            obj.UpdateTask(taskModel);
            return true;
        }
        [HttpPost]
        public bool DeleteTask(object taskModel)
        {
            TaskManager obj = new TaskManager();
            obj.DeleteTask(taskModel);
            return true;
        }
    }
}
