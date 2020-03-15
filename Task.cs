using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_day_plan
{
    class Task
    {


        public string task { get; set; }
        public string category { get; set; }
        public string dateOfTask { get; set; }
        public bool done { get; set; }



        public Task(string taskName, string categoryBox = "No category", string dateOf = "", bool cheskDone = false)
        {

            task = taskName;
            category = categoryBox;
            dateOfTask = dateOf;
            done = cheskDone;

        }

    }
}
