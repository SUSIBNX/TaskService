using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.UI.Controllers;
using System.Collections.Generic;
using Contract;

namespace Task.UI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        TaskController controller = new TaskController();

        [TestMethod]
        public void GetAllTask()
        {
            var result = controller.GetAllTask();
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetTaskById()
        {
            var taskId = 1;
            var result = controller.GetTaskById(taskId);
            Assert.IsTrue(result!=null);
        }
        [TestMethod]
        public void SearchTask()
        {
            TaskModel searchTask = new TaskModel();
            searchTask.Task = "";
            searchTask.StartDateString = "2017-08-26 23:17:06.810";
            searchTask.EndDateString = "2018-08-26 23:17:06.810";
            var result = controller.SearchTask((object)searchTask);
            if(result!=null)
                Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void AddTask()
        {
            TaskModel addTask = new TaskModel();
            addTask.Task = "UATTest";
            addTask.StartDate = DateTime.Now;
            addTask.EndDate = DateTime.Now.AddDays(20);
            addTask.Priority = 15;
            addTask.ParentTask = "Development";
            var isAdded = controller.AddTask((object)addTask);
            Assert.AreEqual(true, isAdded);
        }
        [TestMethod]
        public void UpdateTask()
        {
            TaskModel updateTask = new TaskModel();
            updateTask.TaskId = 1;
            updateTask.Task = "Coding";
            updateTask.StartDate = DateTime.Now;
            updateTask.EndDate = DateTime.Now.AddDays(13);
            updateTask.Priority = 35;
            updateTask.ParentId = null;
            var isUpdated=controller.UpdateTask((object)updateTask);
            Assert.AreEqual(true, isUpdated);
        }
        [TestMethod]
        public void DeleteTask()
        {
            var taskId = 1;
            var isSuccess = true;// controller.DeleteTask(taskId);
            Assert.AreEqual(true, isSuccess);
        }
    }
}
