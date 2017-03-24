using nVMF.Templates.CSGO;

namespace nVMF.Templates
{
    public interface IInventoryItem
    {
        /// <summary>
        /// Gets the default slot of the <see cref="IInventoryItem"/>.
        /// </summary>
        CsgoItemSlot? Slot { get; }

        /// <summary>
        /// Gets the image data of the <see cref="IInventoryItem"/>.
        /// </summary>
        CsgoInventoryImageData ImageData { get; }

        /// <summary>
        /// Gets the path to the sound of which is played when the <see cref="IInventoryItem"/> is pressed.
        /// </summary>
        string MousePressedSound { get; }

        /// <summary>
        /// Gets the path to the sound of which is played when the <see cref="IInventoryItem"/> is dropped.
        /// </summary>
        string DropSound { get; }
    }

    public interface IGameObject
    {
        /// <summary>
        /// Gets the player model of the <see cref="IGameObject"/>.
        /// </summary>
        string ModelPlayer { get; }

        /// <summary>
        /// Gets the world model of the <see cref="IGameObject"/>.
        /// </summary>
        string ModelWorld { get; }
    }

    public interface IUsable
    {
        /// <summary>
        /// Gets the quality of the <see cref="IUsable"/>.
        /// </summary>
        CsgoItemQuality? Quality { get; }

        /// <summary>
        /// Gets the rarity of the <see cref="IUsable"/>.
        /// </summary>
        CsgoItemRarity? Rarity { get; }
    }
}