namespace MigrationTest{
   [Migration(202205120300)]
   public class CreateLogsForeginKeys: Migration {
      public override void Up()
      {
         Alter.Table("Logs").AddColumn("UserID").AsInt64();
         Create.ForeignKey("Log_USERID").FromTable("Logs")
         .ForeignColumn("UserID")
         .ToTable("Users")
         .PrimaryColumn("ID");
      }

      public override void Down(){
         Delete.ForeignKey("Log_USERID").OnTable("Logs");
         Delete.Column("UserID").FromTable("Logs");
      }
   }
}