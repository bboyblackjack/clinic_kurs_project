using System;
using System.Collections.Generic;
using DataModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;

namespace DesktopClient.ViewModels
{
    public class EditCardViewModel : BaseViewModel
    {
        public EditCardViewModel()
        {
            CommandEditCard = new RelayCommand(arg => EditCard());
        }

        //----------------------------------КОМАНДЫ-----------------------------------
        public ICommand CommandEditCard { get; set; }

        //------------------------------ПОЛЯ--------------------------------------------
        private string _weight;
        private string _height;

        private double height;
        private double weight;

        //-----------------------------СВОЙСТВА----------------------------------
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }

        public string Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        //---------------------------------МЕТОДЫ------------------------------------
        private void EditCard()
        {
            try
            {
                height = Convert.ToDouble(Height);
                weight = Convert.ToDouble(Weight);
            }
            catch
            {
                MessageBox.Show("Рост и вес должны быть числовыми! Проверьте ввод данных!");
            }

            var result = CardController.Edit(height, weight);
            if (result)
            {
                MessageBox.Show("Карточка изменена!");
                var window = System.Windows.Application.Current.Windows[1];
                if (window != null)
                    window.Close();
            }
            else
            {
                MessageBox.Show("Карточка не была изменена! Проверьте ввод данных!");
            }
        }
    }
}
