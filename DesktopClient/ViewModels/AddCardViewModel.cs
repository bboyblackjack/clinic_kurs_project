using System;
using System.Collections.Generic;
using DataModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Data;


namespace DesktopClient.ViewModels
{
    
    public class AddCardViewModel : BaseViewModel
    {
        public AddCardViewModel()
        {
            CommandAddCard = new RelayCommand(arg => AddCard());
            CommandSelectionPet = new RelayCommand(arg => SelectionPet());

            //данные для первого combobox (имя пользователя)
            users = UserController.GetAllUsers();           
            foreach (var usr in users)
            {
                listUsers.Add(new UserName(usr.UserId, usr.FullName));
            }
            _userNames = new CollectionView(listUsers);

            //данные для второго combobox (кличка животного)
            pets = PetController.GetAllPets();           
            foreach (var pt in pets)
            {
                listPets.Add(new PetName(pt.PetId, pt.Name));
            }
            _petNames = new CollectionView(listPets);
                         
        }

        //----------------------------------КОМАНДЫ-----------------------------------
        public ICommand CommandAddCard { get; set; }
        public ICommand CommandSelectionPet { get; set; }

        //------------------------------------ПОЛЯ------------------------------------
        private readonly CollectionView _userNames;
        private string _userName;

        private readonly CollectionView _petNames;
        private string _petName;

        List<User> users = new List<User>();
        List<Pet> pets = new List<Pet>();
        IList<UserName> listUsers = new List<UserName>();
        IList<PetName> listPets = new List<PetName>();

        private string _height;
        private string _weight;
        private double height;
        private double weight;


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
      
        public CollectionView PetNames
        {
            get { return _petNames; }
        }

        public string PetName
        {
            get { return _petName; }
            set
            {
                if (_petName != value)
                {
                    _petName = value;
                    OnPropertyChanged("PetName");
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
        
        //---------------------------------МЕТОДЫ------------------------------------
        private void AddCard()
        {
            int UserId = Convert.ToInt32(UserName.ToString());
            int PetId = Convert.ToInt32(PetName.ToString());
            PetUserModel PetUser = new PetUserModel();
            PetUser = PetController.GetPetById(PetId);
            if (PetUser.UserId == UserId)
            {
                try
                {
                    height = Convert.ToDouble(Height);
                    weight = Convert.ToDouble(Weight);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Рост и вес должны быть числовыми!");
                    return;
                }
                Card newCard = new Card()
                {
                    PetId = PetId,
                    Height = height,
                    Weight = weight,
                };
                var result = CardController.PostCard(newCard);
                if (result == "true")
                {

                    MessageBox.Show("Карточка добавлена!");
                    var window = System.Windows.Application.Current.Windows[1];
                    if (window != null)
                    {
                        window.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Карточка не была добавлена! Проверьте ввод данных!");
                }
                
            }
            else
            {
                MessageBox.Show("Клиент и питомец не принадлежат друг другу!");
            }
           
        }

        private void SelectionPet()
        {
            //string UserIdStr = UserName.ToString();
            //int UserId = Convert.ToInt32(UserIdStr);
            ////данные для второго combobox (кличка животного)
            //pets = PetViewModel.GetAllPets(UserId);
            //foreach (var pt in pets)
            //{
            //    listPets.Add(new PetName(pt.PetId, pt.Name));
            //}
           // _petNames = listPets;
        }

        
    }
}
