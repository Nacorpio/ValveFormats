using nVMF.Parser.Syntax.VMF.Nodes;
using nVMF.Utilities;

namespace nVMF.Templates.CSGO
{
    public sealed class CsgoInventorySpotLight
    {
        public CsgoInventorySpotLight(CompoundNode root)
        {
            Root = root;
        }

        public CompoundNode Root { get; }


        public float[] Position => CsgoUtilities.ToCoordinates(Root.Nodes.GetPropertyValue("position"));

        public float[] Color => CsgoUtilities.ToCoordinates(Root.Nodes.GetPropertyValue("color"));

        public float[] LookAt => CsgoUtilities.ToCoordinates(Root.Nodes.GetPropertyValue("lookat"));


        public float? InnerCone
        {
            get
            {
                if (float.TryParse(Root.Nodes.GetPropertyValue("inner_cone"), out float result))
                {
                    return result;
                }

                return null;
            }
        }

        public float? OuterCone
        {
            get
            {
                if (float.TryParse(Root.Nodes.GetPropertyValue("outer_cone"), out float result))
                {
                    return result;
                }

                return null;
            }
        }
    }
}