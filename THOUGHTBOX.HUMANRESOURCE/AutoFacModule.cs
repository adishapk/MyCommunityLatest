using Autofac;
using THOUGHTBOX.HR.SERVICES.Classes;
using THOUGHTBOX.HR.SERVICES.Interfaces;
using THOUGHTBOX.REPOSITORIES.Classes;
using THOUGHTBOX.REPOSITORIES.Interfaces;

namespace THOUGHTBOX.HUMANRESOURCE
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            //builder.Register(c => new SampleService(c.Resolve<SampleRepository>()))
            //    .As<ISampleRepository>()
            //    .InstancePerLifetimeScope();

            //Service Registration

            builder.RegisterType<RegistrationService>().As<IRegistration>().InstancePerLifetimeScope();
            builder.RegisterType<MastertypeServicce>().As<IMastertypeServicce>().InstancePerLifetimeScope();
            builder.RegisterType<SalarystructureService>().As<ISalarystructureService>().InstancePerLifetimeScope();
            builder.RegisterType<EmppersonalService>().As<IEmppersonalService>().InstancePerLifetimeScope();
            builder.RegisterType<UserdetailsService>().As<IUserdetailsService>().InstancePerLifetimeScope();
            builder.RegisterType<CreatealertsService>().As<ICreatealertsService>().InstancePerLifetimeScope();
            builder.RegisterType<CreateCustomerService>().As<ICreateCustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<CreateCompanyService>().As<ICreateCompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<CreateDepartmentService>().As<ICreateDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<createDivisionService>().As<ICreateDivision>().InstancePerLifetimeScope();
            builder.RegisterType<CreateRequestService>().As<ICreateRequestService>().InstancePerLifetimeScope();
            builder.RegisterType<AllocateEmployeesService>().As<IAllocateEmployeesService>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetyearService>().As<ICreatebusintargetyearService>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetmonthService>().As<ICreatebusintargetmonthService>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetmonthEmployeeService>().As<ICreatebusintargetmonthEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<CreateUserService>().As<ICreateUserService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentGraphService>().As<IDepartmentGraphService>().InstancePerLifetimeScope();
            builder.RegisterType<GeneralService>().As<IGeneralService>().InstancePerLifetimeScope();
            builder.RegisterType<RequestfeedbackService>().As<IRequestfeedbackService>().InstancePerLifetimeScope();


            // builder.RegisterType<CreateAccountGroupsServices>().As<ICreateAccountGroupsServices>().InstancePerLifetimeScope();

            //Repository Registration
            builder.RegisterType<DepartmentGraphRepository>().As<IDepartmentGraphRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CreateUserRepository>().As<ICreateUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RegistrationRepo>().As<IRegistrationRepo>().InstancePerLifetimeScope();
            builder.RegisterType<MastertypeRepo>().As<IMastertypeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<SalarystructureRepo>().As<ISalarystructureRepo>().InstancePerLifetimeScope();
            builder.RegisterType<EmppersonalRepo>().As<IEmppersonalRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserdetailsRepo>().As<IUserdetilsRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreatealertsRepo>().As<ICreatealertsRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreateCustomerRepo>().As<ICreateCustomerRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreateCompanyRepo>().As<ICreateCompanyRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreateDepartmentRepo>().As<ICreateDepartmentRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreateDivisionRepo>().As<ICreateDivisionRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreateRequestRepo>().As<ICreateRequestRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AllocateEmployeesRepo>().As<IAllocateEmployeesRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetyearRepo>().As<ICreatebusintargetyearRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetmonthRepo>().As<ICreatebusintargetmonthRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CreatebusintargetmonthEmployeeRepo>().As<ICreatebusintargetmonthEmployeeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<GeneralRepository>().As<IGeneralRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RequestfeedbackRepo>().As<IRequestfeedbackRepo>().InstancePerLifetimeScope();
        }
    }
}
