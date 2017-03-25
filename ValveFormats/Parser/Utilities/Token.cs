namespace ValveFormats.Parser.Utilities
{
    public struct Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> structure.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="start">The start location.</param>
        /// <param name="end">The end location.</param>
        /// <param name="kind">The kind.</param>
        public Token(object value, TokenLocation start, TokenLocation end, TokenKind kind)
        {
            Value = value;
            Start = start;
            End = end;
            Kind = kind;
        }

        /// <summary>
        /// Gets the value of the <see cref="Token"/>.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets the start location of the <see cref="Token"/>.
        /// </summary>
        public TokenLocation Start { get; }

        /// <summary>
        /// Gets the end location of the <see cref="Token"/>.
        /// </summary>
        public TokenLocation End { get; }

        /// <summary>
        /// Gets the kind of the <see cref="Token"/>.
        /// </summary>
        public TokenKind Kind { get; }

        /// <summary>
        /// Gets the length of the <see cref="Token"/>.
        /// </summary>
        public int Length => Value.ToString().Length;

        public static bool operator ==(Token left, Token right)
        {
            return left.End.Equals(right.End);
        }

        public static bool operator !=(Token left, Token right)
        {
            return !(left == right);
        }

        public bool Equals(Token other)
        {
            return End.Equals(other.End) && Kind == other.Kind;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Token && Equals((Token)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (End.GetHashCode() * 397) ^ (int)Kind;
            }
        }
    }
}