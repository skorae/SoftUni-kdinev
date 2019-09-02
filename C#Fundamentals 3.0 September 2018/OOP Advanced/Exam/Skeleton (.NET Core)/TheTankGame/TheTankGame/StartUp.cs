﻿namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IBattleOperator battleOperator = new TankBattleOperator();
            IManager manager = new TankManager(battleOperator);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);
            
            IEngine engine = new Engine(
                reader,
                writer,
                commandInterpreter);

            engine.Run();
        }
    }
}
