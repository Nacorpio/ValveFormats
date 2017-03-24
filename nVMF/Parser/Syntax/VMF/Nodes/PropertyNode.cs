namespace nVMF.Parser.Syntax.VMF.Nodes
{
    public sealed class PropertyNode : DeclarationNode, ISource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyNode"/> class.
        /// </summary>
        internal PropertyNode()
        {
        }

        /// <summary>
        /// Gets the value of the <see cref="PropertyNode"/>.
        /// </summary>
        public object Value { get; set; }
        
        /// <summary>
        /// Returns the source of the <see cref="PropertyNode"/>.
        /// </summary>
        /// <returns></returns>
        public override string GetSource()
        {
            return $"\t\"{Name}\"\t\"{Value}\"";
        }

        public override string ToString()
        {
            return $"{Name} : {Value}";
        }
    }
}