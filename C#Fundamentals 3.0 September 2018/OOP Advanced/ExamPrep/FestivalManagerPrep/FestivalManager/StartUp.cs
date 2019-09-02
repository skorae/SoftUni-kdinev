namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Entities;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;
    using FestivalManager.Entities.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			IStage stage = new Stage();
			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

            IWriter writer = new Writer();
            IReader reader = new Reader();

			var engine = new Engine(festivalController, setController,writer,reader);

			engine.Run();
		}
	}
}