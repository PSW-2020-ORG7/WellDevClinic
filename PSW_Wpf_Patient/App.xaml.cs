﻿
using bolnica.Controller;
using bolnica.Controller.decorators;
using bolnica.Model;
using bolnica.Model.Dto;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using bolnica.Service;
using Controller;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using Service;
using System;
using System.Windows;

namespace PSW_Wpf_Patient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MyDbContext myDbContext;

        public static int j = 0;
        private readonly String _patient_File = "../../../../WellDevCore/Resources/Data/patient.csv";
        private readonly String _patientFile_File = "../../../../WellDevCore/Resources/Data/patientFile.csv";
        private readonly String _article_File = "../../../../WellDevCore/Resources/Data/articles.csv";
        private readonly String _doctor_File = "../../../../WellDevCore/Resources/Data/doctors.csv";
        private readonly String _speciality_File = "../../../../WellDevCore/Resources/Data/speciality.csv";
        private readonly String _businessDay_File = "../../../../WellDevCore/Resources/Data/businessdays.csv";
        private readonly String _room_File = "../../../../WellDevCore/Resources/Data/rooms.csv";
        private readonly String _roomType_File = "../../../../WellDevCore/Resources/Data/roomtypes.csv";
        private readonly String _equipment_File = "../../../../WellDevCore/Resources/Data/equipment.csv";
        private readonly String _address_File = "../../../../WellDevCore/Resources/Data/AddressFile.txt";
        private readonly String _state_File = "../../../../WellDevCore/Resources/Data/StateFile.txt";
        private readonly String _town_File = "../../../../WellDevCore/Resources/Data/TownFile.txt";
        private readonly String _doctorGrade_File = "../../../../WellDevCore/Resources/Data/doctorGradeFile.csv";
        private readonly String _hospitalization_File = "../../../../WellDevCore/Resources/Data/hospitalizationFile.csv";
        private readonly String _examinationPrevius_File = "../../../../WellDevCore/Resources/Data/examinationPrevious.csv";
        private readonly String _examinationUpcoming_File = "../../../../WellDevCore/Resources/Data/upcomingExamination.csv";
        private readonly String _operation_File = "../../../../WellDevCore/Resources/Data/operationFile.csv";
        private readonly String _prescription_File = "../../../../WellDevCore/Resources/Data/prescriptionFile.csv";
        private readonly String _referral_File = "../../../../WellDevCore/Resources/Data/referralFile.csv";
        private readonly String _symptom_File = "../../../../WellDevCore/Resources/Data/symptomFile.csv";
        private readonly String _therapy_File = "../../../../WellDevCore/Resources/Data/therapyFile.csv";
        private readonly String _drug_File = "../../../../WellDevCore/Resources/Data/drugs.csv";
        private readonly String _ingredients_File = "../../../../WellDevCore/Resources/Data/ingredients.csv";
        private readonly String _diagnosis_File = "../../../../WellDevCore/Resources/Data/diagnosisFile.csv";
        private readonly String _renovation_File = "../../../../WellDevCore/Resources/Data/renovations.csv";
        private readonly String _secretary_File = "../../../../WellDevCore/Resources/Data/SecretaryFile.txt";
        private readonly String _director_File = "../../../../WellDevCore/Resources/Data/director.csv";
        private readonly String _notification_File = "../../../../WellDevCore/Resources/Data/patientNotification.csv";

        public IUserController UserController { get; set; }
        public AuthorityArticleDecorator ArticleDecorator
        { get; private set; }
        public AuthorityDoctorDecorator DoctorDecorator { get; set; }
        public AuthorityBusinessDayDecorator BusinessDayDecorator { get; set; }
        public AuthorityExaminationDecorator ExaminationDecorator { get; set; }
        public AuthorityPatientDecorator PatientDecorator { get; set; }
        public IStateController StateController { get; set; }
        public ITownController TownController { get; set; }
        public IAddressController AddressController { get; set; }
        public BusinessDayService BusinessDayService { get; set; }

        public IPatientNotificationController PatientNotificationController { get; set; }
        public AuthorityReportDecorator ReportDecorator { get; set; }

        public AuthorityDoctorGradeDecorator DoctorGradeDecorator { get; set; }

        public AuthoritySecretaryDecorator SecretaryDecorator { get; set; }

        App()
        {
            /*var addressRepo = new AddressRepository(new CSVStream<Address>(_address_File, new AddressCSVConverter(",")), new LongSequencer());
            var townRepo = new TownRepository(new CSVStream<Town>(_town_File, new TownCSVConverter(",", "|")), new LongSequencer(), addressRepo);
            var stateRepo = new StateRepository(new CSVStream<State>(_state_File, new StateCSVConverter(",", "|")), new LongSequencer(), townRepo);
            var doctorGradeRepo = new DoctorGradeRepository(new CSVStream<DoctorGrade>(_doctorGrade_File, new DoctorGradeCSVConverter("|", ";", ":")), new LongSequencer());
            var patientFileRepo = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter(",", "|")), new LongSequencer());
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter(",")), new LongSequencer(), patientFileRepo, addressRepo, townRepo, stateRepo);
            var specialityRepo = new SpecialityRepository(new CSVStream<Speciality>(_speciality_File, new SpecialityCSVConverter(",")), new LongSequencer());
            var equipmentRepo = new EquipmentRepository(new CSVStream<Equipment>(_equipment_File, new EquipmentCSVConverter(",")), new LongSequencer());
            var roomTypeRepo = new RoomTypeRepository(new CSVStream<RoomType>(_roomType_File, new RoomTypeCSVConverter(",")), new LongSequencer());
            var roomRepo = new RoomRepository(new CSVStream<Room>(_room_File, new RoomCSVConverter(",")), new LongSequencer(), roomTypeRepo, equipmentRepo);
            var businessDayRepo = new BusinessDayRepository(new CSVStream<BusinessDay>(_businessDay_File, new BusinessDayCSVConverter(",")), new LongSequencer(), roomRepo);
            var doctorRepository = new DoctorRepository(new CSVStream<Doctor>(_doctor_File, new DoctorCSVConverter(",")), new LongSequencer(), businessDayRepo, specialityRepo, doctorGradeRepo, addressRepo, townRepo, stateRepo);
            businessDayRepo._doctorRepository = doctorRepository;
            var articleRepo = new ArticleRepository(new CSVStream<Article>(_article_File, new ArticleCSVConverter("|")), new LongSequencer(), doctorRepository);
            var symptomRepository = new SymptomRepository(new CSVStream<Symptom>(_symptom_File, new SymptomCSVConverter(",")), new LongSequencer());
            var diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(_diagnosis_File, new DiagnosisCSVConverter(",")), new LongSequencer(), symptomRepository);
            var ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(_ingredients_File, new IngredientsCSVConverter(",")), new LongSequencer());
            var drugRepository = new DrugRepository(new CSVStream<Drug>(_drug_File, new DrugCSVConverter(",")), new LongSequencer(), ingredientRepository);
            var prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(_prescription_File, new PrescriptionCSVConverter(",", ":")), new LongSequencer(), drugRepository);
            var therapyRepository = new TherapyRepository(new CSVStream<Therapy>(_therapy_File, new TherapyCSVConverter("|", ":")), new LongSequencer(), drugRepository);
            var referralRepository = new ReferralRepository(new CSVStream<Referral>(_referral_File, new ReferralCSVConverter(",")), new LongSequencer(), doctorRepository);
            var hospitalizationRepository = new HospitalizationRepository(new CSVStream<Hospitalization>(_hospitalization_File, new HospitalizationCSVConverter(",")), new LongSequencer(), roomRepo, patientRepo, doctorRepository);
            var operationRepository = new OperationRepository(new CSVStream<Operation>(_operation_File, new OperationCSVConverter(",")), new LongSequencer(), roomRepo, doctorRepository, patientRepo);
            var examinationUpcomingRepository = new ExaminationUpcomingRepository(new CSVStream<Examination>(_examinationUpcoming_File, new UpcomingExaminationCSVConverter(",")), new LongSequencer(), doctorRepository, patientRepo);
            var examinationPreviousRepository = new ExaminationPreviousRepository(new CSVStream<Examination>(_examinationPrevius_File, new PreviousExaminationCSVConverter("|")), new LongSequencer(), doctorRepository, patientRepo, diagnosisRepository, prescriptionRepository, therapyRepository, referralRepository);
            patientFileRepo._examinationPreviousRepository = examinationPreviousRepository;
            patientFileRepo._hospitalizationRepository = hospitalizationRepository;
            patientFileRepo._operationRepository = operationRepository;
            var renovationRepo = new RenovationRepository(new CSVStream<Renovation>(_renovation_File, new RenovationCSVConverter("|")), new LongSequencer(), roomRepo);
            var secretaryRepo = new SecretaryRepository(new CSVStream<Secretary>(_secretary_File, new SecretaryCSVConverter(",")), new LongSequencer(), addressRepo, townRepo, stateRepo);
            var directorRepo = new DirectorRepository(new CSVStream<Director>(_director_File, new DirectorCSVConverter(",")), new LongSequencer(), addressRepo, townRepo, stateRepo);
            var notificationRepo = new PatientNotificationRepository(new CSVStream<PatientNotification>(_notification_File, new PatientNotificationCSVConverter(",")), new LongSequencer(), patientRepo);
            */

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
            BusinessDayService = new BusinessDayService(businessDayRepository, doctorService);
            var renovationService = new RenovationService(renovationRepository);
            var roomService = new RoomService(roomRepository, renovationService, BusinessDayService, hospitalizationService);
            var roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            var equipmentService = new EquipmentService(equipmentRepository, roomService);
            var doctorGradeService = new DoctorGradeService(doctorGradeRepository);
            var articleService = new ArticleService(articleRepository);
            var patientFileService = new PatientFileService(patientFileRepository);
            var patientService = new PatientService(patientRepository, patientFileService, doctorGradeService,examinationService);
            var secretaryService = new SecretaryService(secretaryRepository);
            var directorService = new DirectorService(directorRepository);
            var userService = new UserService(patientService, doctorService, secretaryService, directorService);
            var addressService = new AddressService(addressRepository);
            var townService = new TownService(townRepository);
            var stateService = new StateService(stateRepository);
            doctorService._doctorGradeService = doctorGradeService;
            var reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            var notificationService = new PatientNotificationService(patientNotificationRepository);


            UserController = new UserController(userService);
            var articleController = new ArticleController(articleService);
            var doctorController = new DoctorController(doctorService);
            var businessDayController = new BusinessDayController(BusinessDayService);
            var examinationController = new ExaminationController(examinationService);
            var patientController = new PatientController(patientService);
            TownController = new TownController(townService);
            AddressController = new AddressController(addressService);
            StateController = new StateController(stateService);
            var reportController = new ReportController(reportService);
            PatientNotificationController = new PatientNotificationController(notificationService);
            var doctorGradeController = new DoctorGradeController(doctorGradeService);
            var secretaryController = new SecretaryController(secretaryService);

            ArticleDecorator = new AuthorityArticleDecorator(articleController, "Patient");
            DoctorDecorator = new AuthorityDoctorDecorator(doctorController, "Patient");
            BusinessDayDecorator = new AuthorityBusinessDayDecorator(businessDayController, "Patient");
            ExaminationDecorator = new AuthorityExaminationDecorator(examinationController, "Patient");
            PatientDecorator = new AuthorityPatientDecorator(patientController, "Patient");
            ReportDecorator = new AuthorityReportDecorator(reportController, "Patient");
            DoctorGradeDecorator = new AuthorityDoctorGradeDecorator(doctorGradeController, "Patient");
            SecretaryDecorator = new AuthoritySecretaryDecorator(secretaryController, "Patient");


        }


    }
}
