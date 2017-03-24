using System;
using System.Collections.Generic;
using System.Linq;
using Narser.Two.Classes.CSGO;
using Narser.Two.Parser.Syntax.VMF.Nodes;

namespace Narser.Two.Utilities
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
