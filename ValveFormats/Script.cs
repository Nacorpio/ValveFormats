using System;
using System.IO;
using System.Linq;
using nVMF.Parser.Syntax.VMF.Nodes;
using VmfSyntaxParser = nVMF.Parser.Syntax.VMF.VmfSyntaxParser;

namespace nVMF
{
    public sealed class Script
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class using a specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        internal Script(string source)
        {
            Parse(source);
        }

        /// <summary>
        /// Gets the root of the <see cref="Script"/>.
        /// </summary>
        public CompoundNode Root => Nodes
            .Where(x => x is CompoundNode)
            .Cast<CompoundNode>()
            .First(x => x.IsRoot);

        /// <summary>
        /// Gets the nodes of the <see cref="Script"/>.
        /// </summary>
        public DeclarationNodeList Nodes { get; private set; }
        
        /// <summary>
        /// Parses the <see cref="Script"/> using its source.
        /// </summary>
        internal void Parse(string source)
        {
            using (var sp = new VmfSyntaxParser(source))
            {
                sp.Build();
                Nodes = new DeclarationNodeList(sp.Nodes.Cast<DeclarationNode>());
            }
        }

        /// <summary>
        /// Loads a <see cref="Script"/> from a specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Script LoadString(string source)
        {
            return new Script(source);
        }

        /// <summary>
        /// Writes a <see cref="Script"/> to a file at a specified path.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <param name="script">The script to write.</param>
        public static void Write(string path, Script script)
        {
            if (script == null)
            {
                throw new ArgumentNullException(nameof(script));
            }

            File.WriteAllText(path, script.Root.GetSource());
        }

        /// <summary>
        /// Reads a <see cref="Script"/> from a file at a specified file path.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <returns></returns>
        public static Script Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return LoadString(File.ReadAllText(path));
        }
    }
}
