using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace Lab2.Managers
{
    public static class GroupBoxViewService
    {

        /// <summary>
        /// Изменяет размер группы заметок при добавлении или удалении элементов
        /// </summary>
        /// <param name="box">GroupBox, размер которого нужно изменить.</param>
        public static void ResizeGroup(CustomGroupBox containerGroupBox)
        {
            int maxControlWidth = -1;
            Button upButton = (Button)containerGroupBox.Controls[0];
            Button delButton = (Button)containerGroupBox.Controls[1];

            int spacingBetweenNotes = 5; // Расстояние между заметками
            int yOffset = 20; // Начальное смещение по y

            foreach (Control control in containerGroupBox.Controls)
            {
                if (control is CustomGroupBox taskGroupBox)
                {
                    taskGroupBox.Top = yOffset;
                    yOffset += taskGroupBox.Height + spacingBetweenNotes;

                    maxControlWidth = Math.Max(control.Width, maxControlWidth);
                }
            }

            // Увеличение расстояния между последней заметкой и границей коробки
            yOffset += spacingBetweenNotes;
            if (yOffset < 40)
            {
                yOffset = 40;
            }


            // Применяем изменения к размерам GroupBox
            if (maxControlWidth != -1)
            {
                containerGroupBox.Size = new Size(maxControlWidth + 20, yOffset);
                delButton.Left = maxControlWidth;
                upButton.Left = maxControlWidth - 20;


                if (containerGroupBox.Parent != AppContext.TaskBoard)
                {
                    ResizeGroup((CustomGroupBox)containerGroupBox.Parent);
                }
            } 
            
            else
            {
                containerGroupBox.Size = new Size(220, yOffset);
                delButton.Left = 200;
                upButton.Left = 180;

                if (containerGroupBox.Parent != AppContext.TaskBoard)
                {
                    ResizeGroup((CustomGroupBox)containerGroupBox.Parent);
                }
            }
            
        }
        
        public static void ReplaceGroupBox(CustomGroupBox groupBOX)
        {
            groupBOX.Parent = AppContext.TaskBoard;

            if (groupBOX.Tag == "Group")
            {
                groupBOX.Left = 840;
                groupBOX.Top = 20;
                DraggableItemService.AttachDragHandlers(groupBOX);

                if (groupBOX != AppContext.TaskBoard)
                {
                    GroupBoxViewService.ResizeGroup(groupBOX);
                }
            }

            else if (groupBOX.Tag == "Task")
            {
                groupBOX.Left = 10;
                groupBOX.Top = 20;
                DraggableItemService.AttachDragHandlers(groupBOX);
            }

            
        }
    }
}
