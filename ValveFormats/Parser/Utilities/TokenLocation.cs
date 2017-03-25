namespace ValveFormats.Parser.Utilities
{
    /// <summary>
    /// Represents the location of a token.
    /// </summary>
    public struct TokenLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenLocation"/> structure.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="column">The column.</param>
        /// <param name="line">The line number.</param>
        public TokenLocation(int position, int column, int line)
        {
            Position = position;
            Column = column;
            Line = line;
        }

        /// <summary>
        /// Gets or sets the position of the <see cref="TokenLocation"/>.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Gets or sets the column of the <see cref="TokenLocation"/>.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Gets or sets the line number of the <see cref="TokenLocation"/>.
        /// </summary>
        public int Line { get; }

        public static bool operator ==(TokenLocation left, TokenLocation right)
        {
            return left.Position == right.Position;
        }

        public static bool operator !=(TokenLocation left, TokenLocation right)
        {
            return !(left == right);
        }

        public bool Equals(TokenLocation other)
        {
            return Position == other.Position && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TokenLocation && Equals((TokenLocation)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Position * 397) ^ Column;
            }
        }

        public override string ToString()
        {
            return $"pos: {Position}, col: {Column}, line: {Line}";
        }
    }
}