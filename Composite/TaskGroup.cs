using Lab2.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Lab2.Composite
{
    public class TaskGroup : TaskComponent
    {
        [JsonProperty(Order = 1)]
        public string Type { get; set; } = "TaskGroup";


        [JsonProperty(Order = 228)]
        public List<TaskComponent> Children = new List<TaskComponent>();


        public TaskGroup(string name)
        {
            Name = name;
        }

        public override void Create()
        {
            this.View = GroupCreator.CreateGroup(Name, this);
            this.Left = this.View.Left;
            this.Top = this.View.Top;
        }

        public void RemoveChild(TaskComponent child)
        {
            Children.Remove(child);
        }

        public void AddChild (TaskComponent child)
        {
            Children.Add(child);

            CustomGroupBox containerGroupBox = View;
            CustomGroupBox selectedGroupBox = child.View;
            
            // Добавляем элемент в контейнер
            containerGroupBox.Controls.Add(selectedGroupBox);
            selectedGroupBox.Parent = containerGroupBox;

            // Расположение элементов внутри контейнера
            selectedGroupBox.Left = 10;
            selectedGroupBox.Top = 15 + (containerGroupBox.Controls.Count - 1) * 100;

            // Отключаем возможность перетаскивания и делаем видимой кнопку
            DraggableItemService.DeleteDragHandlers(selectedGroupBox);
            if (selectedGroupBox.Controls[0] is Button upButton)
            {
                upButton.Visible = true;
            }

            GroupBoxViewService.ResizeGroup(containerGroupBox);
        }

    }
}
