using Narser.Two.Parser.Utilities;

namespace Narser.Two.Parser.Syntax.VMF
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
            switch (kind)
            {
                /*
                 * "compound"
                 * {
                 *      "name" "value"
                 *      "name" "value"
                 * }
                 * 
                 * or
                 * 
                 * compound
                 * {
                 *      name value
                 *      name value
                 * }
                 */

                case TokenKind.Identifier:
                case TokenKind.StringLiteral:
                    {
                        ParseDeclaration(0, ref node);
                        break;
                    }
            }
        }
    }
}
