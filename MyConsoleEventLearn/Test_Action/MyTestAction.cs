using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleEventLearn.Test_ActionAndFunc
{
    internal class MyTestAction
    {
        public MyTestAction()
        {
            Actioner ac = new Actioner();

            Entity entity = new Entity();
            ac.MyAction += entity.ReceiveAction;
            ac.MyAction += entity.ReceiveAction;

            ac.MyAction = entity.ReceiveAction;

            ac.MyAction?.Invoke("hello?");
        }

        class Entity
        {
            public string name;

            public void ReceiveAction(string mes) { Rl.l(mes); }
        }

        class Actioner
        {
            public Action<string> MyAction;

        }
    }
}
