using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoManager
{
     class ConsoleUI
    {
        private TaskManager manager;

        public ConsoleUI()
        {
            manager = new TaskManager();
        }

        public TaskManager Manager
        {
            get { return manager; }
        }
        public void DisplayMenu()
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4.Delete Task");
            Console.WriteLine("5. Exit");
        }

        public void HandleAddTask()
        {
            Console.WriteLine("Enter new task name: ");
            string addedTask = Console.ReadLine().Trim();
            Manager.AddTask(addedTask);
            Console.WriteLine("Task " + addedTask + " was added successfully.");
        }

        public void HandleListTasks()
        {

            List<Task> tasks = Manager.ListTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks added yet.");
                return;
            }
            Console.WriteLine($"{"Task ID",-10} {"Task Title",-15} {"Task Status"}");
            foreach (var t in tasks)
            {
                Console.WriteLine($"{t.Id,-10} {t.Title,-15} {(t.IsCompleted ? "Complete" : "Incomplete")}");
            }
        }

        public void HandleCompleteTask()
        {
            int completedTask;
            while (!int.TryParse(Console.ReadLine().Trim(), out completedTask) || !Manager.Tasks.Exists(t => t.Id == completedTask))
            {
                Console.WriteLine("Invalid ID, please enter a valid one:");
            }

            if (Manager.CompleteTask(completedTask))
            {
                Console.WriteLine("Task marked completed.");
            }
        }

        public void HandleDeleteTask()
        {
            int deletedTaskId;
            while (!int.TryParse(Console.ReadLine().Trim(), out deletedTaskId) || !Manager.Tasks.Exists(t => t.Id == deletedTaskId))
            {
                Console.WriteLine("Invalid ID, please enter a valid one:");
            }

            if (Manager.DeleteTask(deletedTaskId))
            {
                Console.WriteLine("Task deleted successfully.");
            }
        }

        public void run()
        {
            while (true)
            {
                DisplayMenu();
                string userinput = Console.ReadLine().Trim();
                switch (userinput)
                {
                    case "1":
                        HandleAddTask();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        HandleListTasks();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter the Task ID from the list below:");
                        HandleListTasks();
                        HandleCompleteTask();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case "4":
                        Console.WriteLine("Enter the Task ID from the list below:");
                        HandleListTasks();
                        HandleDeleteTask();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("invalid option, please input a value from 1 to 5.");
                        break;
                }
            }
        }
    }
}
