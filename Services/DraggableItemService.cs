using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Composite;
using Lab2.Services;

namespace Lab2.Managers
{
    public static class DraggableItemService
    {
        private static bool isDragging = false;
        private static int offsetX, offsetY;
        private static Control selectedControl;
        private static GroupBox taskBoardGb = AppContext.TaskBoard; //

        public static void AttachDragHandlers(Control control)
        {
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
            control.MouseUp += Control_MouseUp;
        }

        public static  void DeleteDragHandlers(Control control)
        {
            control.MouseDown -= Control_MouseDown;
            control.MouseMove -= Control_MouseMove;
            control.MouseUp -= Control_MouseUp;
        }

        private static void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offsetX = e.X;
                offsetY = e.Y;
                selectedControl = (Control)sender;
            }
            else
            {
                isDragging = false;
            }
        }

        private static void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.Button == MouseButtons.Left)
            {
                selectedControl.Left += e.X - offsetX;
                selectedControl.Top += e.Y - offsetY;

                selectedControl.BringToFront();
            }
        }

        private static void Control_MouseUp(object sender, MouseEventArgs e)
        {
            CustomGroupBox selectedGroupBox = (CustomGroupBox)sender;
            TaskComponent selectedComponent = selectedGroupBox.Component;

            CustomGroupBox containerGroupBox = CollisionService.FindCollisioningGroup(selectedGroupBox);
            if (containerGroupBox != null)  // Добавляем элемент в контейнер
            {
                TaskGroup container = (TaskGroup)containerGroupBox.Component;
          
                container.AddChild((TaskComponent)selectedGroupBox.Component);
            }

            selectedComponent.Left = selectedGroupBox.Left;
            selectedComponent.Top = selectedGroupBox.Top;

            selectedGroupBox = null;
            isDragging = false;
        }
    }
}
