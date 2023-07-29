using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleEventLearn.Test_ActionAndFunc
{
    internal class MyTestAction_Package
    {
        public MyTestAction_Package()
        {
            Actioner ac = new Actioner();

            Entity entity = new Entity();
            ac.AddListener(entity.ReceiveAction);
            ac.AddListener(entity.ReceiveAction);

            ac.RaiseEvent(this, "Hello");
        }

        class Entity
        {
            public string name;

            public void ReceiveAction(Actioner.ActionArgs args)
            {
                Rl.l($"{name}Receive to {args.mes} by {args.sender}.");
            }
        }

        class Actioner
        {
            private Action<ActionArgs> MyAction;

            public void AddListener(Action<ActionArgs> m)
            {
                MyAction -= m;
                MyAction += m;
            }

            public void RaiseEvent(object sender, string mes)
            {
                var args = new ActionArgs()
                {
                    sender = sender,
                    mes = mes
                };
                MyAction?.Invoke(args);
            }

            public class ActionArgs
            {
                public object sender;
                public string mes;
            }
        }
    }
}
