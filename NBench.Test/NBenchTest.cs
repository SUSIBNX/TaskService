using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Task.UI.Controllers;

namespace NBench.Test
{
    public class NBenchTest
    {
        TaskController taskController = new TaskController();
        private Counter _counter;

        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            _counter = context.GetCounter("TaskCounter");
        }

        [PerfBenchmark(Description = "Counter iteration performance test for GetAllTask()", NumberOfIterations = 15, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("TaskCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_GetAllTask()
        {
            var bytes = new byte[1024];
            var result = taskController.GetAllTask();
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Counter iteration performance test AddTask()", NumberOfIterations = 15, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("TaskCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_AddTask()
        {
            var bytes = new byte[1024];
            TaskModel addTask = new TaskModel();
            addTask.Task = "UAT Test";
            addTask.StartDate = DateTime.Now;
            addTask.EndDate = DateTime.Now.AddDays(20);
            addTask.Priority = 15;
            addTask.ParentTask = "Development";
            var isAdded = taskController.AddTask((object)addTask);
            _counter.Increment();
        }

        [PerfBenchmark(Description = "Counter iteration performance test UpdateTask()", NumberOfIterations = 15, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("TaskCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_UpdateTask()
        {
            var bytes = new byte[1024];
            TaskModel updateTask = new TaskModel();
            updateTask.TaskId = 1;
            updateTask.Task = "Coding";
            updateTask.StartDate = DateTime.Now;
            updateTask.EndDate = DateTime.Now.AddDays(13);
            updateTask.Priority = 35;
            updateTask.ParentId = null;
            var isUpdated = taskController.UpdateTask((object)updateTask);

            _counter.Increment();
        }
        [PerfBenchmark(Description = "Counter iteration performance test SearchTask()", NumberOfIterations = 15, RunMode = RunMode.Throughput, TestMode = TestMode.Measurement, RunTimeMilliseconds = 1000)]
        [CounterMeasurement("TaskCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void NBench_SearchTask()
        {
            var bytes = new byte[1024];
            TaskModel searchTask = new TaskModel();
            searchTask.Task = "";
            searchTask.StartDateString = "2017-08-26 23:17:06.810";
            searchTask.EndDateString = "2018-08-26 23:17:06.810";
            var result = taskController.SearchTask((object)searchTask);
            _counter.Increment();
        }
      
    }
}
