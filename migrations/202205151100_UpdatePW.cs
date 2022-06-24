namespace MigrationTest {
  [Migration(20220515110000)]
  public class UpdatePW: Migration {
    public override void Up()
        {
          Update.Table("Users").Set(new { PW = "123456" })
          .Where( new {Name = "Hello" } );
        }

        public override void Down()
        {
          Update.Table("Users").Set(new { PW = "123"})
          .Where(new {  Name = "Hello"});
        }
  }
}