using System;
using System.Collections.Generic;
using nVMF.Extensions;
using nVMF.Parser.Syntax.VMF.Nodes;

namespace nVMF.Templates.CSGO
{
    public class CsgoWeaponPrefab : CsgoInventoryItemPrefab, IGameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CsgoWeaponPrefab"/> class.
        /// </summary>
        /// <param name="root">The root node.</param>
        internal CsgoWeaponPrefab(CompoundNode root) : base(root)
        {
        }

        /// <summary>
        /// Gets the team the <see cref="CsgoWeapon"/>
        /// </summary>
        public IEnumerable<CsgoTeam> Team
        {
            get
            {
                if (UsedByClasses == null)
                {
                    return null;
                }

                var results = new List<CsgoTeam>();

                if (UsedByClasses.TryGetValue("terrorists", out bool x) && x)
                {
                    results.Add(CsgoTeam.Terrorists);
                }

                if (UsedByClasses.TryGetValue("counter-terrorists", out bool y) && y)
                {
                    results.Add(CsgoTeam.CounterTerrorists);
                }

                return results.Count == 0 ? null : results;
            }
        } 

        /// <summary>
        /// Gets a value indicating whether a name tag can be applied to the <see cref="CsgoWeaponPrefab"/>.
        /// </summary>
        public bool? IsNameable
        {
            get
            {
                if (Capabilities == null)
                {
                    return null;
                }

                if (Capabilities.TryGetValue("nameable", out bool value))
                {
                    return value;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the player model of the <see cref="CsgoWeaponPrefab"/>.
        /// </summary>
        public string ModelPlayer => Root.Nodes.GetPropertyValue("model_player");

        /// <summary>
        /// Gets the world model of the <see cref="CsgoWeaponPrefab"/>.
        /// </summary>
        public string ModelWorld => Root.Nodes.GetPropertyValue("model_world");

        /// <summary>
        /// Creates a new instance of the <see cref="CsgoWeaponPrefab"/> class using a specified root node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <returns></returns>
        public new static CsgoWeaponPrefab Create(CompoundNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return !CsgoPrefab.Create(root).IsWeapon() ? null : new CsgoWeaponPrefab(root);
        }
    }
}