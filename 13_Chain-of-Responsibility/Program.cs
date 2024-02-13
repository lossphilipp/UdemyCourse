using Coding.Exercise;
using System;
using System.Collections.Generic;

var game = new Game();
var goblin1 = new Goblin(game);
var goblin2 = new Goblin(game);
game.Creatures.Add(goblin1);
game.Creatures.Add(goblin2);

Console.WriteLine(goblin1);

namespace Coding.Exercise
{
    public abstract class Creature
    {
        public Game Game { get; set; }
        protected int attack;
        protected int defense;

        new public int Attack
        {
            get
            {
                Query q = new Query(Query.Argument.Attack, attack);
                Game.PerformQuery(this, q);
                return q.Value;
            }
            set { attack = value; }
        }

        new public int Defense
        {
            get
            {
                Query q = new Query(Query.Argument.Defense, defense);
                Game.PerformQuery(this, q);
                return q.Value;
            }
            set { defense = value; }
        }

        protected Creature(Game game, int attack, int defense)
        {
            Game = game;
            Attack = attack;
            Defense = defense;
        }
    }

    public class Goblin : Creature
    {
        public Goblin(Game game) : this (game, 1, 1)
        {
        }
        protected Goblin(Game game, int baseAttack, int baseDefense) : base(game, baseAttack, baseDefense)
        {
            new GoblinModifier(game, this);
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game, 3, 3)
        {
            new GoblinKingModifier(game, this);
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class Query
    {
        public Argument WhatToQuery;
        public int Value;

        public enum Argument
        {
            Attack, Defense
        }

        public Query(Argument whatToQuery, int value)
        {
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;

        protected CreatureModifier(Game game, Creature creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class GoblinModifier : CreatureModifier
    {
        public GoblinModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            if (creature is Goblin &&
                creature != sender &&
                q.WhatToQuery == Query.Argument.Defense)
            {
                q.Value += 1;
            }
        }
    }

    public class GoblinKingModifier : CreatureModifier
    {
        public GoblinKingModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            if (creature is Goblin &&
                creature != sender &&
                q.WhatToQuery == Query.Argument.Attack)
            {
                q.Value += 1;
            }
        }
    }
}