using System;
using ValveFormats.Parser.Syntax.VMF.Nodes;
using ValveFormats.Templates.CSGO;

namespace ValveFormats.Utilities
{
    public static class PrefabUtilities
    {
        /// <summary>
        /// Returns a <see cref="CsgoPrefab"/> object from a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public static CsgoPrefab GetPrefab(CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return new CsgoPrefab(root);
        }
    }
}
