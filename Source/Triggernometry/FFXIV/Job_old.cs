using System;
using System.Collections.Generic;
using System.Globalization;

namespace Triggernometry
{
    [Obsolete("Use Triggernometry.FFXIV.Job")]
    public static class Entity
    {
        /// <summary> 
        /// Convert jobid to any job properties: <br />
        /// jobs[<paramref name="jobid"/>][<paramref name="prop"/>] => value <br /><br />
        /// <i>e.g.</i> <br />
        /// <c>jobs["1"]["role"]</c>, <c>jobs["33"]["isTM"]</c> 
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> jobs = new Dictionary<string, Dictionary<string, string>>();

        /// <summary> Convert jobname in any language or abbrevations to jobid. <br /><br />
        /// <i>e.g.</i> <br />
        /// <c>jobNameToIdMap["PLD"]</c> 
        /// </summary>
        public static Dictionary<string, string> jobNameToIdMap = new Dictionary<string, string>();

        static Entity()
        {
            InitializeJobs();
        }

        public enum RoleType
        { 
            None     = 0,
            Tank     = 8,
            Healer   = 16,
            DPS      = 24,
            Crafter  = 32,
            Gatherer = 48,
            MainRole = 56,

            // leave blank integers for possible future changes
            PureHealer    = Healer | 1,
            FlexHealer    = Healer | 2, // in case added back
            BarrierHealer = Healer | 3,
            StrengthMelee  = DPS | 1,
            DexterityMelee = DPS | 2,
            PhysicalRanged = DPS | 4,
            MagicalRanged  = DPS | 6,
        }

        private static void InitializeJobs() 
        {   //   index      subrole                CN1   CN2     EN3   JP1      CN           DE                 EN               FR                JP                KR    
            AddJob("-1", RoleType.None,           "",    "",    "",    "",   "",         "",               "",              "",                 "",               "");
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
            AddJob("43", RoleType.None,           "丽", "四三", "043", "丽", "职业四三", "job_43",         "job_43",        "job_43",           "job_43",         "job_43");
            AddJob("44", RoleType.None,           "水", "四四", "044", "水", "职业四四", "job_44",         "job_44",        "job_44",           "job_44",         "job_44");
        }

        private static void AddJob(string id, RoleType subrole, string jobCN1, string jobCN2, string jobEN3, string jobJP1,
            string jobCN, string jobDE, string jobEN, string jobFR, string jobJP, string jobKR)
        {
            RoleType role = subrole & RoleType.MainRole;
            bool isT = role == RoleType.Tank;
            bool isH = role == RoleType.Healer;
            bool isM = subrole == RoleType.StrengthMelee || subrole == RoleType.DexterityMelee;
            bool isR = subrole == RoleType.PhysicalRanged || subrole == RoleType.MagicalRanged;
            bool isC = role == RoleType.Crafter;
            bool isG = role == RoleType.Gatherer;
            jobs[id] = new Dictionary<string, string>
            {
                {"role", (subrole & RoleType.MainRole).ToString()},
                {"subrole", subrole.ToString()},
                {"roleid", ((int)subrole).ToString(CultureInfo.InvariantCulture)},
                {"jobid",  id},
                {"isT",  isT ? "1" : "0"},
                {"isH",  isH ? "1" : "0"},
                {"isTH", isT || isH ? "1" : "0"},
                {"isD",  isM || isR ? "1" : "0"},
                {"isM",  isM ? "1" : "0"},
                {"isR",  isR ? "1" : "0"},
                {"isTM", isT || isM ? "1" : "0"},
                {"isHR", isH || isR ? "1" : "0"},
                {"isC",  isC ? "1" : "0"},
                {"isG",  isG ? "1" : "0"},
                {"isCG", isC || isG ? "1" : "0"},
                {"jobCN1", jobCN1},
                {"jobCN2", jobCN2},
                {"job",    jobEN3},
                {"jobEN3", jobEN3},
                {"jobJP1", jobJP1},
                {"jobCN",  jobCN},
                {"jobDE",  jobDE},
                {"jobEN",  jobEN},
                {"jobFR",  jobFR},
                {"jobJP",  jobJP},
                {"jobKR",  jobKR},
            };

            jobNameToIdMap[id] = id;
            jobNameToIdMap[jobCN1.ToLower()] = id;
            jobNameToIdMap[jobCN2.ToLower()] = id;
            jobNameToIdMap[jobEN3.ToLower()] = id;
            jobNameToIdMap[jobJP1.ToLower()] = id;
            jobNameToIdMap[jobCN.ToLower()]  = id;
            jobNameToIdMap[jobDE.ToLower()]  = id;
            jobNameToIdMap[jobEN.ToLower()]  = id;
            jobNameToIdMap[jobFR.ToLower()]  = id;
            jobNameToIdMap[jobJP.ToLower()]  = id;
            jobNameToIdMap[jobKR.ToLower()]  = id;
        }
    }
}