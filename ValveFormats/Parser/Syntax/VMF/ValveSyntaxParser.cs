using ValveFormats.Parser.Utilities;

namespace ValveFormats.Parser.Syntax.VMF
{
    public sealed partial class ValveSyntaxParser : SyntaxParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValveSyntaxParser"/> class.
        /// </summary>
        /// <param name="input">The string input.</param>
        public ValveSyntaxParser(string input)
            : base(input)
        {
            Advanced += OnAdvanced;
        }

        private void OnAdvanced(SyntaxParser sender, TokenKind kind, ref SyntaxNode node)
        {
            if (kind == TokenKind.Identifier || kind == TokenKind.StringLiteral)
                ParseDeclaration(0, ref node);
        }
    }
}
