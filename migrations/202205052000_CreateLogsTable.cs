namespace  MigrationTest
{
   [Migration(202205052000)]
   public class CreateLogsTable:Migration {
       public override void Up(){
          Create.Table("Logs")
         .WithColumn("Id").AsInt64().PrimaryKey().Identity()
         .WithColumn("Message").AsString().NotNullable()
         .WithColumn("Type").AsString().NotNullable()
         .WithColumn("LogDate").AsDateTime();
      }

      public override void Down(){
         Delete.Table("Logs");
      }
   }
}