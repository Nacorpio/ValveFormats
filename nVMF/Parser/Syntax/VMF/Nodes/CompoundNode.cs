using System.Text;

namespace Narser.Two.Parser.Syntax.VMF.Nodes
{
    public class CompoundNode : DeclarationNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundNode"/> class.
        /// </summary>
        internal CompoundNode()
        {
        }
        
        /// <summary>
        /// Gets a value indicating whether the <see cref="CompoundNode"/> is the root.
        /// </summary>
        public bool IsRoot => Parent == null;

        /// <summary>
        /// Gets the nodes of the <see cref="CompoundNode"/>.
        /// </summary>
        public DeclarationNodeList Nodes { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DeclarationNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DeclarationNode this[string name] => Nodes[name];

        /// <summary>
        /// Returns the source of the <see cref="CompoundNode"/>.
        /// </summary>
        /// <returns></returns>
        public override string GetSource()
        {
            var tabs = new string('\t', Depth);
            var sb = new StringBuilder();

            sb.AppendLine($"{new string('\t', Parent == null ? 0 : 1)}\"{Name}\"");
            sb.AppendLine($"{tabs}{{");

            foreach (var declaration in Nodes)
            {
                sb.AppendLine($"{tabs}{declaration.GetSource()}");
            }

            sb.AppendLine($"{tabs}}}");
            return sb.ToString();
        }
    }
}