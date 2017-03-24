using System;
using nVMF.Extensions;
using nVMF.Parser.Syntax.VMF.Nodes;

namespace nVMF.Templates.CSGO
{
    public class CsgoCollectiblePrefab : CsgoInventoryItemPrefab
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsgoCollectiblePrefab"/> class.
        /// </summary>
        /// <param name="root"></param>
        internal CsgoCollectiblePrefab(CompoundNode root) : base(root)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="CsgoCollectiblePrefab"/> can be traded.
        /// </summary>
        public bool? IsTradable
        {
            get
            {
                if (UsedByClasses.TryGetValue("cannot trade", out bool value))
                {
                    return value;
                }

                return null;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CsgoCollectiblePrefab"/> class from a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public new static CsgoCollectiblePrefab Create(CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return !CsgoPrefab.Create(root).IsCollectible() ? null : new CsgoCollectiblePrefab(root);
        }
    }
}