namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void SetShouldPerformSuccessfully()
        {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);

            Set set = new Short("Set1");

            Performer performer = new Performer("Pesho", 20);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            Song song = new Song("Song1", new System.TimeSpan(0, 2, 30));
            set.AddSong(song);

            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = $"1. Set1:\r\n-- 1. Song1 (02:30)\r\n-- Set Successful";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(performer.Instruments.All(x => x.Wear < 100), Is.True);
        }

        [Test]
        public void SetShouldNotPerform()
        {
            Stage stage = new Stage();
            SetController setController = new SetController(stage);

            Set set = new Short("Set1");

            stage.AddSet(set);

            string expected = setController.PerformSets();
            string actual = $"1. Set1:\r\n-- Did not perform";

            Assert.AreEqual(expected, actual);
        }
    }
}