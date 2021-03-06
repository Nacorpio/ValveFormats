using ValveFormats.Parser.Syntax.VMF.Nodes;

namespace ValveFormats.Templates.CSGO
{
    public sealed class CsgoSoundData
    {
        private readonly CompoundNode _root;

        public CsgoSoundData(CompoundNode root)
        {
            _root = root;
        }

        public object SingleShot => _root.Nodes.GetPropertyValue("single_shot");
    }
}