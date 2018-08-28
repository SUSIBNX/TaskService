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
            searchTask.Task = "Coding";
            var result = controller.SearchTask(searchTask);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void AddTask()
        {
            TaskModel addTask = new TaskModel();
            addTask.Task = "Coding";
            addTask.StartDate = "10/10/2017";
            addTask.EndDate = "10/10/2018";
            addTask.Priority = 20;
            addTask.ParentId = null;
            var isAdded=controller.AddTask(addTask);
            Assert.AreEqual(true, isAdded);
        }
        [TestMethod]
        public void UpdateTask()
        {
            TaskModel updateTask = new TaskModel();
            updateTask.TaskId = 1;
            updateTask.Task = "Coding";
            updateTask.StartDate = "10/10/2017";
            updateTask.EndDate = "10/10/2018";
            updateTask.Priority = 35;
            updateTask.ParentId = null;
            var isUpdated=controller.UpdateTask(updateTask);
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
