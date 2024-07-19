using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Utilities;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Mouse operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Input)]
    [XmlRoot(ElementName = "Mouse")]
    internal class ActionMouse : ActionBase
    {

        #region Properties

        /// <summary>
        /// Mouse operations
        /// </summary>
        private enum OperationEnum
        {
            Move,
            LeftClick,
            MiddleClick,
            RightClick
        }

        /// <summary>
        /// Coordinate definitions
        /// </summary>
        private enum CoordinateEnum
        {
            /// <summary>
            /// Coordinates are in absolute screen space (0,0 being the top-left corner of screen)
            /// </summary>
            Absolute,
            /// <summary>
            /// Coordinates are relative to current mouse position
            /// </summary>
            Relative
        }

        /// <summary>
        /// Type of the mouse operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.Move;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.Move)
                {
                    return _Operation.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum), value);
            }
        }

        /// <summary>
        /// Coordinate system to use
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private CoordinateEnum _Coordinate { get; set; } = CoordinateEnum.Absolute;
        [XmlAttribute]
        public string Coordinate
        {
            get
            {
                if (_Coordinate != CoordinateEnum.Absolute)
                {
                    return _Coordinate.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Coordinate = (CoordinateEnum)Enum.Parse(typeof(CoordinateEnum), value);
            }
        }

        /// <summary>
        /// Mouse X position/offset
        /// </summary>
        [ActionAttribute(ordernum: 3, typehint: typeof(int))]
        private string _X { get; set; } = "0";
        [XmlAttribute]
        public string X
        {
            get
            {
                if (_X == "0" || _X == "")
                {
                    return null;
                }
                return _X.ToString();
            }
            set
            {
                _X = value;
            }
        }

        /// <summary>
        /// Mouse Y position/offset
        /// </summary>
        [ActionAttribute(ordernum: 4, typehint: typeof(int))]
        private string _Y { get; set; } = "0";
        [XmlAttribute]
        public string Y
        {
            get
            {
                if (_Y == "0" || _Y == "")
                {
                    return null;
                }
                return _Y.ToString();
            }
            set
            {
                _Y = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            string coorddesc = "";
            switch (_Coordinate)
            {
                case CoordinateEnum.Absolute:
                    coorddesc = I18n.Translate("internal/Action/descmousecoordabsolute", "to absolute coordinates");
                    break;
                case CoordinateEnum.Relative:
                    coorddesc = I18n.Translate("internal/Action/descmousecoordrelative", "by relative coordinates");
                    break;
            }
            switch (_Operation)
            {
                case OperationEnum.Move:
                    return I18n.Translate("internal/Action/descmousemove", "Move mouse {0} X: {1} Y: {2}", coorddesc, _X, _Y);
                case OperationEnum.LeftClick:
                    return I18n.Translate("internal/Action/descmouselmb", "Move mouse {0} X: {1} Y: {2} and left click", coorddesc, _X, _Y);
                case OperationEnum.MiddleClick:
                    return I18n.Translate("internal/Action/descmousemmb", "Move mouse {0} X: {1} Y: {2} and middle click", coorddesc, _X, _Y);
                case OperationEnum.RightClick:
                    return I18n.Translate("internal/Action/descmousermb", "Move mouse {0} X: {1} Y: {2} and right click", coorddesc, _X, _Y);
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            int mousex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _X);
            int mousey = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Y);
            WindowsUtils.MouseEventFlags flags = 0;
            switch (_Coordinate)
            {
                case CoordinateEnum.Absolute:
                    flags |= WindowsUtils.MouseEventFlags.ABSOLUTE;
                    break;
                case CoordinateEnum.Relative:
                    break;
            }
            switch (_Operation)
            {
                case OperationEnum.Move:
                    WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                    break;
                case OperationEnum.LeftClick:
                    Task.Run(() =>
                    {
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.LEFTDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.LEFTUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                    });
                    break;
                case OperationEnum.MiddleClick:
                    Task.Run(() =>
                    {
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MIDDLEDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MIDDLEUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                    });
                    break;
                case OperationEnum.RightClick:
                    Task.Run(() =>
                    {
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.RIGHTDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                        System.Threading.Thread.Sleep(10);
                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.RIGHTUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                    });
                    break;
            }
        }

        #endregion

    }

}
