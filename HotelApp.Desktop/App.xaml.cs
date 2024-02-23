using System.IO;
using System.Windows;

using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Desktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static ServiceProvider serviceProvider;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ServiceCollection services = new ServiceCollection();
			_ = services.AddTransient<MainWindow>();
			_ = services.AddTransient<CheckInForm>();
			_ = services.AddTransient<ISqlDataAccess, SqlDataAccess>();
			_ = services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();

			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			IConfiguration config = builder.Build();

			_ = services.AddSingleton(config);

			string dbChoice = config.GetValue<string>("DatabaseChoice").ToLower();
			if ( dbChoice == "sql" )
			{
				_ = services.AddTransient<IDatabaseData, SqlData>();
			}
			else if ( dbChoice == "sqlite" )
			{
				_ = services.AddTransient<IDatabaseData, SqliteData>();
			}
			else
			{
				// Fallback / Default value
				_ = services.AddTransient<IDatabaseData, SqlData>();
			}

			serviceProvider = services.BuildServiceProvider();
			MainWindow mainWindow = serviceProvider.GetService<MainWindow>();

			mainWindow.Show();
		}
	}
}
