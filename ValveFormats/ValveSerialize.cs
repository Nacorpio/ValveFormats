using System;
using System.Linq;
using ValveFormats.Parser.Syntax.VMF;
using ValveFormats.Parser.Syntax.VMF.Nodes;

namespace ValveFormats
{
    /// <summary>
    /// Provides static methods for serializing/deserializing files formatted with either VDF or VMF.
    /// </summary>
    public static class ValveSerialize
    {
        /// <summary>
        /// Deserializes a specified <see cref="string"/> object.
        /// </summary>
        /// <param name="text">The text to serialize.</param>
        /// <returns></returns>
        public static DeclarationNodeList Deserialize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            DeclarationNodeList result;

            using (var parser = new ValveSyntaxParser(text))
            {
                parser.Build();
                result = new DeclarationNodeList(parser.Nodes.Cast<DeclarationNode>());
            }

            return result;
        }

        /// <summary>
        /// Serializes a specified <see cref="DeclarationNodeList"/> object.
        /// </summary>
        /// <param name="list">The list to serialize.</param>
        /// <returns></returns>
        public static string Serialize(DeclarationNodeList list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            return list
                .Where(x => x is CompoundNode)
                .Cast<CompoundNode>()
                .First(x => x.IsRoot)
                .GetSource();
        }
    }
}