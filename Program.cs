// See https://aka.ms/new-console-template for more information

Parser.Parse(args);
if(Parser.arguments == null){
      Console.WriteLine("Your did not input any arguments, the default action is up migration");
      Runner.Run("up");
      Console.WriteLine("Done");
}
else if(Parser.arguments.ContainsKey("h")){
   Console.WriteLine("--- This is a migration program");
   Console.WriteLine("The accept arguments show as follow");
   Console.WriteLine("-h show guidline");
   Console.WriteLine("-a up: do the up migraton action");
   Console.WriteLine("-a down: do the down migraton action");
   Console.WriteLine("-t xxxx: Target migration number");
}
else {
   string action = Parser.arguments.ContainsKey("a")? Parser.arguments["a"]: "up";
   long? target = Parser.arguments.ContainsKey("t")? long.Parse(Parser.arguments["t"]): null;
   if(action.Equals("down") && target == null){
      Console.WriteLine("Down action must sepecify the target verion");
   }
   else{
      Runner.Run(action, target);
      Console.WriteLine("Done");
   }
}



