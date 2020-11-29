using bolnica.Controller;
using bolnica.Controller.decorators;
using bolnica.Model;
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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PSW_Wpf_doctor
{
    public partial class App : Application
    {
        private readonly MyDbContext myDbContext;

        public IUserController UserController { get; private set; }
        public IAddressController AddressController { get; private set; }
        public IStateController StateController { get; private set; }
        public ITownController TownController { get; private set; }

        public AuthorityDoctorDecorator DoctorDecorator { get; private set; }
        public AuthorityPatientDecorator PatientDecorator { get; private set; }
        public AuthoritySecretaryDecorator SecretaryDecorator { get; private set; }
        public AuthorityDirectorDecorator DirectorDecorator { get; private set; }
        public AuthoritySpecialityDecorator SpecialityDecorator { get; private set; }
        public AuthorityExaminationDecorator ExaminationDecorator { get; private set; }
        public AuthorityPatientFileDecorator PatientFileDecorator { get; private set; }
        public AuthorityDrugDecorator DrugDecorator { get; private set; }
        public AuthorityHospitalizationDecorator HospitalizationDecorator { get; private set; }
        public AuthorityOperationDecorator OperationDecorator { get; private set; }
        public AuthorityDiagnosisDecorator DiagnosisDecorator { get; private set; }
        public AuthorityPrescriptionDecorator PrescriptionDecorator { get; private set; }
        public AuthorityRefferalDecorator RefferalDecorator { get; private set; }
        public AuthoritySympthomDecorator SympthomDecorator { get; private set; }
        public AuthorityTherapyDecorator TherapyDecorator { get; private set; }
        public AuthorityIngredientDecorator IngredientDecorator { get; private set; }
        public AuthorityArticleDecorator ArticleDecorator { get; private set; }
        public AuthorityBusinessDayDecorator BusinessDayDecorator { get; private set; }
        public AuthorityRoomDecorator RoomDecorator { get; private set; }
        public AuthorityRoomTypeDecorator RoomTypeDecorator { get; private set; }
        public AuthorityEquipmentDecorator EquipmentDecorator { get; private set; }
        public AuthorityRenovationDecoratorcs RenovationDecoratorcs { get; private set; }
        public AuthorityDoctorGradeDecorator DoctorGradeDecorator { get; private set; }
        public AuthorityReportDecorator ReportDecorator { get; private set; }
        public BusinessDayService BusinessDayService { get; set; }
        public NotificationController NotificationController { get; private set; }

        private const String CSV_DELIMITER = ",";
        private const String CSV_DELIMITER2 = "|";
        private const String CSV_DICTIONARY_DELIMITER = ";";
        private const String CSV_ARRAY_DELIMITER = ":";
        private const String DOCTOR_FILE = "../../../../WellDevCore/Resources/Data/doctors.csv";
        private const String DOCTOR_GRADE_FILE = "../../../../WellDevCore/Resources/Data/doctorGradeFile.csv";
        private const String SPECIALITY_FILE = "../../../../WellDevCore/Resources/Data/speciality.csv";
        private const String HOSPITALIZATION_FILE = "../../../../WellDevCore/Resources/Data/hospitalizationFile.csv";
        private const String OPERATION_FILE = "../../../../WellDevCore/Resources/Data/operationFile.csv";
        private const String DIAGNOSIS_FILE = "../../../../WellDevCore/Resources/Data/diagnosisFile.csv";
        private const String PRESCRIPTION_FILE = "../../../../WellDevCore/Resources/Data/prescriptionFile.csv";
        private const String REFERRAL_FILE = "../../../../WellDevCore/Resources/Data/referralFile.csv";
        private const String SYMPTOM_FILE = "../../../../WellDevCore/Resources/Data/symptomFile.csv";
        private const String THERAPY_FILE = "../../../../WellDevCore/Resources/Data/therapyFile.csv";
        private const String ARTICLE_FILE = "../../../../WellDevCore/Resources/Data/articles.csv";
        private const String ROOMTYPE_FILE = "../../../../WellDevCore/Resources/Data/roomtypes.csv";
        private const String ROOM_FILE = "../../../../WellDevCore/Resources/Data/rooms.csv";
        private const String EQUIPMENT_FILE = "../../../../WellDevCore/Resources/Data/equipment.csv";
        private const String RENOVATION_FILE = "../../../../WellDevCore/Resources/Data/renovations.csv";
        private const String EXAM_UPCOMING_FILE = "../../../../WellDevCore/Resources/Data/upcomingExamination.csv";
        private const String EXAM_PREVIOUS_FILE = "../../../../WellDevCore/Resources/Data/examinationPrevious.csv";
        private const String PATIENTFILE_FILE = "../../../../WellDevCore/Resources/Data/patientFile.csv";
        private const String PATIENT_FILE = "../../../../WellDevCore/Resources/Data/patient.csv";
        private const String DRUG_FILE = "../../../../WellDevCore/Resources/Data/drugs.csv";
        private const String INGREDIENT_FILE = "../../../../WellDevCore/Resources/Data/ingredients.csv";
        private const String BUSSINESDAY_FILE = "../../../../WellDevCore/Resources/Data/businessdays.csv";
        private const String ADDRESS_FILE = "../../../../WellDevCore/Resources/Data/AddressFile.txt";
        private const String TOWN_FILE = "../../../../WellDevCore/Resources/Data/townFile.txt";
        private const String STATE_FILE = "../../../../WellDevCore/Resources/Data/StateFile.txt";
        private const String SECRETARY_FILE = "../../../../WellDevCore/Resources/Data/SecretaryFile.txt";
        private const String DIRECTOR_FILE = "../../../../WellDevCore/Resources/Data/director.csv";


       // public Program Program = new Program(NeuralNetwork, DataSet);

        public App()
        {

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


            AddressService addressService = new AddressService(addressRepository);
            StateService stateService = new StateService(stateRepository);
            TownService townService = new TownService(townRepository);
            DoctorService doctorService = new DoctorService(doctorRepository);
            DoctorGradeService doctorGradeService = new DoctorGradeService(doctorGradeRepository);
            SpecialityService specialityService = new SpecialityService(specialityRepository);
            HospitalizationService hospitalizationService = new HospitalizationService(hospitalizationRepository);
            OperationService operationService = new OperationService(operationRepository);
            DiagnosisService diagnosisService = new DiagnosisService(diagnosisRepository);
            PrescriptionService prescriptionService = new PrescriptionService(prescriptionRepository);
            ReferralService referralService = new ReferralService(referralRepository);
            SymptomService symptomService = new SymptomService(symptomRepository);
            TherapyService therapyService = new TherapyService(therapyRepository);
            ArticleService articleService = new ArticleService(articleRepository);
            ExaminationService examinationService = new ExaminationService(examinationUpcomingRepository, examinationPreviousRepository);
            DrugService drugService = new DrugService(drugRepository);
            IngredientService ingredientService = new IngredientService(ingredientRepository);
            PatientFileService patientFileService = new PatientFileService(patientFileRepository, hospitalizationService, operationService);
            PatientService patientService = new PatientService(patientRepository, patientFileService, doctorGradeService);
            BusinessDayService = new BusinessDayService(businessDayRepository, doctorService);
            RenovationService renovationService = new RenovationService(renovationRepository);
            RoomService roomService = new RoomService(roomRepository, renovationService, BusinessDayService, hospitalizationService);
            RoomTypeService roomTypeService = new RoomTypeService(roomTypeRepository, roomService);
            EquipmentService equipmentService = new EquipmentService(equipmentRepository, roomService);
            NotificationService notificationService = new NotificationService(drugService, BusinessDayService);
            NotificationController = new NotificationController(notificationService);
            ReportService reportService = new ReportService(examinationService, renovationService, hospitalizationService, operationService);
            SecretaryService secretaryService = new SecretaryService(secretaryRepository);
            DirectorService directorService = new DirectorService(directorRepository);
            UserService userService = new UserService(patientService, doctorService, secretaryService, directorService);

            UserController = new UserController(userService);
            var ArticleController = new ArticleController(articleService);
            var SpecialityController = new SpecialityController(specialityService);
            var ExaminationController = new ExaminationController(examinationService);
            var HospitalizationController = new HospitalizationController(hospitalizationService);
            var OperationController = new OperationController(operationService);
            var DiagnosisController = new DiagnosisController(diagnosisService);
            var PrescriptionController = new PrescriptionController(prescriptionService);
            var ReferralController = new ReferralController(referralService);
            var SymptomController = new SymptomController(symptomService);
            var DrugController = new DrugController(drugService);
            var IngredientController = new IngredientController(ingredientService);
            var PatientController = new PatientController(patientService);
            var PatientFileController = new PatientFileController(patientFileService);
            var RoomController = new RoomController(roomService);
            var RoomTypeController = new RoomTypeController(roomTypeService);
            var EquipmentController = new EquipmentController(equipmentService);
            AddressController = new AddressController(addressService);
            TownController = new TownController(townService);
            StateController = new StateController(stateService);
            var BusinessDayController = new BusinessDayController(BusinessDayService);
            var RenovationController = new RenovationController(renovationService);
            var DoctorGradeController = new DoctorGradeController(doctorGradeService);
            var DoctorController = new DoctorController(doctorService);
            var TherapyController = new TherapyController(therapyService);
            var ReportController = new ReportController(reportService);
            var SecretaryController = new SecretaryController(secretaryService);
            var DirectorContoller = new DirectorContoller(directorService);

            DoctorDecorator = new AuthorityDoctorDecorator(DoctorController, "Doctor");
            PatientDecorator = new AuthorityPatientDecorator(PatientController, "Doctor");
            SecretaryDecorator = new AuthoritySecretaryDecorator(SecretaryController, "Doctor");
            DirectorDecorator = new AuthorityDirectorDecorator(DirectorContoller, "Doctor");
            SpecialityDecorator = new AuthoritySpecialityDecorator(SpecialityController, "Doctor");
            ExaminationDecorator = new AuthorityExaminationDecorator(ExaminationController, "Doctor");
            PatientFileDecorator = new AuthorityPatientFileDecorator(PatientFileController, "Doctor");
            DrugDecorator = new AuthorityDrugDecorator(DrugController, "Doctor");
            HospitalizationDecorator = new AuthorityHospitalizationDecorator(HospitalizationController, "Doctor");
            OperationDecorator = new AuthorityOperationDecorator(OperationController, "Doctor");
            DiagnosisDecorator = new AuthorityDiagnosisDecorator(DiagnosisController, "Doctor");
            PrescriptionDecorator = new AuthorityPrescriptionDecorator(PrescriptionController, "Doctor");
            RefferalDecorator = new AuthorityRefferalDecorator(ReferralController, "Doctor");
            SympthomDecorator = new AuthoritySympthomDecorator(SymptomController, "Doctor");
            TherapyDecorator = new AuthorityTherapyDecorator(TherapyController, "Doctor");
            IngredientDecorator = new AuthorityIngredientDecorator(IngredientController, "Doctor");
            ArticleDecorator = new AuthorityArticleDecorator(ArticleController, "Doctor");
            BusinessDayDecorator = new AuthorityBusinessDayDecorator(BusinessDayController, "Doctor");
            RoomDecorator = new AuthorityRoomDecorator(RoomController, "Doctor");
            RoomTypeDecorator = new AuthorityRoomTypeDecorator(RoomTypeController, "Doctor");
            EquipmentDecorator = new AuthorityEquipmentDecorator(EquipmentController, "Doctor");
            RenovationDecoratorcs = new AuthorityRenovationDecoratorcs(RenovationController, "Doctor");
            DoctorGradeDecorator = new AuthorityDoctorGradeDecorator(DoctorGradeController, "Doctor");
            ReportDecorator = new AuthorityReportDecorator(ReportController, "Doctor");

        }

    }
}
