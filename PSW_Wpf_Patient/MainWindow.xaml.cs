using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.ComponentModel;
using MahApps.Metro.Controls;
using MahApps.Metro;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using Application = System.Windows.Application;
using System.Linq;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using System.Text;
using Model.Dto;
using Model.Users;
using Model.Doctor;
using bolnica.Model.Dto;
using Model.PatientSecretary;
using bolnica.Service;
using ControlzEx.Theming;

using Patient = PSW_Wpf_Patient.Client.Patient;
namespace PSW_Wpf_Patient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {

        public List<ExaminationDTO> scheduledExaminations { get; set; }
        public List<ExaminationDTO> upcomingExaminations { get; set; }
        public List<Doctor> listOfDoctors { get; set; }
        public List<Article> ListOfArticles { get; set; }
        public List<Doctor> doctorsForGrade { get; set; }
        public Patient _patient { get; set; }
        public List<State> States { get; set; }
        public List<Town> Towns { get; set; }
        public List<Address> Addresses { get; set; }
        public static int Theme = 0;

        public MainWindow(Patient patient)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _patient = patient;

            InitializeComponent();

            Country.DisplayMemberPath = "Name";
            Country.SelectedValuePath = "Id";
            App app = Application.Current as App;
            Town.DisplayMemberPath = "Name";
            Town.SelectedValuePath = "Id";
            Addressessss.DisplayMemberPath = "FullAddress";
            Addressessss.SelectedValuePath = "Id";
           
            PriorityBox.SelectedIndex = 0;
            Picker2.Visibility = Visibility.Hidden;
            if (_patient.Guest == true)
            {
                TabExamination.Visibility = Visibility.Hidden;
                TabFile.Visibility = Visibility.Hidden;
                FeedbackHeader.Visibility = Visibility.Hidden;
            }
            

            Picker.DisplayDateStart = DateTime.Now.AddDays(1);
            Picker2.DisplayDateStart = DateTime.Now.AddDays(1);
            this.DataContext = this;

        }

        private void NotifyPatient()
        {
            var app = Application.Current as App;
           

        }
        private void UpdateTownAddress(object sender, RoutedEventArgs e)
        {
            State state = Country.SelectedItem as State;
            Towns = state.GetTown();
            Towns.Sort((x, y) => x.Name.CompareTo(y.Name));
            Town.ItemsSource = Towns;
            Addressessss.ItemsSource = null;


        }

        private void UpdateAddress(object sender, RoutedEventArgs e)
        {
            Town town = Town.SelectedItem as Town;
            if (town == null)
                return;
            Addresses = town.GetAddress();
            Addresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
            Addressessss.ItemsSource = Addresses;
        }

        private void FillData()
        {
            var app = Application.Current as App;
            listOfDoctors = app.DoctorDecorator.GetDoctorsBySpeciality(new Speciality("Opsta praksa"));
            ListOfArticles = app.ArticleDecorator.GetAll().ToList();
            doctorsForGrade = new List<Doctor>();
            upcomingExaminations = new List<ExaminationDTO>();
            
            FillAccountData(_patient);
            SetExaminations();
            SetOperation();
            SetHospitalizations();
            SetArticle(ListOfArticles);
            SetSecretary();
        }

        private void SetSecretary()
        {
            var app = Application.Current as App;
            Secretary secretary = app.SecretaryDecorator.GetAll().ToList()[0];
            TextBlock secret = new TextBlock();
            secret.FontSize = 14;
            secret.Inlines.Add(new Run("Secretary: ") { FontWeight = FontWeights.Bold });
            secret.Inlines.Add(secretary.FullName + "\n");
            secret.Inlines.Add("Phone number: " + secretary.Phone + "\n");
            secret.Inlines.Add("Email: " + secretary.Email + "\n");
            secret.Margin = new Thickness(10, 10, 10, 10);

            Secretary.Children.Add(secret);
        }

        private void SetExaminations()
        {
            var app = Application.Current as App;
            List<Examination> examinations = new List<Examination>();
            
        }

        private void SetHospitalizations()
        {
            var app = Application.Current as App;
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
           
            if (hospitalizations == null)
            {
                return;
            }
            foreach (var hospitalization in hospitalizations)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock description = new TextBlock();

                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.Bold });
                period.FontSize = 15;
                period.Inlines.Add(hospitalization.Period.StartDate.ToString() + "->" + hospitalization.Period.EndDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.Bold });
                room.FontSize = 15;
                room.Inlines.Add(hospitalization.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                b.Child = stackPanelExamination;

                Hospit.Children.Add(b);
            }
        }


        private void SetOperation()
        {
            var app = Application.Current as App;
            List<Operation> operations = new List<Operation>();
            
            if (operations == null)
            {
                return;
            }
            foreach (var operation in operations)
            {

                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock doctor = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock room = new TextBlock();
                TextBlock description = new TextBlock();

                doctor.FontSize = 15;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.Bold });
                doctor.Inlines.Add(operation.Doctor.FullName);
                doctor.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.Bold });
                period.FontSize = 15;
                period.Inlines.Add(operation.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                room.Inlines.Add(new Run("Prostorija: ") { FontWeight = FontWeights.Bold });
                room.FontSize = 15;
                room.Inlines.Add(operation.Room.RoomCode);
                room.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(room);

                //
                description.Inlines.Add(new Run("Opis: ") { FontWeight = FontWeights.Bold });
                description.FontSize = 15;
                description.Inlines.Add(operation.Description);
                description.Margin = new Thickness(10);
                stackPanelExamination.Children.Add(description);



                b.Child = stackPanelExamination;

                Operations.Children.Add(b);
            }
        }

        private void SetArticle(List<Article> listOfArticles)
        {
            ArticlesPanel.Children.Clear();
            foreach (var article in listOfArticles)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 15;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.FontSize = 13;
                newText.MaxWidth = 700;
                writer.FontSize = 12;


                newTopic.Text = article.Topic;
                writer.Text = article.Doctor.FirstName + " " + article.Doctor.LastName;
                newText.Text = article.Text;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(newText);
                stackPanelArticle.Children.Add(writer);

                b.Child = stackPanelArticle;

                ArticlesPanel.Children.Add(b);
            }
        }
        private void FillAccountData(Patient patient)
        {
            
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private List<ExaminationDTO> GetScheduledExaminations()
        {
            var app = Application.Current as App;
            List<Examination> upcomingExaminations = app.ExaminationDecorator.GetUpcomingExaminationsByUser(this._patient.Id);
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            if (upcomingExaminations == null)
            {
                return retVal;
            }
            foreach (Examination exam in upcomingExaminations)
            {
                ExaminationDTO examinationDTO = new ExaminationDTO();
                examinationDTO.Id = exam.Id;
                examinationDTO.Doctor = exam.Doctor;
                examinationDTO.Period = exam.Period;
                BusinessDay day = app.BusinessDayDecorator.GetExactDay(exam.Doctor, exam.Period.StartDate);
                examinationDTO.Room = day.room;
                retVal.Add(examinationDTO);
            }

            return retVal;
        }


        private void LogOut(object sender, RoutedEventArgs e)
        {
            DeleteExamination delete;
            DialogResult result;

            delete = new DeleteExamination("Are you sure you want to log out?", "Yes", "No", "Log out", MainWindow.Theme);
            result = delete.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                App.j = 0;
                WindowLogIn wl = new WindowLogIn();
                wl.Show();
                this.Close();
            }
        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*if ((int)DarkMode.Value == 1)
            
            }*/
        }



        private void ChoosePhoto(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String fileName = op.FileName;
                SuccessUpdatePhoto.Foreground = Brushes.Green;

                SuccessUpdatePhoto.Text = "You have successfully changed photo!";

                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(SuccessUpdatePhoto);
            }
        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {

            var app = Application.Current as App;
            int prom = 0;
            var state = Country.SelectedItem as State;
            var town = Town.SelectedItem as Town;
            var selectedAddress = Addressessss.SelectedItem as Address;

            if (town == null || state == null)
            {
                return;
            }


            
        }

        private void Password(object sender, RoutedEventArgs e)
        {
            
            CurrentPassword.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
        }


        private void PasswordCheck(object sender, RoutedEventArgs e)
        {

            CheckPassword.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();

        }

        private void UpdatePassword(object sender, RoutedEventArgs e)
        {
            if (CurrentPassword.Text != "" && NewPassword.Text != "")
            {
               
                var app = Application.Current as App;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(SuccessUpdatePw);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SetArticle(this.ListOfArticles);
            }
            else
            {
                List<Article> searchList = new List<Article>();
                foreach (Article article in this.ListOfArticles)
                {
                    if (article.Topic.ToLower().Contains(SearchBox.Text.ToLower()))
                        searchList.Add(article);
                }
                if (searchList.Count == 0)
                {
                    SetArticle(this.ListOfArticles);
                    return;
                }
                SetArticle(searchList);
            }

        }

        private void CurrentTherapy(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Izvestaj";

            dlg.Title = "Select PDFFile";
            dlg.Filter = "PDF(*.pdf)|*.pdf";
            String path = "";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                path = Path.GetFullPath(dlg.FileName);
                string filename = dlg.FileName;

                Document doc = new Document(iTextSharp.text.PageSize.A4, 20f, 20f, 30f, 30f);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                doc.Open();
                doc.SetMargins(50, 50, 50, 50);

                Paragraph header = new Paragraph("Izveštaj o trenutnoj terapiji");

                header.Alignment = 1;
                header.Font.Size = 18;
                header.Font.SetStyle(1);
                doc.Add(header);
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));
                doc.Add(new Chunk("\n"));

                Paragraph basicInfo = new Paragraph();
                Chunk basicInfoheader = new Chunk("OSNOVNE INFORMACIJE O PACIJENTU");
                basicInfoheader.Font.Size = 14;
                basicInfoheader.Font.SetStyle(1);
                basicInfo.Add(basicInfoheader);
                basicInfo.Add(new Chunk("\n"));
               // basicInfo.Add("Ime i prezime pacijenta: " + _patient.FullName);
                basicInfo.Add(new Chunk("\n"));
               // basicInfo.Add("Username: " + _patient.Username);
                basicInfo.Add(new Chunk("\n"));


                Paragraph therapy = new Paragraph();
                therapy.Add(new Chunk("\n"));
                therapy.Add(new Chunk("\n"));
                Chunk therapHeader = new Chunk("Trenutna terapija: ");
                therapHeader.Font.Size = 14;
                therapHeader.Font.SetStyle(1);
                therapy.Add(therapHeader);
                therapy.Add(new Chunk("\n"));
               
                therapy.Add(new Chunk("\n"));

                doc.Add(basicInfo);
                doc.Add(therapy);
                doc.Close();



                string messageBoxText = "Uspesno kreiran izvestaj!";
                string caption = "Informacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;

                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);

            }
            else
            {
                return;
            }


            try
            {
                Process process = new System.Diagnostics.Process();
                String file;

                file = path;

                process.StartInfo.FileName = file;
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Feedback(object sender, RoutedEventArgs e)
        {

            if (FeedBack.Text.Length != 0)
            {

                FeedBack.Clear();

                FeedbackText.Text = "Thank you for sharing with us your opinion! ";

                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(FeedbackText);
            }

        }


        private void GradeADoctorButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<String, double> gradesPerQuestion = new Dictionary<string, double>();
            gradesPerQuestion["0"] = Slider1.Value;
            gradesPerQuestion["1"] = Slider2.Value;
            gradesPerQuestion["2"] = Slider3.Value;
            gradesPerQuestion["3"] = Slider4.Value;
            gradesPerQuestion["4"] = Slider5.Value;

            var doctor = (Doctor)DoctorsForFeedback.SelectedItem;
            if (doctor == null)
            {
                FeedbackDOctor.Foreground = Brushes.Red;
                FeedbackDOctor.Text = "You have to pik doctor!";
                Storyboard ssb = Resources["sbHideAnimation"] as Storyboard;
                ssb.Begin(FeedbackDOctor);
                return;
            }

            var app = Application.Current as App;
            app.PatientDecorator.GiveGradeToDoctor(doctor, gradesPerQuestion);
            FeedbackDOctor.Foreground = Brushes.Green;

            FeedbackDOctor.Text = "You have successfully graded the doctor!";

            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
            sb.Begin(FeedbackDOctor);
        }



        private void ScheduleExamination(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = scheduleExaminationsGrid.SelectedItem;

            if (selectedItem == null)
            {
                return;
            }
            if (scheduledExaminations.Count >= 3)
            {
                ErrorSchedule.Foreground = Brushes.Red;

                ErrorSchedule.Text = "You have a maximum number of appointments scheduled!";


                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorSchedule);
                return;
            }

            ErrorSchedule.Foreground = Brushes.Green;
            DeleteExamination delete;
            ExaminationDTO scheduleExam = (ExaminationDTO)selectedItem;

            delete = new DeleteExamination("Schedule examination at the doctor  " +
                                                                        scheduleExam.Doctor.FirstName + " " + scheduleExam.Doctor.LastName + "?", "Yes", "No", "Schedule examination", MainWindow.Theme);
            ErrorSchedule.Text = "You have successfully scheduled an examination!";

            DialogResult result = delete.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Doctor doctor = scheduleExam.Doctor;
                Period period = scheduleExam.Period;

                BusinessDay day = app.BusinessDayDecorator.GetExactDay(doctor, period.StartDate);
                List<Period> periods = new List<Period>();
                periods.Add(period);
                app.BusinessDayDecorator.MarkAsOccupied(periods, day);

                scheduledExaminations = GetScheduledExaminations();
                scheduledExaminationsGrid.ItemsSource = scheduledExaminations;
                upcomingExaminations = new List<ExaminationDTO>();
                scheduleExaminationsGrid.ItemsSource = upcomingExaminations;

                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorSchedule);
            }

        }

        private void CancelExamination(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = scheduledExaminationsGrid.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            ErrorCancel.Foreground = Brushes.Green;
            DeleteExamination delete;
            ExaminationDTO deleteExam = (ExaminationDTO)selectedItem;
            delete = new DeleteExamination("Are you sure you want to cancel the examination at the doctor  " +
                                                                        deleteExam.Doctor.FirstName + " " + deleteExam.Doctor.LastName + "?", "Yes", "No", "Delete examination", MainWindow.Theme);
            ErrorCancel.Text = "You have successfully canceled the appointment!";
            TimeSpan difference = deleteExam.Period.StartDate - DateTime.Now;
            if (difference.TotalMinutes < 24 * 60)
            {
                ErrorCancel.Text = "It is not possible to cancel an appointment held in the next 24";
                ErrorCancel.Foreground = Brushes.Red;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorCancel);
                return;
            }
            DialogResult result = delete.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Examination toDelete = new Examination(deleteExam.Id);
                app.ExaminationDecorator.Delete(toDelete);
                BusinessDay selectedDay = app.BusinessDayDecorator.GetExactDay(deleteExam.Doctor, deleteExam.Period.StartDate);
                List<DateTime> periods = new List<DateTime>();
                periods.Add(deleteExam.Period.StartDate);
                app.BusinessDayDecorator.FreePeriod(selectedDay, periods);

                scheduledExaminations = GetScheduledExaminations();
                scheduledExaminationsGrid.ItemsSource = scheduledExaminations;

                ErrorCancel.Text = "You have successfully canceled the appointment.";
                ErrorCancel.Foreground = Brushes.Green;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorCancel);
            }
        }


        private void SearchPeriods(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            if (DoctorsForExaminations.SelectedItem == null)
                return;
            if (PriorityBox.SelectedIndex == 0)
            {
                if (Picker.SelectedDate == null)
                    return;

                app.BusinessDayService._searchPeriods = new NoPrioritySearch();
                Doctor doctor = (Doctor)DoctorsForExaminations.SelectedItem;
                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period);
                businessDayDTO.PatientScheduling = true;
                upcomingExaminations = app.BusinessDayDecorator.Search(businessDayDTO);
                scheduleExaminationsGrid.ItemsSource = upcomingExaminations;
            }
            else if (PriorityBox.SelectedIndex == 1)
            {
                if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                    return;

                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                period.EndDate = DateTime.Parse(Picker2.Text);

                if (period.StartDate >= period.EndDate)
                    return;

                app.BusinessDayService._searchPeriods = new DoctorPrioritySearch();
                Doctor doctor = (Doctor)DoctorsForExaminations.SelectedItem;
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period);
                businessDayDTO.PatientScheduling = true;
                upcomingExaminations = app.BusinessDayDecorator.Search(businessDayDTO);
                scheduleExaminationsGrid.ItemsSource = upcomingExaminations;
            }
            else
            {
                if (Picker.SelectedDate == null || Picker2.SelectedDate == null)
                    return;

                Period period = new Period();
                period.StartDate = DateTime.Parse(Picker.Text);
                period.EndDate = DateTime.Parse(Picker2.Text);
                if (period.StartDate >= period.EndDate)
                    return;

                app.BusinessDayService._searchPeriods = new DatePrioritySearch();
                Doctor doctor = (Doctor)DoctorsForExaminations.SelectedItem;
                BusinessDayDTO businessDayDTO = new BusinessDayDTO(doctor, period);
                businessDayDTO.PatientScheduling = true;
                upcomingExaminations = app.BusinessDayDecorator.Search(businessDayDTO);
                scheduleExaminationsGrid.ItemsSource = upcomingExaminations;
            }
        }

        private void PriorityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PriorityBox.SelectedIndex != 0)
            {
                Picker2.Visibility = Visibility.Visible;
            }

        }



        private String _ime;
        public String Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private String _password;
        public String Password1
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private String _password2;
        public String Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                if (value != _password2)
                {
                    _password2 = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private String _password3;
        public String Password3
        {
            get
            {
                return _password3;
            }
            set
            {
                if (value != _password3)
                {
                    _password3 = value;
                    OnPropertyChanged("Password");
                }
            }
        }



        private DateTime _dateTime = DateTime.Today;
        public DateTime DATETIME
        {
            get
            {
                return _dateTime;
            }
            set
            {
                if (value != _dateTime)
                {
                    _dateTime = value;
                    OnPropertyChanged("DATETIME");
                }
            }
        }


        private String _prezime;
        public String Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                if (value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        private String _jmbg;
        public String JMBG
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        private String _username;
        public String USERNAME
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("USERNAME");
                }
            }
        }
        private String _email;
        public String EMAIL
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("EMAIL");
                }
            }
        }
        private String _adress;
        public String ADRESS
        {
            get
            {
                return _adress;
            }
            set
            {
                if (value != _adress)
                {
                    _adress = value;
                    OnPropertyChanged("ADRESS");
                }
            }
        }

        private String _phone;
        public String Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        private void DoctorsForExaminations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var app = Application.Current as App;
            var selectedItem = DoctorsForExaminations.SelectedItem;
            Doctor dr = (Doctor)selectedItem;
            if (dr != null)
            {
                ButtonGrade.Content = app.DoctorGradeDecorator.GetAverageGrade(null).ToString();
            }
        }
        private void Button_Map(object sender, RoutedEventArgs e)
        {
            PSW_Wpf_app.MainWindow main = new PSW_Wpf_app.MainWindow("patient");

            main.Show();
        }
    }
}
