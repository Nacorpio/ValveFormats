using System.Linq;
using ValveFormats.Templates;

namespace ValveFormats.Utilities
{
    internal static class CsgoUtilities
    {
        /// <summary>
        /// Converts a specified input <see cref="string"/> to an array of coordinates.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static float[] ToCoordinates(string input)
        {
            string[] split = input
                .Split(' ')
                .ToArray();

            if (split.Length == 0)
            {
                return null;
            }

            return split
                .Select(float.Parse)
                .ToArray();
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemSlot"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemSlot? ToItemSlot(string input)
        {
            switch (input.ToLower())
            {
                case "musickit":
                {
                    return CsgoItemSlot.MusicKit;
                }

                case "flair0":
                {
                    return CsgoItemSlot.Flair;
                }

                case "equipment":
                {
                    return CsgoItemSlot.Equipment;
                }

                case "grenade":
                {
                    return CsgoItemSlot.Grenade;
                }

                case "c4":
                {
                    return CsgoItemSlot.C4;
                }

                case "melee":
                {
                    return CsgoItemSlot.Melee;
                }

                case "secondary":
                {
                    return CsgoItemSlot.Secondary;
                }

                case "smg":
                {
                    return CsgoItemSlot.SubMachineGun;
                }

                case "rifle":
                {
                    return CsgoItemSlot.Rifle;
                }

                case "heavy":
                {
                    return CsgoItemSlot.Heavy;
                }

                case "clothing":
                {
                    return CsgoItemSlot.Clothing;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemRarity"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemRarity? ToItemRarity(string input)
        {
            switch (input.ToLower())
            {
                case "common":
                {
                    return CsgoItemRarity.Common;
                }

                case "uncommon":
                {
                    return CsgoItemRarity.Uncommon;
                }

                case "rare":
                {
                    return CsgoItemRarity.Rare;
                }

                case "ancient":
                {
                    return CsgoItemRarity.Ancient;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemQuality"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemQuality? ToItemQuality(string input)
        {
            switch (input.ToLower())
            {
                case "unique":
                {
                    return CsgoItemQuality.Unique;
                }

                case "genuine":
                {
                    return CsgoItemQuality.Genuine;
                }

                case "normal":
                {
                    return CsgoItemQuality.Normal;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemType"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemType? ToItemType(string input)
        {
            switch (input)
            {
                case "#CSGO_Type_Quest":
                {
                    return CsgoItemType.Quest;
                }

                case "#CSGO_Type_MusicKit":
                {
                    return CsgoItemType.MusicKit;
                }

                case "#CSGO_Type_StoreBundle":
                {
                    return CsgoItemType.StoreBundle;
                }

                case "#CSGO_Type_WeaponCase":
                {
                    return CsgoItemType.WeaponCase;
                }

                case "#CSGO_Type_Tool":
                {
                    return CsgoItemType.Tool;
                }

                case "#CSGO_Tool_WeaponCase_KeyTag":
                {
                    return CsgoItemType.WeaponCaseKeyTag;
                }

                case "#CSGO_Type_recipe":
                {
                    return CsgoItemType.Recipe;
                }

                case "#CSGO_Type_Collectible":
                {
                    return CsgoItemType.Collectible;
                }

                case "#CSGO_Type_Equipment":
                {
                    return CsgoItemType.Equipment;
                }

                case "#CSGO_Type_Grenade":
                {
                    return CsgoItemType.Grenade;
                }

                case "#CSGO_Type_C4":
                {
                    return CsgoItemType.C4;
                }

                case "#CSGO_Type_Knife":
                {
                    return CsgoItemType.Knife;
                }

                case "#CSGO_Type_Pistol":
                {
                    return CsgoItemType.Pistol;
                }

                case "#CSGO_Type_SMG":
                {
                    return CsgoItemType.SubMachinegun;
                }

                case "#CSGO_Type_Rifle":
                {
                    return CsgoItemType.Rifle;
                }

                case "#CSGO_Type_SniperRifle":
                {
                    return CsgoItemType.SniperRifle;
                }

                case "#CSGO_Type_Shotgun":
                {
                    return CsgoItemType.Shotgun;
                }

                case "#CSGO_Type_Machinegun":
                {
                    return CsgoItemType.Machinegun;
                }

                case "#Type_Hands":
                {
                    return CsgoItemType.Hands;
                }

                case "#campaign":
                {
                    return CsgoItemType.Campaign;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemClass"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemClass? ToItemClass(string input)
        {
            switch (input.ToLower())
            {
                case "tool":
                {
                    return CsgoItemClass.Tool;
                }

                case "collectable":
                {
                    return CsgoItemClass.Collectible;
                }

                case "weapon":
                {
                    return CsgoItemClass.Weapon;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoMaterialType"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoMaterialType? ToItemMaterialType(string input)
        {
            switch (input.ToLower())
            {
                case "tool":
                {
                    return CsgoMaterialType.Tool;
                }

                case "weapon":
                {
                    return CsgoMaterialType.Weapon;
                }

                default:
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts a specified input <see cref="string"/> to a <see cref="CsgoItemCraftClass"/> object.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns></returns>
        public static CsgoItemCraftClass? ToItemCraftClass(string input)
        {
            switch (input.ToLower())
            {
                case "tool":
                {
                    return CsgoItemCraftClass.Tool;
                }

                case "collectable":
                {
                    return CsgoItemCraftClass.Collectable;
                }

                case "weapon":
                {
                    return CsgoItemCraftClass.Weapon;
                }

                default:
                {
                    return null;
                }
            }
        }
    }
}
