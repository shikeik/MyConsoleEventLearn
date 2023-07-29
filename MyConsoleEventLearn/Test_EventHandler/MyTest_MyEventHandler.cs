

using System;

namespace MyConsoleEventLearn
{

    internal class MyTest_MyEventHandler
    {
        public MyTest_MyEventHandler()
        {
            var eventor = new MyEventor();
            
            var ent = new Entity();
            eventor.emt += ent.say;
            //eventor.emt = ent.say;

            eventor.RaiseEvent(ent);
            eventor.emt -= ent.say;

            eventor.RaiseEvent(ent);
        }

        class Entity
        {
            public string name = "A Entity";

            public void say(object ent, MyEventor.MyEventArgs args) { Rl.l($"{args.name}-say: {args.mes}"); }
    }

        class MyEventor
        {
            public event EventHandler<MyEventArgs> emt;
            public void RaiseEvent(Entity ent)
            {
                emt?.Invoke(ent, new MyEventArgs() { name = ent.name, mes = "say what" });
            }

            public class MyEventArgs: EventArgs
            {
                public string name;
                public string mes;
            }
        }
    }
}
