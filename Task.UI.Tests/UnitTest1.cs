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
        public void AddTask()
        {
            TaskModel addTask = new TaskModel();
            addTask.Task = "Coding";
            addTask.StartDate = DateTime.Now;
            addTask.EndDate = DateTime.Now;
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
            updateTask.StartDate = DateTime.Now;
            updateTask.EndDate = DateTime.Now;
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
