using System.Text;
using ValveFormats.Parser.Utilities;

namespace ValveFormats.Parser
{
    public partial class Lexer
    {
        protected virtual void OnAdvanced(Lexer sender, int current)
        {
            var st = GetLocation();
            var sb = new StringBuilder();

            switch (current)
            {
                case -1:
                {
                    return;
                }

                case '\r':
                {
                    break;
                }

                case ' ':
                    {
                        HandleWhitespace();
                        break;
                    }

                case '\t':
                    {
                        HandleTab();
                        break;
                    }

                case '\n':
                    {
                        HandleNewLine();
                        break;
                    }

                case '!':
                    {
                        AddToken(TokenKind.ExclamationMark, st, st);
                        break;
                    }

                case '\"':
                    {
                        HandleStringLiteral();
                        break;
                    }

                case '\'':
                    {
                        AddToken(TokenKind.SingleQuote, st);
                        break;
                    }

                case '@':
                    {
                        AddToken(TokenKind.At, st);
                        break;
                    }

                case '#':
                    {
                        AddToken(TokenKind.Hash, st, st);
                        break;
                    }

                case '$':
                    {
                        AddToken(TokenKind.Dollar, st);
                        break;
                    }

                case '¤':
                    {
                        AddToken(TokenKind.CurrencySign, st);
                        break;
                    }

                case '£':
                    {
                        AddToken(TokenKind.Pound, st);
                        break;
                    }

                case '%':
                    {
                        AddToken(TokenKind.Percent, st);
                        break;
                    }

                case '&':
                    {
                        AddToken(TokenKind.Ampersand, st);
                        break;
                    }

                case '/':
                    {
                        if (Peek() == '/')
                        {
                            HandleSingleLineComment();
                            break;
                        }

                        AddToken(TokenKind.ForwardSlash, st);
                        break;
                    }

                case '(':
                    {
                        AddToken(TokenKind.RightParanthesis, st);
                        break;
                    }

                case ')':
                    {
                        AddToken(TokenKind.LeftParanthesis, st);
                        break;
                    }

                case '{':
                    {
                        AddToken(TokenKind.RightCurlyBrace, st);
                        break;
                    }

                case '}':
                    {
                        AddToken(TokenKind.LeftCurlyBrace, st);
                        break;
                    }

                case '[':
                    {
                        AddToken(TokenKind.RightSquareBrace, st);
                        break;
                    }

                case ']':
                    {
                        AddToken(TokenKind.LeftSquareBrace, st);
                        break;
                    }

                case '=':
                    {
                        AddToken(TokenKind.Equals, st);
                        break;
                    }

                case '+':
                    {
                        AddToken(TokenKind.Plus, st);
                        break;
                    }

                case '\\':
                    {
                        AddToken(TokenKind.Backslash, st);
                        break;
                    }

                case '?':
                    {
                        AddToken(TokenKind.QuestionMark, st);
                        break;
                    }

                case '`':
                    {
                        AddToken(TokenKind.GraveAccent, st);
                        break;
                    }

                case '´':
                    {
                        AddToken(TokenKind.Diacritical, st);
                        break;
                    }

                case '^':
                    {
                        AddToken(TokenKind.Caret, st);
                        break;
                    }

                case '~':
                    {
                        AddToken(TokenKind.Tilde, st);
                        break;
                    }

                case '*':
                    {
                        AddToken(TokenKind.Asterisk, st);
                        break;
                    }

                case '-':
                    {
                        AddToken(TokenKind.Hyphen, st);
                        break;
                    }

                case '_':
                    {
                        AddToken(TokenKind.Underscore, st);
                        break;
                    }

                case ':':
                    {
                        AddToken(TokenKind.Colon, st);
                        break;
                    }

                case ';':
                    {
                        AddToken(TokenKind.Semicolon, st);
                        break;
                    }

                case '.':
                    {
                        AddToken(TokenKind.Dot, st);
                        break;
                    }

                case ',':
                    {
                        AddToken(TokenKind.Comma, st);
                        break;
                    }

                case '|':
                    {
                        AddToken(TokenKind.Pipe, st);
                        break;
                    }

                case '<':
                    {
                        AddToken(TokenKind.LeftArrow, st);
                        break;
                    }

                case '>':
                    {
                        AddToken(TokenKind.RightArrow, st);
                        break;
                    }

                case '§':
                    {
                        AddToken(TokenKind.Section, st);
                        break;
                    }

                case '½':
                    {
                        AddToken(TokenKind.OneHalf, st);
                        break;
                    }

                default:
                    {
                        if (char.IsLetter((char) current))
                        {
                            var start = GetLocation();
                            sb.Append((char) current);

                            while (char.IsLetterOrDigit(Peek()) || Peek() == '_')
                            {
                                Advance(false);
                                sb.Append(Current);
                            }

                            AddToken(TokenKind.Identifier, start, sb.ToString());
                            sb.Length = 0;

                            break;
                        }

                        if (char.IsDigit((char) current))
                        {
                            var start = GetLocation();
                            sb.Append((char) current);

                            while (char.IsDigit(Peek()) || Peek() == '.')
                            {
                                Advance(false);
                                sb.Append(Current);
                            }

                            AddToken(TokenKind.Numerical, start, sb.ToString());
                            sb.Length = 0;

                            break;
                        }

                        break;
                    }
            }
        }

        private void AddToken(TokenKind kind, TokenLocation start, object value = null)
        {
            _tokens.Add(new Token(value ?? Current, start, GetLocation(), kind));
        }

        private void HandleStringLiteral()
        {
            var start = GetLocation();
            var sb = new StringBuilder(Current);

            // Advance until it hits a trailing double quote.
            while (Peek() != '\"')
            {
                Advance(false);
                sb.Append(Current);
            }

            // Advance past the trailing double quote.
            Advance(false);
            AddToken(TokenKind.StringLiteral, start, sb.ToString());
        }

        private void HandleSingleLineComment()
        {
            Advance(false);

            while (Peek() != '\n')
            {
                Advance(false);
            }
        }

        private void HandleWhitespace()
        {
            while (char.IsWhiteSpace(Peek()))
            {
                Advance(false);
            }
        }

        private void HandleNewLine()
        {
            _col = 0;
            _line++;
        }

        private void HandleTab()
        {
            _col += 3;
        }
    }
}