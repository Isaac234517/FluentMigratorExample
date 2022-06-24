namespace MigrationTest{
   [Migration(202205121200)]
   public class DeleteLogType: Migration {
      public override void Up()
      {
        Delete.Column("Type").FromTable("Logs");
      }

      public override void Down(){
        Alter.Table("Logs")
        .AddColumn("Type")
        .AsString()
        .NotNullable();
      }
   }
}