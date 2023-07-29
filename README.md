# MyConsoleEventLearn

            //测试普通delegate和event包装后的委托：声明与赋值与使用情况
            //new Test_DelegateAndEvent();

            //测试原始EventHandler: 系统自带的-效果等于带(object sender, EventArgs args)参数的event
            //new MyTestDefaultEventHandler();

            //测试泛型EventHandler并实例使用: 就是一个泛型, 可以使用泛型自定义args类型
            //new MyTest_MyEventHandler();

            //粘贴的示例代码:原始与泛型EventHandler
            //new MyGenericEventHandler();

            //测试原始Action: 使用起来相当于便捷版delegate: 没有繁琐的delegate甚至event这些声明, 定义即用
            //new MyTestAction();

            //手动包装后的MyAction: 效果最好: 
            //Action可以自行选择包装还是开放修改: 也就是使用访问域private/public决定在外部可不可以=清零或者Invoke调用
            //与delegate或event比较: 无需繁琐delegate与event声明
            //与eventhandler比较:
            ////虽然handler声明也简单但是args限制sender与args参数
            ////所以Action<param1, param2...>依旧技高一筹
            ////更自由
            //new MyTestAction_Package();

            //最后是Func:
            //Func与Action对比不同: Action泛型<T, T1, T2...>, Func泛型<T, T1, T2...TResult>
            ////简单说就是Func与Action使用起来完全一致, 不同的只有泛型参数的最后一位是Func委托传入方法的返回类型
            ////可以用来传一个引用类型然后多播一起修改值最后输出
            //new MyTestFunc();

            //结束: 
            ////总的来说:
            ////高级委托就两种: 有返回使用Func, 无返回使用Action
            ////需要封装且无返回可以使用EventHandler(EH), 但如果要自定义参数(不限于sender, args这种形式)那就自行选择Action/Func或EH, EH只是一个默认省事儿选择
            ////总之我就用Action/Func了, 别问, 就是香
            ////最后做个简单Action/Func实例吧


            //使用Action/Func制作实体事件管理器管理两个事件: 攻击与喊话
            new MyTestEventManager();
