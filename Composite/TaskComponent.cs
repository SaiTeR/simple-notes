using Lab2.Managers;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab2.Composite
{
    public abstract class TaskComponent // Component
    {
        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 4)]
        public int Left { get; set; }
        [JsonProperty(Order = 5)]
        public int Top { get; set; }

        [JsonIgnore]
        public CustomGroupBox View { get; set; }


        public abstract void Create();

        public void Delete()
        {
            CustomGroupBox parent = (CustomGroupBox)View.Parent;

            parent.Controls.Remove(View);

            if (parent != AppContext.TaskBoard)
            {
                GroupBoxViewService.ResizeGroup(parent);

                TaskGroup parentComp = (TaskGroup)parent.Component;
                parentComp.RemoveChild(this);
            }


        }

        //public void AddDragNDrop()
        //{
        //    DraggableItemService.AttachDragHandlers(View);
        //}
    }
}
