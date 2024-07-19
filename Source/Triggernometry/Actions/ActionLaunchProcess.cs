using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Launch process
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Programming)]
    [XmlRoot(ElementName = "LaunchProcess")]
    internal class ActionLaunchProcess : ActionBase
    {

        #region Properties

        /// <summary>
        /// Window style to launch the process with
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private System.Diagnostics.ProcessWindowStyle _WindowStyle { get; set; } = System.Diagnostics.ProcessWindowStyle.Normal;
        [XmlAttribute]
        public string WindowStyle
        {
            get
            {
                if (_WindowStyle != System.Diagnostics.ProcessWindowStyle.Normal)
                {
                    return _WindowStyle.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _WindowStyle = (System.Diagnostics.ProcessWindowStyle)Enum.Parse(typeof(System.Diagnostics.ProcessWindowStyle), value);
            }
        }

        /// <summary>
        /// Path to the process to launch
        /// </summary>
        [ActionAttribute(ordernum: 2, specialtype: ActionAttribute.SpecialTypeEnum.ExecutableSelector)]
        private string _Path { get; set; } = "";
        [XmlAttribute]
        public string Path
        {
            get
            {
                if (_Path == "")
                {
                    return null;
                }
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }

        /// <summary>
        /// Command line arguments to pass to the process
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private string _Arguments { get; set; } = "";
        [XmlAttribute]
        public string Arguments
        {
            get
            {
                if (_Arguments == "")
                {
                    return null;
                }
                return _Arguments;
            }
            set
            {
                _Arguments = value;
            }
        }

        /// <summary>
        /// Working directory
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _WorkingDirectory { get; set; } = "";
        [XmlAttribute]
        public string WorkingDirectory
        {
            get
            {
                if (_WorkingDirectory == "")
                {
                    return null;
                }
                return _WorkingDirectory;
            }
            set
            {
                _WorkingDirectory = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            string tempt = "";
            switch (_WindowStyle)
            {
                case System.Diagnostics.ProcessWindowStyle.Hidden:
                    tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Hidden from view]", _WindowStyle.ToString());
                    break;
                case System.Diagnostics.ProcessWindowStyle.Maximized:
                    tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Maximized to fullscreen]", _WindowStyle.ToString());
                    break;
                case System.Diagnostics.ProcessWindowStyle.Minimized:
                    tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Minimized to taskbar]", _WindowStyle.ToString());
                    break;
                case System.Diagnostics.ProcessWindowStyle.Normal:
                    tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Normal]", _WindowStyle.ToString());
                    break;
                default:
                    tempt = _WindowStyle.ToString();
                    break;
            }
            return I18n.Translate("internal/Action/desclaunchprocess", "launch process ({0}) as ({1}) using command line parameters ({2})",
                Path,
                tempt,
                Arguments
            );
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.Arguments = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Arguments);
            psi.WindowStyle = _WindowStyle;
            psi.WorkingDirectory = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WorkingDirectory);
            psi.FileName = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Path);
            p.StartInfo = psi;
            p.Start();
            if (_Asynchronous == false)
            {
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/waitingprocexit", "Waiting for process to exit"));
                p.WaitForExit();
            }
        }

        #endregion

    }

}
