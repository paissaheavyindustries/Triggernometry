using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// OBS remote control operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.RemoteControl)]
    [XmlRoot(ElementName = "ObsControl")]
    internal class ActionObsControl : ActionBase
    {

        #region Properties

        /// <summary>
        /// OBS control operations
        /// </summary>
        private enum OperationEnum
        {
            StartStreaming,
            StopStreaming,
            ToggleStreaming,
            StartRecording,
            StopRecording,
            ToggleRecording,
            RestartRecording,
            RestartRecordingIfActive,
            ResumeRecording,
            PauseRecording,
            ToggleRecordPause,
            StartReplayBuffer,
            StopReplayBuffer,
            ToggleReplayBuffer,
            SaveReplayBuffer,
            SetScene,
            ShowSource,
            HideSource,
            JSONPayload
        }

        /// <summary>
        /// Type of the OBS control operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.StartStreaming;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.StartStreaming)
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
        /// OBS WebSocket endpoint
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private string _Endpoint { get; set; } = @"ws://${_const[OBSWebsocketEndpoint]}:${_const[OBSWebsocketPort]}";
        [XmlAttribute]
        public string Endpoint
        {
            get
            {
                if (_Endpoint == @"ws://${_const[OBSWebsocketEndpoint]}:${_const[OBSWebsocketPort]}")
                {
                    return null;
                }
                return _Endpoint;
            }
            set
            {
                _Endpoint = value;
            }
        }

        /// <summary>
        /// Optional password for the OBS endpoint
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private string _Password { get; set; } = @"${_const[OBSWebsocketPassword]}";
        [XmlAttribute]
        public string Password
        {
            get
            {
                if (_Password == @"${_const[OBSWebsocketPassword]}")
                {
                    return null;
                }
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        /// <summary>
        /// Name of the scene referenced in some operations
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _SceneName { get; set; } = "";
        [XmlAttribute]
        public string SceneName
        {
            get
            {
                if (_SceneName == "")
                {
                    return null;
                }
                return _SceneName;
            }
            set
            {
                _SceneName = value;
            }
        }

        /// <summary>
        /// Name of the source referenced in some operations
        /// </summary>
        [ActionAttribute(ordernum: 5)]
        private string _SourceName { get; set; } = "";
        [XmlAttribute]
        public string SourceName
        {
            get
            {
                if (_SourceName == "")
                {
                    return null;
                }
                return _SourceName;
            }
            set
            {
                _SourceName = value;
            }
        }

        /// <summary>
        /// Custom JSON payload
        /// </summary>
        [ActionAttribute(ordernum: 6)]
        private string _JSONPayload { get; set; } = "";
        [XmlAttribute]
        public string JSONPayload
        {
            get
            {
                if (_JSONPayload == "")
                {
                    return null;
                }
                return _JSONPayload;
            }
            set
            {
                _JSONPayload = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.StartStreaming:
                    return I18n.Translate("internal/Action/descobsstartstream", "start streaming on OBS");
                case OperationEnum.StopStreaming:
                    return I18n.Translate("internal/Action/descobsstopstream", "stop streaming on OBS");
                case OperationEnum.ToggleStreaming:
                    return I18n.Translate("internal/Action/descobstogglestream", "start/stop streaming on OBS (toggle)");
                case OperationEnum.StartRecording:
                    return I18n.Translate("internal/Action/descobsstartrecord", "start recording on OBS");
                case OperationEnum.StopRecording:
                    return I18n.Translate("internal/Action/descobsstoprecord", "stop recording on OBS");
                case OperationEnum.ToggleRecording:
                    return I18n.Translate("internal/Action/descobstogglerecord", "start/stop recording on OBS (toggle)");
                case OperationEnum.RestartRecording:
                    return I18n.Translate("internal/Action/descobsrestartrecord", "stop then start recording on OBS");
                case OperationEnum.RestartRecordingIfActive:
                    return I18n.Translate("internal/Action/descobsrestartrecordifactive", "stop then start recording on OBS (if currently recording)");
                case OperationEnum.ResumeRecording:
                    return I18n.Translate("internal/Action/descobsresumerecord", "resume recording on OBS");
                case OperationEnum.PauseRecording:
                    return I18n.Translate("internal/Action/descobspauserecord", "pause recording on OBS");
                case OperationEnum.ToggleRecordPause:
                    return I18n.Translate("internal/Action/descobstogglerecordpause", "resume/pause recording on OBS (toggle)");
                case OperationEnum.StartReplayBuffer:
                    return I18n.Translate("internal/Action/descobsstartreplay", "start OBS replay buffer");
                case OperationEnum.StopReplayBuffer:
                    return I18n.Translate("internal/Action/descobsstopreplay", "stop OBS replay buffer");
                case OperationEnum.ToggleReplayBuffer:
                    return I18n.Translate("internal/Action/descobstogglereplay", "start/stop OBS replay buffer (toggle)");
                case OperationEnum.SaveReplayBuffer:
                    return I18n.Translate("internal/Action/descobssavereplay", "save OBS replay buffer");
                case OperationEnum.SetScene:
                    return I18n.Translate("internal/Action/descobssetscene", "set current OBS scene to ({0})", _SceneName);
                case OperationEnum.ShowSource:
                    return I18n.Translate("internal/Action/descobsshowsource", "show source ({0}) on OBS scene ({1})", _SourceName, _SceneName);
                case OperationEnum.HideSource:
                    return I18n.Translate("internal/Action/descobshidesource", "hide source ({0}) on OBS scene ({1})", _SourceName, _SceneName);
                case OperationEnum.JSONPayload:
                    return I18n.Translate("internal/Action/descobsjsonpayload", "Send custom JSON payload to OBS");
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            ObsController obsController = ctx.plug._obs;
            if (obsController != null)
            {
                string endpoint = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Endpoint);
                string password = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Password);
                lock (obsController)
                {
                    if (ObsConnector(ctx, endpoint, password) != true)
                        return; // already complaint about errors
                    try
                    {
                        switch (_Operation)
                        {
                            case OperationEnum.StartStreaming:
                                obsController.StartStreaming();
                                break;
                            case OperationEnum.StopStreaming:
                                obsController.StopStreaming();
                                break;
                            case OperationEnum.ToggleStreaming:
                                obsController.ToggleStreaming();
                                break;
                            case OperationEnum.StartRecording:
                                obsController.StartRecording();
                                break;
                            case OperationEnum.StopRecording:
                                obsController.StopRecording();
                                break;
                            case OperationEnum.ToggleRecording:
                                obsController.ToggleRecording();
                                break;
                            case OperationEnum.RestartRecording:
                                obsController.RestartRecording();
                                break;
                            case OperationEnum.RestartRecordingIfActive:
                                obsController.RestartRecordingIfActive();
                                break;
                            case OperationEnum.ResumeRecording:
                                obsController.ResumeRecording();
                                break;
                            case OperationEnum.PauseRecording:
                                obsController.PauseRecording();
                                break;
                            case OperationEnum.ToggleRecordPause:
                                obsController.ToggleRecordPause();
                                break;
                            case OperationEnum.StartReplayBuffer:
                                obsController.StartReplayBuffer();
                                break;
                            case OperationEnum.StopReplayBuffer:
                                obsController.StopReplayBuffer();
                                break;
                            case OperationEnum.ToggleReplayBuffer:
                                obsController.ToggleReplayBuffer();
                                break;
                            case OperationEnum.SaveReplayBuffer:
                                obsController.SaveReplayBuffer();
                                break;
                            case OperationEnum.SetScene:
                                {
                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _SceneName);
                                    obsController.SetCurrentScene(scn);
                                }
                                break;
                            case OperationEnum.ShowSource:
                                {
                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _SceneName);
                                    string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _SourceName);
                                    obsController.ShowHideSource(scn, src, true);
                                }
                                break;
                            case OperationEnum.HideSource:
                                {
                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _SceneName);
                                    string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _SourceName);
                                    obsController.ShowHideSource(scn, src, false);
                                }
                                break;
                            case OperationEnum.JSONPayload:
                                {
                                    string json = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JSONPayload);
                                    obsController.JSONPayload(json);
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/obscontrolexception", "Can't execute OBS control action due to exception: {0}" + ex.Message));
                    }
                }
            }
        }

        #endregion

    }

}
