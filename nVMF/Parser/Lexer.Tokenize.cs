using System.Text;
using nVMF.Parser.Utilities;

namespace nVMF.Parser
{
    public partial class Lexer
    {
        protected virtual void OnAdvanced(Lexer sender, int current)
        {
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
                        AddToken(TokenKind.ExclamationMark);
                        break;
                    }

                case '\"':
                    {
                        HandleStringLiteral();
                        break;
                    }

                case '\'':
                    {
                        AddToken(TokenKind.SingleQuote);
                        break;
                    }

                case '@':
                    {
                        AddToken(TokenKind.At);
                        break;
                    }

                case '#':
                    {
                        AddToken(TokenKind.Hash);
                        break;
                    }

                case '$':
                    {
                        AddToken(TokenKind.Dollar);
                        break;
                    }

                case '¤':
                    {
                        AddToken(TokenKind.CurrencySign);
                        break;
                    }

                case '£':
                    {
                        AddToken(TokenKind.Pound);
                        break;
                    }

                case '%':
                    {
                        AddToken(TokenKind.Percent);
                        break;
                    }

                case '&':
                    {
                        AddToken(TokenKind.Ampersand);
                        break;
                    }

                case '/':
                    {
                        if (Peek() == '/')
                        {
                            HandleSingleLineComment();
                            break;
                        }

                        AddToken(TokenKind.ForwardSlash);
                        break;
                    }

                case '(':
                    {
                        AddToken(TokenKind.RightParanthesis);
                        break;
                    }

                case ')':
                    {
                        AddToken(TokenKind.LeftParanthesis);
                        break;
                    }

                case '{':
                    {
                        AddToken(TokenKind.RightCurlyBrace);
                        break;
                    }

                case '}':
                    {
                        AddToken(TokenKind.LeftCurlyBrace);
                        break;
                    }

                case '[':
                    {
                        AddToken(TokenKind.RightSquareBrace);
                        break;
                    }

                case ']':
                    {
                        AddToken(TokenKind.LeftSquareBrace);
                        break;
                    }

                case '=':
                    {
                        AddToken(TokenKind.Equals);
                        break;
                    }

                case '+':
                    {
                        AddToken(TokenKind.Plus);
                        break;
                    }

                case '\\':
                    {
                        AddToken(TokenKind.Backslash);
                        break;
                    }

                case '?':
                    {
                        AddToken(TokenKind.QuestionMark);
                        break;
                    }

                case '`':
                    {
                        AddToken(TokenKind.GraveAccent);
                        break;
                    }

                case '´':
                    {
                        AddToken(TokenKind.Diacritical);
                        break;
                    }

                case '^':
                    {
                        AddToken(TokenKind.Caret);
                        break;
                    }

                case '~':
                    {
                        AddToken(TokenKind.Tilde);
                        break;
                    }

                case '*':
                    {
                        AddToken(TokenKind.Asterisk);
                        break;
                    }

                case '-':
                    {
                        AddToken(TokenKind.Hyphen);
                        break;
                    }

                case '_':
                    {
                        AddToken(TokenKind.Underscore);
                        break;
                    }

                case ':':
                    {
                        AddToken(TokenKind.Colon);
                        break;
                    }

                case ';':
                    {
                        AddToken(TokenKind.Semicolon);
                        break;
                    }

                case '.':
                    {
                        AddToken(TokenKind.Dot);
                        break;
                    }

                case ',':
                    {
                        AddToken(TokenKind.Comma);
                        break;
                    }

                case '|':
                    {
                        AddToken(TokenKind.Pipe);
                        break;
                    }

                case '<':
                    {
                        AddToken(TokenKind.LeftArrow);
                        break;
                    }

                case '>':
                    {
                        AddToken(TokenKind.RightArrow);
                        break;
                    }

                case '§':
                    {
                        AddToken(TokenKind.Section);
                        break;
                    }

                case '½':
                    {
                        AddToken(TokenKind.OneHalf);
                        break;
                    }

                default:
                    {
                        if (char.IsLetter((char) current))
                        {
                            sb.Append((char) current);

                            while (char.IsLetterOrDigit(Peek()) || Peek() == '_')
                            {
                                Advance(false);
                                sb.Append(Current);
                            }

                            AddToken(TokenKind.Identifier, sb.ToString());
                            sb.Length = 0;

                            break;
                        }

                        if (char.IsDigit((char) current))
                        {
                            sb.Append((char) current);

                            while (char.IsDigit(Peek()) || Peek() == '.')
                            {
                                Advance(false);
                                sb.Append(Current);
                            }

                            AddToken(TokenKind.Numerical, sb.ToString());
                            sb.Length = 0;

                            break;
                        }

                        break;
                    }
            }
        }

        private void AddToken(TokenKind kind, object value = null)
        {
            _tokens.Add(new Token(value ?? Current, GetLocation(), kind));
        }

        private void HandleStringLiteral()
        {
            var sb = new StringBuilder(Current);

            // Advance until it hits a trailing double quote.
            while (Peek() != '\"')
            {
                Advance(false);
                sb.Append(Current);
            }

            // Advance past the trailing double quote.
            Advance(false);

            AddToken(TokenKind.StringLiteral, sb.ToString());
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