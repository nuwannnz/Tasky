using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Tasky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

        private Interfaces.IDataRepository<Models.TaskModel> _repo;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.TaskModel> TaskList { get; set;}
        public ObservableCollection<Controls.TaskModelControl> TaskControlList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this._repo = new Data.JsonRepository<Models.TaskModel>();
            _repo.DataChanged += (s) => { Load(); };
            TaskList = new ObservableCollection<Models.TaskModel>();
            TaskControlList = new ObservableCollection<Controls.TaskModelControl>();
            this.DataContext = this;
       

         //   Load();
        }

        private void Load()
        {
            TaskList.Clear();
            TaskList = _repo.GetAll();
            CreateControls();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaskControlList"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var model = new Models.TaskModel() { Content = MyTextBox.Text, IsDone = false };
            _repo.Add(model);
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void CreateControls()
        {
            TaskControlList.Clear();
            foreach(var model in TaskList)
            {
                var control = new Controls.TaskModelControl(model,_repo);
                TaskControlList.Add(control);
            }
        }
    }
}
