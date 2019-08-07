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

    public sealed class ConditionSingle : ConditionComponent
    {
        
        public enum ExprTypeEnum
        {
            String,
            Numeric
        }

        public enum CndTypeEnum
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

        private string _ExpressionL;
        private ExprTypeEnum _ExpressionTypeL;
        private string _ExpressionR;
        private ExprTypeEnum _ExpressionTypeR;
        private CndTypeEnum _ConditionType;


        [XmlAttribute]
        public string ExpressionL
        {
            get
            {
                return _ExpressionL;
            }
            set
            {
                if (value != _ExpressionL)
                {
                    _ExpressionL = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        [XmlAttribute]
        public ExprTypeEnum ExpressionTypeL
        {
            get
            {
                return _ExpressionTypeL;
            }
            set
            {
                if (value != _ExpressionTypeL)
                {
                    _ExpressionTypeL = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        [XmlAttribute]
        public string ExpressionR
        {
            get
            {
                return _ExpressionR;
            }
            set
            {
                if (value != _ExpressionR)
                {
                    _ExpressionR = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        [XmlAttribute]
        public ExprTypeEnum ExpressionTypeR
        {
            get
            {
                return _ExpressionTypeR;
            }
            set
            {
                if (value != _ExpressionTypeR)
                {
                    _ExpressionTypeR = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        [XmlAttribute]
        public CndTypeEnum ConditionType
        {
            get
            {
                return _ConditionType;
            }
            set
            {
                if (value != _ConditionType)
                {
                    _ConditionType = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        private string Capitalize(string str)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

        public override string ToString()
        {
            string desc = "";
            if (ConditionType == CndTypeEnum.ListContains || ConditionType == CndTypeEnum.ListDoesNotContain)
            {
                desc = I18n.Translate("internal/ConditionSingle/listvar", "List variable specified by");
                desc += " ";
                switch (ExpressionTypeL)
                {
                    case ExprTypeEnum.Numeric:
                        desc += I18n.Translate("internal/ConditionSingle/numericexpression", "numeric expression ({0})", ExpressionL);
                        break;
                    case ExprTypeEnum.String:
                        desc += I18n.Translate("internal/ConditionSingle/stringexpression", "string expression ({0})", ExpressionL);
                        break;
                }
                desc += " ";
                switch (ConditionType)
                {
                    case CndTypeEnum.ListContains:
                        desc += I18n.Translate("internal/ConditionSingle/listmustcontain", "must contain the result from");
                        break;
                    case CndTypeEnum.ListDoesNotContain:
                        desc += I18n.Translate("internal/ConditionSingle/listcantcontain", "must not contain the result from");
                        break;
                }
            }
            else
            {
                switch (ExpressionTypeL)
                {
                    case ExprTypeEnum.Numeric:
                        desc = Capitalize(I18n.Translate("internal/ConditionSingle/numericexpression", "numeric expression ({0})", ExpressionL));
                        break;
                    case ExprTypeEnum.String:
                        desc = Capitalize(I18n.Translate("internal/ConditionSingle/stringexpression", "string expression ({0})", ExpressionL));
                        break;
                }
                desc += " ";
                switch (ConditionType)
                {
                    case CndTypeEnum.NumericEqual:
                        desc += I18n.Translate("internal/ConditionSingle/numericequal", "must be numerically equal to");
                        break;
                    case CndTypeEnum.NumericNotEqual:
                        desc += I18n.Translate("internal/ConditionSingle/numericnotequal", "must not be numerically equal to");
                        break;
                    case CndTypeEnum.NumericGreater:
                        desc += I18n.Translate("internal/ConditionSingle/numericgreater", "must be numerically greater than");
                        break;
                    case CndTypeEnum.NumericGreaterEqual:
                        desc += I18n.Translate("internal/ConditionSingle/numericgreaterequal", "must be numerically greater or equal to");
                        break;
                    case CndTypeEnum.NumericLess:
                        desc += I18n.Translate("internal/ConditionSingle/numericless", "must be numerically less than");
                        break;
                    case CndTypeEnum.NumericLessEqual:
                        desc += I18n.Translate("internal/ConditionSingle/numericlessequal", "must be numerically less or equal to");
                        break;
                    case CndTypeEnum.StringEqualCase:
                        desc += I18n.Translate("internal/ConditionSingle/stringequalcase", "must pass case-sensitive string comparison to the string from");
                        break;
                    case CndTypeEnum.StringEqualNocase:
                        desc += I18n.Translate("internal/ConditionSingle/stringequalnocase", "must pass case-insensitive string comparison to the string from");
                        break;
                    case CndTypeEnum.StringNotEqualCase:
                        desc += I18n.Translate("internal/ConditionSingle/stringnotequalcase", "must not pass case-sensitive string comparison to the string from");
                        break;
                    case CndTypeEnum.StringNotEqualNocase:
                        desc += I18n.Translate("internal/ConditionSingle/stringnotequalnocase", "must not pass case-insensitive string comparison to the string from");
                        break;
                    case CndTypeEnum.RegexMatch:
                        desc += I18n.Translate("internal/ConditionSingle/regexmatch", "must match the regular expression from");
                        break;
                    case CndTypeEnum.RegexNotMatch:
                        desc += I18n.Translate("internal/ConditionSingle/noregexmatch", "must not match the regular expression from");
                        break;
                }
            }            
            switch (ExpressionTypeR)
            {
                case ExprTypeEnum.Numeric:
                    desc += " " + I18n.Translate("internal/ConditionSingle/numericexpression", "numeric expression ({0})", ExpressionR);
                    break;
                case ExprTypeEnum.String:
                    desc += " " + I18n.Translate("internal/ConditionSingle/stringexpression", "string expression ({0})", ExpressionR);
                    break;
            }            
            return Capitalize(desc);
        }

        internal override ConditionComponent Duplicate()
        {
            ConditionSingle cs = new ConditionSingle();
            cs.ConditionType = ConditionType;
            cs.Enabled = Enabled;
            cs.ExpressionL = ExpressionL;
            cs.ExpressionR = ExpressionR;
            cs.ExpressionTypeL = ExpressionTypeL;
            cs.ExpressionTypeR = ExpressionTypeR;            
            return cs;
        }

        internal override bool CheckCondition(Context ctx, Context.LoggerDelegate logger, object o)
        {
            try
            {
                if (Enabled == false)
                {
                    return false;
                }
                string lval = "", rval = "";
                switch (ExpressionTypeL)
                {
                    case ExprTypeEnum.Numeric:
                        
                        lval = I18n.ThingToString(ctx.EvaluateNumericExpression(logger, o, ExpressionL));
                        break;
                    case ExprTypeEnum.String:
                        lval = ctx.EvaluateStringExpression(logger, o, ExpressionL);
                        break;
                }
                switch (ExpressionTypeR)
                {
                    case ExprTypeEnum.Numeric:
                        rval = I18n.ThingToString(ctx.EvaluateNumericExpression(logger, o, ExpressionR));
                        break;
                    case ExprTypeEnum.String:
                        rval = ctx.EvaluateStringExpression(logger, o, ExpressionR);
                        break;
                }
                switch (ConditionType)
                {
                    case CndTypeEnum.NumericEqual:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return Math.Abs(ld - rd) < double.Epsilon ? true : false;
                        }
                    case CndTypeEnum.NumericNotEqual:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return Math.Abs(ld - rd) < double.Epsilon ? false : true;
                        }
                    case CndTypeEnum.NumericGreater:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return ld > rd;
                        }
                    case CndTypeEnum.NumericGreaterEqual:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return ld >= rd;
                        }
                    case CndTypeEnum.NumericLess:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return ld < rd;
                        }
                    case CndTypeEnum.NumericLessEqual:
                        {
                            double ld = double.Parse(lval, CultureInfo.InvariantCulture);
                            double rd = double.Parse(rval, CultureInfo.InvariantCulture);
                            return ld <= rd;
                        }
                    case CndTypeEnum.StringEqualCase:
                        {
                            return (String.Compare(lval, rval, false) == 0);
                        }
                    case CndTypeEnum.StringEqualNocase:
                        {
                            return (String.Compare(lval, rval, true) == 0);
                        }
                    case CndTypeEnum.StringNotEqualCase:
                        {
                            return (String.Compare(lval, rval, false) != 0);
                        }
                    case CndTypeEnum.StringNotEqualNocase:
                        {
                            return (String.Compare(lval, rval, true) != 0);
                        }
                    case CndTypeEnum.RegexMatch:
                        {
                            return Regex.IsMatch(lval, rval);
                        }
                    case CndTypeEnum.RegexNotMatch:
                        {
                            return (Regex.IsMatch(lval, rval) == false);
                        }
                    case CndTypeEnum.ListContains:
                        {
                            lock (ctx.plug.listvariables)
                            {
                                if (ctx.plug.listvariables.ContainsKey(lval) == true)
                                {
                                    if (ctx.plug.listvariables[lval].IndexOf(rval) > 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            return false;
                        }
                    case CndTypeEnum.ListDoesNotContain:
                        {
                            lock (ctx.plug.listvariables)
                            {
                                if (ctx.plug.listvariables.ContainsKey(lval) == true)
                                {
                                    if (ctx.plug.listvariables[lval].IndexOf(rval) > 0)
                                    {
                                        return false;
                                    }
                                }
                            }
                            return true;
                        }
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

    }

}
