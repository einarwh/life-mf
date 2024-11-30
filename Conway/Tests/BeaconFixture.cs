using Conway.Core.Configs;

namespace Conway.Tests
{
    public class BeaconFixture : ConwayFixture
    {
        public void Test_Beacon_Gen0()
        {
            Verify(new BeaconConfig(0), new BeaconConfig(1));
        }

        public void Test_Beacon_Gen1()
        {
            Verify(new BeaconConfig(1), new BeaconConfig(0));
        }
    }
}
