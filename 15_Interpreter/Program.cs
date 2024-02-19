using System;
using System.Text;
using System.Collections.Generic;
using Coding.Exercise;


var tester = new ExpressionProcessor();
Console.WriteLine(tester.Calculate("1+2+3"));
Console.WriteLine(tester.Calculate("1+2+xy"));
tester.Variables.Add('x', 3);
Console.WriteLine(tester.Calculate("10-2-x"));

namespace Coding.Exercise
{
    public class Token
    {
        public TokenType TypeOfToken;
        public string Text;

        public Token(TokenType myType, string text)
        {
            TypeOfToken = myType;
            Text = text;
        }

        public enum TokenType
        {
            Plus,
            Minus,
            Number,
            Letter
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            try
            {
                List<Token> tokenList = Lex(expression);
                int result = Parse(tokenList);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Token> Lex(string expression)
        {
            List<Token> result = new List<Token>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+')
                {
                    result.Add(new Token(Token.TokenType.Plus, expression[i].ToString()));
                }
                else if (expression[i] == '-')
                {
                    result.Add(new Token(Token.TokenType.Minus, expression[i].ToString()));
                }
                else if (char.IsDigit(expression[i]))
                {
                    StringBuilder sb = new StringBuilder(expression[i].ToString());
                    for (int j = i+1; j < expression.Length; j++)
                    {
                        if (char.IsDigit(expression[j]))
                        {
                            sb.Append(expression[j]);
                            ++i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    result.Add(new Token(Token.TokenType.Number, sb.ToString()));
                }
                else if (char.IsLetter(expression[i]))
                {
                    if (i == expression.Length - 1)
                    {
                        result.Add(new Token(Token.TokenType.Letter, expression[i].ToString()));
                    }
                    else if (!char.IsLetter(expression[i + 1]))
                    {
                        result.Add(new Token(Token.TokenType.Letter, expression[i].ToString()));
                    }
                    else
                    {
                        for (int j = i + 1; j < expression.Length; j++)
                        {
                            if (!char.IsLetter(expression[j]))
                            {
                                string substring = expression.Substring(i, j - i);
                                result.Add(new Token(Token.TokenType.Letter, substring));
                                break;
                            }
                        }
                        ++i;
                    }
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            return result;
        }

        public int Parse(List<Token> tokenlist)
        {
            int result;
            if (tokenlist[0].TypeOfToken == Token.TokenType.Number)
            {
                result = int.Parse(tokenlist[0].Text);
            }
            else
            {
                result = 0;
            }
            for (int i = 0; i < tokenlist.Count; i++)
            {
                switch (tokenlist[i].TypeOfToken)
                {
                    case Token.TokenType.Plus:
                        if (tokenlist[i + 1].TypeOfToken == Token.TokenType.Letter)
                        {
                            if (tokenlist[i + 1].Text.Length == 1)
                            {
                                int value = Variables[char.Parse(tokenlist[i + 1].Text)];
                                result += value;
                            }
                        }
                        else
                        {
                            result += int.Parse(tokenlist[i + 1].Text);
                        }
                        ++i;
                        break;
                    case Token.TokenType.Minus:
                        if (tokenlist[i + 1].TypeOfToken == Token.TokenType.Letter)
                        {
                            if (tokenlist[i + 1].Text.Length == 1)
                            {
                                int value = Variables[char.Parse(tokenlist[i + 1].Text)];
                                result -= value;
                            }
                        }
                        else
                        {
                            result -= int.Parse(tokenlist[i + 1].Text);
                        }
                        ++i;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
