using Contract;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;

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
        public List<TaskModel> SearchTask(object taskModel)
        {
            TaskRepository obj = new TaskRepository();
            var result = obj.SearchTask(ModelConverter(taskModel));
            return result;
        }
        public TaskModel GetTaskById(int taskId)
        {
            TaskRepository obj = new TaskRepository();
            var result = obj.GetTaskById(taskId);
            return result;
        }
        public bool AddTask(object taskModel)
        {
            TaskRepository obj = new TaskRepository();
            obj.AddTask(ModelConverter(taskModel));
            return true;
        }
        public bool UpdateTask(object taskModel)
        {
            TaskRepository obj = new TaskRepository();
            obj.UpdateTask(ModelConverter(taskModel));
            return true;
        }
        public bool DeleteTask(object taskModel)
        {
            TaskRepository obj = new TaskRepository();
            obj.DeleteTask(ModelConverter(taskModel));
            return true;
        }
        private TaskModel ModelConverter(object task)
        {
            TaskModel taskModel = new TaskModel();
            try
            {
                taskModel = (TaskModel)task;
                if (taskModel.StartDate != null)
                    taskModel.StartDateString = taskModel.StartDate.ToString();
                if (taskModel.EndDate != null)
                    taskModel.EndDateString = taskModel.EndDate.ToString();
                return taskModel;
            }
            catch
            {
                string details = task.ToString();
                JavaScriptSerializer objJavascript = new JavaScriptSerializer();
                var testModels = objJavascript.DeserializeObject(details);

                if (testModels != null)
                {
                    Dictionary<string, object> dic = (Dictionary<string, object>)testModels;
                    foreach (var citem in dic)
                    {
                        Dictionary<string, object> dic1 = (Dictionary<string, object>)citem.Value;
                        object value;
                        if (dic1.TryGetValue("Task", out value))
                            taskModel.Task = value.ToString();
                        if (dic1.TryGetValue("ParentTask", out value))
                            taskModel.ParentTask = value.ToString();
                        if (dic1.TryGetValue("Priority", out value))
                            taskModel.Priority = (int)value;
                        if (dic1.TryGetValue("StartDate", out value))
                            taskModel.StartDateString = value.ToString();
                        if (dic1.TryGetValue("EndDate", out value))
                            taskModel.EndDateString = value.ToString();
                        if (dic1.TryGetValue("TaskId", out value))
                            taskModel.TaskId = (int)value;
                        if (dic1.TryGetValue("PriorityEnd", out value))
                            taskModel.PriorityEnd = (int)value;

                        return taskModel;
                    }
                }
            }
           
            return taskModel;
        }
    }
}
