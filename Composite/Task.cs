using Lab2.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Lab2.Composite
{
    public class Task : TaskComponent // Leaf
    {
        [JsonProperty(Order = 1)]
        public string Type { get; set; } = "Task";

        [JsonProperty(Order = 3)]
        public string Content { get; set; }

        public Task(string name)
        {
            this.Name = name;
        }


        public override void Create()
        {
            this.View = TaskCreator.CreateTask(Name, this);
            this.Left = this.View.Left;
            this.Top = this.View.Top;
        }

        public void UpdateContent(string newContent) 
        {
            Content = newContent;
        }
    }
}
