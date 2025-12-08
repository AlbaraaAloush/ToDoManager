using System;

namespace ToDoManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manage = new TaskManager();
            Console.WriteLine("Welcome to C# task manager, what would you like to do today?");
            while (true)
            {
                
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4.Delete Task");
                Console.WriteLine("5. Exit");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        Console.WriteLine("Enter the new task title: ");
                        string taskTitle = Console.ReadLine();
                        manage.AddTask(taskTitle);
                        Console.WriteLine(taskTitle + " has been added successfully!");
                        break;
                    case "2":
                        manage.ListTasks();
                        break;
                    case "3":
                        Console.WriteLine("provide the task ID from the table below: ");
                        manage.ListTasks();
                        int taskId;
                        while (!int.TryParse(Console.ReadLine(), out taskId) || taskId < 0 || taskId >= manage.TaskCounter)
                        {
                            Console.WriteLine("Invalid ID, please enter a valid one:");
                        }
                        manage.CompleteTask(taskId);
                        break;
                    case "4":
                        Console.WriteLine("selected 4");
                        break;
                    case "5":
                        Console.WriteLine("selected 5");
                        return;
                    default:
                        Console.WriteLine("invalid option, please input a value from 1 to 5.");
                        break;
                }
            }

        }
    }
}