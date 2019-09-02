namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Test1()
        {
            ArsenalPart arsenalPart = new ArsenalPart("model", 0.5, 2.555m, 20);
            ShellPart shellPart = new ShellPart("shell", 2, 3, 5);
            EndurancePart endurancePart = new EndurancePart("hp", 2, 3, 6);
            Vanguard vanguardVehicle = new Vanguard("moodle", 4, 5, 100, 100, 100, new VehicleAssembler());

            vanguardVehicle.AddArsenalPart(arsenalPart);
            vanguardVehicle.AddShellPart(shellPart);
            vanguardVehicle.AddEndurancePart(endurancePart);

            string expected = vanguardVehicle.ToString();
            string actual = "Vanguard - moodle\r\nTotal Weight: 8.500\r\nTotal Price: 13.555\r\nAttack: 120\r\nDefense: 105\r\nHitPoints: 106\r\nParts: model, shell, hp";

            Assert.AreEqual(expected,actual);
        }
    }
}