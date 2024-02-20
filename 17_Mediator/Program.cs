using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Participant
    {
        public int Value { get; set; }
        public Mediator Mediator;

        public Participant(Mediator mediator)
        {
            Mediator = mediator;
            Mediator.people.Add(this);
        }

        public void Say(int n)
        {
            Mediator.IncreaseValue(this, n);
        }
    }

    public class Mediator
    {
        public List<Participant> people = new List<Participant>();

        public void IncreaseValue(Participant source, int value)
        {
            foreach (Participant p in people)
            {
                if (source != p)
                {
                    p.Value += value;
                }
            }
        }
    }
}
