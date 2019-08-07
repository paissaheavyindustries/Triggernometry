using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class Condition
    {

        [XmlAttribute]
        public bool Enabled { get; set; }

        public enum ExpressionTypeEnum
        {
            String,
            Numeric
        }

        public enum ConditionTypeEnum
        {
            NumericEqual,
            NumericNotEqual,
            NumericGreater,
            NumericGreaterEqual,
            NumericLess,
            NumericLessEqual,
            StringEqualCase,
            StringEqualNocase,
            StringNotEqualCase,
            StringNotEqualNocase,
            RegexMatch,
            RegexNotMatch,
            ListContains,
            ListDoesNotContain
        }

        [XmlAttribute]
        public string ExpressionL;
        [XmlAttribute]
        public ExpressionTypeEnum ExpressionTypeL;
        [XmlAttribute]
        public string ExpressionR;
        [XmlAttribute]
        public ExpressionTypeEnum ExpressionTypeR;
        [XmlAttribute]
        public ConditionTypeEnum ConditionType;

        public Condition()
        {
            Enabled = true;
        }

        internal ConditionSingle ConvertToConditionSingle()
        {
            ConditionSingle cs = new ConditionSingle();
            cs.ConditionType = (ConditionSingle.CndTypeEnum)this.ConditionType;
            cs.ExpressionL = ExpressionL;
            cs.ExpressionTypeL = (ConditionSingle.ExprTypeEnum)ExpressionTypeL;
            cs.ExpressionR = ExpressionR;
            cs.ExpressionTypeR = (ConditionSingle.ExprTypeEnum)ExpressionTypeR;
            cs.Enabled = Enabled;
            return cs;
        }

    }

}
