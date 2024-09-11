using Lab2.Composite;
using Lab2.Factories;
using Lab2.Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab2.Services
{
    public static class FormDataService
    {
        public static void SaveFormData()
        {
            List<TaskComponent> formElements = new List<TaskComponent>();

            // Получаем все элементы формы из контекста приложения
            foreach (CustomGroupBox element in AppContext.TaskBoard.Controls)
            {
                TaskComponent component = (TaskComponent)element.Component;
                formElements.Add(component);
            }

            // Сериализуем список в JSON
            string formDataJson = JsonConvert.SerializeObject(formElements, Formatting.Indented);

            // Записываем JSON в файл
            File.WriteAllText("formData.json", formDataJson);
        }

        public static void LoadFormData()
        {
            // Читаем содержимое файла JSON
            string formDataJson = File.ReadAllText("formData.json");

            List<TaskComponent> formElements = new List<TaskComponent>();

            // Преобразуем JSON строку в массив объектов
            JArray jsonArray = JArray.Parse(formDataJson);

            // Проходим по каждому элементу массива и создаем соответствующий объект TaskComponent
            foreach (JToken jsonToken in jsonArray)
            {
                // Преобразуем каждый элемент массива в объект JObject
                JObject jsonObject = jsonToken as JObject;
                if (jsonObject != null)
                {
                    // Создаем TaskComponent с помощью фабрики TaskComponentFactory
                    TaskComponent component = TaskComponentFactory.CreateFromJson(jsonObject);
                    formElements.Add(component);
                }
            }

            // Воссоздаем форму
            RecreateTaskBoard(formElements);
        }


        private static void RecreateTaskBoard(List<TaskComponent> components)
        {
            foreach (TaskComponent component in components)
            {
                if (component is Composite.Task task)
                {
                    CustomGroupBox taskView = TaskCreator.RecreateTask(task);
                    task.View = taskView;
                    taskView.Parent = AppContext.TaskBoard;
                }
                else if (component is TaskGroup group)
                {

                    RecreateGroupAndChildren(group, AppContext.TaskBoard);
                }
            }
        }

        private static void RecreateGroupAndChildren(TaskGroup group,  CustomGroupBox parentControl)
        {
            CustomGroupBox groupView = GroupCreator.RecreateGroup(group);
            group.View = groupView;
            groupView.Parent = parentControl;

            if (parentControl != AppContext.TaskBoard) 
            {
                DraggableItemService.DeleteDragHandlers(groupView);
                GroupBoxViewService.ResizeGroup(parentControl);
                groupView.Controls[0].Visible = true;
            }

            foreach (TaskComponent child in group.Children)
            {
                if (child is Composite.Task childTask)
                {
                    CustomGroupBox childTaskView = TaskCreator.RecreateTask(childTask);
                    childTask.View = childTaskView;
                    groupView.Controls.Add(childTaskView);

                    childTaskView.Controls[0].Visible = true;
                    DraggableItemService.DeleteDragHandlers(childTaskView);
                    GroupBoxViewService.ResizeGroup(groupView);
                }

                else if (child is TaskGroup childGroup)
                {
                    RecreateGroupAndChildren(childGroup, groupView);
                }

            }
        }
    }
}
