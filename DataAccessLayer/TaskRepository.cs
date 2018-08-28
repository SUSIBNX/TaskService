using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TaskRepository
    {
        /// <summary>
        /// GetAllTask
        /// </summary>
        /// <returns></returns>
        public List<TaskModel> GetAllTask()
        {
            TaskEntities entity = new TaskEntities();
            var taskE =  (from task in entity.Tasks.Include("ParentTask")
                         select new TaskModel()
                         {
                            TaskId = task.Task_Id,
                            Task = task.Task1,
                            ParentTask = task.ParentTask.Parent_Task,
                            Priority = task.Priority,
                            StartDate = task.Start_Date!=null? task.Start_Date.ToString(): "",
                            EndDate= task.End_Date!=null? task.End_Date.ToString() : "",
                            ParentId= task.ParentTask.Parent_Id,
                         }).ToList();
            return taskE;
        }
        /// <summary>
        /// GetTaskById
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>

        public TaskModel GetTaskById(int taskId)
        {
            TaskEntities entity = new TaskEntities();
            var taskE = (from task in entity.Tasks.Include("ParentTask")
                         where task.Task_Id== taskId
                         select new TaskModel()
                         {
                             TaskId = task.Task_Id,
                             Task = task.Task1,
                             ParentTask = task.ParentTask.Parent_Task,
                             Priority = task.Priority,
                             StartDate = task.Start_Date != null ? task.Start_Date.ToString() : "",
                             EndDate = task.End_Date != null ? task.End_Date.ToString() : "",
                             ParentId = task.ParentTask.Parent_Id,
                         }).FirstOrDefault();
            return taskE;
        }
        /// <summary>
        /// AddTask
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public bool AddTask(TaskModel taskModel)
        {
            TaskEntities entity = new TaskEntities();
            Task addTask = new Task();
            addTask.Task1 = taskModel.Task;
            if (!string.IsNullOrEmpty(taskModel.StartDate))
                addTask.Start_Date = Convert.ToDateTime(taskModel.StartDate);
            if (!string.IsNullOrEmpty(taskModel.EndDate))
                addTask.End_Date = Convert.ToDateTime(taskModel.EndDate);
            addTask.Priority = taskModel.Priority;
            addTask.Parent_Id = taskModel.ParentId;
            entity.Tasks.Add(addTask);
            entity.SaveChanges();
            return true;
        }
        /// <summary>
        /// UpdateTask
        /// </summary>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public bool UpdateTask(TaskModel taskModel)
        {
            TaskEntities entity = new TaskEntities();
            var taskE = entity.Tasks.Where(x => x.Task_Id == taskModel.TaskId).FirstOrDefault();
            if(taskE!=null)
            {
                taskE.Task1 = taskModel.Task;
                if (!string.IsNullOrEmpty(taskModel.StartDate))
                    taskE.Start_Date = Convert.ToDateTime(taskModel.StartDate);
                if (!string.IsNullOrEmpty(taskModel.EndDate))
                    taskE.End_Date = Convert.ToDateTime(taskModel.EndDate);
                taskE.Priority = taskModel.Priority;
                taskE.Parent_Id = taskModel.ParentId;
                entity.SaveChanges();
            }
            return true;
        }
        /// <summary>
        /// DeleteTask
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public bool DeleteTask(int taskId)
        {
            TaskEntities entity = new TaskEntities();
            var taskE = entity.Tasks.Where(x => x.Task_Id == taskId).FirstOrDefault();
            if (taskE != null)
            {
                entity.Tasks.Remove(taskE);
                entity.SaveChanges();
            }
            return true;
        }
    }
}
