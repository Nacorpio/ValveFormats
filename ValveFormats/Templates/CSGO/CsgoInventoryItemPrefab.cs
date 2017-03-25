using System;
using ValveFormats.Parser.Syntax.VMF.Nodes;
using ValveFormats.Utilities;

namespace ValveFormats.Templates.CSGO
{
    /// <summary>
    /// Represents a prefab that can be visually represented inside the CS:GO inventory.
    /// </summary>
    public class CsgoInventoryItemPrefab : CsgoPrefab, IUsable, IInventoryItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsgoInventoryItemPrefab"/> class.
        /// </summary>
        /// <param name="root">The root node.</param>
        internal CsgoInventoryItemPrefab(CompoundNode root) : base(root)
        {
        }

        /// <summary>
        /// Gets the sub position of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public string SubPosition => Root.Nodes.GetPropertyValue("item_sub_position");

        /// <summary>
        /// Gets the image data of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public CsgoInventoryImageData ImageData => new CsgoInventoryImageData(Root);

        /// <summary>
        /// Gets the sound of when the <see cref="CsgoInventoryItemPrefab"/> has been dropped.
        /// </summary>
        public string DropSound => Root.Nodes.GetPropertyValue("drop_sound");

        /// <summary>
        /// Gets the sound of when the <see cref="CsgoInventoryItemPrefab"/> has been pressed.
        /// </summary>
        public string MousePressedSound => Root.Nodes.GetPropertyValue("mouse_pressed_sound");


        /// <summary>
        /// Gets the quality of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public CsgoItemQuality? Quality
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("item_quality", out string value))
                {
                    return CsgoUtilities.ToItemQuality(value);
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the rarity of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public CsgoItemRarity? Rarity
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("item_rarity", out string value))
                {
                    return CsgoUtilities.ToItemRarity(value);
                }

                return null;
            }
        }

        /// <summary>
        /// Creates a new <see cref="CsgoInventoryItemPrefab"/> instance from a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public new static CsgoInventoryItemPrefab Create(CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return new CsgoInventoryItemPrefab(root);
        }
    }
}