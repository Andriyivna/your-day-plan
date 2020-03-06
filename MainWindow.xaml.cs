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

        public MainWindow()
        {
            InitializeComponent();

           
            ChoseDate.Content = MyCalendar.DisplayDate.Date.ToShortDateString();


            list.ItemsSource = tasks;
         

        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskPopup.IsOpen = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddTaskPopup.IsOpen = false;           
            tasks.Add(new Task(taskName.Text, categoryBox.Text, taskDate.DisplayDate.ToShortDateString(),false));
            list.Items.Refresh();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
