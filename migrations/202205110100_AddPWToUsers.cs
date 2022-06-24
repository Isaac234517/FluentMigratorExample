namespace MigrationTest{
   [Migration(202205110100)]
   public class AddPWToUsers: Migration {
      public override void Up()
      {
         Alter.Table("Users")
         .AddColumn("Password").AsString(10);
      }

      public override void Down(){
         Delete.Column("Password").FromTable("Users");
      }
   }
}