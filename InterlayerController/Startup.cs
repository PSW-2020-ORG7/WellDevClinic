using bolnica.Controller;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Service;
using Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model.Doctor;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace InterlayerController
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            //System.Threading.Thread.Sleep(25000);
            services.AddMvc();
            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());
            services.AddScoped<IExaminationController, ExaminationController>();
            services.AddScoped<IDoctorController, DoctorController>();
            services.AddScoped<IAddressController, AddressController>();
            services.AddScoped<IArticleController, ArticleController>();
            services.AddScoped<IBusinessDayController, BusinessDayController>();
            services.AddScoped<IDiagnosisController, DiagnosisController>();
            services.AddScoped<IDoctorGradeController, DoctorGradeController>();
            services.AddScoped<IDrugController, DrugController>();
            services.AddScoped<IEquipmentController, EquipmentController>();
            services.AddScoped<IFeedbackController, FeedbackController>();
            services.AddScoped<IHospitalizationController, HospitalizationController>();
            services.AddScoped<IIngredientController, IngredientController>();
            services.AddScoped<INotificationController, NotificationController>();
            services.AddScoped<IOperationController, OperationController>();
            services.AddScoped<IPatientFileController, PatientFileController>();
            services.AddScoped<IPatientNotificationController, PatientNotificationController>();
            services.AddScoped<IPatientController, PatientController>();
            services.AddScoped<IPrescriptionController, PrescriptionController>();
            services.AddScoped<IReferralController, ReferralController>();
            services.AddScoped<IRenovationController, RenovationController>();
            services.AddScoped<IReportController, ReportController>();
            services.AddScoped<IRoomController, RoomController>();
            services.AddScoped<IRoomTypeController, RoomTypeController>();
            services.AddScoped<ISecretaryController, SecretaryController>();
            services.AddScoped<ISpecialityController, SpecialityController>();
            services.AddScoped<IStateController, StateController>();
            services.AddScoped<ISymptomController, SymptomController>();
            services.AddScoped<ITherapyController, TherapyController>();
            services.AddScoped<ITownController, TownController>();
            services.AddScoped<IUserController, UserController>();
            services.AddScoped<IDirectorController, DirectorContoller>();

            services.AddScoped<IExaminationService, ExaminationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IBusinessDayService, BusinessDayService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IDoctorGradeService, DoctorGradeService>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IHospitalizationService, HospitalizationService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IPatientFileService, PatientFileService>();
            services.AddScoped<IPatientNotificationService, PatientNotificationService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IReferralService, ReferralService>();
            services.AddScoped<IRenovationService, RenovationService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<ISecretaryService, SecretaryService>();
            services.AddScoped<ISpecialityService, SpecialityService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ISymptomService, SymptomService>();
            services.AddScoped<ITherapyService, TherapyService>();
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDirectorService, DirectorService>();


            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IBusinessDayRepository, BusinessDayRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IDoctorGradeRepository, DoctorGradeRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IExaminationPreviousRepository, ExaminationPreviousRepository>();
            services.AddScoped<IExaminationUpcomingRepository, ExaminationUpcomingRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IHospitalizationRepository, HospitalizationRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IPatientFileRepository, PatientFileRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientNotificationRepository, PatientNotificationRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IReferralRepository, ReferralRepository>();
            services.AddScoped<IRenovationRepository, RenovationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<ISecretaryRepository, SecretaryRepository>();
            services.AddScoped<ISpecialityRepository, SpecialityRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<ITherapyRepository, TherapyRepository>();
            services.AddScoped<ITownRepository, TownRepository>();
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext db)
        {
            //System.Threading.Thread.Sleep(25000);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     FileProvider = new PhysicalFileProvider(
            //     Path.Combine(env.ContentRootPath, "profilePictures")),
            //     RequestPath = "/StaticFiles"
            // });
        }
        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newmydb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }
    }
}
