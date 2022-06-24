namespace  MigrationTest
{
   [Migration(202205121300)]
   public class SeedUserData:Migration {
      public override void Up()
      {
         Insert.IntoTable("Users").Row (
            new { Name = "Hello", UserName = "World", BirthDay = new DateTime(2000,11,1,12,1,0), Password = "123"}
         );
      }

      public override void Down()
      {
         Delete.FromTable("Users").Row(
            new { Name = "Hello"}
         );
      }
   }
   
}