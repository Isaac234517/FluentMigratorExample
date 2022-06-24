
namespace MigrationTest {
   [Migration(202205051453)]
   public class CreateUserTable:Migration {
      public override void Up(){
         Create.Table("Users")
         .WithColumn("Id").AsInt64().PrimaryKey().Identity()
         .WithColumn("Name").AsString().NotNullable()
         .WithColumn("UserName").AsString().NotNullable()
         .WithColumn("Birthday").AsDateTime();
      }

      public override void Down(){
         Delete.Table("Users");
      }
   }
}