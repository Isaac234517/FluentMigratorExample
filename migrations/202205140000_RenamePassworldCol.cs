namespace MigrationTest {
   [Migration(202205140000)]
   public class RenamePasswordCol:Migration {
      public override void Up()
      {
         Rename.Column("Password").OnTable("Users")
         .To("PW");
      }

      public override void Down()
      {
         Rename.Column("PW").OnTable("Users")
         .To("Password");
      }
   }
}