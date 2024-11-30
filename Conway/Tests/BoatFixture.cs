using System;

using Conway.Core.Configs;

namespace Conway.Tests
{
    public class BoatFixture : ConwayFixture
    {
        public void Test_Boat()
        {
            Verify(new BoatConfig(), new BoatConfig());
        }

        public void Test_Fail()
        {
            throw new Exception();
        }
    }
}
