using System;
using System.Threading;

using Gadgeteer.Modules.GHIElectronics;

using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

using Mjunit;

namespace Conway.Tests
{
    public class DisplayTestClient : ITestClient
    {
        private readonly Display_T35 _display;
        private readonly Font _font;
        private readonly Bitmap _bitmap;

        private TestOutcome _outcome;

        public DisplayTestClient(Display_T35 display, Font font)
        {
            _display = display;
            _font = font;
            _bitmap = new Bitmap((int)_display.Width, (int)_display.Height);
        }

        public void OnTestRunStart(object sender, TestRunEventHandlerArgs args)
        {
            _outcome = TestOutcome.Pass;
            _bitmap.Clear();
        }

        public void OnTestRunComplete(object sender, TestRunEventHandlerArgs args)
        {
            _bitmap.Clear();
            DrawOverview(args.Result);
            _bitmap.Flush();
        }

        public void OnSingleTestComplete(object sender, TestRunEventHandlerArgs args)
        {
            var r = args.Result;
            if (_outcome == TestOutcome.Pass)
            {
                _outcome = r.Outcome;
            }

            _bitmap.Clear();
            DrawSingle(r);
            _bitmap.Flush();
            Thread.Sleep(1000);
        }

        private void DrawOverview(TestResult r)
        {
            var color = r.Outcome == TestOutcome.Pass ? Colors.Green : Colors.Red;
            string header = r.Outcome == TestOutcome.Pass ? "Self-test succeeded!" : "Self-test failed...";
            string text = header + 
                "\n\nTest assembly:\n" + r.Name + 
                "\n\nTests run: " + r.NumberOfTests + 
                "\nTests passed: " + r.NumberOfTestsPassed +
                "\nTests failed: " + r.NumberOfTestsFailed;
            _bitmap.DrawTextInRect(text, 10, 10, 300, 200, 0, color, _font);
        }

        private void DrawSingle(TestResult r)
        {
            var color = r.Outcome == TestOutcome.Pass ? Colors.Green : Colors.Red;
            string outcomeText = GetOutcomeText(r.Outcome);
            string text = r.Name + " - " + outcomeText;
            if (r.Outcome == TestOutcome.Fail)
            {
                var single = r as SingleTestResult;
                if (single != null)
                {
                    var ex = single.AssertFailedException ?? single.Exception;
                    if (ex != null)
                    {
                        text += "\n" + ex.Message;
                    }
                }
            }

            _bitmap.DrawTextInRect(text, 10, 200, 300, 40, 0, color, _font);
        }

        private string GetOutcomeText(TestOutcome outcome)
        {
            if (outcome == TestOutcome.Pass)
            {
                return "Pass";
            }

            if (outcome == TestOutcome.Fail)
            {
                return "Fail";
            }

            return string.Empty;
        }
    }
}
