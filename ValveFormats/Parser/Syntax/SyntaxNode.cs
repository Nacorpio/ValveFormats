using System.Collections.Generic;
using System.Linq;
using ValveFormats.Parser.Utilities;

namespace ValveFormats.Parser.Syntax
{
    public abstract class SyntaxNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxNode"/> class.
        /// </summary>
        protected SyntaxNode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxNode"/> class.
        /// </summary>
        /// <param name="tokens">The associated tokens.</param>
        protected SyntaxNode(IEnumerable<Token> tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Gets the tokens associated with the <see cref="SyntaxNode"/>.
        /// </summary>
        internal IEnumerable<Token> Tokens { get; set; }

        /// <summary>
        /// Gets the start location of the <see cref="SyntaxNode"/>.
        /// </summary>
        internal TokenLocation Start => Tokens.First().Start;

        /// <summary>
        /// Gets the end location of the <see cref="SyntaxNode"/>.
        /// </summary>
        internal TokenLocation End => Tokens.Last().End;

        /// <summary>
        /// Gets the length of the <see cref="SyntaxNode"/>.
        /// </summary>
        internal int Length => Tokens.Sum(x => x.Length);

        public static bool operator ==(SyntaxNode left, SyntaxNode right)
        {
            return left?.Start == right?.Start && left?.End == right?.End;
        }

        public static bool operator !=(SyntaxNode left, SyntaxNode right)
        {
            return !(left == right);
        }

        protected bool Equals(SyntaxNode other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((SyntaxNode)obj);
        }

        /// <summary>
        /// Returns the hash code of the <see cref="SyntaxNode"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Start.Position ^ End.Position;
        }
    }
}