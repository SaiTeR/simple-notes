using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Composite;

namespace Lab2.Managers
{
    public static class TaskCreator
    {        
        public static CustomGroupBox CreateTask(string taskName, Composite.Task taskObj)
        {
            // Каркас заметки
            CustomGroupBox taskGroupBox = new CustomGroupBox();
            taskGroupBox.Text = taskName;
            taskGroupBox.Size = new System.Drawing.Size(200, 100);
            taskGroupBox.Tag = "Task";
            taskGroupBox.Top = 20;
            taskGroupBox.Left = 10;
            taskGroupBox.Component = taskObj;

            // Кнопка для выхода из группы (возврат на общее поле)
            Button upButton = new Button();
            upButton.Click += TaskUpButton_Click;
            upButton.Size = new System.Drawing.Size(20, 20);
            upButton.Location = new Point(145, 0);
            upButton.Text = "^";
            upButton.Visible = false;
            taskGroupBox.Controls.Add(upButton);

            // Кнопка удаления заметки
            Button delButton = new Button();
            delButton.Click += TaskDeleteButton_Click;
            delButton.Size = new System.Drawing.Size(20, 20);
            delButton.Location = new Point(170, 0);
            delButton.Text = "X";
            taskGroupBox.Controls.Add(delButton);

            // Текст заметки
            RichTextBox txtContent = new RichTextBox();
            txtContent.Dock = DockStyle.Fill;
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.TextChanged += TxtContent_TextChanged;
            taskGroupBox.Controls.Add(txtContent);

            DraggableItemService.AttachDragHandlers(taskGroupBox);

            return taskGroupBox;
        }

        public static CustomGroupBox RecreateTask(Composite.Task task)
        {
            CustomGroupBox taskGroupBox = CreateTask(task.Name, task);

            taskGroupBox.Left = task.Left;
            taskGroupBox.Top = task.Top;
            taskGroupBox.Controls[2].Text = task.Content;

            return taskGroupBox;
        }

        private static void TaskUpButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;

            CustomGroupBox child = (CustomGroupBox)button.Parent;
            CustomGroupBox parent = (CustomGroupBox)child.Parent;

            Composite.Task childComp = (Composite.Task)child.Component;
            TaskGroup parentComp = (TaskGroup)parent.Component;

            parentComp.RemoveChild(childComp);

            GroupBoxViewService.ReplaceGroupBox(child);
            GroupBoxViewService.ResizeGroup(parent);

            childComp.Left = child.Left;
            childComp.Top = child.Top;
        }

        private static void TaskDeleteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            CustomGroupBox task = (CustomGroupBox)button.Parent;
            Composite.Task taskComp = (Composite.Task)task.Component;

            taskComp.Delete();
        }


        private static void TxtContent_TextChanged(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;
            CustomGroupBox task = (CustomGroupBox)textBox.Parent;
            Composite.Task taskComp = (Composite.Task)task.Component;

            taskComp.UpdateContent(textBox.Text);
        }
    }
}
