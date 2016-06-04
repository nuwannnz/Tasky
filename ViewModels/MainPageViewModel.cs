#define NOT_DESIGN
#define DESIGN_TIME
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tasky.Interfaces;
using Tasky.Models;
using Tasky.MVVM;

namespace Tasky.ViewModels
{
    public class MainPageViewModel:MVVM.ViewModelBase
    {
        private IDataRepository<TaskModel> _dataRepository = null;
      
        private bool _isInAddMode = false;
        private ObservableCollection<Controls.TaskModelControl> _controlList = null;

       
     
        public MainPageViewModel()
        {
            //intializing the data repository

            _controlList = new ObservableCollection<Controls.TaskModelControl>();
#if DESIGN_TIME
            _dataRepository = new Data.JsonRepository<TaskModel>();
            _dataRepository.DataChanged += (s) => { Load(); };

          

            //loding data
            Load();
#endif
           
            
        }


#region Visual Methods
        public string  DayInt
        {
            get
            {
                var _dayInt= DateTime.Today.Day.ToString();
                if(_dayInt.Length == 1)
                {
                    _dayInt = string.Format("0{0}", _dayInt);
                }
                return _dayInt;
            }
        }

        public string DayNameString
        {
            get
            {
               return DateTime.Today.DayOfWeek.ToString();                       
            }
        }

        public string MonthAndYearString
        {
            get
            {
                var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month).ToString();
                var year = DateTime.Today.Year.ToString();

                return string.Format("{0}, {1}", month, year);
            }
        }

        public string StatusString
        {
            get
            {
                var status = "Tasks remaining";
                if(ControlList.Count>0 && RemainingTasks == string.Empty)
                {
                    status = "Okay, all done";
                }
                return status;
            }
        }

        public SolidColorBrush StatusColorBrush
        {
            get
            {                
                Color statusColor = new Color();
                statusColor = (Color)ColorConverter.ConvertFromString("#FFC13232");
                if(StatusString != "Tasks remaining")
                {
                    statusColor = (Color)ColorConverter.ConvertFromString("#FF17B25D");
                }
                return new SolidColorBrush(statusColor);
            }
        }

        public bool IsInAddMode
        {
            get { return _isInAddMode; }
            set
            {                 
                _isInAddMode = value; RaisePropertyChanged(nameof(IsInAddMode));
            }
        }

        public string  RemainingTasks
        {
            get
            {
                var count= _controlList.Where(x => (x.Model.IsDone == false)).Count();
                var countString = string.Empty;
                if (count > 0)
                    countString = count.ToString();
                return countString;
            }
        }
#endregion

        public ObservableCollection<Controls.TaskModelControl> ControlList
        {
            get { return _controlList; }
            set { _controlList = value;RaisePropertyChanged(nameof(ControlList)); }                        
        }

        public void ReCallData()
        {
            Load();
        }

        //This method will get all the task models and then update the ControlList      
        private void Load()
        {
            this.ControlList.Clear();
            var modelList =  _dataRepository.GetAll();

            foreach(var model in modelList)
            {
                var control = new Controls.TaskModelControl(model, _dataRepository);
                this.ControlList.Add(control);
            }
            RaisePropertyChanged(nameof(ControlList));
            RaisePropertyChanged(nameof(RemainingTasks));
            RaisePropertyChanged(nameof(StatusColorBrush));
            RaisePropertyChanged(nameof(StatusString));
        }

        private void JustDesignTime()
        {
            for (int i = 0; i < 10; i++)
            {
                var control1 = new Controls.TaskModelControl(new TaskModel() { IsDone = false }, _dataRepository);
                var control2 = new Controls.TaskModelControl(new TaskModel() { IsDone = true }, _dataRepository);

                ControlList.Add(control1);
                ControlList.Add(control2);
            }
        }

#region Commands

        public ICommand AddNewCommand
        {
            get
            {
                return new DelegateCommand((object p) =>
                {
                    var contentTextBox = p as TextBox;
                    if (contentTextBox != null)
                    {
                        var content = contentTextBox.Text;
                        if (!string.IsNullOrEmpty(content))
                        {
                            TaskModel model = new TaskModel()
                            {
                                Content = content,
                                IsDone = false
                            };

                            //adding the model to the repo
                               _dataRepository.Add(model);

                            contentTextBox.Text = string.Empty;
                        }
                    }
                    //toggleing the IsInAddMode
                    IsInAddMode = !IsInAddMode;

                });
            }
        }

        public ICommand ToggleAddModeCommand
        {
            get
            {
                return new DelegateCommand((object p) =>
                {
                    var contentTextbox = p as TextBox;
                    if(contentTextbox != null)
                    {
                        contentTextbox.Text = string.Empty;
                    }
                    IsInAddMode = !IsInAddMode;
                });
            }
        }
#endregion
    }
}
