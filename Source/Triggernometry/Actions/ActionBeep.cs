using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Beep
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Audio)]
    [XmlRoot(ElementName = "Beep")]
    internal class ActionBeep : ActionBase
    {

        #region Properties

        /// <summary>
        /// Frequency of the beep
        /// </summary>
        [ActionAttribute(ordernum: 1, typehint: typeof(float))]
        private string _Frequency { get; set; } = "1046.5"; // freq(C6)
        [XmlAttribute]
        public string Frequency
        {
            get
            {
                if (_Frequency == "1046.5")
                {
                    return null;
                }
                return _Frequency;
            }
            set
            {
                _Frequency = value;
            }
        }

        /// <summary>
        /// Duration of the beep
        /// </summary>
        [ActionAttribute(ordernum: 2, typehint: typeof(int))]
        private string _Duration { get; set; } = "100";
        [XmlAttribute]
        public string Duration
        {
            get
            {
                if (_Duration == "100")
                {
                    return null;
                }
                return _Duration;
            }
            set
            {
                _Duration = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate("internal/Action/descbeep", "Beep at ({0}) hz for ({1}) ms", _Frequency, _Duration);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            double freq = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Frequency);
            if (freq < 37.0)
            {
                freq = 37.0;
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqlo", "Beep frequency below limit, capping to {0}", freq));
            }
            if (freq > 32767.0)
            {
                freq = 32767.0;
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqhi", "Beep frequency above limit, capping to {0} ", freq));
            }
            double len = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Duration);
            if (len < 0.0)
            {
                len = 0.0;
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beeplengthlo", "Beep length below limit, capping to {0}", len));
            }
            Console.Beep((int)Math.Ceiling(freq), (int)Math.Ceiling(len));
        }

        #endregion

    }

}
