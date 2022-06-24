namespace MigrationTest {
   public class Runner{

      public static void Run(string action, long? target = null){
          var serviceProvider = CreateServices();

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                if(action.Equals("down")){
                    RollbackupDatabase(scope.ServiceProvider, target!.Value);
                }
                else {
                    UpdateDatabase(scope.ServiceProvider, target);
                }
            }
      }

      private static IServiceProvider CreateServices(){
           return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SqlServer support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(SQLServerConnectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(CreateUserTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
      }

        private static void UpdateDatabase(IServiceProvider serviceProvider, long? version)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            if(version == null)
            // Execute the migrations
                runner.MigrateUp();
            else
                runner.MigrateUp(version!.Value);
        }


        private static void RollbackupDatabase(IServiceProvider serviceProvider, long version){
           var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
           runner.RollbackToVersion(version);
        }

        //Your sql server database connection string
        private const string SQLServerConnectionString = @"Data Source=xxxxxxx;Initial Catalog=FluentMigrator;Integrated Security=False;Persist Security Info=False;User ID=xxxx;Password=xxxxx;Trust Server Certificate=True";
   }
}