using System.Linq;
using ValveFormats.Parser.Syntax.VMF;
using ValveFormats.Parser.Syntax.VMF.Nodes;

namespace ValveFormats
{
    public sealed class Script
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class using a specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        internal Script(string source)
        {
            Parse(source);
        }

        /// <summary>
        /// Gets the root of the <see cref="Script"/>.
        /// </summary>
        public CompoundNode Root => Nodes
            .Where(x => x is CompoundNode)
            .Cast<CompoundNode>()
            .First(x => x.IsRoot);

        /// <summary>
        /// Gets the nodes of the <see cref="Script"/>.
        /// </summary>
        public DeclarationNodeList Nodes { get; private set; }
        
        /// <summary>
        /// Parses the <see cref="Script"/> using its source.
        /// </summary>
        internal void Parse(string source)
        {
            using (var sp = new ValveSyntaxParser(source))
            {
                sp.Build();
                Nodes = new DeclarationNodeList(sp.Nodes.Cast<DeclarationNode>());
            }
        }
    }
}
