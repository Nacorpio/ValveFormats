using System;
using System.Collections.Generic;
using System.Linq;
using nVMF.Parser.Syntax.VMF.Nodes;

namespace nVMF.Extensions
{
    public static class CompoundExtensions
    {
        public static IDictionary<string, bool> ToDictionary(this CompoundNode node)
        {
            return node.Nodes
                .Where(x => x is PropertyNode)
                .Cast<PropertyNode>()
                .ToDictionary(
                    x => x.Name,
                    x => x != null && Convert.ToBoolean(int.Parse(x.Value.ToString())));
        }

        /// <summary>
        /// Returns all the children of the <see cref="CompoundNode"/>.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DeclarationNode> GetAllChildren(this CompoundNode node)
        {
            return node.Nodes
                    .Where(x => x is CompoundNode)
                    .Cast<CompoundNode>()
                    .SelectMany(x => x.GetAllChildren())
                    .Concat(
                        node.Nodes
                            .Where(x => x is PropertyNode));
        }
    }
}
