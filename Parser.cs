namespace MigrationTest{
   public static class Parser {
      public static Dictionary<string, string> arguments;

      public static void Parse(string[] args){
         string[] arr = string.Join(" ", args).Split("-");
         if(arr.Length > 1){
            foreach(var arg in arr){
               string[] parameters = arg.Split(" ");
               if(arguments == null)
                  arguments = new Dictionary<string, string>();
               if(parameters.Length > 1)
                  arguments.Add(parameters[0], parameters[1]);
               else{
                  if(parameters[0].Equals("h"))
                     arguments.Add("h", "help");
               }
            }
         }
      }
   }
}