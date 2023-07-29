using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleEventLearn
{
    internal class Test_DelegateAndEvent
    {
        public Test_DelegateAndEvent()
        {
            //test1();
            test2();
        }

        /// <summary>
        ///总结：
        ///<para/>delegate可以定义传入参数与返回值并调用，
        ///<para/>并且可在外部增删改以及调用
        /// </summary>
        private void test1()
        {
            var dclass = new MyDelegateClass();
            dclass.mydele = new MyDelegateClass.MyDelegate((string mes) => { Rl.l("重置mydele: " + mes); });
            dclass.mydele?.Invoke("message");
        }

        /// <summary>
        ///总结：
        ///<para/>event对delegate进行封装，使用封装后的event替换delegate从而限制其=赋值以及Invoke调用
        ///<para/>
        ///<para/>使用情况：
        ///<para/>在不希望外部可以=清零delegate时：
        ///<para/>使用event封装并声明RaiseEvent()接口以供外部调用事件，
        ///<para/>并使用+=/-=来注册/移除监听组件
        /// </summary>
        private void test2()
        {
            var dclass = new MyDelegateEventClass();
            //dclass.MyEvent = new MyDelegateEventClass.MyDelegate((string mes) => { Rl.l("重置mydele: " + mes); });
            dclass.MyEvent += new MyDelegateEventClass.MyDelegate((string mes) => { Rl.l("重置mydele: " + mes); });
            //dclass?.Invoke();
        }

        class MyDelegateClass
        {
            public delegate void MyDelegate(string mes);

            public void MyDelegateMethod(string message)
            {
                Rl.l(message);
            }

            public MyDelegate mydele;
            public MyDelegateClass()
            {
                mydele = new MyDelegate(MyDelegateMethod);
                mydele += new MyDelegate(MyDelegateMethod);
                mydele?.Invoke("Hello");
            }

        }


        public class MyDelegateEventClass
        {
            public delegate void MyDelegate(string mes);
            public event MyDelegate MyEvent;

            public void MyDelegateMethod(string message)
            {
                Rl.l(message);
            }


            public MyDelegateEventClass()
            {
                MyEvent += new MyDelegate(MyDelegateMethod);
                MyEvent += MyDelegateMethod;
                MyEvent?.Invoke("Hello");
            }

        }
    }
}
