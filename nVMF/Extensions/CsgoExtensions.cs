using System;
using System.Collections.Generic;
using System.Linq;
using Narser.Two.Classes;
using Narser.Two.Classes.CSGO;
using Narser.Two.Parser.Syntax.VMF.Nodes;

namespace Narser.Two.Extensions
{
    public static class CsgoExtensions
    {
        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a primary weapon prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsPrimaryWeapon(this CsgoPrefab prefab)
        {
            return prefab.Inherits("primary");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a secondary weapon prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsSecondaryWeapon(this CsgoPrefab prefab)
        {
            return prefab.Inherits("secondary");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a melee weapon prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsMeleeWeapon(this CsgoPrefab prefab)
        {
            return prefab.Inherits("melee");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a weapon prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsWeapon(this CsgoPrefab prefab)
        {
            return prefab.Inherits("weapon_base");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a weapon case prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsWeaponCase(this CsgoPrefab prefab)
        {
            return prefab.Inherits("weapon_case_base");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> is a collectible prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <returns></returns>
        public static bool IsCollectible(this CsgoPrefab prefab)
        {
            return prefab.Inherits("collectible");
        }

        /// <summary>
        /// Determines whether a specified <see cref="CsgoPrefab"/> inherits a specified prefab.
        /// </summary>
        /// <param name="prefab">The prefab to check.</param>
        /// <param name="other">The other prefab.</param>
        /// <returns></returns>
        public static bool Inherits(this CsgoPrefab prefab, string other)
        {
            return GetInheritanceTree(prefab).Any(x => x.Root.Name == other);
        }
        
        /// <summary>
        /// Returns the inheritance tree of a specified <see cref="CsgoPrefab"/>.
        /// </summary>
        /// <param name="prefab">The prefab.</param>
        /// <returns></returns>
        public static IEnumerable<CsgoPrefab> GetInheritanceTree(this CsgoPrefab prefab)
        {
            var results = new List<CsgoPrefab>();
            var next = prefab;

            while (true)
            {
                if (next.Base == null)
                {
                    break;
                }

                var parent = next.Root.Parent as CompoundNode;
                var node = parent?.Nodes[next.Base] as CompoundNode;

                next = CsgoPrefab.Create(node);
                results.Add(next);
            }

            return results;
        }
        
        /// <summary>
        /// Returns a collection of <see cref="CsgoPrefab"/> objects from a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public static IEnumerable<CsgoPrefab> GetPrefabs(this CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var node = root.Name.Equals("prefabs")
                ? root
                : root.Nodes["prefabs"] as CompoundNode;

            var prefabs = node?.Nodes
                .Where(x => x is CompoundNode)
                .Cast<CompoundNode>();

            return prefabs?.Select(x =>
            {
                var prefab = new CsgoPrefab(x);

                switch (prefab.CraftClass)
                {
                    case CsgoItemCraftClass.Weapon:
                        {
                            return new CsgoInventoryItemPrefab(x);
                        }
                }

                return null;
            });
        }
    }
}
