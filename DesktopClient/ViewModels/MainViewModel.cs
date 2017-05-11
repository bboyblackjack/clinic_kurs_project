using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DataModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;



namespace DesktopClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            //команды
            CommandSelectedCard = new RelayCommand(arg => SelectedCard());
            CommandAddCard = new RelayCommand(arg => AddCardShow());
            CommandEditCard = new RelayCommand(arg => EditCard());
            CommandDeleteCard = new RelayCommand(arg => DeleteCard());
            CommandDesignateService = new RelayCommand(arg => DesignateService());
            CommandCancel = new RelayCommand(arg => CancelService());
            CommandRefresh = new RelayCommand(arg => RefreshData());
            CommandLogout = new RelayCommand(arg => Logout());

            //Загрузить данные из БД
            GetAllCards();
            SelectedCard();
            GetAllApplications();
            GetAllRecords();
        }

        //----------------------------------КОМАНДЫ-----------------------------------
        public ICommand CommandSelectedCard { get; set; }
        public ICommand CommandAddCard { get; set; }
        public ICommand CommandEditCard { get; set; }
        public ICommand CommandDeleteCard { get; set; }
        public ICommand CommandDesignateService { get; set; }
        public ICommand CommandCancel { get; set; }
        public ICommand CommandRefresh { get; set; }
        public ICommand CommandLogout { get; set; }
        

        //------------------------------------ПОЛЯ------------------------------------
        //--------для первой вкладки--------
        private List<AllCardsModel> _gridCards;
        private List<Card> cards = new List<Card>();
        private string _card;
        private int _selectedIndexCard;

        //--------для второй вкладки--------
        private List<ApplicationsModel> _gridApplications;
        private int _selectedIndexApplication;
        private List<DataModel.Application> applications = new List<DataModel.Application>();

        //--------для третьей вкладки--------
        private List<RecordsModel> _gridRecords;
        private int _selectedIndexRecord;
        private List<Record> records = new List<Record>();



        //-----------------------------СВОЙСТВА----------------------------------
        //--------для первой вкладки--------
        public List<AllCardsModel> GridCards
        {
            get { return _gridCards; }
            set
            {
                if (_gridCards != value)
                {
                    _gridCards = value;
                    OnPropertyChanged("GridCards");
                }
            }
        }

        public string Card
        {
            get { return _card; }
            set
            {
                if (_card != value)
                {
                    _card = value;
                    OnPropertyChanged("Card");
                }
            }
        }

        public int SelectedIndexCard
        {
            get { return _selectedIndexCard; }
            set
            {
                if (_selectedIndexCard != value)
                {
                    _selectedIndexCard = value;
                    OnPropertyChanged("SelectedIndexCard");
                }
            }
        }

        //--------для второй вкладки--------
        public List<ApplicationsModel> GridApplications
        {
            get { return _gridApplications; }
            set
            {
                if (_gridApplications != value)
                {
                    _gridApplications = value;
                    OnPropertyChanged("GridApplications");
                }
            }
        }

        public int SelectedIndexApplication
        {
            get { return _selectedIndexApplication; }
            set
            {
                if (_selectedIndexApplication != value)
                {
                    _selectedIndexApplication = value;
                    OnPropertyChanged("SelectedIndexApplication");
                }
            }
        }

        //--------для третьей вкладки--------
        public List<RecordsModel> GridRecords
        {
            get { return _gridRecords; }
            set
            {
                if (_gridRecords != value)
                {
                    _gridRecords = value;
                    OnPropertyChanged("GridRecords");
                }
            }
        }

        public int SelectedIndexRecord
        {
            get { return _selectedIndexRecord; }
            set
            {
                if (_selectedIndexRecord != value)
                {
                    _selectedIndexRecord = value;
                    OnPropertyChanged("SelectedIndexRecord");
                }
            }
        }

        //---------------------------------МЕТОДЫ------------------------------------

        //получение списка карточек
        private void GetAllCards()
        {
            cards = CardController.GetAllCards();
            List<AllCardsModel> allCards = new List<AllCardsModel>();
            foreach (var card in cards)
            {
                AllCardsModel cardModel = new AllCardsModel()
                {
                    CardId = card.CardId,
                    UserName = card.Pet.User.FullName,
                    PetName = card.Pet.Name,
                };
                allCards.Add(cardModel);
            }
            GridCards = allCards;
        }

        //вывод все информации об одной карточке
        private void SelectedCard()
        {
            if (SelectedIndexCard == -1)
                SelectedIndexCard = 0;
            int id = GridCards[SelectedIndexCard].CardId;
            Card card = new Card();
            card = CardController.GetCardById(id);
            CardModel cardModel = new CardModel()
            {
                CardId = card.CardId,
                UserName = card.Pet.User.FullName,
                PetName = card.Pet.Name,
                Birthday = card.Pet.Birthday.ToString().Substring(0, 10),
                Kind = card.Pet.Kind.Name,
                Breed = card.Pet.Breed.Name,
                Color = card.Pet.Color.Name,
                Height = card.Height,
                Weight = card.Weight,
            };
            string result = "Номер карточки: " + cardModel.CardId.ToString() + "\r\n" + "\r\n" +
                            "Владелец: " + cardModel.UserName + "\r\n" + "\r\n" +
                            "Кличка животного: " + cardModel.PetName + "\r\n" + "\r\n" +
                            "Дата рождения: " + cardModel.Birthday + "\r\n" + "\r\n" +
                            "Вид: " + cardModel.Kind + "\r\n" + "\r\n" +
                            "Порода: " + cardModel.Breed + "\r\n" + "\r\n" +
                            "Окрас: " + cardModel.Color + "\r\n" + "\r\n" +
                            "Рост: " + cardModel.Height + " м" + "\r\n" + "\r\n" +
                            "Вес: " + cardModel.Weight + " кг";
            Card = result;
        }

        //получение всех необработанных заявок
        private void GetAllApplications()
        {
            applications = ApplicationController.GetAllApplications();
            List<ApplicationsModel> appModels = new List<ApplicationsModel>();
            foreach (var app in applications)
            {
                ApplicationsModel appModel = new ApplicationsModel()
                {
                    ApplicationId = app.ApplicationId,
                    UserName = app.User.FullName,
                    PetName = app.Pet.Name,
                    Service = app.Service.Name,
                    Date = app.Date.ToString().Substring(0, 10),
                    Time = app.Time.Interval,
                };
                appModels.Add(appModel);
            }
            GridApplications = appModels;
        }

        //получение всех обработанных заявок
        private void GetAllRecords()
        {
            records = RecordsController.GetAllRecords();
            List<RecordsModel> recordsModels = new List<RecordsModel>();
            foreach (var rcd in records)
            {
                RecordsModel recordModel = new RecordsModel()
                {
                    RecordId = rcd.RecordId,
                    DoctorName = rcd.User.FullName,
                    Service = rcd.Service.Name,
                    CardId = rcd.CardId,
                    Date = rcd.Date.ToString().Substring(0, 10),
                    Time = rcd.Time.Interval,
                };
                recordsModels.Add(recordModel);
            }
            GridRecords = recordsModels;
        }

        //открыть окно с добавлением карточки
        private void AddCardShow()
        {
            AddCardWindow addCardWindow = new AddCardWindow();
            addCardWindow.Show();
        }

        //редактировать карточку
        private void EditCard()
        {
            //получаем текущую карточку
            CardController.GetCurrentCard(GridCards[SelectedIndexCard].CardId);

            //открываем окно
            EditCardWindow editCardWindow = new EditCardWindow();
            editCardWindow.Show();
        }

        //удалить карточку
        private void DeleteCard()
        {
            var result = CardController.Delete(GridCards[SelectedIndexCard].CardId);
            if (result)
            {
                MessageBox.Show("Карточка удалена!");
            }
            else
            {
                MessageBox.Show("Карточка не удалена, так как к ней привязаны записи на услуги!");
            }
        }

        //команда назначить услугу
        private void DesignateService()
        {
            //получаем выбранную заявку
            try
            {
                RecordsController.GetCurrentApp(GridApplications[SelectedIndexApplication].ApplicationId);
                //открываем окно с назначением услуги
                DesignateServiceWindow designateServiceWindow = new DesignateServiceWindow();
                designateServiceWindow.Show();  
            }
            catch
            {
                MessageBox.Show("Выберите заявку!");
            }
                        
        }

        //Отменить услугу
        private  void CancelService()
        {
            try
            {
                var result = RecordsController.Delete(GridRecords[SelectedIndexRecord].RecordId);
                if (result)
                {
                    MessageBox.Show("Услуга отменена!");
                }
                else
                {
                    MessageBox.Show("Произошла ошибка! Услуга не отменена!");
                }
            }
            catch
            {
                MessageBox.Show("Выберите услугу!");
            }
                  
        }

       //Обновить данные
        private void RefreshData()
        {
            //Загрузить данные из БД
            GetAllCards();
            GetAllApplications();
            GetAllRecords();
            SelectedCard();
        }

        //выйти
        private void Logout()
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            var window = System.Windows.Application.Current.Windows[0];
            if (window != null)
                window.Close();           
        }

    }
}
