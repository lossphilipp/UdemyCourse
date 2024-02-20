using System;
using System.Text;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<Token> state { get; }

        public Memento(List<Token> current)
        {
            state = current;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));
            return SaveState();
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            return SaveState();
        }

        private Memento SaveState()
        {
            List<Token> list = new List<Token>();
            foreach (Token token in Tokens)
            {
                list.Add(new Token(token.Value));
            }
            return new Memento(list);
        }

        public void Revert(Memento m)
        {
            Tokens = m.state;
        }
    }
}
