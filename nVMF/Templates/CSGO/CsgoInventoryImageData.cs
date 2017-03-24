using System.Collections.Generic;
using System.Linq;
using nVMF.Parser.Syntax.VMF.Nodes;
using nVMF.Utilities;

namespace nVMF.Templates.CSGO
{
    public sealed class CsgoInventoryImageData
    {
        private readonly CompoundNode _imageDataNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsgoInventoryImageData"/> class.
        /// </summary>
        /// <param name="root">The root node.</param>
        public CsgoInventoryImageData(CompoundNode root)
        {
            Root = root;
            _imageDataNode = Root.Nodes["inventory_image_data"] as CompoundNode;
        }

        /// <summary>
        /// Gets the root node of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public CompoundNode Root { get; }

        /// <summary>
        /// Gets the image of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public string Image => Root.Nodes.GetPropertyValue("image_inventory");


        /// <summary>
        /// Gets the image width in pixels of the <see cref="IInventoryItem"/>.
        /// </summary>
        public int? ImageWidth
        {
            get
            {
                if (int.TryParse(Root.Nodes.GetPropertyValue("image_inventory_size_w"), out int result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the image height in pixels of the <see cref="IInventoryItem"/>.
        /// </summary>
        public int? ImageHeight
        {
            get
            {
                if (int.TryParse(Root.Nodes.GetPropertyValue("image_inventory_size_h"), out int result))
                {
                    return result;
                }

                return null;
            }
        }


        /// <summary>
        /// Gets the camera angles of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public float[] CameraAngles =>
            _imageDataNode == null ? null : CsgoUtilities.ToCoordinates(_imageDataNode.Nodes.GetPropertyValue("camera_angles"));

        /// <summary>
        /// Gets the camera offset of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public float[] CameraOffset =>
            _imageDataNode == null ? null : CsgoUtilities.ToCoordinates(_imageDataNode.Nodes.GetPropertyValue("camera_offset"));


        /// <summary>
        /// Gets a value indicating whether to override the default light.
        /// </summary>
        public bool? OverrideDefaultLight
        {
            get
            {
                if (_imageDataNode == null)
                {
                    return null;
                }

                return
                    bool.TryParse(_imageDataNode.Nodes.GetPropertyValue("override_default_light"), out bool result) &&
                    result;
            }
        }

        /// <summary>
        /// Gets the field of view of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public float? Fov
        {
            get
            {
                if (_imageDataNode == null)
                {
                    return null;
                }

                if (float.TryParse(_imageDataNode.Nodes.GetPropertyValue("camera_fov"), out float result))
                {
                    return result;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the spot light objects of the <see cref="CsgoInventoryImageData"/>.
        /// </summary>
        public IEnumerable<CsgoInventorySpotLight> SpotLights
        {
            get
            {
                if (_imageDataNode == null)
                {
                    return null;
                }

                var spotlights = new List<CsgoInventorySpotLight>();

                foreach (var node in _imageDataNode.Nodes.Where(x => x.Name.StartsWith("spot_light")))
                {
                    spotlights.Add(new CsgoInventorySpotLight(node as CompoundNode));
                }

                return spotlights;
            }
        }
    }
}