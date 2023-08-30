using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern
{
    public interface IAttackStrategy
    {
        void ApplyStrategy();
    }

    public class OffensiveStrategy : IAttackStrategy
    {
        public void ApplyStrategy()
        {
            Console.WriteLine("Attacking offensively");
        }
    }

    public class DefensiveStrategy : IAttackStrategy
    {
        public void ApplyStrategy()
        {
            Console.WriteLine("Attacking defensively");
        }
    }

    public class MyTeam
    {
        private IAttackStrategy _attackStrategy;

        public MyTeam(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public MyTeam()
        {

        }

        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public void ApplyAttackStrategy()
        {
            _attackStrategy.ApplyStrategy();
        }
    }

    public static class FootballExample
    {
        public static void RunSample()
        {
            var myTeam = new MyTeam(new OffensiveStrategy());
            myTeam.ApplyAttackStrategy();

            myTeam.SetAttackStrategy(new DefensiveStrategy());
            myTeam.ApplyAttackStrategy();
        }
    }
}
