using System.Collections;
using System.Reflection;
using System.Threading;

using Conway.Core;
using Conway.Core.Configs;
using Conway.Tests;

using Microsoft.SPOT;

using Mjunit;
using Gadgeteer.Modules.GHIElectronics;

namespace Conway
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            /*******************************************************************************************
            Modules added in the Program.gadgeteer designer view are used by typing 
            their name followed by a period, e.g.  button.  or  camera.
            
            Many modules generate useful events. Type +=<tab><tab> to add a handler to an event, e.g.:
                button.ButtonPressed +=<tab><tab>
            
            If you want to do something periodically, use a GT.Timer and handle its Tick event, e.g.:
                GT.Timer timer = new GT.Timer(1000); // every second (1000ms)
                timer.Tick +=<tab><tab>
                timer.Start();
            *******************************************************************************************/
           
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
            
            if (SelfTest())
            {
                Play(new GosperConfig());
            }
        }

        private bool SelfTest()
        {
            var font = Resources.GetFont(Resources.FontResources.NinaB);
            led.GreenBlueSwapped = true;
            var client = new LedTestClient(led);
            var clients = new ArrayList
                {
                    new DisplayTestClient(display, font),
                    client
                };
            Thread.Sleep(1000);
            
            var runner = new TestRunner(clients);
            runner.Run(Assembly.GetExecutingAssembly());

            do
            {
                Thread.Sleep(2000);
            }
            while (!runner.Done);

            Thread.Sleep(7000);

            return client.Success;
        }

        private static void Play(Config cfg, int delay = 0)
        {
            var life = new Life((uint)cfg.Columns, (uint)cfg.Rows, cfg.Cells);
            var painter = new Painter(cfg.Pixels);
            var cells = cfg.Cells;
            while (cells.Length > 0)
            {
                cells = life.Evolve();
                painter.Clear();
                foreach (var c in cells)
                {
                    painter.AddCell((int)c.X, (int)c.Y);
                }

                painter.Paint();

                if (delay > 0)
                {
                    Thread.Sleep(delay);
                }
            }
        }
    }
}
