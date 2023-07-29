using System;

namespace MyConsoleEventLearn
{

    internal class MyTestDefaultEventHandler
    {
        public MyTestDefaultEventHandler()
        {
            var eventor = new Eventor();
            eventor.emt += (object sender, EventArgs args) => { Rl.l("Im a emt-" + sender + ", Args: " + args.ToString()); };

            eventor.RaiseEvent(this, EventArgs.Empty);
        }

        class Eventor
        {
            public event EventHandler emt; 
            public void RaiseEvent(object sender, EventArgs args) { emt?.Invoke(sender, args); }
        }
    }
}
