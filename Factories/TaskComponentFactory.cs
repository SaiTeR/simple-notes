using Lab2.Composite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Lab2.Factories
{
    public static class TaskComponentFactory
    {
        public static TaskComponent CreateFromJson(JObject jsonObject)
        {
            string type = jsonObject.Value<string>("Type");

            if (type == "Task")
            {
                return jsonObject.ToObject<Composite.Task>();
            }
            else if (type == "TaskGroup")
            {
                TaskGroup taskGroup = new TaskGroup(jsonObject.Value<string>("Name"));
                taskGroup.Left = jsonObject.Value<int>("Left");
                taskGroup.Top = jsonObject.Value<int>("Top");

                JArray childrenJson = jsonObject["Children"] as JArray;
                if (childrenJson != null)
                {
                    foreach (JObject childJson in childrenJson)
                    {
                        TaskComponent childComponent = CreateFromJson(childJson);
                        taskGroup.Children.Add(childComponent);
                    }
                }
                return taskGroup;
            }
            else
            {
                throw new JsonException($"Unknown type: {type}");
            }
        }
    }
}
