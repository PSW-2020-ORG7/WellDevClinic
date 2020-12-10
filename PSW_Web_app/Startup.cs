using System;
using bolnica.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Repository;
using bolnica.Repository;
using Service;
using bolnica.Service;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using System.IO;
namespace PSW_Web_app
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
              System.Threading.Thread.Sleep(70000);
            services.AddMvc();
            services.AddDbContext<MyDbContext>(opts =>
                    opts.UseMySql(CreateConnectionStringFromEnvironment(),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)).UseLazyLoadingProxies());
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            System.Threading.Thread.Sleep(60000);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
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
