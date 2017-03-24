using System;
using nVMF.Parser.Syntax.VMF.Nodes;
using nVMF.Templates.CSGO;

namespace nVMF.Utilities
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
