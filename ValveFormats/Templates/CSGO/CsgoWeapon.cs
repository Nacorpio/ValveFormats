using ValveFormats.Parser.Syntax.VMF.Nodes;

namespace ValveFormats.Templates.CSGO
{
    public class CsgoWeapon
    {
        private readonly CompoundNode _root;

        public CsgoWeapon(CompoundNode root)
        {
            if (root.Name.Equals("WeaponData"))
            {
                _root = root;
                return;
            }

            _root = root.Nodes["WeaponData"] as CompoundNode;
        }

        public object MuzzleFlashEffectFirstPerson => _root.Nodes.GetPropertyValue("MuzzleFlashEffect_1stPerson");

        public object MuzzleFlashEffectThirdPerson => _root.Nodes.GetPropertyValue("MuzzleFlashEffect_3rdPerson");

        public object HeatEffect => _root.Nodes.GetPropertyValue("HeatEffect");

        public object HeatPerShot => _root.Nodes.GetPropertyValue("HeatPerShot");

        public object AddonScale => _root.Nodes.GetPropertyValue("AddonScale");

        public object AddonLocation => _root.Nodes.GetPropertyValue("AddonLocation");


        public object EjectBrassEffect => _root.Nodes.GetPropertyValue("EjectBrassEffect");

        public object TracerEffect => _root.Nodes.GetPropertyValue("TracerEffect");

        public object TracerFrequency => _root.Nodes.GetPropertyValue("TracerFrequency");


        public object MaxPlayerSpeed => _root.Nodes.GetPropertyValue("MaxPlayerSpeed");

        public object Type => _root.Nodes.GetPropertyValue("WeaponType");

        public object FullAuto => _root.Nodes.GetPropertyValue("FullAuto");

        public object Price => _root.Nodes.GetPropertyValue("WeaponPrice");

        public object ArmorRatio => _root.Nodes.GetPropertyValue("WeaponArmorRatio");

        public object KillAward => _root.Nodes.GetPropertyValue("KillAward");

        public object CrosshairMinDistance => _root.Nodes.GetPropertyValue("CrosshairMinDistance");

        public object CrosshairDeltaDistance => _root.Nodes.GetPropertyValue("CrosshairDeltaDistance");

        public object Team => _root.Nodes.GetPropertyValue("Team");

        public object BuiltRightHanded => _root.Nodes.GetPropertyValue("BuiltRightHanded");

        public object PlayerAnimationExtension => _root.Nodes.GetPropertyValue("PlayerAnimationExtension");


        public object CanEquipWithShield => _root.Nodes.GetPropertyValue("CanEquipWithShield");


        public object Penetration => _root.Nodes.GetPropertyValue("Penetration");

        public object Damage => _root.Nodes.GetPropertyValue("Damage");

        public object Range => _root.Nodes.GetPropertyValue("Range");

        public object RangeModifier => _root.Nodes.GetPropertyValue("RangeModifier");

        public object Bullets => _root.Nodes.GetPropertyValue("Bullets");

        public object CycleTime => _root.Nodes.GetPropertyValue("CycleTime");

        public object TimeToIdle => _root.Nodes.GetPropertyValue("TimeToIdle");

        public object IdleInterval => _root.Nodes.GetPropertyValue("IdleInterval");

        public object FlinchVelocityModifierLarge => _root.Nodes.GetPropertyValue("FlinchVelocityModifierLarge");

        public object FlinchVelocityModifierSmall => _root.Nodes.GetPropertyValue("FlinchVelocityModifierSmall");


        public object Spread => _root.Nodes.GetPropertyValue("Spread");

        public object InaccuracyCrouch => _root.Nodes.GetPropertyValue("InaccuracyCrouch");

        public object InaccuracyStand => _root.Nodes.GetPropertyValue("InaccuracyStand");

        public object InaccuracyJump => _root.Nodes.GetPropertyValue("InaccuracyJump");

        public object InaccuracyLand => _root.Nodes.GetPropertyValue("InaccuracyLand");

        public object InaccuracyLadder => _root.Nodes.GetPropertyValue("InaccuracyLadder");

        public object InaccuracyFire => _root.Nodes.GetPropertyValue("InaccuracyFire");

        public object InaccuracyMove => _root.Nodes.GetPropertyValue("InaccuracyMove");


        public object RecoveryTimeCrouch => _root.Nodes.GetPropertyValue("RecoveryTimeCrouch");

        public object RecoveryTimeStand => _root.Nodes.GetPropertyValue("RecoveryTimeStand");


        public object RecoilAngle => _root.Nodes.GetPropertyValue("RecoilAngle");

        public object RecoilAngleVariance => _root.Nodes.GetPropertyValue("RecoilAngleVariance");

        public object RecoilMagnitude => _root.Nodes.GetPropertyValue("RecoilMagnitude");

        public object RecoilMagnitudeVariance => _root.Nodes.GetPropertyValue("RecoilMagnitudeVariance");

        public object RecoilSeed => _root.Nodes.GetPropertyValue("RecoilSeed");


        public object PrintName => _root.Nodes.GetPropertyValue("printname");

        public object ViewModel => _root.Nodes.GetPropertyValue("viewmodel");

        public object PlayerModel => _root.Nodes.GetPropertyValue("playermodel");


        public object AnimPrefix => _root.Nodes.GetPropertyValue("anim_prefix");

        public object Bucket => _root.Nodes.GetPropertyValue("bucket");

        public object BucketPosition => _root.Nodes.GetPropertyValue("bucket_position");


        public object ClipSize => _root.Nodes.GetPropertyValue("clip_size");

        public object DefaultClip => _root.Nodes.GetPropertyValue("default_clip");

        public object DefaultClip2 => _root.Nodes.GetPropertyValue("default_clip2");


        public object PrimaryAmmo => _root.Nodes.GetPropertyValue("primary_ammo");

        public object SecondaryAmmo => _root.Nodes.GetPropertyValue("secondary_ammo");


        public object Weight => _root.Nodes.GetPropertyValue("weight");

        public object ItemFlags => _root.Nodes.GetPropertyValue("item_flags");


        public object Rumble => _root.Nodes.GetPropertyValue("rumble");

        public CsgoSoundData SoundData => new CsgoSoundData(_root.Nodes["SoundData"] as CompoundNode);
    }
}