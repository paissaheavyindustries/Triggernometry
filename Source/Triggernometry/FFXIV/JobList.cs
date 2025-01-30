using System.Collections.Generic;
using System.Linq;

namespace Triggernometry.FFXIV
{
    public enum JobEnum
    {
        None = -1,
        ADV = 0, GLA = 1, PGL = 2, MRD = 3, LNC = 4, ARC = 5, CNJ = 6, THM = 7,
        CRP = 8, BSM = 9, ARM = 10, GSM = 11, LTW = 12, WVR = 13, ALC = 14, CUL = 15,
        MIN = 16, BTN = 17, FSH = 18, PLD = 19, MNK = 20, WAR = 21, DRG = 22, BRD = 23,
        WHM = 24, BLM = 25, ACN = 26, SMN = 27, SCH = 28, ROG = 29, NIN = 30, MCH = 31,
        DRK = 32, AST = 33, SAM = 34, RDM = 35, BLU = 36, GNB = 37, DNC = 38, RPR = 39,
        SGE = 40, VPR = 41, PCT = 42, _43 = 43, _44 = 44,
    }

    public partial class Job
    {
        //"19, 1, 21, 3, 32, 37, 24, 6, 28, 33, 40, 20, 2, 22, 4, 30, 29, 34, 39, 23, 5, 31, 38, 25, 7, 27, 26, 35, 36";
        internal static List<Job> XivDefaultOrder;
        public static Job None => GetJob(JobEnum.None);
        public static Job ADV => GetJob(JobEnum.ADV);
        public static Job GLA => GetJob(JobEnum.GLA);
        public static Job PGL => GetJob(JobEnum.PGL);
        public static Job MRD => GetJob(JobEnum.MRD);
        public static Job LNC => GetJob(JobEnum.LNC);
        public static Job ARC => GetJob(JobEnum.ARC);
        public static Job CNJ => GetJob(JobEnum.CNJ);
        public static Job THM => GetJob(JobEnum.THM);
        public static Job CRP => GetJob(JobEnum.CRP);
        public static Job BSM => GetJob(JobEnum.BSM);
        public static Job ARM => GetJob(JobEnum.ARM);
        public static Job GSM => GetJob(JobEnum.GSM);
        public static Job LTW => GetJob(JobEnum.LTW);
        public static Job WVR => GetJob(JobEnum.WVR);
        public static Job ALC => GetJob(JobEnum.ALC);
        public static Job CUL => GetJob(JobEnum.CUL);
        public static Job MIN => GetJob(JobEnum.MIN);
        public static Job BTN => GetJob(JobEnum.BTN);
        public static Job FSH => GetJob(JobEnum.FSH);
        public static Job PLD => GetJob(JobEnum.PLD);
        public static Job MNK => GetJob(JobEnum.MNK);
        public static Job WAR => GetJob(JobEnum.WAR);
        public static Job DRG => GetJob(JobEnum.DRG);
        public static Job BRD => GetJob(JobEnum.BRD);
        public static Job WHM => GetJob(JobEnum.WHM);
        public static Job BLM => GetJob(JobEnum.BLM);
        public static Job ACN => GetJob(JobEnum.ACN);
        public static Job SMN => GetJob(JobEnum.SMN);
        public static Job SCH => GetJob(JobEnum.SCH);
        public static Job ROG => GetJob(JobEnum.ROG);
        public static Job NIN => GetJob(JobEnum.NIN);
        public static Job MCH => GetJob(JobEnum.MCH);
        public static Job DRK => GetJob(JobEnum.DRK);
        public static Job AST => GetJob(JobEnum.AST);
        public static Job SAM => GetJob(JobEnum.SAM);
        public static Job RDM => GetJob(JobEnum.RDM);
        public static Job BLU => GetJob(JobEnum.BLU);
        public static Job GNB => GetJob(JobEnum.GNB);
        public static Job DNC => GetJob(JobEnum.DNC);
        public static Job RPR => GetJob(JobEnum.RPR);
        public static Job SGE => GetJob(JobEnum.SGE);
        public static Job VPR => GetJob(JobEnum.VPR);
        public static Job PCT => GetJob(JobEnum.PCT);

        static Job()
        {
            _jobs = new List<Job>
            {
                new Job {
                    JobType = JobEnum.ADV,
                    SubRole = RoleType.None,
                    NameCN1 = "冒",
                    NameCN2 = "冒险",
                    NameJP1 = "無",
                    NameTCN1 = "冒",
                    NameTCN2 = "冒險",
                    NameCN = "冒险者",
                    NameDE = "Abenteurer",
                    NameEN = "Adventurer",
                    NameFR = "Aventurier",
                    NameJP = "冒険者",
                    NameKR = "모험가",
                    NameTCN = "冒險者",
                },
                #region Other Jobs
                new Job {
                    JobType = JobEnum.GLA,
                    SubRole = RoleType.Tank,
                    NameCN1 = "剑",
                    NameCN2 = "剑术",
                    NameJP1 = "剣",
                    NameTCN1 = "劍",
                    NameTCN2 = "劍術",
                    NameCN = "剑术师",
                    NameDE = "Gladiator",
                    NameEN = "Gladiator",
                    NameFR = "Gladiateur",
                    NameJP = "剣術士",
                    NameKR = "검술사",
                    NameTCN = "劍術師",
                },
                new Job {
                    JobType = JobEnum.PGL,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "格",
                    NameCN2 = "格斗",
                    NameJP1 = "闘",
                    NameTCN1 = "格",
                    NameTCN2 = "格斗",
                    NameCN = "格斗家",
                    NameDE = "Faustkämpfer",
                    NameEN = "Pugilist",
                    NameFR = "Pugiliste",
                    NameJP = "格闘士",
                    NameKR = "격투사",
                    NameTCN = "格斗家",
                },
                new Job {
                    JobType = JobEnum.MRD,
                    SubRole = RoleType.Tank,
                    NameCN1 = "斧",
                    NameCN2 = "斧术",
                    NameJP1 = "斧",
                    NameTCN1 = "斧",
                    NameTCN2 = "斧術",
                    NameCN = "斧术师",
                    NameDE = "Marodeur",
                    NameEN = "Marauder",
                    NameFR = "Maraudeur",
                    NameJP = "斧術士",
                    NameKR = "도끼술사",
                    NameTCN = "斧術師",
                },
                new Job {
                    JobType = JobEnum.LNC,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "枪",
                    NameCN2 = "枪术",
                    NameJP1 = "槍",
                    NameTCN1 = "槍",
                    NameTCN2 = "槍術",
                    NameCN = "枪术师",
                    NameDE = "Pikenier",
                    NameEN = "Lancer",
                    NameFR = "Maître d'hast",
                    NameJP = "槍術士",
                    NameKR = "창술사",
                    NameTCN = "槍術師",
                },
                new Job {
                    JobType = JobEnum.ARC,
                    SubRole = RoleType.PhysicalRanged,
                    NameCN1 = "弓",
                    NameCN2 = "弓术",
                    NameJP1 = "弓",
                    NameTCN1 = "弓",
                    NameTCN2 = "弓術",
                    NameCN = "弓箭手",
                    NameDE = "Waldläufer",
                    NameEN = "Archer",
                    NameFR = "Archer",
                    NameJP = "弓術士",
                    NameKR = "궁술사",
                    NameTCN = "弓箭手",
                },
                new Job {
                    JobType = JobEnum.CNJ,
                    SubRole = RoleType.PureHealer,
                    NameCN1 = "幻",
                    NameCN2 = "幻术",
                    NameJP1 = "幻",
                    NameTCN1 = "幻",
                    NameTCN2 = "幻術",
                    NameCN = "幻术师",
                    NameDE = "Druide",
                    NameEN = "Conjurer",
                    NameFR = "Élémentaliste",
                    NameJP = "幻術士",
                    NameKR = "환술사",
                    NameTCN = "幻術師",
                },
                new Job {
                    JobType = JobEnum.THM,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "咒",
                    NameCN2 = "咒术",
                    NameJP1 = "呪",
                    NameTCN1 = "咒",
                    NameTCN2 = "咒術",
                    NameCN = "咒术师",
                    NameDE = "Thaumaturg",
                    NameEN = "Thaumaturge",
                    NameFR = "Occultiste",
                    NameJP = "呪術士",
                    NameKR = "주술사",
                    NameTCN = "咒術師",
                },
                new Job {
                    JobType = JobEnum.CRP,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "木",
                    NameCN2 = "刻木",
                    NameJP1 = "木",
                    NameTCN1 = "木",
                    NameTCN2 = "刻木",
                    NameCN = "刻木匠",
                    NameDE = "Zimmerer",
                    NameEN = "Carpenter",
                    NameFR = "Menuisier",
                    NameJP = "木工師",
                    NameKR = "목수",
                    NameTCN = "刻木匠",
                },
                new Job {
                    JobType = JobEnum.BSM,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "锻",
                    NameCN2 = "锻铁",
                    NameJP1 = "鍛",
                    NameTCN1 = "鍛",
                    NameTCN2 = "鍛鐵",
                    NameCN = "锻铁匠",
                    NameDE = "Grobschmied",
                    NameEN = "Blacksmith",
                    NameFR = "Forgeron",
                    NameJP = "鍛冶師",
                    NameKR = "대장장이",
                    NameTCN = "鍛鐵匠",
                },
                new Job {
                    JobType = JobEnum.ARM,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "甲",
                    NameCN2 = "铸甲",
                    NameJP1 = "甲",
                    NameTCN1 = "甲",
                    NameTCN2 = "鑄甲",
                    NameCN = "铸甲匠",
                    NameDE = "Plattner",
                    NameEN = "Armorer",
                    NameFR = "Armurier",
                    NameJP = "甲冑師",
                    NameKR = "갑주제작사",
                    NameTCN = "鑄甲匠",
                },
                new Job {
                    JobType = JobEnum.GSM,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "雕",
                    NameCN2 = "雕金",
                    NameJP1 = "彫",
                    NameTCN1 = "雕",
                    NameTCN2 = "雕金",
                    NameCN = "雕金匠",
                    NameDE = "Goldschmied",
                    NameEN = "Goldsmith",
                    NameFR = "Orfèvre",
                    NameJP = "彫金師",
                    NameKR = "보석공예가",
                    NameTCN = "雕金匠",
                },
                new Job {
                    JobType = JobEnum.LTW,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "革",
                    NameCN2 = "制革",
                    NameJP1 = "革",
                    NameTCN1 = "革",
                    NameTCN2 = "制革",
                    NameCN = "制革匠",
                    NameDE = "Gerber",
                    NameEN = "Leatherworker",
                    NameFR = "Tanneur",
                    NameJP = "革細工師",
                    NameKR = "가죽공예가",
                    NameTCN = "制革匠",
                },
                new Job {
                    JobType = JobEnum.WVR,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "裁",
                    NameCN2 = "裁衣",
                    NameJP1 = "裁",
                    NameTCN1 = "裁",
                    NameTCN2 = "裁衣",
                    NameCN = "裁衣匠",
                    NameDE = "Weber",
                    NameEN = "Weaver",
                    NameFR = "Couturier",
                    NameJP = "裁縫師",
                    NameKR = "재봉사",
                    NameTCN = "裁衣匠",
                },
                new Job {
                    JobType = JobEnum.ALC,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "炼",
                    NameCN2 = "炼金",
                    NameJP1 = "錬",
                    NameTCN1 = "煉",
                    NameTCN2 = "煉金",
                    NameCN = "炼金术士",
                    NameDE = "Alchemist",
                    NameEN = "Alchemist",
                    NameFR = "Alchimiste",
                    NameJP = "錬金術師",
                    NameKR = "연금술사",
                    NameTCN = "煉金術士",
                },
                new Job {
                    JobType = JobEnum.CUL,
                    SubRole = RoleType.Crafter,
                    NameCN1 = "烹",
                    NameCN2 = "烹调",
                    NameJP1 = "調",
                    NameTCN1 = "烹",
                    NameTCN2 = "烹調",
                    NameCN = "烹调师",
                    NameDE = "Gourmet",
                    NameEN = "Culinarian",
                    NameFR = "Cuisinier",
                    NameJP = "調理師",
                    NameKR = "요리사",
                    NameTCN = "烹調師",
                },
                new Job {
                    JobType = JobEnum.MIN,
                    SubRole = RoleType.Gatherer,
                    NameCN1 = "矿",
                    NameCN2 = "采矿",
                    NameJP1 = "鉱",
                    NameTCN1 = "礦",
                    NameTCN2 = "采礦",
                    NameCN = "采矿工",
                    NameDE = "Minenarbeiter",
                    NameEN = "Miner",
                    NameFR = "Mineur",
                    NameJP = "採掘師",
                    NameKR = "광부",
                    NameTCN = "采礦工",
                },
                new Job {
                    JobType = JobEnum.BTN,
                    SubRole = RoleType.Gatherer,
                    NameCN1 = "园",
                    NameCN2 = "园艺",
                    NameJP1 = "園",
                    NameTCN1 = "園",
                    NameTCN2 = "園藝",
                    NameCN = "园艺工",
                    NameDE = "Gärtner",
                    NameEN = "Botanist",
                    NameFR = "Botaniste",
                    NameJP = "園芸師",
                    NameKR = "원예가",
                    NameTCN = "園藝工",
                },
                new Job {
                    JobType = JobEnum.FSH,
                    SubRole = RoleType.Gatherer,
                    NameCN1 = "鱼",
                    NameCN2 = "捕鱼",
                    NameJP1 = "漁",
                    NameTCN1 = "魚",
                    NameTCN2 = "捕魚",
                    NameCN = "捕鱼人",
                    NameDE = "Fischer",
                    NameEN = "Fisher",
                    NameFR = "Pêcheur",
                    NameJP = "漁師",
                    NameKR = "어부",
                    NameTCN = "捕魚人",
                },
                new Job {
                    JobType = JobEnum.PLD,
                    SubRole = RoleType.Tank,
                    NameCN1 = "骑",
                    NameCN2 = "骑士",
                    NameJP1 = "ナ",
                    NameTCN1 = "騎",
                    NameTCN2 = "騎士",
                    NameCN = "骑士",
                    NameDE = "Paladin",
                    NameEN = "Paladin",
                    NameFR = "Paladin",
                    NameJP = "ナイト",
                    NameKR = "나이트",
                    NameTCN = "騎士",
                },
                new Job {
                    JobType = JobEnum.MNK,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "僧",
                    NameCN2 = "武僧",
                    NameJP1 = "モ",
                    NameTCN1 = "僧",
                    NameTCN2 = "武僧",
                    NameCN = "武僧",
                    NameDE = "Mönch",
                    NameEN = "Monk",
                    NameFR = "Moine",
                    NameJP = "モンク",
                    NameKR = "몽크",
                    NameTCN = "武僧",
                },
                new Job {
                    JobType = JobEnum.WAR,
                    SubRole = RoleType.Tank,
                    NameCN1 = "战",
                    NameCN2 = "战士",
                    NameJP1 = "戦",
                    NameTCN1 = "戰",
                    NameTCN2 = "戰士",
                    NameCN = "战士",
                    NameDE = "Krieger",
                    NameEN = "Warrior",
                    NameFR = "Guerrier",
                    NameJP = "戦士",
                    NameKR = "전사",
                    NameTCN = "戰士",
                },
                new Job {
                    JobType = JobEnum.DRG,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "龙",
                    NameCN2 = "龙骑",
                    NameJP1 = "竜",
                    NameTCN1 = "龍",
                    NameTCN2 = "龍騎",
                    NameCN = "龙骑士",
                    NameDE = "Dragoon",
                    NameEN = "Dragoon",
                    NameFR = "Chevalier dragon",
                    NameJP = "竜騎士",
                    NameKR = "용기사",
                    NameTCN = "龍騎士",
                },
                new Job {
                    JobType = JobEnum.BRD,
                    SubRole = RoleType.PhysicalRanged,
                    NameCN1 = "诗",
                    NameCN2 = "诗人",
                    NameJP1 = "詩",
                    NameTCN1 = "詩",
                    NameTCN2 = "詩人",
                    NameCN = "吟游诗人",
                    NameDE = "Barde",
                    NameEN = "Bard",
                    NameFR = "Barde",
                    NameJP = "吟遊詩人",
                    NameKR = "음유시인",
                    NameTCN = "吟游詩人",
                },
                new Job {
                    JobType = JobEnum.WHM,
                    SubRole = RoleType.PureHealer,
                    NameCN1 = "白",
                    NameCN2 = "白魔",
                    NameJP1 = "白",
                    NameTCN1 = "白",
                    NameTCN2 = "白魔",
                    NameCN = "白魔法师",
                    NameDE = "Weißmagier",
                    NameEN = "White Mage",
                    NameFR = "Mage blanc",
                    NameJP = "白魔道士",
                    NameKR = "백마도사",
                    NameTCN = "白魔法師",
                },
                new Job {
                    JobType = JobEnum.BLM,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "黑",
                    NameCN2 = "黑魔",
                    NameJP1 = "黒",
                    NameTCN1 = "黒",
                    NameTCN2 = "黒魔",
                    NameCN = "黑魔法师",
                    NameDE = "Schwarzmagier",
                    NameEN = "Black Mage",
                    NameFR = "Mage noir",
                    NameJP = "黒魔道士",
                    NameKR = "흑마도사",
                    NameTCN = "黒魔法師",
                },
                new Job {
                    JobType = JobEnum.ACN,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "秘",
                    NameCN2 = "秘术",
                    NameJP1 = "巴",
                    NameTCN1 = "秘",
                    NameTCN2 = "秘術",
                    NameCN = "秘术师",
                    NameDE = "Hermetiker",
                    NameEN = "Arcanist",
                    NameFR = "Arcaniste",
                    NameJP = "巴術士",
                    NameKR = "비술사",
                    NameTCN = "秘術師",
                },
                new Job {
                    JobType = JobEnum.SMN,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "召",
                    NameCN2 = "召唤",
                    NameJP1 = "召",
                    NameTCN1 = "召",
                    NameTCN2 = "召喚",
                    NameCN = "召唤师",
                    NameDE = "Beschwörer",
                    NameEN = "Summoner",
                    NameFR = "Invocateur",
                    NameJP = "召喚士",
                    NameKR = "소환사",
                    NameTCN = "召喚師",
                },
                new Job {
                    JobType = JobEnum.SCH,
                    SubRole = RoleType.BarrierHealer,
                    NameCN1 = "学",
                    NameCN2 = "学者",
                    NameJP1 = "学",
                    NameTCN1 = "学",
                    NameTCN2 = "学者",
                    NameCN = "学者",
                    NameDE = "Gelehrter",
                    NameEN = "Scholar",
                    NameFR = "Érudit",
                    NameJP = "学者",
                    NameKR = "학자",
                    NameTCN = "学者",
                },
                new Job {
                    JobType = JobEnum.ROG,
                    SubRole = RoleType.DexterityMelee,
                    NameCN1 = "双",
                    NameCN2 = "双剑",
                    NameJP1 = "双",
                    NameTCN1 = "双",
                    NameTCN2 = "双劍",
                    NameCN = "双剑师",
                    NameDE = "Schurke",
                    NameEN = "Rogue",
                    NameFR = "Surineur",
                    NameJP = "双剣士",
                    NameKR = "쌍검사",
                    NameTCN = "双劍師",
                },
                new Job {
                    JobType = JobEnum.NIN,
                    SubRole = RoleType.DexterityMelee,
                    NameCN1 = "忍",
                    NameCN2 = "忍者",
                    NameJP1 = "忍",
                    NameTCN1 = "忍",
                    NameTCN2 = "忍者",
                    NameCN = "忍者",
                    NameDE = "Ninja",
                    NameEN = "Ninja",
                    NameFR = "Ninja",
                    NameJP = "忍者",
                    NameKR = "닌자",
                    NameTCN = "忍者",
                },
                new Job {
                    JobType = JobEnum.MCH,
                    SubRole = RoleType.PhysicalRanged,
                    NameCN1 = "机",
                    NameCN2 = "机工",
                    NameJP1 = "機",
                    NameTCN1 = "机",
                    NameTCN2 = "机工",
                    NameCN = "机工士",
                    NameDE = "Maschinist",
                    NameEN = "Machinist",
                    NameFR = "Machiniste",
                    NameJP = "機工士",
                    NameKR = "기공사",
                    NameTCN = "机工士",
                },
                new Job {
                    JobType = JobEnum.DRK,
                    SubRole = RoleType.Tank,
                    NameCN1 = "暗",
                    NameCN2 = "黑骑",
                    NameJP1 = "暗",
                    NameTCN1 = "暗",
                    NameTCN2 = "黒騎",
                    NameCN = "暗黑骑士",
                    NameDE = "Dunkelritter",
                    NameEN = "Dark Knight",
                    NameFR = "Chevalier noir",
                    NameJP = "暗黒騎士",
                    NameKR = "암흑기사",
                    NameTCN = "暗黒騎士",
                },
                new Job {
                    JobType = JobEnum.AST,
                    SubRole = RoleType.PureHealer,
                    NameCN1 = "占",
                    NameCN2 = "占星",
                    NameJP1 = "占",
                    NameTCN1 = "占",
                    NameTCN2 = "占星",
                    NameCN = "占星术士",
                    NameDE = "Astrologe",
                    NameEN = "Astrologian",
                    NameFR = "Astromancien",
                    NameJP = "占星術士",
                    NameKR = "점성술사",
                    NameTCN = "占星術士",
                },
                new Job {
                    JobType = JobEnum.SAM,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "武",
                    NameCN2 = "武士",
                    NameJP1 = "侍",
                    NameTCN1 = "武",
                    NameTCN2 = "武士",
                    NameCN = "武士",
                    NameDE = "Samurai",
                    NameEN = "Samurai",
                    NameFR = "Samouraï",
                    NameJP = "侍",
                    NameKR = "사무라이",
                    NameTCN = "武士",
                },
                new Job {
                    JobType = JobEnum.RDM,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "赤",
                    NameCN2 = "赤魔",
                    NameJP1 = "赤",
                    NameTCN1 = "赤",
                    NameTCN2 = "赤魔",
                    NameCN = "赤魔法师",
                    NameDE = "Rotmagier",
                    NameEN = "Red Mage",
                    NameFR = "Mage rouge",
                    NameJP = "赤魔道士",
                    NameKR = "적마도사",
                    NameTCN = "赤魔法師",
                },
                new Job {
                    JobType = JobEnum.BLU,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "青",
                    NameCN2 = "青魔",
                    NameJP1 = "青",
                    NameTCN1 = "青",
                    NameTCN2 = "青魔",
                    NameCN = "青魔法师",
                    NameDE = "Blaumagier",
                    NameEN = "Blue Mage",
                    NameFR = "Mage bleu",
                    NameJP = "青魔道士",
                    NameKR = "청마도사",
                    NameTCN = "青魔法師",
                },
                new Job {
                    JobType = JobEnum.GNB,
                    SubRole = RoleType.Tank,
                    NameCN1 = "绝",
                    NameCN2 = "绝枪",
                    NameJP1 = "ガ",
                    NameTCN1 = "絶",
                    NameTCN2 = "絶槍",
                    NameCN = "绝枪战士",
                    NameDE = "Revolverheld",
                    NameEN = "Gunbreaker",
                    NameFR = "Pisto-sabreur",
                    NameJP = "ガンブレイカー",
                    NameKR = "건브레이커",
                    NameTCN = "絶槍戰士",
                },
                new Job {
                    JobType = JobEnum.DNC,
                    SubRole = RoleType.PhysicalRanged,
                    NameCN1 = "舞",
                    NameCN2 = "舞者",
                    NameJP1 = "踊",
                    NameTCN1 = "舞",
                    NameTCN2 = "舞者",
                    NameCN = "舞者",
                    NameDE = "Tänzer",
                    NameEN = "Dancer",
                    NameFR = "Danseur",
                    NameJP = "踊り子",
                    NameKR = "무도가",
                    NameTCN = "舞者",
                },
                new Job {
                    JobType = JobEnum.RPR,
                    SubRole = RoleType.StrengthMelee,
                    NameCN1 = "钐",
                    NameCN2 = "钐镰",
                    NameJP1 = "リ",
                    NameTCN1 = "鎌",
                    NameTCN2 = "鎌刀",
                    NameCN = "钐镰客",
                    NameDE = "Schnitter",
                    NameEN = "Reaper",
                    NameFR = "Faucheur",
                    NameJP = "リーパー",
                    NameKR = "리퍼",
                    NameTCN = "钐鎌客",
                },
                new Job {
                    JobType = JobEnum.SGE,
                    SubRole = RoleType.BarrierHealer,
                    NameCN1 = "贤",
                    NameCN2 = "贤者",
                    NameJP1 = "賢",
                    NameTCN1 = "賢",
                    NameTCN2 = "賢者",
                    NameCN = "贤者",
                    NameDE = "Weiser",
                    NameEN = "Sage",
                    NameFR = "Sage",
                    NameJP = "賢者",
                    NameKR = "현자",
                    NameTCN = "賢者",
                },
                new Job {
                    JobType = JobEnum.VPR,
                    SubRole = RoleType.DexterityMelee,
                    NameCN1 = "蛇",
                    NameCN2 = "蝰蛇",
                    NameJP1 = "ヴ",
                    NameTCN1 = "蛇",
                    NameTCN2 = "蛇劍",
                    NameCN = "蝰蛇剑士",
                    NameDE = "Viper",
                    NameEN = "Viper",
                    NameFR = "Vipère",
                    NameJP = "ヴァイパー",
                    NameKR = "Viper",
                    NameTCN = "蝰蛇劍士",
                },
                new Job {
                    JobType = JobEnum.PCT,
                    SubRole = RoleType.MagicalRanged,
                    NameCN1 = "绘",
                    NameCN2 = "绘灵",
                    NameJP1 = "ピ",
                    NameTCN1 = "繪",
                    NameTCN2 = "繪靈",
                    NameCN = "绘灵法师",
                    NameDE = "Piktomantie",
                    NameEN = "Pictomancer",
                    NameFR = "Pictomancien",
                    NameJP = "ピクトマンサー",
                    NameKR = "Pictomancien",
                    NameTCN = "繪靈法師",
                },
                new Job {
                    JobType = JobEnum._43,
                    SubRole = RoleType.None,
                    NameCN1 = "丽",
                    NameCN2 = "四三",
                    NameJP1 = "丽",
                    NameTCN1 = "麗",
                    NameTCN2 = "四三",
                    NameCN = "job_43",
                    NameDE = "job_43",
                    NameEN = "job_43",
                    NameFR = "job_43",
                    NameJP = "job_43",
                    NameKR = "job_43",
                    NameTCN = "job_43",
                },
                new Job {
                    JobType = JobEnum._44,
                    SubRole = RoleType.None,
                    NameCN1 = "水",
                    NameCN2 = "四四",
                    NameJP1 = "水",
                    NameTCN1 = "水",
                    NameTCN2 = "四四",
                    NameCN = "job_44",
                    NameDE = "job_44",
                    NameEN = "job_44",
                    NameFR = "job_44",
                    NameJP = "job_44",
                    NameKR = "job_44",
                    NameTCN = "job_44",
                },
                #endregion Other Jobs
            };

            foreach (var job in _jobs)
            {
                foreach (var name in job._names())
                {
                    _jobByNames[name] = job;
                }
            }

            XivDefaultOrder = new List<Job>
            {
                PLD, GLA, WAR, MRD, DRK, GNB,
                WHM, CNJ, SCH, AST, SGE,
                MNK, PGL, DRG, LNC, NIN, ROG, SAM, RPR, VPR,
                BRD, ARC, MCH, DNC,
                BLM, THM, SMN, ACN, RDM, PCT, BLU,
                CRP, BSM, ARM, GSM, LTW, WVR, ALC, CUL,
                MIN, BTN, FSH, 
                ADV,
            };

            for (var i = 0; i < XivDefaultOrder.Count; i++)
            {
                XivDefaultOrder[i].DefaultOrder = i;
            }
        }

        IEnumerable<string> _names()
        {
            yield return JobID.ToString();
            yield return NameCN;    yield return NameDE;    yield return NameEN;    yield return NameFR;    
            yield return NameJP;    yield return NameKR;    yield return NameTCN;   yield return NameCN1;   
            yield return NameCN2;   yield return NameEN3;   yield return NameJP1;   yield return NameTCN1;  yield return NameTCN2;
        }
    }

}

/*       index      subrole                CN1   CN2     EN3   JP1      CN           DE                 EN               FR                JP                KR    
    AddJob("0",  RoleType.None,           "冒", "冒险", "ADV", "無", "冒险者",   "Abenteurer",     "Adventurer",    "Aventurier",       "冒険者",         "모험가");
    AddJob("1",  RoleType.Tank,           "剑", "剑术", "GLA", "剣", "剑术师",   "Gladiator",      "Gladiator",     "Gladiateur",       "剣術士",         "검술사");
    AddJob("2",  RoleType.StrengthMelee,  "格", "格斗", "PGL", "闘", "格斗家",   "Faustkämpfer",   "Pugilist",      "Pugiliste",        "格闘士",         "격투사");
    AddJob("3",  RoleType.Tank,           "斧", "斧术", "MRD", "斧", "斧术师",   "Marodeur",       "Marauder",      "Maraudeur",        "斧術士",         "도끼술사");
    AddJob("4",  RoleType.StrengthMelee,  "枪", "枪术", "LNC", "槍", "枪术师",   "Pikenier",       "Lancer",        "Maître d'hast",    "槍術士",         "창술사");
    AddJob("5",  RoleType.PhysicalRanged, "弓", "弓术", "ARC", "弓", "弓箭手",   "Waldläufer",     "Archer",        "Archer",           "弓術士",         "궁술사");
    AddJob("6",  RoleType.PureHealer,     "幻", "幻术", "CNJ", "幻", "幻术师",   "Druide",         "Conjurer",      "Élémentaliste",    "幻術士",         "환술사");
    AddJob("7",  RoleType.MagicalRanged,  "咒", "咒术", "THM", "呪", "咒术师",   "Thaumaturg",     "Thaumaturge",   "Occultiste",       "呪術士",         "주술사");
    AddJob("8",  RoleType.Crafter,        "木", "刻木", "CRP", "木", "刻木匠",   "Zimmerer",       "Carpenter",     "Menuisier",        "木工師",         "목수");
    AddJob("9",  RoleType.Crafter,        "锻", "锻铁", "BSM", "鍛", "锻铁匠",   "Grobschmied",    "Blacksmith",    "Forgeron",         "鍛冶師",         "대장장이");
    AddJob("10", RoleType.Crafter,        "甲", "铸甲", "ARM", "甲", "铸甲匠",   "Plattner",       "Armorer",       "Armurier",         "甲冑師",         "갑주제작사");
    AddJob("11", RoleType.Crafter,        "雕", "雕金", "GSM", "彫", "雕金匠",   "Goldschmied",    "Goldsmith",     "Orfèvre",          "彫金師",         "보석공예가");
    AddJob("12", RoleType.Crafter,        "革", "制革", "LTW", "革", "制革匠",   "Gerber",         "Leatherworker", "Tanneur",          "革細工師",       "가죽공예가");
    AddJob("13", RoleType.Crafter,        "裁", "裁衣", "WVR", "裁", "裁衣匠",   "Weber",          "Weaver",        "Couturier",        "裁縫師",         "재봉사");
    AddJob("14", RoleType.Crafter,        "炼", "炼金", "ALC", "錬", "炼金术士", "Alchemist",      "Alchemist",     "Alchimiste",       "錬金術師",       "연금술사");
    AddJob("15", RoleType.Crafter,        "烹", "烹调", "CUL", "調", "烹调师",   "Gourmet",        "Culinarian",    "Cuisinier",        "調理師",         "요리사");
    AddJob("16", RoleType.Gatherer,       "矿", "采矿", "MIN", "鉱", "采矿工",   "Minenarbeiter",  "Miner",         "Mineur",           "採掘師",         "광부");
    AddJob("17", RoleType.Gatherer,       "园", "园艺", "BTN", "園", "园艺工",   "Gärtner",        "Botanist",      "Botaniste",        "園芸師",         "원예가");
    AddJob("18", RoleType.Gatherer,       "鱼", "捕鱼", "FSH", "漁", "捕鱼人",   "Fischer",        "Fisher",        "Pêcheur",          "漁師",           "어부");
    AddJob("19", RoleType.Tank,           "骑", "骑士", "PLD", "ナ", "骑士",     "Paladin",        "Paladin",       "Paladin",          "ナイト",         "나이트");
    AddJob("20", RoleType.StrengthMelee,  "僧", "武僧", "MNK", "モ", "武僧",     "Mönch",          "Monk",          "Moine",            "モンク",         "몽크");
    AddJob("21", RoleType.Tank,           "战", "战士", "WAR", "戦", "战士",     "Krieger",        "Warrior",       "Guerrier",         "戦士",           "전사");
    AddJob("22", RoleType.StrengthMelee,  "龙", "龙骑", "DRG", "竜", "龙骑士",   "Dragoon",        "Dragoon",       "Chevalier dragon", "竜騎士",         "용기사");
    AddJob("23", RoleType.PhysicalRanged, "诗", "诗人", "BRD", "詩", "吟游诗人", "Barde",          "Bard",          "Barde",            "吟遊詩人",       "음유시인");
    AddJob("24", RoleType.PureHealer,     "白", "白魔", "WHM", "白", "白魔法师", "Weißmagier",     "White Mage",    "Mage blanc",       "白魔道士",       "백마도사");
    AddJob("25", RoleType.MagicalRanged,  "黑", "黑魔", "BLM", "黒", "黑魔法师", "Schwarzmagier",  "Black Mage",    "Mage noir",        "黒魔道士",       "흑마도사");            
    AddJob("26", RoleType.MagicalRanged,  "秘", "秘术", "ACN", "巴", "秘术师",   "Hermetiker",     "Arcanist",      "Arcaniste",        "巴術士",         "비술사");
    AddJob("27", RoleType.MagicalRanged,  "召", "召唤", "SMN", "召", "召唤师",   "Beschwörer",     "Summoner",      "Invocateur",       "召喚士",         "소환사");
    AddJob("28", RoleType.BarrierHealer,  "学", "学者", "SCH", "学", "学者",     "Gelehrter",      "Scholar",       "Érudit",           "学者",           "학자");
    AddJob("29", RoleType.DexterityMelee, "双", "双剑", "ROG", "双", "双剑师",   "Schurke",        "Rogue",         "Surineur",         "双剣士",         "쌍검사");
    AddJob("30", RoleType.DexterityMelee, "忍", "忍者", "NIN", "忍", "忍者",     "Ninja",          "Ninja",         "Ninja",            "忍者",           "닌자");
    AddJob("31", RoleType.PhysicalRanged, "机", "机工", "MCH", "機", "机工士",   "Maschinist",     "Machinist",     "Machiniste",       "機工士",         "기공사");
    AddJob("32", RoleType.Tank,           "暗", "黑骑", "DRK", "暗", "暗黑骑士", "Dunkelritter",   "Dark Knight",   "Chevalier noir",   "暗黒騎士",       "암흑기사");
    AddJob("33", RoleType.PureHealer,     "占", "占星", "AST", "占", "占星术士", "Astrologe",      "Astrologian",   "Astromancien",     "占星術士",       "점성술사");
    AddJob("34", RoleType.StrengthMelee,  "武", "武士", "SAM", "侍", "武士",     "Samurai",        "Samurai",       "Samouraï",         "侍",             "사무라이");
    AddJob("35", RoleType.MagicalRanged,  "赤", "赤魔", "RDM", "赤", "赤魔法师", "Rotmagier",      "Red Mage",      "Mage rouge",       "赤魔道士",       "적마도사");
    AddJob("36", RoleType.MagicalRanged,  "青", "青魔", "BLU", "青", "青魔法师", "Blaumagier",     "Blue Mage",     "Mage bleu",        "青魔道士",       "청마도사");
    AddJob("37", RoleType.Tank,           "绝", "绝枪", "GNB", "ガ", "绝枪战士", "Revolverheld",   "Gunbreaker",    "Pisto-sabreur",    "ガンブレイカー", "건브레이커");
    AddJob("38", RoleType.PhysicalRanged, "舞", "舞者", "DNC", "踊", "舞者",     "Tänzer",         "Dancer",        "Danseur",          "踊り子",         "무도가");
    AddJob("39", RoleType.StrengthMelee,  "钐", "钐镰", "RPR", "リ", "钐镰客",   "Schnitter",      "Reaper",        "Faucheur",         "リーパー",       "리퍼");
    AddJob("40", RoleType.BarrierHealer,  "贤", "贤者", "SGE", "賢", "贤者",     "Weiser",         "Sage",          "Sage",             "賢者",           "현자");
    AddJob("41", RoleType.DexterityMelee, "蛇", "蝰蛇", "VPR", "ヴ", "蝰蛇剑士", "Viper",          "Viper",         "Vipère",           "ヴァイパー",     "Viper");
    AddJob("42", RoleType.MagicalRanged,  "绘", "绘灵", "PCT", "ピ", "绘灵法师", "Piktomantie",    "Pictomancer",   "Pictomancien",     "ピクトマンサー", "Pictomancien");
*/