using System.Collections.Generic;
using LOR_DiceSystem;
using Mary_Ib21341.BLL;
using UtilLoader21341.Models;

namespace Mary_Ib21341
{
    public static class UtilLoader21341
    {
        public static DefaultKeywordOption DefaultKeywordOption()
        {
            return new DefaultKeywordOption
                { PackageId = MaryModParameters.PackageId, Keyword = "MaryModPage_21341" };
        }

        public static List<RewardOptionRoot> RewardOptionRoot()
        {
            return new List<RewardOptionRoot>
            {
                new RewardOptionRoot
                {
                    Books = new List<ItemQuantityRoot>
                    {
                        new ItemQuantityRoot
                        {
                            LorId = new LorIdRoot { PackageId = MaryModParameters.PackageId, Id = 2 }, Quantity = 99
                        }
                    }
                }
            };
        }

        public static List<SkinOptionRoot> SkinOptionRoot()
        {
            return new List<SkinOptionRoot>
            {
                new SkinOptionRoot { PackageId = MaryModParameters.PackageId, SkinName = "MarySkin_21341" }
            };
        }

        public static List<CustomSkinOptionRoot> CustomSkinOptionRoot()
        {
            return new List<CustomSkinOptionRoot>
            {
                new CustomSkinOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, SkinName = "MarySkin_21341",
                    KeypageId = 10000001, CharacterNameId = 1
                }
            };
        }

        public static List<SpriteOptionRoot> SpriteOptionRoot()
        {
            return new List<SpriteOptionRoot>
            {
                new SpriteOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 10000001 },
                    SpritePK = "MaryDefault_21341"
                }
            };
        }

        public static List<KeypageOptionRoot> KeypageOptionRoot()
        {
            return new List<KeypageOptionRoot>
            {
                new KeypageOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, KeypageId = 10000001, EveryoneCanEquip = true,
                    BookCustomOptions = new BookCustomOptionRoot
                    {
                        NameTextId = 1
                    }
                },
                new KeypageOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, KeypageId = 1,
                    BookCustomOptions = new BookCustomOptionRoot
                    {
                        NameTextId = 1
                    }
                },
                new KeypageOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, KeypageId = 4,
                    BookCustomOptions = new BookCustomOptionRoot
                    {
                        NameTextId = 1
                    }
                }
            };
        }

        public static List<CategoryOptionRoot> CategoryOptionRoot()
        {
            return new List<CategoryOptionRoot>
            {
                new CategoryOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, AdditionalValue = "1",
                    CustomIconSpriteId = MaryModParameters.PackageId, CategoryNameId = MaryModParameters.PackageId,
                    CredenzaBooksId = new List<int>
                        { 10000001 },
                    CategoryBooksId = new List<int>
                        { 10000001 }
                }
            };
        }

        public static List<PassiveOptionRoot> PassiveOptionRoot()
        {
            return new List<PassiveOptionRoot>
            {
                new PassiveOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, PassiveId = 3,
                    CannotBeUsedWithPassives = new List<LorIdRoot>
                    {
                        new LorIdRoot { PackageId = MaryModParameters.KamiyoModPackPackageId, Id = 22 },
                        new LorIdRoot { PackageId = MaryModParameters.VortexTowerPackageId, Id = 3 },
                        new LorIdRoot { PackageId = MaryModParameters.VortexTowerPackageId, Id = 8 },
                        new LorIdRoot { Id = 230008 }
                    }
                },
                new PassiveOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, PassiveId = 8,
                    BannedEgoFloorCards = true,
                    BannedEmotionCardSelection = true,
                    GainCoins = false,
                    IsSupportPassive = true
                }
            };
        }

        public static List<CardOptionRoot> CardOptionRoot()
        {
            return new List<CardOptionRoot>
            {
                new CardOptionRoot
                {
                    PackageId = MaryModParameters.PackageId,
                    Ids = new List<int> { 1 },
                    Option = CardOption.OnlyPage, Keywords = new List<string> { "MaryPage_21341" },
                    BookId = new List<LorIdRoot>
                        { new LorIdRoot { PackageId = MaryModParameters.PackageId, Id = 10000001 } }
                },
                new CardOptionRoot
                {
                    PackageId = MaryModParameters.PackageId, Ids = new List<int> { 2 },
                    Option = CardOption.Personal
                }
            };
        }
    }
}