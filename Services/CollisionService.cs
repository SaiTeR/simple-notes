using Lab2.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services
{
    public static class CollisionService
    {
        /// <summary>
        /// Проверяет есть ли коллизия между выбранным перетаскиваемым элементов и контейнером (Group)
        /// </summary>
        /// <param name="group">GroupBox, размер которого нужно изменить.</param>
        public static CustomGroupBox? FindCollisioningGroup(CustomGroupBox selectedGroupBox)
        {
            if (selectedGroupBox != null)
            {
                // Перебираем другие контролы в поиске коллизий
                foreach (Control control in AppContext.TaskBoard.Controls)
                {
                    if (control is CustomGroupBox containerGroupBox && containerGroupBox != selectedGroupBox)
                    {
                        if (containerGroupBox.Tag.ToString() == "Group")
                        {
                            // Границы выбранного GroupBox
                            Rectangle selectedBounds = selectedGroupBox.Bounds;

                            // Границы категории
                            Rectangle categoryBounds = containerGroupBox.Bounds;

                            // Проверяем коллизию
                            if (selectedBounds.IntersectsWith(categoryBounds))
                            {
                                return containerGroupBox;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
