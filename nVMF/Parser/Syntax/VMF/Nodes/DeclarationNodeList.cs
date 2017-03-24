using System;
using System.Collections.Generic;
using System.Linq;

namespace Narser.Two.Parser.Syntax.VMF.Nodes
{
    public sealed class DeclarationNodeList : List<DeclarationNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeclarationNodeList"/> class.
        /// </summary>
        /// <param name="collection">A collection of declarations.</param>
        internal DeclarationNodeList(IEnumerable<DeclarationNode> collection) : base(collection)
        {
        }

        /// <summary>
        /// Gets a <see cref="DeclarationNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public DeclarationNode this[string name] => this.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));

        /// <summary>
        /// Sets the value of a <see cref="PropertyNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The new value.</param>
        public void SetPropertyValue(string name, object value)
        {
            if (TryGetProperty(name, out PropertyNode node))
            {
                node.Value = value;
            }
        }

        /// <summary>
        /// Returns the property value of a <see cref="PropertyNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns></returns>
        public string GetPropertyValue(string name)
        {
            if (TryGetProperty(name, out PropertyNode prop))
            {
                return (string) prop.Value;
            }

            return null;
        }

        /// <summary>
        /// Attempts to fetch a <see cref="PropertyNode"/> value with a specified name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="value">The resulting value.</param>
        /// <returns></returns>
        public bool TryGetPropertyValue(string name, out string value)
        {
            if (TryGetProperty(name, out PropertyNode property))
            {
                value = property.Value.ToString();
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Attemps to fetch a <see cref="PropertyNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns></returns>
        public bool TryGetProperty(string name, out PropertyNode property)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var node = (PropertyNode)this.FirstOrDefault(x => x is PropertyNode && x.Name.Equals(name));

            if (node == null)
            {
                property = null;
                return false;
            }

            property = node;
            return true;
        }

        /// <summary>
        /// Attemps to fetch a <see cref="CompoundNode"/> with a specified name.
        /// </summary>
        /// <param name="name">The compound name.</param>
        /// <param name="compound">The resulting compound.</param>
        /// <returns></returns>
        public bool TryGetCompound(string name, out CompoundNode compound)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var node = (CompoundNode)this.FirstOrDefault(x => x is CompoundNode && x.Name.Equals(name));

            if (node == null)
            {
                compound = null;
                return false;
            }

            compound = node;
            return true;
        }

        /// <summary>
        /// Returns whether the <see cref="CompoundNode"/> contains a child with a specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool Contains(string name) => this.Any(x => x.Name.ToLower().Equals(name.ToLower()));

    }
}