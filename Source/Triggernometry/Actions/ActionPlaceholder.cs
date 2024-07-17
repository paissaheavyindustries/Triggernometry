using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Placeholder (noop)
    /// </summary>
    [XmlRoot(ElementName = "Placeholder")]
    public class ActionPlaceholder : ActionBase
    {

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate("internal/Action/descplaceholder", "Placeholder");
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            // nothing to execute            
        }

        #endregion

    }

}
