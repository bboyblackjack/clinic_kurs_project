using System;
using System.Collections.Generic;
using DataModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;

namespace DesktopClient.ViewModels
{
    public class DesignateServiceViewModel : BaseViewModel
    {
        public DesignateServiceViewModel()
        {
            CommandDesignateService = new RelayCommand(arg => DesignateService());
            
            //данные для combobox (имя пользователя)
            users = UserController.GetAllDoctors();
            foreach (var usr in users)
            {
                listUsers.Add(new UserName(usr.UserId, usr.FullName));
            }
            _userNames = new CollectionView(listUsers);
        }
        

        //----------------------------------КОМАНДЫ-----------------------------------
        public ICommand CommandDesignateService { get; set; }

        //------------------------------ПОЛЯ--------------------------------------------
        private readonly CollectionView _userNames;
        private string _userName;

        List<User> users = new List<User>();
        IList<UserName> listUsers = new List<UserName>();
        ApplicationsModel appModel = new ApplicationsModel();

        //-----------------------------СВОЙСТВА----------------------------------
        public CollectionView UserNames
        {
            get { return _userNames; }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
     

        //---------------------------------МЕТОДЫ------------------------------------
        private void DesignateService()
        {
            int UserId = Convert.ToInt32(UserName.ToString());
            var resultRecord = RecordsController.PostRecord(UserId);       
            if (resultRecord == "true")
            {
                MessageBox.Show("Услуга назначена!");
                var window = System.Windows.Application.Current.Windows[1];
                if (window != null)
                    window.Close();
            }
            else
            {
                MessageBox.Show("Услуга не была назначена! Проверьте ввод данных!");
            }
        }

    }
}
