﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
namespace LiveSplit.HollowKnight {
    public partial class HollowKnightSplitSettings : UserControl {
        public string Split { get; set; } = "";
        private int mX = 0;
        private int mY = 0;
        private bool isDragging = false;
        public HollowKnightSplitSettings() {
            InitializeComponent();
        }
        private void cboName_SelectedIndexChanged(object sender, EventArgs e) {
            string splitDescription = cboName.SelectedValue.ToString();
            SplitName split = GetSplitName(splitDescription);
            Split = split.ToString();

            MemberInfo info = typeof(SplitName).GetMember(split.ToString())[0];
            DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
            ToolTipAttribute tooltip = (ToolTipAttribute)info.GetCustomAttributes(typeof(ToolTipAttribute), false)[0];
            ToolTips.SetToolTip(cboName, tooltip.ToolTip);
        }
        public static SplitName GetSplitName(string text) {
            foreach (SplitName split in Enum.GetValues(typeof(SplitName))) {
                string name = split.ToString();
                MemberInfo info = typeof(SplitName).GetMember(name)[0];
                DescriptionAttribute description = (DescriptionAttribute)info.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];

                if (name.Equals(text, StringComparison.OrdinalIgnoreCase) || description.Description.Equals(text, StringComparison.OrdinalIgnoreCase)) {
                    return split;
                }
            }
            return SplitName.ForgottenCrossroads;
        }
        private void picHandle_MouseMove(object sender, MouseEventArgs e) {
            if (!isDragging) {
                if (e.Button == MouseButtons.Left) {
                    int num1 = mX - e.X;
                    int num2 = mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > 20) {
                        DoDragDrop(this, DragDropEffects.All);
                        isDragging = true;
                        return;
                    }
                }
            }
        }
        private void picHandle_MouseDown(object sender, MouseEventArgs e) {
            mX = e.X;
            mY = e.Y;
            isDragging = false;
        }
    }
    public enum SplitName {
        [Description("Abyss Shriek (Skill)"), ToolTip("Splits when obtaining Abyss Shriek (Shadow Scream)")]
        AbyssShriek,
        [Description("Crystal Heart (Skill)"), ToolTip("Splits when obtaining Crystal Heart (Super Dash)")]
        CrystalHeart,
        [Description("Cyclone Slash (Skill)"), ToolTip("Splits when obtaining Cyclone Slash (Nail Art)")]
        CycloneSlash,
        [Description("Dash Slash (Skill)"), ToolTip("Splits when obtaining Dash Slash (Nail Art)")]
        DashSlash,
        [Description("Descending Dark (Skill)"), ToolTip("Splits when obtaining Descending Dark (Shadow Dive)")]
        DescendingDark,
        [Description("Desolate Dive (Skill)"), ToolTip("Splits when obtaining Desolate Dive")]
        DesolateDive,
        [Description("Dream Nail (Skill)"), ToolTip("Splits when obtaining Dream Nail")]
        DreamNail,
        [Description("Dream Nail - Awoken (Skill)"), ToolTip("Splits when Awkening the Dream Nail")]
        DreamNail2,
        [Description("Dream Gate (Skill)"), ToolTip("Splits when obtaining Dream Gate")]
        DreamGate,
        [Description("Great Slash (Skill)"), ToolTip("Splits when obtaining Great Slash (Nail Art)")]
        GreatSlash,
        [Description("Howling Wraiths (Skill)"), ToolTip("Splits when obtaining Howling Wraiths (Scream)")]
        HowlingWraiths,
        [Description("Isma's Tear (Skill)"), ToolTip("Splits when obtaining Isma's Tear (Acid Armour)")]
        IsmasTear,
        [Description("Mantis Claw (Skill)"), ToolTip("Splits when obtaining Mantis Claw (Wall Jump)")]
        MantisClaw,
        [Description("Monarch Wings (Skill)"), ToolTip("Splits when obtaining Monarch Wings (Double Jump)")]
        MonarchWings,
        [Description("Mothwing Cloak (Skill)"), ToolTip("Splits when obtaining Mothwing Cloak (Dash)")]
        MothwingCloak,
        [Description("Shade Cloak (Skill)"), ToolTip("Splits when obtaining Shade Cloak (Shadow Dash)")]
        ShadeCloak,
        [Description("Shade Soul (Skill)"), ToolTip("Splits when obtaining Shade Soul (Vengeful Spirit 2)")]
        ShadeSoul,
        [Description("Vengeful Spirit (Skill)"), ToolTip("Splits when obtaining Vengeful Spirit")]
        VengefulSpirit,

        [Description("God Tuner (Item)"), ToolTip("Splits when obtaining the God Tuner")]
        GodTuner,
        [Description("Hunter's Mark (Item)"), ToolTip("Splits when obtaining the Hunter's Mark")]
        HuntersMark,
        [Description("Kings Brand (Item)"), ToolTip("Splits when obtaining the Kings Brand")]
        KingsBrand,
        [Description("Love Key (Item)"), ToolTip("Splits when obtaining the Love Key")]
        LoveKey,
        [Description("Elegant Key (Item)"), ToolTip("Splits when obtaining the Elegant Key")]
        ElegantKey,
        [Description("Lumafly Lantern (Item)"), ToolTip("Splits when obtaining the Lumafly Lantern")]
        LumaflyLantern,
        [Description("Pale Lurker Key (Item)"), ToolTip("Splits when obtaining the Simple Key from the Pale Lurker")]
        PaleLurkerKey,
        [Description("Pale Ore - Any (Item)"), ToolTip("Splits if you've obtained any Pale Ore")]
        PaleOre,
        [Description("Salubra's Blessing (Item)"), ToolTip("Splits when obtaining Salubra's Blessing")]
        SalubrasBlessing,
        [Description("Simple Key - First (Item)"), ToolTip("Splits when obtaining the first Simple Key")]
        SimpleKey,
        [Description("Sly Key (Item)"), ToolTip("Splits when obtaining the Simple Key from Sly")]
        SlyKey,
        [Description("Tram Pass (Item)"), ToolTip("Splits when obtaining the Tram Pass")]
        TramPass,

        [Description("Mask Fragment 1 (Fragment)"), ToolTip("Splits when getting 1st Mask fragment")]
        MaskFragment1,
        [Description("Mask Fragment 2 (Fragment)"), ToolTip("Splits when getting 2nd Mask fragment")]
        MaskFragment2,
        [Description("Mask Fragment 3 (Fragment)"), ToolTip("Splits when getting 3rd Mask fragment")]
        MaskFragment3,
        [Description("Mask Fragment 4 (Upgrade)"), ToolTip("Splits when getting 4th Mask fragment (6 HP)")]
        Mask1,
        [Description("Mask Fragment 5 (Fragment)"), ToolTip("Splits when getting 5th Mask fragment")]
        MaskFragment5,
        [Description("Mask Fragment 6 (Fragment)"), ToolTip("Splits when getting 6th Mask fragment")]
        MaskFragment6,
        [Description("Mask Fragment 7 (Fragment)"), ToolTip("Splits when getting 7th Mask fragment")]
        MaskFragment7,
        [Description("Mask Fragment 8 (Upgrade)"), ToolTip("Splits when getting 8th Mask fragment (7 HP)")]
        Mask2,
        [Description("Mask Fragment 9 (Fragment)"), ToolTip("Splits when getting 9th Mask fragment")]
        MaskFragment9,
        [Description("Mask Fragment 10 (Fragment)"), ToolTip("Splits when getting 10th Mask fragment")]
        MaskFragment10,
        [Description("Mask Fragment 11 (Fragment)"), ToolTip("Splits when getting 11th Mask fragment")]
        MaskFragment11,
        [Description("Mask Fragment 12 (Upgrade)"), ToolTip("Splits when getting 12th Mask fragment (8 HP)")]
        Mask3,
        [Description("Mask Fragment 13 (Fragment)"), ToolTip("Splits when getting 13th Mask fragment")]
        MaskFragment13,
        [Description("Mask Fragment 14 (Fragment)"), ToolTip("Splits when getting 14th Mask fragment")]
        MaskFragment14,
        [Description("Mask Fragment 15 (Fragment)"), ToolTip("Splits when getting 15th Mask fragment")]
        MaskFragment15,
        [Description("Mask Fragment 16 (Upgrade)"), ToolTip("Splits when getting 16th Mask fragment (9 HP)")]
        Mask4,
        [Description("Nail 1 (Upgrade)"), ToolTip("Splits when getting Nail Upgrade 1")]
        NailUpgrade1,
        [Description("Nail 2 (Upgrade)"), ToolTip("Splits when getting Nail Upgrade 2")]
        NailUpgrade2,
        [Description("Nail 3 (Upgrade)"), ToolTip("Splits when getting Coil Nail (Upgrade 3)")]
        NailUpgrade3,
        [Description("Nail 4 (Upgrade)"), ToolTip("Splits when getting Pure Nail (Upgrade 4)")]
        NailUpgrade4,
        [Description("Vessel Fragment 1 (Fragment)"), ToolTip("Splits when getting 1st Vessel fragment")]
        VesselFragment1,
        [Description("Vessel Fragment 2 (Fragment)"), ToolTip("Splits when getting 2nd Vessel fragment")]
        VesselFragment2,
        [Description("Vessel Fragment 3 (Upgrade)"), ToolTip("Splits when getting 3rd Vessel fragment (1 extra MP)")]
        Vessel1,
        [Description("Vessel Fragment 4 (Fragment)"), ToolTip("Splits when getting 4th Vessel fragment")]
        VesselFragment4,
        [Description("Vessel Fragment 5 (Fragment)"), ToolTip("Splits when getting 5th Vessel fragment")]
        VesselFragment5,
        [Description("Vessel Fragment 6 (Upgrade)"), ToolTip("Splits when getting 6th Vessel fragment (2 extra MP)")]
        Vessel2,
        [Description("Vessel Fragment 7 (Fragment)"), ToolTip("Splits when getting 7th Vessel fragment")]
        VesselFragment7,
        [Description("Vessel Fragment 8 (Fragment)"), ToolTip("Splits when getting 8th Vessel fragment")]
        VesselFragment8,
        [Description("Vessel Fragment 9 (Upgrade)"), ToolTip("Splits when getting 9th Vessel fragment (3 extra MP)")]
        Vessel3,

        [Description("Broken Vessel (Boss)"), ToolTip("Splits when killing Broken Vessel")]
        BrokenVessel,
        [Description("Brooding Mawlek (Boss)"), ToolTip("Splits when killing Brooding Mawlek")]
        BroodingMawlek,
        [Description("Collector (Boss)"), ToolTip("Splits when killing Collector")]
        Collector,
        [Description("Crystal Guardian 1 (Boss)"), ToolTip("Splits when killing the Crystal Guardian for the first time")]
        CrystalGuardian1,
        [Description("Crystal Guardian 2 (Boss)"), ToolTip("Splits when killing the Crystal Guardian for the second time")]
        CrystalGuardian2,
        [Description("Dung Defender (Boss)"), ToolTip("Splits when killing Dung Defender")]
        DungDefender,
        [Description("Elder Hu (Boss)"), ToolTip("Splits when killing Elder Hu")]
        ElderHu,
        [Description("False Knight (Boss)"), ToolTip("Splits when killing False Knight")]
        FalseKnight,
        [Description("Failed Champion (Boss)"), ToolTip("Splits when killing Failed Champion (False Knight Dream)")]
        FailedKnight,
        [Description("Flukemarm (Boss)"), ToolTip("Splits when killing Flukemarm")]
        Flukemarm,
        [Description("Galien (Boss)"), ToolTip("Splits when killing Galien")]
        Galien,
        [Description("God Tamer (Boss)"), ToolTip("Splits when killing the God Tamer")]
        GodTamer,
        [Description("Gorb (Boss)"), ToolTip("Splits when killing Gorb")]
        Gorb,
        [Description("Grey Prince Zote (Boss)"), ToolTip("Splits when killing Grey Prince")]
        GreyPrince,
        [Description("Gruz Mother (Boss)"), ToolTip("Splits when killing Gruz Mother")]
        GruzMother,
        [Description("Hollow Knight - Dream Nail (Boss)"), ToolTip("Splits when going into the dream world for Hollow Knight to fight Radiance")]
        HollowKnight,
        [Description("Hornet 1 (Boss)"), ToolTip("Splits when killing Hornet for the first time")]
        Hornet1,
        [Description("Hornet 2 (Boss)"), ToolTip("Splits when killing Hornet for the second time")]
        Hornet2,
        [Description("Lost Kin (Boss)"), ToolTip("Splits when killing Lost Kin (Broken Vessel Dream)")]
        LostKin,
        [Description("Mantis Lords (Boss)"), ToolTip("Splits when killing Mantis Lords")]
        MantisLords,
        [Description("Markoth (Boss)"), ToolTip("Splits when killing Markoth")]
        Markoth,
        [Description("Marmu (Boss)"), ToolTip("Splits when killing Marmu")]
        Marmu,
        [Description("Mega Moss Charger (Boss)"), ToolTip("Splits when killing Mega Moss Charger")]
        MegaMossCharger,
        [Description("Nightmare King Grimm (Boss)"), ToolTip("Splits when killing Nightmare King Grimm")]
        NightmareKingGrimm,
        [Description("No Eyes (Boss)"), ToolTip("Splits when killing No Eyes")]
        NoEyes,
        [Description("Nosk (Boss)"), ToolTip("Splits when killing Nosk")]
        Nosk,
        [Description("Oro & Mato Nail Bros (Boss)"), ToolTip("Splits when killing the Nail Bros (Pantheon)")]
        MatoOroNailBros,
        [Description("Pure Vessel (Boss)"), ToolTip("Splits when killing Pure Vessel")]
        PureVessel,
        [Description("Sheo Paintmaster (Boss)"), ToolTip("Splits when killing Sheo (Pantheon)")]
        SheoPaintmaster,
        [Description("Sly Nailsage (Boss)"), ToolTip("Splits when killing Nailsage Sly (Pantheon)")]
        SlyNailsage,
        [Description("Soul Master (Boss)"), ToolTip("Splits when killing Soul Master")]
        SoulMaster,
        [Description("Soul Tyrant (Boss)"), ToolTip("Splits when killing Soul Tyrant (Soul Master Dream)")]
        SoulTyrant,
        [Description("Traitor Lord (Boss)"), ToolTip("Splits when killing Traitor Lord")]
        TraitorLord,
        [Description("Troupe Master Grimm (Boss)"), ToolTip("Splits when killing Troupe Master Grimm")]
        TroupeMasterGrimm,
        [Description("Uumuu (Boss)"), ToolTip("Splits when killing Uumuu")]
        Uumuu,
        [Description("Watcher Knight (Boss)"), ToolTip("Splits when killing Watcher Knight")]
        BlackKnight,
        [Description("White Defender (Boss)"), ToolTip("Splits when killing White Defender")]
        WhiteDefender,
        [Description("Xero (Boss)"), ToolTip("Splits when killing Xero")]
        Xero,
        [Description("Hive Knight (Boss)"), ToolTip("Splits when killing Hive Knight")]
        HiveKnight,

        [Description("Vengefly King (Pantheon)"), ToolTip("Splits after killing Vengefly King in Pantheon 1")]
        VengeflyKingP,
        [Description("Gruz Mother (Pantheon)"), ToolTip("Splits after killing Gruz Mother in Pantheon 1")]
        GruzMotherP,
        [Description("False Knight (Pantheon)"), ToolTip("Splits after killing False Knight in Pantheon 1")]
        FalseKnightP,
        [Description("Massive Moss Charger (Pantheon)"), ToolTip("Splits after killing Massive Moss Charger in Pantheon 1")]
        MassiveMossChargerP,
        [Description("Hornet 1 (Pantheon)"), ToolTip("Splits after killing Hornet 1 in Pantheon 1")]
        Hornet1P,
        [Description("Gorb (Pantheon)"), ToolTip("Splits after killing Gorb in Pantheon 1")]
        GorbP,
        [Description("Dung Defender (Pantheon)"), ToolTip("Splits after killing Dung Defender in Pantheon 1")]
        DungDefenderP,
        [Description("Soul Warrior (Pantheon)"), ToolTip("Splits after killing Soul Warrior in Pantheon 1")]
        SoulWarriorP,
        [Description("Brooding Mawlek (Pantheon)"), ToolTip("Splits after killing Brooding Mawlek in Pantheon 1")]
        BroodingMawlekP,
        [Description("Oro & Mato Nail Bros (Pantheon)"), ToolTip("Splits after killing Oro & Mato in Pantheon 1")]
        OroMatoNailBrosP,

        [Description("Xero (Pantheon)"), ToolTip("Splits after killing Xero in Pantheon 2")]
        XeroP,
        [Description("Crystal Guardian (Pantheon)"), ToolTip("Splits after killing Crystal Guardian in Pantheon 2")]
        CrystalGuardianP,
        [Description("Soul Master (Pantheon)"), ToolTip("Splits after killing Soul Master in Pantheon 2")]
        SoulMasterP,
        [Description("Oblobbles (Pantheon)"), ToolTip("Splits after killing Oblobbles in Pantheon 2")]
        OblobblesP,
        [Description("Mantis Lords (Pantheon)"), ToolTip("Splits after killing Mantis Lords in Pantheon 2")]
        MantisLordsP,
        [Description("Marmu (Pantheon)"), ToolTip("Splits after killing Marmu in Pantheon 2")]
        MarmuP,
        [Description("Nosk (Pantheon)"), ToolTip("Splits after killing Nosk in Pantheon 2")]
        NoskP,
        [Description("Flukemarm (Pantheon)"), ToolTip("Splits after killing Flukemarm in Pantheon 2")]
        FlukemarmP,
        [Description("Broken Vessel (Pantheon)"), ToolTip("Splits after killing Broken Vessel in Pantheon 2")]
        BrokenVesselP,
        [Description("Sheo Paintmaster (Pantheon)"), ToolTip("Splits after killing Sheo Paintmaster in Pantheon 2")]
        SheoPaintmasterP,

        [Description("Hive Knight (Pantheon)"), ToolTip("Splits after killing Hive Knight in Pantheon 3")]
        HiveKnightP,
        [Description("Elder Hu (Pantheon)"), ToolTip("Splits after killing Elder Hu in Pantheon 3")]
        ElderHuP,
        [Description("Collector (Pantheon)"), ToolTip("Splits after killing The Collector in Pantheon 3")]
        CollectorP,
        [Description("God Tamer (Pantheon)"), ToolTip("Splits after killing God Tamer in Pantheon 3")]
        GodTamerP,
        [Description("Troupe Master Grimm (Pantheon)"), ToolTip("Splits after killing Troupe Master Grimm in Pantheon 3")]
        TroupeMasterGrimmP,
        [Description("Galien (Pantheon)"), ToolTip("Splits after killing Galien in Pantheon 3")]
        GalienP,
        [Description("Grey Prince Zote (Pantheon)"), ToolTip("Splits after killing Grey Prince Zote in Pantheon 3")]
        GreyPrinceZoteP,
        [Description("Uumuu (Pantheon)"), ToolTip("Splits after killing Uumuu in Pantheon 3")]
        UumuuP,
        [Description("Hornet 2 (Pantheon)"), ToolTip("Splits after killing Hornet 2 in Pantheon 3")]
        Hornet2P,
        [Description("Sly Nailsage (Pantheon)"), ToolTip("Splits after killing Sly Nailsage in Pantheon 3")]
        SlyP,

        [Description("Enraged Guardian (Pantheon)"), ToolTip("Splits after killing Enraged Guardian in Pantheon 4")]
        EnragedGuardianP,
        [Description("Lost Kin (Pantheon)"), ToolTip("Splits after killing Lost Kin in Pantheon 4")]
        LostKinP,
        [Description("No Eyes (Pantheon)"), ToolTip("Splits after killing No Eyes in Pantheon 4")]
        NoEyesP,
        [Description("Traitor Lord (Pantheon)"), ToolTip("Splits after killing Traitor Lord in Pantheon 4")]
        TraitorLordP,
        [Description("White Defender (Pantheon)"), ToolTip("Splits after killing White Defender in Pantheon 4")]
        WhiteDefenderP,
        [Description("Failed Champion (Pantheon)"), ToolTip("Splits after killing Failed Champion in Pantheon 4")]
        FailedChampionP,
        [Description("Markoth (Pantheon)"), ToolTip("Splits after killing Markoth in Pantheon 4")]
        MarkothP,
        [Description("Watcher Knights (Pantheon)"), ToolTip("Splits after killing Watcher Knights in Pantheon 4")]
        WatcherKnightsP,
        [Description("Soul Tyrant (Pantheon)"), ToolTip("Splits after killing Soul Tyrant in Pantheon 4")]
        SoulTyrantP,
        [Description("Pure Vessel (Pantheon)"), ToolTip("Splits after killing Pure Vessel in Pantheon 4")]
        PureVesselP,

        [Description("Nosk Hornet (Pantheon)"), ToolTip("Splits after killing Nosk Hornet in Pantheon 5")]
        NoskHornetP,
        [Description("Nightmare King Grimm (Pantheon)"), ToolTip("Splits after killing Nightmare King Grimm in Pantheon 5")]
        NightmareKingGrimmP,

        [Description("Herrah the Beast (Dreamer)"), ToolTip("Splits when you see the mask for Herrah (In Spider Area)")]
        Hegemol,
        [Description("Lurien the Watcher (Dreamer)"), ToolTip("Splits when you see the mask for Lurien (After killing Watcher Knight)")]
        Lurien,
        [Description("Monomon the Teacher (Dreamer)"), ToolTip("Splits when you see the mask for Monomon (After killing Uumuu)")]
        Monomon,
        [Description("First Dreamer (Dreamer)"), ToolTip("Splits when you see the mask for the first dreamer killed")]
        Dreamer1,
        [Description("Second Dreamer (Dreamer)"), ToolTip("Splits when you see the mask for the second dreamer killed")]
        Dreamer2,
        [Description("Third Dreamer (Dreamer)"), ToolTip("Splits when you see the mask for the third dreamer killed")]
        Dreamer3,
        [Description("Nightmare Lantern (Event)"), ToolTip("Splits when activating the Nightmare Lantern")]
        NightmareLantern,
        [Description("Nightmare Lantern Destroyed (Event)"), ToolTip("Splits when destroying the Nightmare Lantern")]
        NightmareLanternDestroyed,
        [Description("Seer Departs (Event)"), ToolTip("Splits when the Seer Departs after bringing back 2400 essence")]
        SeerDeparts,
        [Description("Spirit Glade Door (Event)"), ToolTip("Splits when the Seer open Spirit Glade after bringing back 200 essence")]
        SpiritGladeOpen,
        [Description("Watcher Knights Chandelier (Event)"), ToolTip("Splits when dropping the chandelier on one of the watcher knights")]
        WatcherChandelier,
        [Description("Beasts Den Trap Bench (Event)"), ToolTip("Splits when getting the trap bench in Beasts Den")]
        BeastsDenTrapBench,
        [Description("Hollow Knight Scream (Event)"), ToolTip("Splits at the end of the first Hollow Knight scream after the chains are broken")]
        UnchainedHollowKnight,

        [Description("Colosseum Fight 1 (Trial)"), ToolTip("Splits when beating the first Colosseum trial")]
        ColosseumBronze,
        [Description("Colosseum Fight 2 (Trial)"), ToolTip("Splits when beating the second Colosseum trial")]
        ColosseumSilver,
        [Description("Colosseum Fight 3 (Trial)"), ToolTip("Splits when beating the third Colosseum trial")]
        ColosseumGold,
        [Description("Pantheon 1 (Trial)"), ToolTip("Splits when beating the first Pantheon")]
        Pantheon1,
        [Description("Pantheon 2 (Trial)"), ToolTip("Splits when beating the second Pantheon")]
        Pantheon2,
        [Description("Pantheon 3 (Trial)"), ToolTip("Splits when beating the third Pantheon")]
        Pantheon3,
        [Description("Pantheon 4 (Trial)"), ToolTip("Splits when beating the fourth Pantheon")]
        Pantheon4,
        [Description("Pantheon 5 (Trial)"), ToolTip("Splits when beating the fifth Pantheon")]
        Pantheon5,
        [Description("Path of Pain (Completed)"), ToolTip("Splits when completing the Path of Pain section in White Palace")]
        PathOfPain,

        [Description("Aspid Hunter (Mini Boss)"), ToolTip("Splits when killing the final Aspid Hunter")]
        AspidHunter,
        [Description("Aluba (Killed)"), ToolTip("Splits when killing an Aluba")]
        Aluba,
        [Description("Husk Miner (Killed)"), ToolTip("Splits when killing a Husk Miner")]
        HuskMiner,
        [Description("Great Hopper (Killed)"), ToolTip("Splits when killing a Great Hopper")]
        GreatHopper,
        [Description("Gorgeous Husk (Killed)"), ToolTip("Splits when killing Gorgeous Husk")]
        GorgeousHusk,
        [Description("Moss Knight (Mini Boss)"), ToolTip("Splits when killing Moss Knight")]
        MossKnight,
        [Description("Shrumal Ogre (Mini Boss)"), ToolTip("Splits when killing the final Shrumal Ogre")]
        MushroomBrawler,
        [Description("Zote Rescued Vengefly King (Mini Boss)"), ToolTip("Splits when rescuing Zote from the Vengefly King")]
        Zote1,
        [Description("Zote Rescued Deepnest (Mini Boss)"), ToolTip("Splits when rescuing Zote in Deepnest")]
        Zote2,
        [Description("Zote Killed Colosseum (Mini Boss)"), ToolTip("Splits when killing Zote in the Colosseum")]
        ZoteKilled,

        [Description("Distant Village (Stag Station)"), ToolTip("Splits when obtaining Distant Village Stag Station")]
        DeepnestStation,
        [Description("Forgotten Crossroads (Stag Station)"), ToolTip("Splits when opening the Forgotten Crossroads Stag Station")]
        CrossroadsStation,
        [Description("Kings Station (Stag Station)"), ToolTip("Splits when obtaining Kings Station Stag Station")]
        KingsStationStation,
        [Description("City Storerooms (Stag Station)"), ToolTip("Splits when obtaining City Storerooms Stag Station")]
        StoreroomsStation,
        [Description("Greenpath (Stag Station)"), ToolTip("Splits when obtaining Greenpath Stag Station")]
        GreenpathStation,
        [Description("Queens Station (Stag Station)"), ToolTip("Splits when obtaining Queens Station Stag Station")]
        QueensStationStation,

        [Description("Mr. Mushroom 1 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom1,
        [Description("Mr. Mushroom 2 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom2,
        [Description("Mr. Mushroom 3 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom3,
        [Description("Mr. Mushroom 4 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom4,
        [Description("Mr. Mushroom 5 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom5,
        [Description("Mr. Mushroom 6 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom6,
        [Description("Mr. Mushroom 7 (Spot)"), ToolTip("Splits when talking to Mr. Mushroom")]
        MrMushroom7,

        [Description("Abyss (Area)"), ToolTip("Splits when entering Abyss text first appears")]
        Abyss,
        [Description("City Of Tears (Area)"), ToolTip("Splits when entering City Of Tears text first appears")]
        CityOfTears,
        [Description("Colosseum (Area)"), ToolTip("Splits when entering Colosseum text first appears")]
        Colosseum,
        [Description("Crystal Peak (Area)"), ToolTip("Splits when entering Crystal Peak text first appears")]
        CrystalPeak,
        [Description("Deepnest (Area)"), ToolTip("Splits when entering Deepnest text first appears")]
        Deepnest,
        [Description("Deepnest Spa (Area)"), ToolTip("Splits when entering the Deepnest Spa area with bench")]
        DeepnestSpa,
        [Description("Dirtmouth (Area)"), ToolTip("Splits when entering Dirtmouth text first appears")]
        Dirtmouth,
        [Description("Fog Canyon (Area)"), ToolTip("Splits when entering Fog Canyon text first appears")]
        FogCanyon,
        [Description("Forgotten Crossroads (Area)"), ToolTip("Splits when entering Forgotten Crossroads text first appears")]
        ForgottenCrossroads,
        [Description("Fungal Wastes (Area)"), ToolTip("Splits when entering Fungal Wastes text first appears")]
        FungalWastes,
        [Description("Godhome (Area)"), ToolTip("Splits when entering Godhome text first appears")]
        Godhome,
        [Description("Greenpath (Area)"), ToolTip("Splits when entering Greenpath text first appears")]
        Greenpath,
        [Description("Hive (Area)"), ToolTip("Splits when entering Hive text first appears")]
        Hive,
        [Description("Infected Crossroads (Area)"), ToolTip("Splits when entering Infected Crossroads text first appears")]
        InfectedCrossroads,
        [Description("Kingdom's Edge (Area)"), ToolTip("Splits when entering Kingdom's Edge text first appears")]
        KingdomsEdge,
        [Description("Queens Gardens (Area)"), ToolTip("Splits when entering Queen's Gardens text first appears")]
        QueensGardens,
        [Description("Resting Grounds (Area)"), ToolTip("Splits when entering Resting Grounds text first appears")]
        RestingGrounds,
        [Description("Royal Waterways (Area)"), ToolTip("Splits when entering Royal Waterways text first appears")]
        RoyalWaterways,
        [Description("Teachers Archive (Area)"), ToolTip("Splits when entering Teachers Archive for the first time")]
        TeachersArchive,
        [Description("White Palace (Area)"), ToolTip("Splits when entering White Palace text for the first time")]
        WhitePalace,
        [Description("King's Pass (Area)"), ToolTip("Splits when leaving King's pass")]
        KingsPass,

        [Description("Baldur Shell (Charm)"), ToolTip("Splits when obtaining the Baldur Shell charm")]
        BaldurShell,
        [Description("Dashmaster (Charm)"), ToolTip("Splits when obtaining the Dashmaster charm")]
        Dashmaster,
        [Description("Deep Focus (Charm)"), ToolTip("Splits when obtaining the Deep Focus charm")]
        DeepFocus,
        [Description("Defenders Crest (Charm)"), ToolTip("Splits when obtaining the Defenders Crest charm")]
        DefendersCrest,
        [Description("Dreamshield (Charm)"), ToolTip("Splits when obtaining the Dreamshield charm")]
        Dreamshield,
        [Description("Dream Wielder (Charm)"), ToolTip("Splits when obtaining the Dream Wielder charm")]
        DreamWielder,
        [Description("Flukenest (Charm)"), ToolTip("Splits when obtaining the Flukenest charm")]
        Flukenest,
        [Description("Fragile Greed (Charm)"), ToolTip("Splits when obtaining the Fragile Greed charm")]
        FragileGreed,
        [Description("Fragile Heart (Charm)"), ToolTip("Splits when obtaining the Fragile Heart charm")]
        FragileHeart,
        [Description("Fragile Strength (Charm)"), ToolTip("Splits when obtaining the Fragile Strength charm")]
        FragileStrength,
        [Description("Fury of the Fallen (Charm)"), ToolTip("Splits when obtaining the Fury of the Fallen charm")]
        FuryOfTheFallen,
        [Description("Gathering Swarm (Charm)"), ToolTip("Splits when obtaining the Gathering Swarm charm")]
        GatheringSwarm,
        [Description("Glowing Womb (Charm)"), ToolTip("Splits when obtaining the Glowing Womb charm")]
        GlowingWomb,
        [Description("Grimmchild (Charm)"), ToolTip("Splits when obtaining the Grimmchild charm")]
        Grimmchild,
        [Description("Grimmchild Lvl 2 (Charm)"), ToolTip("Splits when obtaining the Grimmchild Lvl 2 charm")]
        Grimmchild2,
        [Description("Grimmchild Lvl 3 (Charm)"), ToolTip("Splits when obtaining the Grimmchild Lvl 3 charm")]
        Grimmchild3,
        [Description("Grimmchild Lvl 4 (Charm)"), ToolTip("Splits when obtaining the Grimmchild Lvl 4 charm")]
        Grimmchild4,
        [Description("Grubberfly's Elegy (Charm)"), ToolTip("Splits when obtaining the Grubberfly's Elegy charm")]
        GrubberflysElegy,
        [Description("Grubsong (Charm)"), ToolTip("Splits when obtaining the Grubsong charm")]
        Grubsong,
        [Description("Heavy Blow (Charm)"), ToolTip("Splits when obtaining the Heavy Blow charm")]
        HeavyBlow,
        [Description("Hiveblood (Charm)"), ToolTip("Splits when obtaining the Hiveblood charm")]
        Hiveblood,
        [Description("Joni's Blessing (Charm)"), ToolTip("Splits when obtaining the Joni's Blessing charm")]
        JonisBlessing,
        [Description("Kingsoul (Charm)"), ToolTip("Splits when obtaining the completed Kingsoul charm")]
        Kingsoul,
        [Description("Lifeblood Core (Charm)"), ToolTip("Splits when obtaining the Lifeblood Core charm")]
        LifebloodCore,
        [Description("Lifeblood Heart (Charm)"), ToolTip("Splits when obtaining the Lifeblood Heart charm")]
        LifebloodHeart,
        [Description("Longnail (Charm)"), ToolTip("Splits when obtaining the Longnail charm")]
        Longnail,
        [Description("Mark Of Pride (Charm)"), ToolTip("Splits when obtaining the Mark Of Pride charm")]
        MarkOfPride,
        [Description("Nailmaster's Glory (Charm)"), ToolTip("Splits when obtaining the Nailmaster's Glory charm")]
        NailmastersGlory,
        [Description("Quick Focus (Charm)"), ToolTip("Splits when obtaining the Quick Focus charm")]
        QuickFocus,
        [Description("Quick Slash (Charm)"), ToolTip("Splits when obtaining the Quick Slash charm")]
        QuickSlash,
        [Description("Shaman Stone (Charm)"), ToolTip("Splits when obtaining Shaman Stone charm")]
        ShamanStone,
        [Description("Shape of Unn (Charm)"), ToolTip("Splits when obtaining Shape of Unn charm")]
        ShapeOfUnn,
        [Description("Sharp Shadow (Charm)"), ToolTip("Splits when obtaining Sharp Shadow charm")]
        SharpShadow,
        [Description("Soul Catcher (Charm)"), ToolTip("Splits when obtaining the Soul Catcher charm")]
        SoulCatcher,
        [Description("Soul Eater (Charm)"), ToolTip("Splits when obtaining the Soul Eater charm")]
        SoulEater,
        [Description("Spell Twister (Charm)"), ToolTip("Splits when obtaining the Spell Twister charm")]
        SpellTwister,
        [Description("Spore Shroom (Charm)"), ToolTip("Splits when obtaining the Spore Shroom charm")]
        SporeShroom,
        [Description("Sprintmaster (Charm)"), ToolTip("Splits when obtaining the Sprintmaster charm")]
        Sprintmaster,
        [Description("Stalwart Shell (Charm)"), ToolTip("Splits when obtaining Stalwart Shell charm")]
        StalwartShell,
        [Description("Steady Body (Charm)"), ToolTip("Splits when obtaining the Steady Body charm")]
        SteadyBody,
        [Description("Thorns Of Agony (Charm)"), ToolTip("Splits when obtaining Thorns of Agony charm")]
        ThornsOfAgony,
        [Description("Void Heart (Charm)"), ToolTip("Splits when changing the Kingsoul to the Void Heart charm")]
        VoidHeart,
        [Description("Wayward Compass (Charm)"), ToolTip("Splits when obtaining Wayward Compass charm")]
        WaywardCompass,
        [Description("Weaversong (Charm)"), ToolTip("Splits when obtaining the Weaversong charm")]
        Weaversong,
        [Description("Shrumal Ogres (Charm Notch)"), ToolTip("Splits when obtaining the charm notch after defeating the Shrumal Ogres")]
        NotchShrumalOgres,
        [Description("Fog Canyon (Charm Notch)"), ToolTip("Splits when obtaining the charm notch in Fog Canyon")]
        NotchFogCanyon,
        [Description("Salubra 1 (Charm Notch)"), ToolTip("Splits when obtaining the first charm notch from Salubra")]
        NotchSalubra1,
        [Description("Salubra 2 (Charm Notch)"), ToolTip("Splits when obtaining the second charm notch from Salubra")]
        NotchSalubra2,
        [Description("Salubra 3 (Charm Notch)"), ToolTip("Splits when obtaining the third charm notch from Salubra")]
        NotchSalubra3,
        [Description("Salubra 4 (Charm Notch)"), ToolTip("Splits when obtaining the fourth charm notch from Salubra")]
        NotchSalubra4,

        [Description("Relic Dealer Lemm (NPC)"), ToolTip("Splits when talking to Lemm for the first time")]
        Lemm1,
        [Description("Relic Dealer Lemm Shop (NPC)"), ToolTip("Splits when talking to Lemm in the shop for the first time")]
        Lemm2,
        [Description("Elderbug Flower Quest (NPC)"), ToolTip("Splits when giving the flower to the Elderbug")]
        ElderbugFlower,
        [Description("Bretta Rescued (NPC)"), ToolTip("Splits when saving Bretta")]
        BrettaRescued,
        [Description("Brumm Flame (NPC)"), ToolTip("Splits when collecting Brumm's flame in Deepnest")]
        BrummFlame,
        [Description("Little Fool (NPC)"), ToolTip("Splits when talking to the Little Fool for the first time")]
        LittleFool,

        [Description("Grimm Flame 1 (Flame)"), ToolTip("Splits after obtaining the first flame.")]
        Flame1,
        [Description("Grimm Flame 2 (Flame)"), ToolTip("Splits after obtaining the second flame.")]
        Flame2,
        [Description("Grimm Flame 3 (Flame)"), ToolTip("Splits after obtaining the third flame.")]
        Flame3,

        [Description("Pale Ore 1 (Ore)"), ToolTip("Splits after obtaining the first pale ore.")]
        Ore1,
        [Description("Pale Ore 2 (Ore)"), ToolTip("Splits after obtaining the second pale ore.")]
        Ore2,
        [Description("Pale Ore 3 (Ore)"), ToolTip("Splits after obtaining the third pale ore.")]
        Ore3,
        [Description("Pale Ore 4 (Ore)"), ToolTip("Splits after obtaining the fourth pale ore.")]
        Ore4,
        [Description("Pale Ore 5 (Ore)"), ToolTip("Splits after obtaining the fifth pale ore.")]
        Ore5,
        [Description("Pale Ore 6 (Ore)"), ToolTip("Splits after obtaining the sixth pale ore.")]
        Ore6,

        [Description("Rescued Grub 1 (Grub)"), ToolTip("Splits when rescuing grub #1")]
        Grub1,
        [Description("Rescued Grub 2 (Grub)"), ToolTip("Splits when rescuing grub #2")]
        Grub2,
        [Description("Rescued Grub 3 (Grub)"), ToolTip("Splits when rescuing grub #3")]
        Grub3,
        [Description("Rescued Grub 4 (Grub)"), ToolTip("Splits when rescuing grub #4")]
        Grub4,
        [Description("Rescued Grub 5 (Grub)"), ToolTip("Splits when rescuing grub #5")]
        Grub5,
        [Description("Rescued Grub 6 (Grub)"), ToolTip("Splits when rescuing grub #6")]
        Grub6,
        [Description("Rescued Grub 7 (Grub)"), ToolTip("Splits when rescuing grub #7")]
        Grub7,
        [Description("Rescued Grub 8 (Grub)"), ToolTip("Splits when rescuing grub #8")]
        Grub8,
        [Description("Rescued Grub 9 (Grub)"), ToolTip("Splits when rescuing grub #9")]
        Grub9,
        [Description("Rescued Grub 10 (Grub)"), ToolTip("Splits when rescuing grub #10")]
        Grub10,
        [Description("Rescued Grub 11 (Grub)"), ToolTip("Splits when rescuing grub #11")]
        Grub11,
        [Description("Rescued Grub 12 (Grub)"), ToolTip("Splits when rescuing grub #12")]
        Grub12,
        [Description("Rescued Grub 13 (Grub)"), ToolTip("Splits when rescuing grub #13")]
        Grub13,
        [Description("Rescued Grub 14 (Grub)"), ToolTip("Splits when rescuing grub #14")]
        Grub14,
        [Description("Rescued Grub 15 (Grub)"), ToolTip("Splits when rescuing grub #15")]
        Grub15,
        [Description("Rescued Grub 16 (Grub)"), ToolTip("Splits when rescuing grub #16")]
        Grub16,
        [Description("Rescued Grub 17 (Grub)"), ToolTip("Splits when rescuing grub #17")]
        Grub17,
        [Description("Rescued Grub 18 (Grub)"), ToolTip("Splits when rescuing grub #18")]
        Grub18,
        [Description("Rescued Grub 19 (Grub)"), ToolTip("Splits when rescuing grub #19")]
        Grub19,
        [Description("Rescued Grub 20 (Grub)"), ToolTip("Splits when rescuing grub #20")]
        Grub20,
        [Description("Rescued Grub 21 (Grub)"), ToolTip("Splits when rescuing grub #21")]
        Grub21,
        [Description("Rescued Grub 22 (Grub)"), ToolTip("Splits when rescuing grub #22")]
        Grub22,
        [Description("Rescued Grub 23 (Grub)"), ToolTip("Splits when rescuing grub #23")]
        Grub23,
        [Description("Rescued Grub 24 (Grub)"), ToolTip("Splits when rescuing grub #24")]
        Grub24,
        [Description("Rescued Grub 25 (Grub)"), ToolTip("Splits when rescuing grub #25")]
        Grub25,
        [Description("Rescued Grub 26 (Grub)"), ToolTip("Splits when rescuing grub #26")]
        Grub26,
        [Description("Rescued Grub 27 (Grub)"), ToolTip("Splits when rescuing grub #27")]
        Grub27,
        [Description("Rescued Grub 28 (Grub)"), ToolTip("Splits when rescuing grub #28")]
        Grub28,
        [Description("Rescued Grub 29 (Grub)"), ToolTip("Splits when rescuing grub #29")]
        Grub29,
        [Description("Rescued Grub 30 (Grub)"), ToolTip("Splits when rescuing grub #30")]
        Grub30,
        [Description("Rescued Grub 31 (Grub)"), ToolTip("Splits when rescuing grub #31")]
        Grub31,
        [Description("Rescued Grub 32 (Grub)"), ToolTip("Splits when rescuing grub #32")]
        Grub32,
        [Description("Rescued Grub 33 (Grub)"), ToolTip("Splits when rescuing grub #33")]
        Grub33,
        [Description("Rescued Grub 34 (Grub)"), ToolTip("Splits when rescuing grub #34")]
        Grub34,
        [Description("Rescued Grub 35 (Grub)"), ToolTip("Splits when rescuing grub #35")]
        Grub35,
        [Description("Rescued Grub 36 (Grub)"), ToolTip("Splits when rescuing grub #36")]
        Grub36,
        [Description("Rescued Grub 37 (Grub)"), ToolTip("Splits when rescuing grub #37")]
        Grub37,
        [Description("Rescued Grub 38 (Grub)"), ToolTip("Splits when rescuing grub #38")]
        Grub38,
        [Description("Rescued Grub 39 (Grub)"), ToolTip("Splits when rescuing grub #39")]
        Grub39,
        [Description("Rescued Grub 40 (Grub)"), ToolTip("Splits when rescuing grub #40")]
        Grub40,
        [Description("Rescued Grub 41 (Grub)"), ToolTip("Splits when rescuing grub #41")]
        Grub41,
        [Description("Rescued Grub 42 (Grub)"), ToolTip("Splits when rescuing grub #42")]
        Grub42,
        [Description("Rescued Grub 43 (Grub)"), ToolTip("Splits when rescuing grub #43")]
        Grub43,
        [Description("Rescued Grub 44 (Grub)"), ToolTip("Splits when rescuing grub #44")]
        Grub44,
        [Description("Rescued Grub 45 (Grub)"), ToolTip("Splits when rescuing grub #45")]
        Grub45,
        [Description("Rescued Grub 46 (Grub)"), ToolTip("Splits when rescuing grub #46")]
        Grub46,

        [Description("Whispering Root (Ancestral Mound)"), ToolTip("Splits upon completing the whispering root in the Ancestral Mound")]
        TreeMound,
        [Description("Whispering Root (City of Tears)"), ToolTip("Splits upon completing the whispering root in the City of Tears")]
        TreeCity,
        [Description("Whispering Root (Crystal Peak)"), ToolTip("Splits upon completing the whispering root in Crystal Peak")]
        TreePeak,
        [Description("Whispering Root (Deepnest)"), ToolTip("Splits upon completing the whispering root in Deepnest")]
        TreeDeepnest,
        [Description("Whispering Root (Forgotten Crossroads)"), ToolTip("Splits upon completing the whispering root in the Forgotten Crossroads")]
        TreeCrossroads,
        [Description("Whispering Root (Leg Eater)"), ToolTip("Splits upon completing the whispering root left from Leg Eater")]
        TreeLegEater,
        [Description("Whispering Root (Mantis Village)"), ToolTip("Splits upon completing the whispering root above the Mantis Village")]
        TreeMantisVillage,
        [Description("Whispering Root (Greenpath)"), ToolTip("Splits upon completing the whispering root in Greenpath")]
        TreeGreenpath,
        [Description("Whispering Root (Hive)"), ToolTip("Splits upon completing the whispering root in the Hive")]
        TreeHive,
        [Description("Whispering Root (Howling Cliifs)"), ToolTip("Splits upon completing the whispering root in the Howling Cliifs")]
        TreeCliffs,
        [Description("Whispering Root (Kingdom's Edge)"), ToolTip("Splits upon completing the whispering root in the Kingdom's Edge")]
        TreeKingdomsEdge,
        [Description("Whispering Root (Queen's Gardens)"), ToolTip("Splits upon completing the whispering root in the Queen's Gardens")]
        TreeQueensGardens,
        [Description("Whispering Root (Resting Grounds)"), ToolTip("Splits upon completing the whispering root in the Resting Grounds")]
        TreeRestingGrounds,
        [Description("Whispering Root (Royal Waterways)"), ToolTip("Splits upon completing the whispering root in the Royal Waterways")]
        TreeWaterways,
        [Description("Whispering Root (Spirits' Glade)"), ToolTip("Splits upon completing the whispering root in the Spirits' Glade")]
        TreeGlade
    }
    public class ToolTipAttribute : Attribute {
        public string ToolTip { get; set; }
        public ToolTipAttribute(string text) {
            ToolTip = text;
        }
    }
}