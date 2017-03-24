using System;
using System.Collections.Generic;
using System.Linq;
using Narser.Two.Extensions;
using Narser.Two.Parser.Syntax.VMF.Nodes;
using Narser.Two.Utilities;

namespace Narser.Two.Classes.CSGO
{
    public class CsgoPrefab
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsgoPrefab"/> class.
        /// </summary>
        /// <param name="root">The root node.</param>
        internal CsgoPrefab(CompoundNode root)
        {
            Root = root;
        }

        /// <summary>
        /// Gets the root node of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public CompoundNode Root { get; }


        /// <summary>
        /// Gets the base of which the <see cref="CsgoPrefab"/> inherits from.
        /// </summary>
        public string Base => Root.Nodes.GetPropertyValue("prefab");

        /// <summary>
        /// Gets the name of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public string Name => Root.Nodes.GetPropertyValue("item_name");


        /// <summary>
        /// Gets the crafting material type of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public CsgoMaterialType? CraftMaterialType =>
            Root.Nodes.TryGetPropertyValue("craft_material_type", out string value) ? CsgoUtilities.ToItemMaterialType(value) : null;

        /// <summary>
        /// Gets the slot of the <see cref="CsgoInventoryItemPrefab"/>.
        /// </summary>
        public CsgoItemSlot? Slot
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("item_slot", out string value))
                {
                    return CsgoUtilities.ToItemSlot(value);
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the class of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public CsgoItemClass? Class
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("item_class", out string value))
                {
                    return CsgoUtilities.ToItemClass(value);
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the type of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public CsgoItemType? Type
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("item_type_name", out string value))
                {
                    return CsgoUtilities.ToItemType(value);
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the craft class of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public CsgoItemCraftClass? CraftClass
        {
            get
            {
                if (Root.Nodes.TryGetPropertyValue("craft_class", out string value))
                {
                    return CsgoUtilities.ToItemCraftClass(value);
                }

                return null;
            }
        }


        /// <summary>
        /// Gets the attributes of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public IReadOnlyDictionary<string, DeclarationNode> Attributes
        {
            get
            {
                if (Root.Nodes.TryGetCompound("attributes", out CompoundNode node))
                {
                    return node.Nodes
                        .ToDictionary(
                            x => x.Name,
                            x => x
                        );
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the capabilities of the <see cref="CsgoPrefab"/>.
        /// </summary>
        public IReadOnlyDictionary<string, bool> Capabilities
        {
            get
            {
                if (Root.Nodes.TryGetCompound("capabilities", out CompoundNode node))
                {
                    return (IReadOnlyDictionary<string, bool>) node.ToDictionary();
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the classes that uses the <see cref="CsgoPrefab"/>.
        /// </summary>
        public IReadOnlyDictionary<string, bool> UsedByClasses
        {
            get
            {
                if (Root.Nodes.TryGetCompound("used_by_classes", out CompoundNode node))
                {
                    return (IReadOnlyDictionary<string, bool>) node.ToDictionary();
                }

                return null;
            }
        }
        
        /// <summary>
        /// Creates a <see cref="CsgoPrefab"/> instance from a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public static CsgoPrefab Create(CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return new CsgoPrefab(root);
        } 
    }
}