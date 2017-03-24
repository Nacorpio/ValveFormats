using System;
using System.Collections.Generic;
using System.IO;
using nVMF.Parser.Utilities;

namespace nVMF.Parser
{
    public delegate void LexerEventHandler(Lexer sender, EventArgs eventArgs);

    public delegate void LexerAdvancedEventHandler(Lexer sender, int current);

    /// <summary>
    /// Allows for a simple way of advancing through a stream of <see cref="char"/> objects.
    /// </summary>
    public partial class Lexer : IDisposable
    {
        /// <summary>
        /// Raised when the <see cref="Lexer"/> has been advanced.
        /// </summary>
        public event LexerAdvancedEventHandler Advanced;

        private readonly TextReader _textReader;
        private readonly List<Token> _tokens;

        private int _pos, _col, _line;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lexer" /> class.
        /// </summary>
        /// <param name="input">An input string.</param>
        public Lexer(string input)
        {
            _textReader = new StringReader(input);
            _tokens = new List<Token>();

            _line = 1;
        }

        /// <summary>
        /// Gets the current character of the <see cref="Lexer"/>.
        /// </summary>
        public char Current { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the underlying <see cref="TextReader"/> object has reached its end.
        /// </summary>
        public bool IsAtEnd => _textReader.Peek() == -1;

        /// <summary>
        /// Gets the resulting tokens of the <see cref="Lexer"/>.
        /// </summary>
        public IEnumerable<Token> Tokens => _tokens;

        /// <summary>
        /// Advances the <see cref="Lexer"/> until its end and tokenizes every token.
        /// </summary>
        public void TokenizeAll()
        {
            if (IsAtEnd)
            {
                return;
            }

            Advanced += OnAdvanced;
            AdvanceUntil(x => IsAtEnd);
        }

        /// <summary>
        /// Advances the <see cref="Lexer"/> a specific amount of steps.
        /// </summary>
        /// <param name="raise">Whether to raise the <see cref="Advanced"/> event.</param>
        /// <param name="n">The amount of steps to advance.</param>
        public void Advance(bool raise = true, int n = 1)
        {
            if (n == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            var x = n;
            while (x != 0)
            {
                Current = (char) _textReader.Read();

                if (raise)
                    Advanced?.Invoke(this, Current);

                _pos++;
                _col++;

                x--;
            }
        }

        /// <summary>
        /// Advances the <see cref="Lexer"/> while a specified predicate is being matched.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns></returns>
        public IEnumerable<char> AdvanceWhile(Predicate<char> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            var results = new List<char>();

            while (predicate(Peek()))
            {
                Advance();
                results.Add(Current);
            }

            return results;
        }

        /// <summary>
        /// Advances the <see cref="Lexer"/> until a specified predicate predicate is being matched.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <returns></returns>
        public IEnumerable<char> AdvanceUntil(Predicate<char> predicate)
        {
            return AdvanceWhile(x => !predicate(x));
        }

        /// <summary>
        /// Peeks the next character in the <see cref="Lexer"/>.
        /// </summary>
        /// <returns></returns>
        public char Peek()
        {
            return (char) _textReader.Peek();
        }

        /// <summary>
        /// Returns the current location of the <see cref="Lexer"/>.
        /// </summary>
        /// <returns></returns>
        public TokenLocation GetLocation()
        {
            return new TokenLocation(_pos, _col, _line);
        }

        /// <summary>
        /// Disposes the current <see cref="Lexer"/> instance.
        /// </summary>
        public void Dispose()
        {
            _tokens.Clear();

            _textReader.Close();
            _textReader.Dispose();
        }
    }
}
