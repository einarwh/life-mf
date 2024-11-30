using Conway.Core.Configs;

namespace Conway.Tests
{
    public class BlinkerFixture : ConwayFixture
    {
        public void Test_Blinker_Gen0()
        {
            Verify(new BlinkerConfig(0), new BlinkerConfig(1));
        }

        public void Test_Blinker_Gen1()
        {
            Verify(new BlinkerConfig(1), new BlinkerConfig(0));
        }
    }
}
