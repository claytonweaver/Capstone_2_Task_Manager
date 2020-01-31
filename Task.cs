using System;
using System.Collections.Generic; 

namespace Capstone_2_Tasks
{
    class Task
    {
        private string employee;
        private DateTime dueDate;
        private string description;
        private bool completed;

        public string Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public Task()
        {

        }

        public Task(string _employee, DateTime _dueDate, string _description, bool _completed)
        {
            employee = _employee;
            dueDate = _dueDate;
            description = _description;
            completed = _completed;

        }

        


    }
}
