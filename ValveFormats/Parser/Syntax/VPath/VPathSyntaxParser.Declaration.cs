using nVMF.Parser.Utilities;

namespace nVMF.Parser.Syntax.VPath
{
    public sealed partial class VPathSyntaxParser : SyntaxParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VPathSyntaxParser"/> class.
        /// </summary>
        /// <param name="input">The string input.</param>
        public VPathSyntaxParser(string input)
            : base(input)
        {
            Advanced += OnAdvanced;
        }

        private void OnAdvanced(SyntaxParser sender, TokenKind kind, ref SyntaxNode node)
        {
            switch (kind)
            {
                
            }
        }
    }
}