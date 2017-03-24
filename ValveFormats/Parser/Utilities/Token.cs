namespace nVMF.Parser.Utilities
{
    public struct Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> structure.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="location">The location.</param>
        /// <param name="kind">The kind.</param>
        public Token(object value, TokenLocation location, TokenKind kind)
        {
            Value = value;
            Location = location;
            Kind = kind;
        }

        /// <summary>
        /// Gets the value of the <see cref="Token"/>.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets the location of the <see cref="Token"/>.
        /// </summary>
        public TokenLocation Location { get; }

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
            return left.Location.Equals(right.Location);
        }

        public static bool operator !=(Token left, Token right)
        {
            return !(left == right);
        }

        public bool Equals(Token other)
        {
            return Location.Equals(other.Location) && Kind == other.Kind;
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
                return (Location.GetHashCode() * 397) ^ (int)Kind;
            }
        }
    }
}