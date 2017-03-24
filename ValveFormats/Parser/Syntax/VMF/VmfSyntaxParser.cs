using nVMF.Parser.Utilities;

namespace nVMF.Parser.Syntax.VMF
{
    public sealed partial class VmfSyntaxParser : SyntaxParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VmfSyntaxParser"/> class.
        /// </summary>
        /// <param name="input">The string input.</param>
        public VmfSyntaxParser(string input)
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
