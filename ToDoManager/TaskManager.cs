using System;

namespace ToDoManager
{
    class TaskManager
    {
        private Task[] tasks = new Task[100];
        private int taskCounter; // uninitialized, so value is zero by default
        private int nextId;

        public Task[] Tasks
        {
            get { return tasks; }
        }
        public int TaskCounter
        {
            get { return taskCounter; }
        }

        public void AddTask(string taskTitle)
        {
            Task newTask = new Task(nextId, taskTitle);
            tasks[taskCounter] = newTask;
            nextId++;
            taskCounter++;
        }

        public void ListTasks()
        {
          
                Console.WriteLine($"{"Task ID", -10} { "Task Title", -15} {"Task Status"}");
                for (int i = 0; i < taskCounter; i++)
                {
                    if (tasks[i]!=null)
                    {
                        Console.WriteLine($"{tasks[i].Id, -10} {tasks[i].Title, -15} {(tasks[i].IsCompleted?"Complete":"Incomplete")}");
                    }
                   
                }
               
        }

        public void CompleteTask(int taskId)
        {
            if (taskCounter == 0)
            {
                Console.WriteLine("No Tasks added yet");
            } else if( taskId >= taskCounter || taskId < 0)
            {
                Console.WriteLine("Invalid ID, please enter a valid one:");
                return;
            } else
            {
                for(int i = 0; i < taskCounter; i++)
                {
                    if(taskId == tasks[i].Id)
                    {
                        tasks[i].markCompleted();
                        Console.WriteLine("Task " + tasks[i].Id + " marked as completed successfully.");
                        break;
                    }
                }
            }
                

        }

        public void DeleteTask(int taskId)
        {
            if (taskCounter == 0)
            {
                Console.WriteLine("No Tasks added yet");
            }

            int indexToDelete = -1;

            for(int i = 0; i < taskCounter; i++)
            {
                if (tasks[i].Id == taskId)
                {
                    indexToDelete = i;
                    break;
                }
            }

            if(indexToDelete == -1)
            {
                Console.WriteLine("No Task found with ID " + taskId);
            }

            for(int i = indexToDelete; i < taskCounter - 1; i++)
            {
                tasks[i] = tasks[i + 1];
            }

            taskCounter--;
            tasks[taskCounter] = null;
            Console.WriteLine("Task " + taskId + " Deleted Successfully");
        }
    } 
}