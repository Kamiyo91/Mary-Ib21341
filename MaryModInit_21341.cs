using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using Mary_Ib21341.BLL;
using UnityEngine;

namespace Mary_Ib21341
{
    public class MaryModInit_21341 : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(MaryModParameters.Path + "/ArtWork"));
            ArtUtil.GetCardArtWorks(new DirectoryInfo(MaryModParameters.Path + "/CardArtWork"));
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, MaryModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(MaryModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(MaryModParameters.PackageId);
            ArtUtil.MakeCustomBook(MaryModParameters.PackageId);
            ArtUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(MaryModParameters.PackageId);
            MaryModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(MaryModParameters.PackageId, MaryModParameters.Path);
            ModParameters.DefaultKeyword.Add(MaryModParameters.PackageId, "MaryModPage_21341");
            ModParameters.Assemblies.Add(Assembly.GetExecutingAssembly());
            OnInitSprites();
            OnInitKeypages();
            OnInitCards();
            OnInitDropBooks();
            OnInitPassives();
            OnInitRewards();
            OnInitStages();
            OnInitCredenza();
            OnInitCustomSkins();
        }

        private static void OnInitCustomSkins()
        {
            ModParameters.CustomBookSkinsOptions.Add(MaryModParameters.PackageId, new List<CustomBookSkinsOption>
            {
                new CustomBookSkinsOption("MarySkin_21341", 10000001, characterNameId: 1)
            });
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(new Dictionary<LorId, int>
                {
                    { new LorId(MaryModParameters.PackageId, 2), 0 }
                }
            ));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(MaryModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(1, CardOption.OnlyPage, new List<string> { "MaryPage_21341" },
                    new List<LorId> { new LorId(MaryModParameters.PackageId, 10000001) },
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false)),
                new CardOptions(2, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false)),
                new CardOptions(3, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false)),
                new CardOptions(4, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false)),
                new CardOptions(5, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false)),
                new CardOptions(6, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0, 0.5f, 1f), leftFrame: "MaryLeftPage_21341",
                        rightFrame: "MaryRightPage_21341", frontFrame: "MaryUIBattlePage_Cover_21341",
                        customIconColor: new Color(0, 0.5f, 1f), useHSVFilter: false))
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(MaryModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f))),
                new KeypageOptions(1,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f))),
                new KeypageOptions(4,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f)))
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(MaryModParameters.PackageId,
                new CredenzaOptions(CredenzaEnum.ModifiedCredenza, credenzaNameId: MaryModParameters.PackageId,
                    customIconSpriteId: MaryModParameters.PackageId, credenzaBooksId: new List<int>
                    {
                        10000001
                    }, bookDataColor: new CredenzaColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f))));
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(MaryModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "MaryDefault_21341")
            });
        }

        private static void OnInitStages()
        {
            ModParameters.StageOptions.Add(MaryModParameters.PackageId, new List<StageOptions>
            {
                new StageOptions(1,
                    stageColorOptions: new StageColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f)))
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(MaryModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(3,
                    cannotBeUsedWithPassives: new List<LorId>
                    {
                        new LorId(230008), new LorId(MaryModParameters.KamiyoModPackPackageId, 22),
                        new LorId(MaryModParameters.VortexTowerPackageId, 3),
                        new LorId(MaryModParameters.VortexTowerPackageId, 8)
                    }),
                new PassiveOptions(4, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f)),
                    forceAggroOptions: new ForceAggroOptions(forceAggroByTargetedPassive: new List<LorId>
                        { new LorId(MaryModParameters.PackageId, 5) })),
                new PassiveOptions(5, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f))),
                new PassiveOptions(6, false),
                new PassiveOptions(8, false, bannedEgoFloorCards: true, bannedEmotionCardSelection: true,
                    gainCoins: false)
            });
        }

        private static void OnInitDropBooks()
        {
            ModParameters.DropBookOptions.Add(MaryModParameters.PackageId, new List<DropBookOptions>
            {
                new DropBookOptions(1, new DropBookColorOptions(new Color(0, 0.5f, 1f), new Color(0, 0.5f, 1f)))
            });
        }
    }
}