using Coding.Exercise;
using System;
using System.Collections.Generic;

//Game game = new Game();
//Rat rat1 = new Rat(game);
//Rat rat2 = new Rat(game);
//Rat rat3 = new Rat(game);
//rat3.Dispose();
//Console.WriteLine();

namespace Coding.Exercise
{
    public class Game
    {
        public event EventHandler<EventArgs> RatCountChanged;
        public event EventHandler<EventArgs> RatScreamingEvent;
        public event EventHandler<EventArgs> RatDyingEvent;

        public void SpawnRat(Rat rat)
        {
            rat.ScreamEvent += RatScreaming;
            RatCountChanged.Invoke(this, EventArgs.Empty);
        }

        public void KillRat(Rat rat)
        {
            rat.ScreamEvent -= RatScreaming;
            RatDyingEvent.Invoke(rat, EventArgs.Empty);
        }

        public void RatScreaming(object sender, EventArgs e)
        {
            RatScreamingEvent.Invoke(sender, EventArgs.Empty);
        }
    }

    public class Rat : IDisposable
    {
        private readonly Game _game;
        List<Rat> rats = new List<Rat>();
        
        public event EventHandler<EventArgs> ScreamEvent;
        public int Attack => rats.Count;

        public Rat(Game game)
        {
            _game = game;
            _game.RatCountChanged += Scream;
            _game.RatScreamingEvent += CountRats;
            _game.RatDyingEvent += OtherRatDied;
            _game.SpawnRat(this);
        }

        public void Dispose()
        {
            _game.RatCountChanged -= Scream;
            _game.RatScreamingEvent -= CountRats;
            _game.RatDyingEvent -= OtherRatDied;
            _game.KillRat(this);
        }

        private void Scream(object sender, EventArgs e)
        {
            ScreamEvent.Invoke(this, EventArgs.Empty);
        }

        private void CountRats(object sender, EventArgs e)
        {
            Rat senderRat = (Rat)sender;
            if (!rats.Contains(senderRat))
            {
                rats.Add(senderRat);
            }
        }

        private void OtherRatDied(object sender, EventArgs e)
        {
            Rat senderRat = (Rat)sender;
            if (rats.Contains(senderRat))
            {
                rats.Remove(senderRat);
            }
        }
    }
}