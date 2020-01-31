using System;
using System.Collections.Generic;


namespace Capstone_2_Tasks
{


    class Program
    {
        static void Main(string[] args)
        {
            string mainMenu = "Would you like to go back to the main menu? (y/n)";
            string tryAgain = "Would you like to try again?";

            List<Task> tasks = new List<Task>
            {
                new Task("Clayton",DateTime.Parse("2/3/20"),"Finish Capstone",false),
                new Task("David",DateTime.Parse("3/9/20"),"Finish Stock Report", false),
                new Task("Jon",DateTime.Parse("1/3/20"),"Organize Manager Brunch",true),
                new Task("Sarah",DateTime.Parse("2/20/20"),"Present Q1 Report",false),
                new Task("Andrew",DateTime.Parse("1/12/20"),"Write Q4 Performance Reviews",true)

            };

            bool resume = false;
            do
            {


                try
                {
                    ShowMainMenu();
                    int userChoice = int.Parse(GetUserInput(""));
                    if (userChoice == 1)
                    {
                        DisplayTasks(tasks);
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if (userChoice == 2)
                    {
                        tasks.Add(CreateTask());
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if (userChoice == 3)
                    {
                        DisplayTasks(tasks);
                        DeleteTask(tasks);
                        resume = AskToTryAgain(GetUserInput(mainMenu));

                    }
                    else if (userChoice == 4)
                    {
                        DisplayTasks(tasks);
                        tasks.Add(MarkTaskComplete(tasks));
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if (userChoice == 5)
                    {
                        DisplayTasks(tasks);
                        DisplayTasksByName(tasks);
                        resume = AskToTryAgain(GetUserInput(mainMenu));

                    }
                    else if (userChoice == 6)
                    {
                        DisplayTasks(tasks);
                        DisplayTasksBeforeDate(tasks);
                        resume = AskToTryAgain(GetUserInput(mainMenu));

                    }
                    else if (userChoice == 7)
                    {
                        DisplayTasks(tasks);
                        tasks.Add(EditTaskName(tasks));
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if(userChoice == 8)
                    {
                        DisplayTasks(tasks);
                        tasks.Add(EditTaskDescription(tasks));
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if(userChoice == 9)
                    {
                        DisplayTasks(tasks);
                        tasks.Add(EditTaskDate(tasks));
                        resume = AskToTryAgain(GetUserInput(mainMenu));
                    }
                    else if(userChoice == 10)
                    {
                        resume = false;
                    }
                }
                catch (FormatException)
                {
                    resume = AskToTryAgain(GetUserInput(tryAgain)); 
                }
                catch (StackOverflowException)
                {
                    resume = AskToTryAgain(GetUserInput(tryAgain));
                }
                catch (IndexOutOfRangeException)
                {
                    resume = AskToTryAgain(GetUserInput(tryAgain));
                }

                
            }

            while (resume);
        }




        public static bool AskToTryAgain(string input)
        {
            try
            {
                if (input.ToLower()[0] == 'y')
                    return true;
                else if (input.ToLower()[0] == 'n')
                    return false;
                else
                    Console.WriteLine("Wrong input. Would you like to try again? (y/n)");
                string input2 = Console.ReadLine();
                AskToTryAgain(input2);
            }
            catch (StackOverflowException)
            {
                string userError = GetUserInput("That's not right. Try again: 'y' or 'n'");
                AskToTryAgain(userError);
            }
            return true;
        }
        public static Task CreateTask()
        {
            string taskName = GetUserInput("Team Member Name: ");
            DateTime dueDate = DateTime.Parse(GetUserInput("Due Date (mm/dd/yyyy): "));
            string description = GetUserInput("Description: ");
            bool completed = false;

            Task newTask = new Task(taskName, dueDate, description, completed);
            return newTask;

        }
        public static void DeleteTask(List<Task> tasks)
        {
            int userNumber = int.Parse(GetUserInput($"Which task would you like to remove? Please select a number between 1 and {tasks.Count}."));
            for (int i = 0; i < tasks.Count; i++)
            {
                if (userNumber == i + 1)
                {
                    tasks.RemoveAt(i);
                }
            }

        }
        public static void DisplayTasks(List<Task> tasks)
        {
            for (int i = 1; i < tasks.Count + 1; i++)
            {

                if (tasks[i - 1].Completed)
                {
                    Console.WriteLine($"{i}. Team Member: {tasks[i - 1].Employee}. Due Date: {tasks[i - 1].DueDate}. '{tasks[i - 1].Description}.' The task is complete.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{i}. Team Member: {tasks[i - 1].Employee}. Due Date: {tasks[i - 1].DueDate}. '{tasks[i - 1].Description}' The task is not complete.");
                    Console.WriteLine();
                }
            }


        }
        public static void DisplayTasksByName(List<Task> tasks)
        {
            string userChoice = GetUserInput($"Enter the first name of the employee that you would like to see the tasks of.");
            for (int i = 1; i < tasks.Count + 1; i++)
            {
                if (userChoice == tasks[i - 1].Employee)
                {
                    Console.WriteLine($"{tasks[i - 1].Employee}: '{tasks[i - 1].Description}' Due Date: {tasks[i - 1].DueDate}");
                }
            }


        }
        public static void DisplayTasksBeforeDate(List<Task> tasks)
        {
            DateTime userDate = DateTime.Parse(GetUserInput($"Enter the date of the tasks that you would like to see before said date. (dd/mm/yyyy)"));
            for (int i = 1; i < tasks.Count + 1; i++)
            {
                int isBefore = DateTime.Compare(userDate, tasks[i - 1].DueDate);
                if (isBefore > 0)
                {
                    Console.WriteLine($"{i}. Team Member: {tasks[i - 1].Employee}. Due Date: {tasks[i - 1].DueDate}. '{tasks[i - 1].Description}.' The task is complete.");
                }

            }
        }
        public static Task EditTaskName(List<Task> tasks)
        {
            int userNumber = int.Parse(GetUserInput($"Which task would you like to change the name of? Please select a number between 1 and {tasks.Count}."));
            string newName = GetUserInput("What would you like the new name to be?");
            for (int i = 0; i < tasks.Count; i++)
            {
                if (userNumber == i + 1)
                {
                    string employee = newName;
                    string description = tasks[i].Description;
                    DateTime DueDate = tasks[i].DueDate;
                    bool completed = tasks[i].Completed;
                    tasks.RemoveAt(i);
                    return new Task(employee, DueDate, description, completed);
                }

            }
            return null;
        }
        public static Task EditTaskDate(List<Task> tasks)
        {
            int userNumber = int.Parse(GetUserInput($"Which task would you like to change the date of? Please select a number between 1 and {tasks.Count}."));
            DateTime newDate = DateTime.Parse(GetUserInput("What would you like the new date to be?"));
            for (int i = 0; i < tasks.Count + 1; i++)
            {
                if (userNumber == i)
                {
                    string employee = tasks[i].Employee;
                    string description = tasks[i].Description;
                    DateTime DueDate = newDate;
                    bool completed = tasks[i].Completed;
                    tasks.RemoveAt(i);
                    return new Task(employee, DueDate, description, completed);
                }

            }
            return null;
        }
        public static Task EditTaskDescription(List<Task> tasks)
        {
            int userNumber = int.Parse(GetUserInput($"Which task would you like to change the description on? Please select a number between 1 and {tasks.Count}."));
            string newDescription = GetUserInput("What would you like the new description to be?");
            for (int i = 0; i < tasks.Count + 1; i++)
            {
                if (userNumber == i + 1)
                {
                    string employee = tasks[i].Employee;
                    string description = newDescription;
                    DateTime DueDate = tasks[i].DueDate;
                    bool completed = tasks[i].Completed;
                    tasks.RemoveAt(i);
                    return new Task(employee, DueDate, description, completed);
                }

            }
            return null;
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static Task MarkTaskComplete(List<Task> tasks)
        {
            int userNumber = int.Parse(GetUserInput($"Which task would you like to mark completed? Please select a number between 1 and {tasks.Count}."));
            for (int i = 0; i < tasks.Count + 1; i++)
            {
                if (userNumber == i + 1)
                {
                    string employee = tasks[i].Employee;
                    string description = tasks[i].Description;
                    DateTime DueDate = tasks[i].DueDate;
                    bool completed = true;
                    tasks.RemoveAt(i);
                    return new Task(employee, DueDate, description, completed);
                }

            }
            return null;
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("Welcome to the task manager!");
            Console.WriteLine();
            Console.WriteLine("     1. List tasks");
            Console.WriteLine("     2. Add task");
            Console.WriteLine("     3. Delete task");
            Console.WriteLine("     4. Mark task complete");
            Console.WriteLine("     5. See task by name");
            Console.WriteLine("     6. See tasks before certain date");
            Console.WriteLine("     7. Edit a task's employee");
            Console.WriteLine("     8. Edit a task's description");
            Console.WriteLine("     9. Edit a task's due date");
            Console.WriteLine("     10. Quit");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");

        }



    }




}

    

