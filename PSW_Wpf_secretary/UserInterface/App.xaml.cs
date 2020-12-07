using System;
using System.Windows;
using Repository;
using bolnica.Repository;
using Service;
using Controller;
using bolnica.Controller;
using System.Windows.Controls;
using bolnica.Service;
using bolnica.Controller.decorators;
using bolnica.Model;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MyDbContext myDbContext;

        private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";

        private const string DIRECTOR_FILE = "../../../../PSW_Wpf_director/Resources/Data/director.csv";
        private const String DOCTOR_FILE = "../../../../PSW_Wpf_director/Resources/Data/doctors.csv";
        private const String DOCTOR_GRADE_FILE = "../../../../PSW_Wpf_director/Resources/Data/doctorGradeFile.csv";
        private const String SPECIALITY_FILE = "../../../../PSW_Wpf_director/Resources/Data/speciality.csv";
        private const String HOSPITALIZATION_FILE = "../../../../PSW_Wpf_director/Resources/Data/hospitalizationFile.csv";
        private const String OPERATION_FILE = "../../../../PSW_Wpf_director/Resources/Data/operationFile.csv";
        private const String DIAGNOSIS_FILE = "../../../../PSW_Wpf_director/Resources/Data/diagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "../../../../PSW_Wpf_director/Resources/Data/prescriptionFile.csv";
        private const String REFERRAL_FILE = "../../../../PSW_Wpf_director/Resources/Data/referralFile.csv";
        private const String SYMPTOM_FILE = "../../../../PSW_Wpf_director/Resources/Data/symptomFile.csv";
        private const String THERAPY_FILE = "../../../../PSW_Wpf_director/Resources/Data/therapyFile.csv";
        private const String ARTICLE_FILE = "../../../../PSW_Wpf_director/Resources/Data/articles.csv";
        private const String ROOMTYPE_FILE = "../../../../PSW_Wpf_director/Resources/Data/roomtypes.csv";
        private const String ROOM_FILE = "../../../../PSW_Wpf_director/Resources/Data/rooms.csv";
        private const String EQUIPMENT_FILE = "../../../../PSW_Wpf_director/Resources/Data/equipment.csv";
        private const String RENOVATION_FILE = "../../../../PSW_Wpf_director/Resources/Data/renovations.csv";
        private const String EXAM_UPCOMING_FILE = "../../../../PSW_Wpf_director/Resources/Data/upcomingExamination.csv";
        private const String EXAM_PREVIOUS_FILE = "../../../../PSW_Wpf_director/Resources/Data/examinationPrevious.csv";
        private const String PATIENTFILE_FILE = "../../../../PSW_Wpf_director/Resources/Data/patientFile.csv";
        private const String PATIENT_FILE = "../../../../PSW_Wpf_director/Resources/Data/patient.csv";
        private const String DRUG_FILE = "../../../../PSW_Wpf_director/Resources/Data/drugs.csv";
        private const String INGREDIENT_FILE = "../../../../PSW_Wpf_director/Resources/Data/ingredients.csv";
        private const String BUSSINESDAY_FILE = "../../../../PSW_Wpf_director/Resources/Data/businessdays.csv";
        private const String ADDRESS_FILE = "../../../../PSW_Wpf_director/Resources/Data/AddressFile.txt";
        private const String TOWN_FILE = "../../../../PSW_Wpf_director/Resources/Data/townFile.txt";
        private const String STATE_FILE = "../../../../PSW_Wpf_director/Resources/Data/StateFile.txt";
        private const String SECRETARY_FILE = "../../../../PSW_Wpf_director/Resources/Data/SecretaryFile.txt";


        public AuthorityRoomTypeDecorator authorityRoomType { get; private set; }
        public AuthorityIngredientDecorator authorityIngredient { get; private set; }
        public AuthorityRoomDecorator authorityRoom { get; private set; }

        public AuthorityEquipmentDecorator authorityEquipment { get; private set; }

        public AuthorityRenovationDecoratorcs authorityRenovation { get; private set; }

        public AuthorityDrugDecorator authorityDrug { get; private set; }

        public AuthorityDoctorDecorator authorityDoctor { get; private set; }

        public AuthoritySpecialityDecorator authoritySpeciality { get; private set; }

        public IStateController StateController { get; private set; }

        public AuthorityBusinessDayDecorator authorityBusinessDay { get; private set; }

        public AuthorityDirectorDecorator authorityDirector { get; private set; }

        public AuthorityArticleDecorator authorityArticle { get; private set; }

        public AddressController AddressController { get; private set; }
        public NotificationController NotificationController { get; private set; }



        public IUserController UserController { get; private set; }
        public AuthorityExaminationDecorator authorityExamination { get; private set; }
        public AuthorityPatientDecorator authorityPatient { get; private set; }
        public AuthorityPatientFileDecorator authorityPatientFile { get; private set; }
        public AuthorityHospitalizationDecorator authorityHospitalization { get; private set; }
        public AuthorityOperationDecorator authorityOperation { get; private set; }
        public AuthorityDiagnosisDecorator authorityDiagnosis { get; private set; }
        public AuthorityPrescriptionDecorator authorityPrescription { get; private set; }
        public AuthorityRefferalDecorator authorityRefferal { get; private set; }
        public AuthoritySympthomDecorator authoritySymptom { get; private set; }
        public AuthorityTherapyDecorator authorityTherapy { get; private set; }
        public ITownController TownController { get; private set; }
        public AuthorityReportDecorator authorityReport { get; private set; }

        public App()
        {
            IRoomTypeController RoomTypeController;
            IIngredientController IngredientController;
            IRoomController RoomController;

            IEquipmentController EquipmentController;

            IRenovationController RenovationController;

            IDrugController DrugController;

            IDoctorController DoctorController;

            ISpecialityController SpecialityController;


            IBusinessDayController BusinessDayController;

            IDirectorController DirectorController;

            IArticleController ArticleController;

            IExaminationController ExaminationController;
            IPatientController PatientController;
            IPatientFileController PatientFileController;
            IHospitalizationController HospitalizationController;
            IOperationController OperationController;
            IDiagnosisController DiagnosisController;
            IPrescriptionController PrescriptionController;
            IReferralController ReferralController;
            ISymptomController SymptomController;
            ITherapyController TherapyController;
            IReportController ReportController;


            IDoctorGradeRepository doctorGradeRepository = new DoctorGradeRepository(myDbContext);
            ISpecialityRepository specialityRepository = new SpecialityRepository(myDbContext);
            ISymptomRepository symptomRepository = new SymptomRepository(myDbContext);
            IDiagnosisRepository diagnosisRepository = new DiagnosisRepository(symptomRepository, myDbContext);
            IngredientRepository ingredientRepository = new IngredientRepository(myDbContext);
            DrugRepository drugRepository = new DrugRepository(ingredientRepository, myDbContext);
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository(drugRepository, myDbContext);
            TherapyRepository therapyRepository = new TherapyRepository(drugRepository, myDbContext);
            RoomTypeRepository roomTypeRepository = new RoomTypeRepository(myDbContext);
            EquipmentRepository equipmentRepository = new EquipmentRepository(myDbContext);
            RoomRepository roomRepository = new RoomRepository(roomTypeRepository, equipmentRepository, myDbContext);
            BusinessDayRepository businessDayRepository = new BusinessDayRepository(roomRepository, myDbContext);
            RenovationRepository renovationRepository = new RenovationRepository(roomRepository, myDbContext);
            AddressRepository addressRepository = new AddressRepository(myDbContext);
            TownRepository townRepository = new TownRepository(addressRepository, myDbContext);
            StateRepository stateRepository = new StateRepository(townRepository, myDbContext);
            DoctorRepository doctorRepository = new DoctorRepository(businessDayRepository, specialityRepository, doctorGradeRepository, addressRepository, townRepository, stateRepository, myDbContext);
            ArticleRepository articleRepository = new ArticleRepository(doctorRepository, myDbContext);
            SecretaryRepository secretaryRepository = new SecretaryRepository(addressRepository, townRepository, stateRepository, myDbContext);
            DirectorRepository directorRepository = new DirectorRepository(addressRepository, townRepository, stateRepository, myDbContext);
            businessDayRepository._doctorRepository = doctorRepository;
            ReferralRepository referralRepository = new ReferralRepository(doctorRepository, myDbContext);
            PatientFileRepository patientFileRepository = new PatientFileRepository(myDbContext);
            PatientRepository patientRepository = new PatientRepository(patientFileRepository, addressRepository, townRepository, stateRepository, myDbContext);
            HospitalizationRepository hospitalizationRepository = new HospitalizationRepository(roomRepository, doctorRepository, myDbContext);
            OperationRepository operationRepository = new OperationRepository(roomRepository, doctorRepository, myDbContext);
            IExaminationUpcomingRepository examinationUpcomingRepository = new ExaminationUpcomingRepository(doctorRepository, patientRepository, myDbContext);
            IExaminationPreviousRepository examinationPreviousRepository = new ExaminationPreviousRepository(doctorRepository, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository, myDbContext);
            patientFileRepository._hospitalizationRepository = hospitalizationRepository;
            patientFileRepository._operationRepository = operationRepository;
            patientFileRepository._examinationPreviousRepository = examinationPreviousRepository;
            IFeedbackRepository feedbackRepository = new FeedbackRepository(myDbContext);
            IPatientNotificationRepository patientNotificationRepository = new PatientNotificationRepository(patientRepository, myDbContext);

            var specialityService = new SpecialityService(specialityRepository);
            var hospitalizationService = new HospitalizationService(hospitalizationRepository);
            var operationService = new OperationService(operationRepository);
            var diagnosisService = new DiagnosisService(diagnosisRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository);
            var referralService = new ReferralService(referralRepository);
            var symptomService = new SymptomService(symptomRepository);
            var therapyService = new TherapyService(therapyRepository);
            var examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository, diagnosisService, prescriptionService, referralService, symptomService, therapyService);
            var drugService = new DrugService(drugRepository);
            var ingredientService = new IngredientService(ingredientRepository);
            var doctorService = new DoctorService(doctorRepository);
            BusinessDayService businessDayService = new BusinessDayService(businessDayRepository, doctorService);
            var renovationService = new RenovationService(renovationRepository);
            var roomService = new RoomService(roomRepository, renovationService, businessDayService, hospitalizationService);
            var roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            var equipmentService = new EquipmentService(equipmentRepository, roomService);
            var doctorGradeService = new DoctorGradeService(doctorGradeRepository);
            var articleService = new ArticleService(articleRepository);
            var patientFileService = new PatientFileService(patientFileRepository);
            var patientService = new PatientService(patientRepository, patientFileService, doctorGradeService, examinationService);
            var secretaryService = new SecretaryService(secretaryRepository);
            var directorService = new DirectorService(directorRepository);
            var userService = new UserService(patientService, doctorService, secretaryService, directorService);
            var addressService = new AddressService(addressRepository);
            var townService = new TownService(townRepository);
            var stateService = new StateService(stateRepository);
            doctorService._doctorGradeService = doctorGradeService;
            var reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            var patientnotificationService = new PatientNotificationService(patientNotificationRepository);

            UserController = new UserController(userService);
            ArticleController = new ArticleController(articleService);
            SpecialityController = new SpecialityController(specialityService);
            ExaminationController = new ExaminationController(examinationService);
            HospitalizationController = new HospitalizationController(hospitalizationService);
            OperationController = new OperationController(operationService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            PrescriptionController = new PrescriptionController(prescriptionService);
            ReferralController = new ReferralController(referralService);
            SymptomController = new SymptomController(symptomService);
            DrugController = new DrugController(drugService);
            IngredientController = new IngredientController(ingredientService);
            DiagnosisController = new DiagnosisController(diagnosisService);
            PatientController = new PatientController(patientService);
            PatientFileController = new PatientFileController(patientFileService);
            RoomController = new RoomController(roomService);
            RoomTypeController = new RoomTypeController(roomTypeService);
            EquipmentController = new EquipmentController(equipmentService);
            AddressController = new AddressController(addressService);
            TownController = new TownController(townService);
            StateController = new StateController(stateService);
            BusinessDayController = new BusinessDayController(businessDayService);
            RenovationController = new RenovationController(renovationService);
            DoctorController = new DoctorController(doctorService);
            DirectorController = new DirectorContoller(directorService);
            TherapyController = new TherapyController(therapyService);


            //ReportService reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            ReportController = new ReportController(reportService);


            authorityReport = new AuthorityReportDecorator(ReportController, "Director");
            authorityArticle = new AuthorityArticleDecorator(ArticleController, "Director");
            authorityBusinessDay = new AuthorityBusinessDayDecorator(BusinessDayController, "Director");
            authorityDiagnosis = new AuthorityDiagnosisDecorator(DiagnosisController, "Director");
            authorityDirector = new AuthorityDirectorDecorator(DirectorController, "Director");
            authorityDoctor = new AuthorityDoctorDecorator(DoctorController, "Director");
            authorityDrug = new AuthorityDrugDecorator(DrugController, "Director");
            authorityEquipment = new AuthorityEquipmentDecorator(EquipmentController, "Director");
            authorityHospitalization = new AuthorityHospitalizationDecorator(HospitalizationController, "Director");
            authorityIngredient = new AuthorityIngredientDecorator(IngredientController, "Director");
            authorityOperation = new AuthorityOperationDecorator(OperationController, "Director");
            authorityPatient = new AuthorityPatientDecorator(PatientController, "Director");
            authorityPatientFile = new AuthorityPatientFileDecorator(PatientFileController, "Director");
            authorityPrescription = new AuthorityPrescriptionDecorator(PrescriptionController, "Director");
            authorityRefferal = new AuthorityRefferalDecorator(ReferralController, "Director");
            authorityRenovation = new AuthorityRenovationDecoratorcs(RenovationController, "Director");
            authorityRoom = new AuthorityRoomDecorator(RoomController, "Director");
            authoritySymptom = new AuthoritySympthomDecorator(SymptomController, "Director");
            authorityRoomType = new AuthorityRoomTypeDecorator(RoomTypeController, "Director");
            authorityDiagnosis = new AuthorityDiagnosisDecorator(DiagnosisController, "Director");
            authoritySpeciality = new AuthoritySpecialityDecorator(SpecialityController, "Director");
            authorityExamination = new AuthorityExaminationDecorator(ExaminationController, "Director");
            authorityTherapy = new AuthorityTherapyDecorator(TherapyController, "Director");

            UserController = new UserController(userService);

            NotificationService notificationService = new NotificationService(drugService, businessDayService);
            NotificationController = new NotificationController(notificationService);

            authorityArticle = new AuthorityArticleDecorator(ArticleController, "Director");
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textField = sender as TextBox;
            textField.SelectAll();
        }
    }
}
