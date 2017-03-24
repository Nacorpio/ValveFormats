namespace Narser.Two.Parser.Syntax.VMF.Nodes
{
    public abstract class DeclarationNode : SyntaxNode, ISource
    {
        /// <summary>
        /// Gets the name of the <see cref="DeclarationNode"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the nest depth of the <see cref="DeclarationNode"/>.
        /// </summary>
        public int Depth { get; internal set; }

        /// <summary>
        /// Gets the parent of the <see cref="DeclarationNode"/>.
        /// </summary>
        public DeclarationNode Parent { get; internal set; }

        public virtual string GetSource()
        {
            return string.Empty;
        }
    }
}