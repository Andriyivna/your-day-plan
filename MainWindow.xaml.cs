using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace your_day_plan
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Task> tasks = new List<Task>();
        List<string> categoryArray = new List<string>();
        List<Task> DisplayActiveTasks = new List<Task>();
        List<Task> DisplayDoneTasks = new List<Task>();
        int currentEditingTask;
        string selectedDate;
        bool ignoreDate = false;
        public MainWindow()
        {
            InitializeComponent();

            //ChoseDate.Content = MyCalendar.DisplayDate.Date.ToShortDateString();
            
            DoneList.ItemsSource = DisplayDoneTasks;
            ActiveList.ItemsSource = DisplayActiveTasks;
            ChoseDate.Content = MyCalendar.DisplayDate.Date.ToShortDateString();
            selectedDate= MyCalendar.DisplayDate.Date.ToShortDateString();

        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            currentEditingTask = -1;
            AddTaskPopup.IsOpen = true;
          //  window.WindowStyle = WindowStyle.None;
           // window.ResizeMode = ResizeMode.NoResize;
            categoryBox.SelectedIndex=0;
            taskDate.SelectedDate = DateTime.Today;
            taskName.Focus();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (taskName.Text == "")
            {
                MessageBox.Show("Please, enter name of task");
            }
            else if (currentEditingTask == -1) {

                AddTaskPopup.IsOpen = false;
                // window.WindowStyle = WindowStyle.SingleBorderWindow;
                tasks.Add(new Task(taskName.Text, categoryBox.Text, taskDate.SelectedDate.Value.ToShortDateString(), false));
                UpdateDisplayingTasks();
                taskName.Text = "";
                categoryBox.Text = "";
            } else {
                AddTaskPopup.IsOpen = false;
                tasks[currentEditingTask].task = taskName.Text;
                tasks[currentEditingTask].category = categoryBox.Text;
                tasks[currentEditingTask].dateOfTask = taskDate.SelectedDate.Value.ToShortDateString();
                UpdateDisplayingTasks();
                taskName.Text = "";
                categoryBox.Text = "";

            }                     
        }

       

        private void NameOfTask_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void UpdateDisplayingTasks()
        {
            DisplayActiveTasks.Clear();
            DisplayDoneTasks.Clear();

            CreateCategoryArray();
           

            for (int i = 0; i < tasks.Count; i++)
            {
                
                if(!ignoreDate && tasks[i].dateOfTask != selectedDate)
                {
                    continue;
                }
               
                if (!categoryArray.Contains(tasks[i].category))
                {
                    continue;
                }
                if (tasks[i].done)
                {
                    DisplayDoneTasks.Add(tasks[i]);
                }
                else
                {
                    DisplayActiveTasks.Add(tasks[i]);
                }

                
                
            }
            ActiveList.Items.Refresh();
            DoneList.Items.Refresh();
        }

        private void NameOfTaskDone_Checked(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ignoreDate = false;       
            ChoseDate.Content = MyCalendar.SelectedDate.Value.ToShortDateString();
            selectedDate = MyCalendar.SelectedDate.Value.ToShortDateString();
           
            UpdateDisplayingTasks();
        }
            

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            Task task = ((Button)sender).Tag as Task;
            int index = tasks.IndexOf(task);
            tasks.RemoveAt(index);
            UpdateDisplayingTasks();
        }

        private void CreateCategoryArray()
        {
            categoryArray.Clear();
            if (meeting.IsChecked.Value || all.IsChecked.Value){
                categoryArray.Add("Meeting");
            } 
            if (work.IsChecked.Value || all.IsChecked.Value) {
                categoryArray.Add("Work");
            }
            if (sport.IsChecked.Value || all.IsChecked.Value) {
                categoryArray.Add("Sport");
            } 
            if ( noCategory.IsChecked.Value || all.IsChecked.Value) {
                categoryArray.Add("No category");
            }                     
        }

     

        private void all_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void noCategory_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }
      
        private void work_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void meeting_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void sport_Click(object sender, RoutedEventArgs e)
        {
            UpdateDisplayingTasks();
        }

        private void closePupup_Click(object sender, RoutedEventArgs e)
        {
            AddTaskPopup.IsOpen = false;
            taskName.Text = "";
            categoryBox.Text = "";
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Task tas = ((Button)sender).Tag as Task;
            int index = tasks.IndexOf(tas);
            currentEditingTask = index;
            
            AddTaskPopup.IsOpen = true;
            taskName.Text = tasks[index].task;
            taskName.CaretIndex = tasks[index].task.Length;
            taskName.ScrollToHorizontalOffset(double.MaxValue);
            taskName.Focus();
            categoryBox.Text = tasks[index].category;
            ChoseDate.Content = tasks[index].dateOfTask;
        }
       

        private void allTasks_Click(object sender, RoutedEventArgs e)
        {
            ignoreDate = true;
            UpdateDisplayingTasks();

        }
    }
}
