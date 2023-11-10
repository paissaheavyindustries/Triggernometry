using System.Collections.Generic;

namespace Triggernometry
{
    internal static class Entity
    {
        /// <summary> Convert jobid to any job properties. <i>e.g.</i> jobs["1"]["role"], jobs["33"]["isTM"] </summary>
        public static Dictionary<string, Dictionary<string, string>> jobs = new Dictionary<string, Dictionary<string, string>>();

        /// <summary> Convert jobname in any language or abbrevations to jobid. <i>e.g.</i> jobNameToIdMap["PLD"] </summary>
        public static Dictionary<string, string> jobNameToIdMap = new Dictionary<string, string>();

        static Entity() 
        {   //     index role  CN1   CN2     EN3   JP1    CN         DE                EN               FR                  JP                KR    
            AddJob("-1", "", "", "", "", "", "", "", "", "", "", "");
            AddJob( "0", " ", "冒", "冒险", "ADV", "無", "冒险者",   "Abenteurer",     "Adventurer",    "Aventurier",       "冒険者",         "모험가");
            AddJob( "1", "T", "剑", "剑术", "GLA", "剣", "剑术师",   "Gladiator",      "Gladiator",     "Gladiateur",       "剣術士",         "검술사");
            AddJob( "2", "M", "格", "格斗", "PGL", "闘", "格斗家",   "Faustkämpfer",   "Pugilist",      "Pugiliste",        "格闘士",         "격투사");
            AddJob( "3", "T", "斧", "斧术", "MRD", "斧", "斧术师",   "Marodeur",       "Marauder",      "Maraudeur",        "斧術士",         "도끼술사");
            AddJob( "4", "M", "枪", "枪术", "LNC", "槍", "枪术师",   "Pikenier",       "Lancer",        "Maître d'hast",    "槍術士",         "창술사");
            AddJob( "5", "R", "弓", "弓术", "ARC", "弓", "弓箭手",   "Waldläufer",     "Archer",        "Archer",           "弓術士",         "궁술사");
            AddJob( "6", "H", "幻", "幻术", "CNJ", "幻", "幻术师",   "Druide",         "Conjurer",      "Élémentaliste",    "幻術士",         "환술사");
            AddJob( "7", "R", "咒", "咒术", "THM", "呪", "咒术师",   "Thaumaturg",     "Thaumaturge",   "Occultiste",       "呪術士",         "주술사");
            AddJob( "8", "C", "木", "刻木", "CRP", "木", "刻木匠",   "Zimmerer",       "Carpenter",     "Menuisier",        "木工師",         "목수");
            AddJob( "9", "C", "锻", "锻铁", "BSM", "鍛", "锻铁匠",   "Grobschmied",    "Blacksmith",    "Forgeron",         "鍛冶師",         "대장장이");
            AddJob("10", "C", "甲", "铸甲", "ARM", "甲", "铸甲匠",   "Plattner",       "Armorer",       "Armurier",         "甲冑師",         "갑주제작사");
            AddJob("11", "C", "雕", "雕金", "GSM", "彫", "雕金匠",   "Goldschmied",    "Goldsmith",     "Orfèvre",          "彫金師",         "보석공예가");
            AddJob("12", "C", "革", "制革", "LTW", "革", "制革匠",   "Gerber",         "Leatherworker", "Tanneur",          "革細工師",       "가죽공예가");
            AddJob("13", "C", "裁", "裁衣", "WVR", "裁", "裁衣匠",   "Weber",          "Weaver",        "Couturier",        "裁縫師",         "재봉사");
            AddJob("14", "C", "炼", "炼金", "ALC", "錬", "炼金术士", "Alchemist",      "Alchemist",     "Alchimiste",       "錬金術師",       "연금술사");
            AddJob("15", "C", "烹", "烹调", "CUL", "調", "烹调师",   "Gourmet",        "Culinarian",    "Cuisinier",        "調理師",         "요리사");
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
            AddJob("32", "T", "暗", "黑骑", "DRK", "暗", "暗黑骑士", "Dunkelritter",   "Dark Knight",  "Chevalier noir",    "暗黒騎士",       "암흑기사");
            AddJob("33", "H", "占", "占星", "AST", "占", "占星术士", "Astrologe",      "Astrologian",  "Astromancien",      "占星術士",       "점성술사");
            AddJob("34", "M", "武", "武士", "SAM", "侍", "武士",     "Samurai",        "Samurai",      "Samouraï",          "侍",             "사무라이");
            AddJob("35", "R", "赤", "赤魔", "RDM", "赤", "赤魔法师", "Rotmagier",      "Red Mage",     "Mage rouge",        "赤魔道士",       "적마도사");
            AddJob("36", "R", "青", "青魔", "BLU", "青", "青魔法师", "Blaumagier",     "Blue Mage",    "Mage bleu",         "青魔道士",       "청마도사");
            AddJob("37", "T", "绝", "绝枪", "GNB", "ガ", "绝枪战士", "Revolverheld",   "Gunbreaker",   "Pisto-sabreur",     "ガンブレイカー", "건브레이커");
            AddJob("38", "R", "舞", "舞者", "DNC", "踊", "舞者",     "Tänzer",         "Dancer",       "Danseur",           "踊り子",         "무도가");
            AddJob("39", "M", "钐", "钐镰", "RPR", "リ", "钐镰客",   "Schnitter",      "Reaper",       "Faucheur",          "リーパー",       "리퍼");
            AddJob("40", "H", "贤", "贤者", "SGE", "賢", "贤者",     "Weiser",         "Sage",         "Sage",              "賢者",           "현자");
            AddJob("41", "M", "金", "４１", "041", "金", "职业４１", "job_41",         "job_41",       "job_41",            "job_41",         "job_41");
            AddJob("42", "R", "生", "４２", "042", "生", "职业４２", "job_42",         "job_42",       "job_42",            "job_42",         "job_42");
            AddJob("43", " ", "丽", "４３", "043", "丽", "职业４３", "job_43",         "job_43",       "job_43",            "job_43",         "job_43");
            AddJob("44", " ", "水", "４４", "044", "水", "职业４４", "job_44",         "job_44",       "job_44",            "job_44",         "job_44");
        }   // use 《千字文》 as placeholders for new jobs to avoid repeated keys in jobNameToIdMap

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

            jobs[id] = new Dictionary<string, string>
            {
                {"role", roleString},
                {"jobid",  id},
                {"isT",   (role == "T") ? "1" : "0"},
                {"isH",   (role == "H") ? "1" : "0"},
                {"isTH", ((role == "T") || (role == "H")) ? "1" : "0"},
                {"isD",  ((role == "M") || (role == "R")) ? "1" : "0"},
                {"isM",   (role == "M") ? "1" : "0"},
                {"isR",   (role == "R") ? "1" : "0"},
                {"isTM", ((role == "T") || (role == "M")) ? "1" : "0"},
                {"isHR", ((role == "H") || (role == "R")) ? "1" : "0"},
                {"isC",   (role == "C") ? "1" : "0"},
                {"isG",   (role == "G") ? "1" : "0"},
                {"isCG", ((role == "C") || (role == "G")) ? "1" : "0"},
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