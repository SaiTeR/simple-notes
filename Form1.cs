using Lab2.Managers;
using System.Drawing.Text;
using Lab2.Composite;
using Lab2.Services;

namespace Lab2
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            AppContext.TaskBoard = taskBoardGb;
            FormDataService.LoadFormData();
        }


        private void createTaskBtn_Click(object sender, EventArgs e)
        {
            string name;
            if (taskNameTxt.Text == "")
            {
                name = "Новая заметка";
            }
            else
            {
                name = taskNameTxt.Text;
            }

            Composite.Task newTask = new Composite.Task(name);
            newTask.Create();
            taskBoardGb.Controls.Add(newTask.View);

            taskNameTxt.Text = "";
        }


        private void createGroupBtn_Click(object sender, EventArgs e)
        {
            string name;
            if (groupNameTxt.Text == "")
            {
                name = "Новая группа";
            }
            else
            {
                name = groupNameTxt.Text;
            }

            TaskGroup newGroup = new TaskGroup(name);
            newGroup.Create();

            taskBoardGb.Controls.Add(newGroup.View);
            groupNameTxt.Text = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDataService.SaveFormData();
        }
    }
}
