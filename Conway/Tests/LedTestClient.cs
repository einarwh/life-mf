using Gadgeteer.Modules.GHIElectronics;

using Microsoft.SPOT.Presentation.Media;

using Mjunit;

namespace Conway.Tests
{
    public class LedTestClient : ITestClient
    {
        private readonly MulticolorLed _led;

        private bool _isBlinking;
        private bool _hasFailed;

        public LedTestClient(MulticolorLed led)
        {
            _led = led;
            Init();
        }

        public bool Success
        {
            get
            {
                return !_hasFailed;
            }
        }

        public void Init()
        {
            _led.TurnOff();
            _isBlinking = false;
            _hasFailed = false;
        }

        public void OnTestRunStart(object sender, TestRunEventHandlerArgs args)
        {
            Init();
        }

        public void OnTestRunComplete(object sender, TestRunEventHandlerArgs args)
        {
            OnAnyTestComplete(sender, args);
        }

        public void OnSingleTestComplete(object sender, TestRunEventHandlerArgs args)
        {
            OnAnyTestComplete(sender, args);
        }

        private void OnAnyTestComplete(object sender, TestRunEventHandlerArgs args)
        {
            if (!_hasFailed)
            {
                if (args.Result.Outcome == TestOutcome.Fail)
                {
                    _led.BlinkRepeatedly(Colors.Red);
                    _hasFailed = true;
                }
                else if (!_isBlinking)
                {
                    _led.BlinkRepeatedly(Colors.Green);
                }

                _isBlinking = true;
            }
        }
    }
}