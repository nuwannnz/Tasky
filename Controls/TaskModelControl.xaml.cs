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
using Tasky.Models;

namespace Tasky.Controls
{
    /// <summary>
    /// Interaction logic for TaskModelControl.xaml
    /// </summary>
    public partial class TaskModelControl : UserControl
    {
        public TaskModel Model { get; set; }
        private Interfaces.IDataRepository<TaskModel> _repo;

        public TaskModelControl():this(null,null)
        {
            InitializeComponent();
            
        }
        public TaskModelControl(TaskModel model,Interfaces.IDataRepository<TaskModel> data)
        {
            InitializeComponent();
            _repo = data;
            if (model == null)
            {
                this.Model = new TaskModel();
            }
            else
            {
                this.Model = model;
            }
            this.DataContext = Model;

            if (this.Model.IsDone)
            {
                MyCheckBox.IsChecked = true;
            }
        }

        private void MyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!Model.IsDone)
            {
                Model.IsDone = true;
                if (Properties.Settings.Default.DeleteAfterComplete)
                {
                    _repo.Delete(Model);
                }
                else
                {
                    _repo.Save(Model);
                }
            }
        }

        private void MyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Model.IsDone = false;
            _repo.Save(Model);
        }

        private void MyCancelButton_Click(object sender, RoutedEventArgs e)
        {
            MyEditModeGrid.Visibility = Visibility.Hidden;
        }

        private void MySaveButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Content = MyEditTextBox.Text;
            _repo.Save(Model);
        }

        private void MyEditButton_Click(object sender, RoutedEventArgs e)
        {
            MyEditModeGrid.Visibility = Visibility.Visible;
            MyEditTextBox.Text = Model.Content;
            RootGrid.ContextMenu.IsOpen = false;
        }

        private void MyDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _repo.Delete(Model);
            RootGrid.ContextMenu.IsOpen = false;
        }
    }
}
