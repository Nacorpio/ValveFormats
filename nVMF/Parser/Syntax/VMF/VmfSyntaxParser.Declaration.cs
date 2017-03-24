using System.Collections.Generic;
using Narser.Two.Parser.Syntax.VMF.Nodes;
using Narser.Two.Parser.Utilities;

namespace Narser.Two.Parser.Syntax.VMF
{
    public sealed partial class VmfSyntaxParser
    {
        internal bool ParseDeclaration(int depth, ref SyntaxNode node)
        {
            var tokens = new List<Token>();

            if (!ExpectAny(TokenKind.Identifier, TokenKind.StringLiteral))
            {
                if (!Expect(TokenKind.LeftCurlyBrace))
                {
                    return false;
                }

                Advance();
                return false;
            }

            var tName = Advance();
            tokens.Add(tName);

            switch (Peek().Kind)
            {
                case TokenKind.RightCurlyBrace:
                {
                    if (!ParseCompound(depth, out node))
                    {
                        return false;
                    }

                    break;
                }

                case TokenKind.Numerical:
                case TokenKind.StringLiteral:
                case TokenKind.Identifier:
                {
                    if (!ParseProperty(depth, out node))
                    {
                        return false;
                    }

                    break;
                }
            }

            tokens.AddRange(node.Tokens);

            node.Tokens = tokens;

            ((DeclarationNode) node).Name = tName.Value.ToString();
            ((DeclarationNode) node).Depth = depth;

            return true;
        }

        internal bool ParseCompound(int depth, out SyntaxNode node)
        {
            var tokens = new List<Token>();
            node = new CompoundNode();

            if (!Expect(TokenKind.RightCurlyBrace))
            {
                return false;
            }

            tokens.Add(Advance());

            var declarations = new List<DeclarationNode>();
            SyntaxNode declaration = null;

            while (ParseDeclaration(depth + 1, ref declaration))
            {
                var decl = declaration as DeclarationNode;

                if (decl == null)
                {
                    break;
                }

                decl.Parent = (DeclarationNode) node;
                
                declarations.Add(decl);
                tokens.AddRange(declaration.Tokens);
            }

            tokens.Add(GetCurrent());

            //node = new CompoundNode(tokens, declarations);

            node.Tokens = tokens;
            ((CompoundNode)node).Nodes = new DeclarationNodeList(declarations);

            return true;
        }

        internal bool ParseProperty(int depth, out SyntaxNode node)
        {
            var tokens = new List<Token>();
            node = new PropertyNode();

            if (!ExpectAny(TokenKind.Identifier, TokenKind.StringLiteral, TokenKind.Numerical))
            {
                return false;
            }

            var tValue = Advance();
            tokens.Add(tValue);

            node.Tokens = tokens;
            ((PropertyNode) node).Value = tValue.Value;

            return true;
        }
    }
}