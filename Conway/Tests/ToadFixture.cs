using Conway.Core.Configs;

namespace Conway.Tests
{
    public class ToadFixture : ConwayFixture
    {
        public void Test_Toad_Gen0()
        {
            Verify(new ToadConfig(0), new ToadConfig(1));
        }

        public void Test_Toad_Gen1()
        {
            Verify(new ToadConfig(1), new ToadConfig(0));
        }
    }
}
