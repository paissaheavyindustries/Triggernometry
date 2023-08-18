using System.Collections.Generic;

namespace Triggernometry
{
    internal static class Entity
    {
        public static Dictionary<string, Dictionary<string, object>> jobs = new Dictionary<string, Dictionary<string, object>>();

        public static Dictionary<string, string> jobEN3ToIdMap = new Dictionary<string, string>();

        static Entity()
        {   //     index role  CN1   CN2     EN3   JP1    CN         DE                EN               FR                  JP                KR    
            AddJob( "0", " ", "无", "无职", "NON", "無", "无职业",   "Kein",           "None",          "Non",              "無職",           "없음");
            AddJob( "1", "T", "剑", "剑术", "GLA", "剣", "剑术师",   "Gladiator",      "Gladiator",     "Gladiateur",       "剣術士",         "검술사");
            AddJob( "2", "M", "斗", "格斗", "PGL", "闘", "格斗家",   "Faustkämpfer",   "Pugilist",      "Pugiliste",        "格闘士",         "격투사");
            AddJob( "3", "T", "斧", "斧术", "MRD", "斧", "斧术师",   "Marodeur",       "Marauder",      "Maraudeur",        "斧術士",         "도끼술사");
            AddJob( "4", "M", "枪", "枪术", "LNC", "槍", "枪术师",   "Pikenier",       "Lancer",        "Maître d'hast",    "槍術士",         "창술사");
            AddJob( "5", "R", "弓", "弓术", "ARC", "弓", "弓箭手",   "Waldläufer",     "Archer",        "Archer",           "弓術士",         "궁술사");
            AddJob( "6", "H", "幻", "幻术", "CNJ", "幻", "幻术师",   "Druide",         "Conjurer",      "Élémentaliste",    "幻術士",         "환술사");
            AddJob( "7", "R", "咒", "咒术", "THM", "呪", "咒术师",   "Thaumaturg",     "Thaumaturge",   "Occultiste",       "呪術士",         "주술사");
            AddJob( "8", "C", "木", "刻木", "CRP", "木", "刻木匠",   "Zimmerer",       "Carpenter",     "Menuisier",        "木工師",         "목수");
            AddJob( "9", "C", "铁", "锻铁", "BSM", "鍛", "锻铁匠",   "Grobschmied",    "Blacksmith",    "Forgeron",         "鍛冶師",         "대장장이");
            AddJob("10", "C", "甲", "铸甲", "ARM", "甲", "铸甲匠",   "Plattner",       "Armorer",       "Armurier",         "甲冑師",         "갑주제작사");
            AddJob("11", "C", "雕", "雕金", "GSM", "彫", "雕金匠",   "Goldschmied",    "Goldsmith",     "Orfèvre",          "彫金師",         "보석공예가");
            AddJob("12", "C", "革", "制革", "LTW", "革", "制革匠",   "Gerber",         "Leatherworker", "Tanneur",          "革細工師",       "가죽공예가");
            AddJob("13", "C", "衣", "裁衣", "WVR", "裁", "裁衣匠",   "Weber",          "Weaver",        "Couturier",        "裁縫師",         "재봉사");
            AddJob("14", "C", "炼", "炼金", "ALC", "錬", "炼金术士", "Alchemist",      "Alchemist",     "Alchimiste",       "錬金術師",       "연금술사");
            AddJob("15", "C", "厨", "烹调", "CUL", "調", "烹调师",   "Gourmet",        "Culinarian",    "Cuisinier",        "調理師",         "요리사");
            AddJob("16", "G", "矿", "采矿", "MIN", "鉱", "采矿工",   "Minenarbeiter",  "Miner",         "Mineur",           "採掘師",         "광부");
            AddJob("17", "G", "园", "园艺", "BTN", "園", "园艺工",   "Gärtner",        "Botanist",      "Botaniste",        "園芸師",         "원예가");
            AddJob("18", "G", "鱼", "捕鱼", "FSH", "漁", "捕鱼人",   "Fischer",        "Fisher",        "Pêcheur",          "漁師",           "어부");
            AddJob("19", "T", "骑", "骑士", "PLD", "ナ", "骑士",     "Paladin",        "Paladin",       "Paladin",          "ナイト",         "나이트");
            AddJob("20", "M", "僧", "武僧", "MNK", "モ", "武僧",     "Mönch",          "Monk",          "Moine",            "モンク",         "몽크");
            AddJob("21", "T", "战", "战士", "WAR", "戦", "战士",     "Krieger",        "Warrior",       "Guerrier",         "戦士",           "전사");
            AddJob("22", "M", "龙", "龙骑", "DRG", "竜", "龙骑士",   "Dragoon",        "Dragoon",       "Chevalier dragon", "竜騎士",         "용기사");
            AddJob("23", "R", "诗", "诗人", "BRD", "詩", "吟游诗人", "Barde",          "Bard",          "Barde",            "吟遊詩人",       "음유시인");
            AddJob("24", "H", "白", "白魔", "WHM", "白", "白魔法师", "Weißmagier",     "White Mage",    "Mage blanc",       "白魔道士",       "백마도사");
            AddJob("25", "R", "黑", "黑魔", "BLM", "黒", "黑魔法师", "Schwarzmagier",  "Black Mage",    "Mage noir",        "黒魔道士",       "흑마도사");
            AddJob("26", "R", "秘", "秘术", "ACN", "巴", "秘术师",   "Hermetiker",     "Arcanist",      "Arcaniste",        "巴術士",         "비술사");
            AddJob("27", "R", "召", "召唤", "SMN", "召", "召唤师",   "Beschwörer",     "Summoner",      "Invocateur",       "召喚士",         "소환사");
            AddJob("28", "H", "学", "学者", "SCH", "学", "学者",     "Gelehrter",      "Scholar",       "Érudit",           "学者",           "학자");
            AddJob("29", "M", "双", "双剑", "ROG", "双", "双剑师",   "Schurke",        "Rogue",         "Surineur",         "双剣士",         "쌍검사");
            AddJob("30", "M", "忍", "忍者", "NIN", "忍", "忍者",     "Ninja",          "Ninja",        "Ninja",             "忍者",           "닌자");
            AddJob("31", "R", "机", "机工", "MCH", "機", "机工士",   "Maschinist",     "Machinist",    "Machiniste",        "機工士",         "기공사");
            AddJob("32", "T", "暗", "暗黑", "DRK", "暗", "暗黑骑士", "Dunkelritter",   "Dark Knight",  "Chevalier noir",    "暗黒騎士",       "암흑기사");
            AddJob("33", "H", "占", "占星", "AST", "占", "占星术士", "Astrologe",      "Astrologian",  "Astromancien",      "占星術士",       "점성술사");
            AddJob("34", "M", "侍", "武士", "SAM", "侍", "武士",     "Samurai",        "Samurai",      "Samouraï",          "侍",             "사무라이");
            AddJob("35", "R", "赤", "赤魔", "RDM", "赤", "赤魔法师", "Rotmagier",      "Red Mage",     "Mage rouge",        "赤魔道士",       "적마도사");
            AddJob("36", "R", "青", "青魔", "BLU", "青", "青魔法师", "Blaumagier",     "Blue Mage",    "Mage bleu",         "青魔道士",       "청마도사");
            AddJob("37", "T", "枪", "绝枪", "GNB", "ガ", "绝枪战士", "Revolverheld",   "Gunbreaker",   "Pisto-sabreur",     "ガンブレイカー", "건브레이커");
            AddJob("38", "R", "舞", "舞者", "DNC", "踊", "舞者",     "Tänzer",         "Dancer",       "Danseur",           "踊り子",         "무도가");
            AddJob("39", "M", "镰", "钐镰", "RPR", "リ", "钐镰客",   "Schnitter",      "Reaper",       "Faucheur",          "リーパー",       "리퍼");
            AddJob("40", "H", "贤", "贤者", "SGE", "賢", "贤者",     "Weiser",         "Sage",         "Sage",              "賢者",           "현자");
            AddJob("41", " ", "未", "未知", "???", "？", "未知职业", "Unbekannt",      "Unknown",      "Inconnu",           "？",             "？");
            AddJob("42", " ", "未", "未知", "???", "？", "未知职业", "Unbekannt",      "Unknown",      "Inconnu",           "？",             "？");
        }

        private static void AddJob(string id, string role, string jobCN1, string jobCN2, string jobEN3, string jobJP1,
            string jobCN, string jobDE, string jobEN, string jobFR, string jobJP, string jobKR)
        {
            string roleString;
            switch (role)
            {
                case "T":
                    roleString = "Tank";
                    break;
                case "H":
                    roleString = "Healer";
                    break;
                case "M":
                case "R":
                    roleString = "DPS";
                    break;
                case "C":
                    roleString = "Crafter";
                    break;
                case "G":
                    roleString = "Gatherer";
                    break;
                default:
                    roleString = "";
                    break;
            }

            jobs[id] = new Dictionary<string, object>
            {
                {"role", roleString},
                {"isT",   (role == "T") ? "1" : "0"},
                {"isH",   (role == "H") ? "1" : "0"},
                {"isTH", ((role == "T") || (role == "H")) ? "1" : "0"},
                {"isD",  ((role == "M") || (role == "R")) ? "1" : "0"},
                {"isM",   (role == "M") ? "1" : "0"},
                {"isR",   (role == "R") ? "1" : "0"},
                {"isC",   (role == "C") ? "1" : "0"},
                {"isG",   (role == "G") ? "1" : "0"},
                {"isCG", ((role == "C") || (role == "G")) ? "1" : "0"},
                {"jobCN1", jobCN1},
                {"jobCN2", jobCN2},
                {"jobEN3", jobEN3},
                {"jobJP1", jobJP1},
                {"jobCN",  jobCN},
                {"jobDE",  jobDE},
                {"jobEN",  jobEN},
                {"jobFR",  jobFR},
                {"jobJP",  jobJP},
                {"jobKR",  jobKR},
            };

            jobEN3ToIdMap[jobEN3] = id;
        }
    }
}

/*
public Dictionary<string, string[]> XIVJobNames = new Dictionary<string, string[]>
        {
            { "cn",  new string[] { "0", "剑术师", "格斗家", "斧术师", "枪术师", "弓箭手", "幻术师", "咒术师", "刻木匠", "锻铁匠", "铸甲匠", "雕金匠", "制革匠", "裁衣匠", "炼金术士", "烹调师", "采矿工", "园艺工", "捕鱼人", "骑士", "武僧", "战士", "龙骑士", "吟游诗人", "白魔法师", "青魔法师", "秘术师", "召唤师", "学者", "双剑师", "忍者", "机工士", "暗黑骑士", "占星术士", "武士", "赤魔法师", "青魔法师", "绝枪战士", "舞者", "钐镰客", "贤者" } },
            { "de",  new string[] { "0", "Gladiator", "Faustkämpfer", "Marodeur", "Pikenier", "Waldläufer", "Druide", "Thaumaturg", "Zimmerer", "Grobschmied", "Plattner", "Goldschmied", "Gerber", "Weber", "Alchemist", "Gourmet", "Minenarbeiter", "Gärtner", "Fischer", "Paladin", "Mönch", "Krieger", "Dragoon", "Barde", "Weißmagier", "Blaumagier", "Hermetiker", "Beschwörer", "Gelehrter", "Schurke", "Ninja", "Maschinist", "Dunkelritter", "Astrologe", "Samurai", "Rotmagier", "Blaumagier", "Revolverklinge", "Tänzer", "Schnitter", "Weiser" } },
            { "en",  new string[] { "0", "Gladiator", "Pugilist", "Marauder", "Lancer", "Archer", "Conjurer", "Thaumaturge", "Carpenter", "Blacksmith", "Armorer", "Goldsmith", "Leatherworker", "Weaver", "Alchemist", "Culinarian", "Miner", "Botanist", "Fisher", "Paladin", "Monk", "Warrior", "Dragoon", "Bard", "White Mage", "Black Mage", "Arcanist", "Summoner", "Scholar", "Rogue", "Ninja", "Machinist", "Dark Knight", "Astrologian", "Samurai", "Red Mage", "Blue Mage", "Gunbreaker", "Dancer", "Reaper", "Sage" } },
            { "fr",  new string[] { "0", "Gladiateur", "Pugiliste", "Maraudeur", "Maître d'hast", "Archer", "Élémentaliste", "Occultiste", "Menuisier", "Forgeron", "Armurier", "Orfèvre", "Tanneur", "Couturier", "Alchimiste", "Cuisinier", "Mineur", "Botaniste", "Pêcheur", "Paladin", "Moine", "Guerrier", "Chevalier dragon", "Barde", "Mage blanc", "Mage bleu", "Arcaniste", "Invocateur", "Érudit", "Surineur", "Ninja", "Machiniste", "Chevalier noir", "Astromancien", "Samouraï", "Mage rouge", "Mage bleu", "Pistosabreur", "Danseur", "Faucheur", "Sage" } },
            { "jp",  new string[] { "0", "剣術士", "格闘士", "斧術士", "槍術士", "弓術士", "幻術士", "呪術士", "木工師", "鍛冶師", "甲冑師", "彫金師", "革細工師", "裁縫師", "錬金術師", "調理師", "採掘師", "園芸師", "漁師", "ナイト", "モンク", "戦士", "竜騎士", "吟遊詩人", "白魔道士", "青魔道士", "巴術士", "召喚士", "学者", "双剣士", "忍者", "機工士", "暗黒騎士", "占星術師", "侍", "赤魔道士", "青魔道士", "ガンブレイカー", "踊り子", "リーパー", "賢者" } },
            { "kr",  new string[] { "0", "검술사", "격투사", "도끼술사", "창술사", "궁술사", "환술사", "주술사", "목수", "대장장이", "갑주제작사", "보석공예가", "가죽공예가", "재봉사", "연금술사", "요리사", "광부", "원예가", "어부", "나이트", "몽크", "전사", "용기사", "음유시인", "백마도사", "흑마도사", "비술사", "소환사", "학자", "쌍검사", "닌자", "기공사", "암흑기사", "점성술사", "사무라이", "적마도사", "청마도사", "건브레이커", "무도가", "리퍼", "현자" } },
            { "cn1", new string[] { "无", "剑", "斗", "斧", "枪", "弓", "幻", "咒", "木", "铁", "甲", "雕", "革", "衣", "炼", "厨", "矿", "园", "鱼", "骑", "僧", "战", "龙", "诗", "白", "黑", "秘", "召", "学", "双", "忍", "机", "暗", "占", "侍", "赤", "青", "绝", "舞", "镰", "贤", "？", "？", "？" } },
            { "cn2", new string[] { "无职", "剑术", "格斗", "斧术", "枪术", "弓术", "幻术", "咒术", "刻木", "锻铁", "铸甲", "雕金", "制革", "裁衣", "炼金", "烹调", "采矿", "园艺", "捕鱼", "骑士", "武僧", "战士", "龙骑", "诗人", "白魔", "黑魔", "秘术", "召唤", "学者", "双剑", "忍者", "机工", "黑骑", "占星", "武士", "赤魔", "青魔", "绝枪", "舞者", "钐镰", "贤者", "未知", "未知", "未知" } },
            { "en3", new string[] { "NON", "GLA", "PGL", "MRD", "LNC", "ARC", "CNJ", "THM", "CRP", "BSM", "ARM", "GSM", "LTW", "WVR", "ALC", "CUL", "MIN", "BTN", "FSH", "PLD", "MNK", "WAR", "DRG", "BRD", "WHM", "BLM", "ACN", "SMN", "SCH", "ROG", "NIN", "MCH", "DRK", "AST", "SAM", "RDM", "BLM", "GNB", "DNC", "RPR", "SGE", "???", "???", "???" } },
            { "jp1", new string[] { "無", "剣", "闘", "斧", "槍", "弓", "幻", "呪", "木", "鍛", "甲", "彫", "革", "裁", "錬", "調", "鉱", "園", "漁", "ナ", "モ", "戦", "竜", "詩", "白", "黒", "巴", "召", "学", "双", "忍", "機", "暗", "占", "侍", "赤", "青", "ガ", "踊", "リ", "賢", "？", "？", "？" } },
        };
*/