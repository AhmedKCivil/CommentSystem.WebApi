using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using CommentSystem.Data.Interfaces;
using CommentSystem.Services;
using CommentSystem.Services.Interfaces;
using CommentSystem.Data.CommentSystemDB;

namespace CommentSystem.WebApi
{
	/// <summary>
	/// AutoFac dependency injection helper class
	/// </summary>
	public static class AutoFacConfig
	{
		/// <summary>
		/// Configures the dependency resolver
		/// </summary>
		/// <param name="config"></param>
		public static void Configure(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// OPTIONAL: Register the Autofac filter provider.
			builder.RegisterWebApiFilterProvider(config);

			RegisterTypes(builder);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		public static void RegisterTypes(ContainerBuilder builder)
		{
			builder.RegisterType<CommentSystemDBUnitOfWork>().As<ICommentSystemUnitOfWork>().InstancePerRequest();

			builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

			builder.RegisterType<CommentService>().As<ICommentService>().InstancePerRequest();

			builder.RegisterType<DateTimeService>().As<IDateTimeService>().InstancePerRequest();

			//builder.RegisterType<HAH_patientcarerecordService>().As<IHAH_patientcarerecordService>().InstancePerRequest();

			//builder.RegisterType<ContactService>().As<IContactService>().InstancePerRequest();

			//builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();

		}
	}
}