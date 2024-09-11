using Lab2.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Managers
{
    public class GroupCreator
    {
        public static CustomGroupBox CreateGroup(string groupName, TaskGroup groupObj)
        {
            CustomGroupBox taskgroupGroupBox = new CustomGroupBox();
            taskgroupGroupBox.Text = groupName;
            taskgroupGroupBox.Size = new System.Drawing.Size(220, 40);
            taskgroupGroupBox.Top = 20;
            taskgroupGroupBox.Left = 840;
            taskgroupGroupBox.Tag = "Group";
            taskgroupGroupBox.Component = groupObj;

            // Кнопка для выхода из группы (возврат на общее поле)
            Button upButton = new Button();
            upButton.Click += GroupButton_Click;
            upButton.Size = new System.Drawing.Size(20, 20);
            upButton.Location = new Point(180, 0);
            upButton.Text = "^";
            upButton.Visible = false;
            taskgroupGroupBox.Controls.Add(upButton);
            

            // Кнопка удаления заметки
            Button delButton = new Button();
            delButton.Click += GroupDeleteButton_Click;
            delButton.Size = new System.Drawing.Size(20, 20);
            delButton.Location = new Point(200, 0);
            delButton.Text = "X";
            taskgroupGroupBox.Controls.Add(delButton);

            DraggableItemService.AttachDragHandlers(taskgroupGroupBox);

            return taskgroupGroupBox;
        }

        public static CustomGroupBox RecreateGroup(TaskGroup group)
        {
            CustomGroupBox taskgroupGroupBox = CreateGroup(group.Name, group);

            taskgroupGroupBox.Left = group.Left;
            taskgroupGroupBox.Top = group.Top;

            return taskgroupGroupBox;
        }

        private static void GroupButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;

            CustomGroupBox child = (CustomGroupBox)button.Parent;
            CustomGroupBox parent = (CustomGroupBox)child.Parent;

            TaskGroup childComp = (TaskGroup)child.Component;
            TaskGroup parentComp = (TaskGroup)parent.Component;

            parentComp.RemoveChild(childComp);
            
            GroupBoxViewService.ReplaceGroupBox(child);
            GroupBoxViewService.ResizeGroup(parent);

            childComp.Left = child.Left;
            childComp.Top = child.Top;
        }

        private static void GroupDeleteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CustomGroupBox group = (CustomGroupBox)button.Parent;
            CustomGroupBox groupParent = (CustomGroupBox)group.Parent;

            groupParent.Controls.Remove(group);


            if (groupParent != AppContext.TaskBoard)
            {
                GroupBoxViewService.ResizeGroup(groupParent);
            }

        }
    }
}
