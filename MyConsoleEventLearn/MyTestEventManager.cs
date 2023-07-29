using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyConsoleEventLearn
{
    internal class MyTestEventManager
    {
        /// <summary>
        /// 一个简单的实体管理器: 
        /// <para/>可以注册实体列表, 并提供 攻击 与 注册攻击广播信息 接口
        /// </summary>
        public MyTestEventManager()
        {
            var EM = new EntityManager();
            var ent1 = new Entity(EM) { Name = "Pig", Damage = 1 };
            var ent2 = new Entity(EM) { Name = "Spider", Damage = 5 };
            var ent3 = new Entity(EM) { Name = "Rabbit", Damage = 1 };

            ent2.Attack(ent1);Rl.l();
            ent3.Attack(ent1);
        }

        /// <summary>
        /// 实体: 拥有name与damage, 以及受伤方法, 并且可以通过实体管理器调用attack其他实体并广播攻击事件信息
        /// </summary>
        class Entity
        {
            public string Name { get; set; }
            public float Damage { get; set; }
            public EntityManager EM { get; private set; }

            public Entity(EntityManager EM)
            {
                this.EM = EM;
                EM.AddEntity(this);

                //RegisterEvents
                EM.AddListener<Action<EntityManager.AttackArgs>>(ReceiveAttackMes);
            }

            public void Attack(Entity ent)
            {
                EM.Attack(this, ent);
            }
            public void OnHurt(Entity attacker)
            {
                Rl.l($"[{Name}]: Im BeAttacked: attacker: [{attacker.Name}], damage: {attacker.Damage}");
            }

            public void ReceiveAttackMes(EntityManager.AttackArgs args)
            {
                Rl.l($"[{Name}-Receive to AttackMes]: {{[Attacker-{args.Attacker.Name}] attack to [{args.Victim.Name}] for {args.Attacker.Damage} damage.}}");
            }
        }

        class EntityManager
        {
            private List<Entity> ents= new List<Entity>();

            private Action<AttackArgs> AttackMes;

            public void Attack(Entity attacker, Entity victim)
            {
                Rl.l($"[EntityManager]: {{[Attacker-{attacker.Name}] attack to {victim.Name} for {attacker.Damage} damage.}}");
                victim.OnHurt(attacker);
                RaiseEvent<Action<AttackArgs>>(new AttackArgs() { Attacker=attacker, Victim=victim });
            }


            public void AddListener<T>(T receiveAttackMes)
            {
                if (typeof(T) == typeof(Action<AttackArgs>))
                {
                    AttackMes += (Action<AttackArgs>)(object)receiveAttackMes;
                }
            }

            private void RaiseEvent<T>(EventArgs attackArgs)
            {
                if(typeof(T) == typeof(Action<AttackArgs>))
                {
                    AttackArgs args = (AttackArgs)attackArgs;

                    AttackMes -= args.Attacker.ReceiveAttackMes;
                    AttackMes -= args.Victim.ReceiveAttackMes;

                    AttackMes?.Invoke(args);

                    AttackMes += args.Attacker.ReceiveAttackMes;
                    AttackMes += args.Victim.ReceiveAttackMes;
                }
            }

            internal void AddEntity(Entity ent)
            {
                this.ents.Add(ent);
            }

            public class AttackArgs : EventArgs
            {
                public Entity Attacker { get; set; }
                public Entity Victim { get; set; }
            }
        }











        /*
        //写了半天没写明白
         
        public MyTestEventManager()
        {
            //创建事件管理器
            var EM = new MyEventManager();

            //实例化两个实体
            var ent = new Entity() { name = "Pig", damage = 1 };
            var ent2 = new Entity() { name = "Spider", damage = 5 };

            //为实体事件注册监听器
            ////实体可以调用事件管理器的攻击与喊话: 并通知所有注册此类方法的其他实体
            ent.RegisterAllEvent(EM);
            ent2.RegisterAllEvent(EM);

            //主动派遣攻击事件
            var attackArgs = new MyEventManager.AttackArgs() { attacker = ent2, attacked = ent };
            var attackMes = EM.RaiseEvent(attackArgs);

            //广播攻击信息
            //EM.RaiseEvent(attackMes);

        }


        class MyEventManager
        {
            private Func<AttackArgs, AttackMes> Attack;


            public void AddListener(Func<AttackArgs, AttackMes> attack)
            {
                Attack += attack;
            }

            public AttackMes RaiseEvent(AttackArgs args)
            {
                return Attack?.Invoke(args);
            }

            public class AttackArgs : Entity
            {
                public Entity attacker { get; set; }
                public Entity attacked { get; set; }
            }

            public class AttackMes
            {

            }

            internal void InvokeAttack(Entity ent)
            {

            }
        }

        private class Entity
        {
            public string name;
            public float damage;

            public MyEventManager EM { get; private set; }

            public void RegisterAllEvent(MyEventManager EM)
            {
                this.EM = EM;
                //EM.AddListener(Say);
            }

            private void Attack(Entity ent)
            {
                EM.InvokeAttack(ent);
            }
        }
         */
    }
}