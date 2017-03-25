using System;
using System.Collections.Generic;
using System.Linq;
using ValveFormats.Parser.Utilities;

namespace ValveFormats.Parser.Syntax
{
    public delegate void SyntaxParserAdvancedEvent(SyntaxParser sender, TokenKind kind, ref SyntaxNode node);

    public abstract class SyntaxParser : IDisposable
    {
        public event SyntaxParserAdvancedEvent Advanced;

        private readonly string _input;
        private readonly List<SyntaxNode> _nodes;

        private List<Token> _tokens;
        
        /// <summary>
        /// Initializes a new instance of teh <see cref="SyntaxParser"/> class.
        /// </summary>
        /// <param name="input">The string input.</param>
        protected SyntaxParser(string input)
        {
            _input = input;
            _nodes = new List<SyntaxNode>();
        }

        /// <summary>
        /// Gets the current position of the <see cref="SyntaxParser"/>.
        /// </summary>
        public int Position { get; private set; } = -1;

        /// <summary>
        /// Gets the nodes of the <see cref="SyntaxParser"/>.
        /// </summary>
        public IReadOnlyList<SyntaxNode> Nodes => _nodes;

        /// <summary>
        /// Advances the <see cref="SyntaxParser"/> a specified amount of steps.
        /// </summary>
        /// <param name="n">The amount of steps to advance.</param>
        /// <returns></returns>
        public Token Advance(int n = 1)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            Position += n;
            return GetCurrent();
        }

        /// <summary>
        /// Peeks the next token in the <see cref="SyntaxParser"/>.
        /// </summary>
        /// <param name="n">The amount of tokens to peek.</param>
        /// <returns></returns>
        public Token Peek(int n = 1)
        {
            var x = Position + n;
            return x > _tokens.Count - 1 ? new Token(null, default(TokenLocation), default(TokenLocation), TokenKind.None) : _tokens[x];
        }

        /// <summary>
        /// Builds the syntax tree of the <see cref="SyntaxParser"/>.
        /// </summary>
        public void Build()
        {
            using (var lexer = new Lexer(_input))
            {
                lexer.TokenizeAll();
                _tokens = new List<Token>(lexer.Tokens);
            }

            SyntaxNode node = null;
            while (Position != _tokens.Count - 1)
            {
                Advanced?.Invoke(this, Peek().Kind, ref node);

                if (node != null)
                {
                    _nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// Expects a token with any of the specified token kinds.
        /// </summary>
        /// <param name="kinds">The token kinds.</param>
        /// <returns></returns>
        public bool ExpectAny(params TokenKind[] kinds)
        {
            return kinds.Select((k, i) => Peek().Kind == kinds[i]).Any(x => x);
        }

        /// <summary>
        /// Expects a series of tokens in the specified order.
        /// </summary>
        /// <param name="kinds">The token kinds.</param>
        /// <returns></returns>
        public bool Expect(params TokenKind[] kinds)
        {
            return kinds.Select((k, i) => Peek(i + 1).Kind == kinds[i]).All(x => x);
        }

        /// <summary>
        /// Returns the current token of the <see cref="SyntaxParser"/>.
        /// </summary>
        /// <returns></returns>
        public Token GetCurrent()
        {
            return _tokens[Position];
        }

        /// <summary>
        /// Disposes all resources associated with the <see cref="SyntaxParser"/>.
        /// </summary>
        public void Dispose()
        {
            _nodes.Clear();
            _tokens.Clear();
        }
    }
}
