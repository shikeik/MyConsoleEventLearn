using System;

namespace MyConsoleEventLearn
{
    internal class MyTestFunc
    {
        public MyTestFunc()
        {
            Functor ac = new Functor();

            Entity entity = new Entity();
            ac.MyFunc += entity.ReceiveFunc;
            ac.MyFunc += entity.ReceiveFunc;

            ac.MyFunc = entity.ReceiveFunc;
            ac.MyFunc += entity.ReceiveFunc;

            var ret = ac.MyFunc?.Invoke(new Param() { value = 0 });

            Rl.l(ret.value+"");
        }

        class Entity
        {
            public string name;

            public Param ReceiveFunc(Param mes)
            {
                var randomNum = new Random().Next(10);
                Rl.l(mes.value + "+" + randomNum);

                mes.value += randomNum;
                return mes;
            }
        }

        class Functor
        {
            public Func<Param, Param> MyFunc;

        }

        class Param
        {
            public int value = 0;
        }
    }
}