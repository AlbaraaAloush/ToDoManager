using System;
using System.Threading.Tasks;

namespace ToDoManager
{
    class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private int nextId; // used to give ID to each task

        public List<Task> Tasks
        {
            get { return tasks; }
        }

        public Task GetTaskById(int taskId)
        {
            return tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public void AddTask(string taskTitle)
        {
            tasks.Add(new Task(nextId, taskTitle));
            nextId++;
        }

        public List<Task> ListTasks()
        {

            return tasks;
           
                
               
        }

        public bool CompleteTask(int taskId)
        {
            Task task = GetTaskById(taskId);

            if (task == null)
            {
                return false;
            }

            task.MarkCompleted();
            return true;

        }

        public bool DeleteTask(int taskId)
        {
            Task task = GetTaskById(taskId);

            if (task == null)
            {
                return false;
            }
            tasks.Remove(task);
            return true;
        }
    } 
}