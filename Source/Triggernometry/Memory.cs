using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Triggernometry;
using static Triggernometry.RealPlugin;

// to-do: I18n

namespace Triggernometry.Utilities
{
    public static partial class Memory
    {
        #region XIV Process / Handle

        public const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        private static DateTime _lastUpdateTime = DateTime.MinValue;
        private const int CACHE_INTERVAL_SECONDS = 10;

        private static Process _xivProc = null;
        public static Process XivProc
        {
            get
            {
                UpdateProcCacheIfNeeded();
                return _xivProc;
            }
        }

        private static int _xivProcId = 0;
        public static int XivProcId
        {
            get
            {
                UpdateProcCacheIfNeeded();
                return _xivProcId;
            }
        }

        private static IntPtr _xivProcHandle = IntPtr.Zero;
        public static IntPtr XivProcHandle
        {
            get
            {
                UpdateProcCacheIfNeeded();
                return _xivProcHandle;
            }
        }

        public static IntPtr XivBaseAddress => XivProc.MainModule.BaseAddress;

        private static void UpdateProcCacheIfNeeded() // any better ways to monitor the changing of ffxiv process?
        {
            if ((DateTime.Now - _lastUpdateTime).TotalSeconds > CACHE_INTERVAL_SECONDS)
            {
                _lastUpdateTime = DateTime.Now;

                _xivProc = PluginBridges.BridgeFFXIV.GetProcess();
                _xivProcId = _xivProc?.Id ?? 0;

                if (_xivProc?.HasExited ?? true)
                {
                    _xivProcHandle = IntPtr.Zero;
                    return;
                }
                
                if (_xivProcHandle != IntPtr.Zero)
                {
                    if (GetProcessId(_xivProcHandle) == _xivProcId)
                    {
                        return;
                    }
                    else
                    {
                        DisposeXivProcHandle();
                    }
                }
                foreach (var action in _xivProcUpdatedActions.Values)
                {
                    try { action.Invoke(); }
                    catch (Exception ex) { plug.UnfilteredAddToLog(DebugLevelEnum.Error, ex.ToString()); }
                }
                _xivProcHandle = OpenProcess(PROCESS_ALL_ACCESS, false, _xivProcId);
            }
        }

        public static void DisposeXivProcHandle()
        {
            if (_xivProcHandle != IntPtr.Zero)
            {
                try { CloseHandle(_xivProcHandle); }
                catch { }
                _xivProcHandle = IntPtr.Zero;
            }
        }

        private static Dictionary<string, System.Action> _xivProcUpdatedActions = new Dictionary<string, System.Action>();

        // could be used in scripts
        public static void RegisterXivProcUpdatedAction(string key, System.Action action)
        {
            _xivProcUpdatedActions[key] = action;
        }

        public static void UnregisterXivProcUpdatedAction(string key)
        {
            _xivProcUpdatedActions.Remove(key);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetProcessId(IntPtr hProcess);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        #endregion

        #region Read / Write Memory

        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, uint dwSize, out int lpBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint dwSize, out int lpBytesWritten);

        public static T BytesToStructure<T>(byte[] bytes, int start = 0) where T : struct
        {
            // simple types
            if (typeof(T) == typeof(int))
                return (T)(object)BitConverter.ToInt32(bytes, start);
            if (typeof(T) == typeof(long))
                return (T)(object)BitConverter.ToInt64(bytes, start);
            if (typeof(T) == typeof(short))
                return (T)(object)BitConverter.ToInt16(bytes, start);
            if (typeof(T) == typeof(float))
                return (T)(object)BitConverter.ToSingle(bytes, start);
            if (typeof(T) == typeof(double))
                return (T)(object)BitConverter.ToDouble(bytes, start);
            if (typeof(T) == typeof(uint))
                return (T)(object)BitConverter.ToUInt32(bytes, start);
            if (typeof(T) == typeof(ulong))
                return (T)(object)BitConverter.ToUInt64(bytes, start);
            if (typeof(T) == typeof(ushort))
                return (T)(object)BitConverter.ToUInt16(bytes, start);
            if (typeof(T) == typeof(bool))
                return (T)(object)BitConverter.ToBoolean(bytes, start);

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = handle.AddrOfPinnedObject() + start;
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }

        public static byte[] StructureToBytes<T>(T structure) where T : struct
        {
            // simple types
            if (typeof(T) == typeof(int))
                return BitConverter.GetBytes((int)(object)structure);
            if (typeof(T) == typeof(long))
                return BitConverter.GetBytes((long)(object)structure);
            if (typeof(T) == typeof(short))
                return BitConverter.GetBytes((short)(object)structure);
            if (typeof(T) == typeof(float))
                return BitConverter.GetBytes((float)(object)structure);
            if (typeof(T) == typeof(double))
                return BitConverter.GetBytes((double)(object)structure);
            if (typeof(T) == typeof(uint))
                return BitConverter.GetBytes((uint)(object)structure);
            if (typeof(T) == typeof(ulong))
                return BitConverter.GetBytes((ulong)(object)structure);
            if (typeof(T) == typeof(ushort))
                return BitConverter.GetBytes((ushort)(object)structure);
            if (typeof(T) == typeof(bool))
                return BitConverter.GetBytes((bool)(object)structure);

            int size = Marshal.SizeOf<T>();
            byte[] bytes = new byte[size];
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = handle.AddrOfPinnedObject();
                Marshal.StructureToPtr(structure, ptr, false);
            }
            finally
            {
                handle.Free();
            }
            return bytes;
        }

        public static byte[] ReadModuleData(Process proc)
        {
            if (proc.HasExited) return new byte[] { };
            int moduleSize = proc.MainModule.ModuleMemorySize;
            byte[] moduleData = new byte[moduleSize];
            ReadProcessMemory(proc.Handle, proc.MainModule.BaseAddress, moduleData, (uint)moduleSize, out _);
            return moduleData;
        }

        public static byte[] ReadBytes(IntPtr procHandle, IntPtr address, uint size)
        {
            byte[] lpBuffer = new byte[size];
            ReadProcessMemory(procHandle, address, lpBuffer, size, out _);
            return lpBuffer;
        }

        public static void WriteBytes(IntPtr procHandle, IntPtr address, uint size, byte[] newValue)
        {
            WriteProcessMemory(procHandle, address, newValue, size, out _);
        }

        public static T Read<T>(IntPtr procHandle, IntPtr address) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] valueBytes = new byte[size];
            if (!ReadProcessMemory(procHandle, address, valueBytes, (uint)size, out int bytesRead) || bytesRead != size)
            {
                plug.UnfilteredAddToLog(DebugLevelEnum.Error, "Failed to read memory or read incorrect number of bytes.");
                return default;
            }
            return BytesToStructure<T>(valueBytes);
        }

        public static void Write<T>(IntPtr procHandle, IntPtr address, T newValue) where T : struct
        {
            byte[] valueBytes = StructureToBytes(newValue);
            if (!WriteProcessMemory(procHandle, address, valueBytes, (uint)valueBytes.Length, out int bytesWritten) || bytesWritten != valueBytes.Length)
            {
                plug.UnfilteredAddToLog(DebugLevelEnum.Error, "Failed to write all bytes to memory.");
            }
        }

        #endregion

        #region Scanner

        public class ScanPattern
        {
            public string RawPattern;
            public byte?[] Bytes;
            public int Length;
            public Regex PatternRegex;

            public int Offset;
            public bool Jump;

            public byte? this[int index] => Bytes[index];

            /// <summary> Accepts input like "00 11 ? ? aa" or "00 11 ? ? aa * * * * bb" </summary>
            /// <param name="patternStr"></param>
            public ScanPattern(string patternStr)
            {
                // '?' : a wildcard
                // '*' : a wildcard to jump to
                RawPattern = patternStr.Trim().Replace("??", "?").Replace("**", "*");
                string[] splittedRawPattern = RawPattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string regexStr = "";
                List<byte?> bytes = new List<byte?>();
                for (int i = 0; i < splittedRawPattern.Length; i++)
                {
                    switch (splittedRawPattern[i])
                    {
                        case "?":
                            regexStr += ".";
                            bytes.Add(null);
                            break;
                        case "*":
                            if (Jump) throw new Exception($"Too much * in pattern {patternStr}");
                            Offset = i;
                            Jump = true;
                            regexStr += "(?<jump>.{4})";
                            bytes.AddRange(new byte?[] { null, null, null, null });
                            i += 3;
                            break;
                        default:
                            if (byte.TryParse(splittedRawPattern[i], NumberStyles.HexNumber, null, out byte result))
                            {
                                regexStr += "\\x" + splittedRawPattern[i].PadLeft(2, '0');
                                bytes.Add(result);
                                break;
                            }
                            else throw new Exception($"Invalid byte {splittedRawPattern[i]} in pattern {patternStr}");
                    }
                }
                PatternRegex = new Regex(regexStr, RegexOptions.Compiled | RegexOptions.Singleline);
                Bytes = bytes.ToArray();
                Length = Bytes.Length;
            }
        }

        public static int? ScanPoint(byte[] data, string rawPattern, bool showWarning = true) => ScanPoint(data, new ScanPattern(rawPattern), showWarning);
        public static int? ScanPoint(byte[] data, ScanPattern pattern, bool showWarning = true)
        {
            string dataStr = Encoding.GetEncoding("ISO-8859-1").GetString(data);  // Latin-1
            int address;

            Match match = pattern.PatternRegex.Match(dataStr);
            if (match.Success)
            {
                plug.UnfilteredAddToLog(DebugLevelEnum.Verbose, $"Found address \"{pattern.RawPattern}\" in module data");
                address = match.Index + pattern.Offset;
            }
            else
            {
                plug.UnfilteredAddToLog(showWarning ? DebugLevelEnum.Warning : DebugLevelEnum.Verbose, $"Failed to find \"{pattern.RawPattern}\" in module data");
                return null;
            }
            if (pattern.Jump)
            {
                int offset = BytesToStructure<int>(data, address);
                address += offset + 4;
            }
            return address;
        }

        public static IntPtr? ScanAddress(byte[] data, string rawPattern) => ScanAddress(data, new ScanPattern(rawPattern));
        public static IntPtr? ScanAddress(byte[] data, ScanPattern pattern)
        {
            int? offset = ScanPoint(data, pattern);
            if (offset == null) return null;
            return (IntPtr)BytesToStructure<long>(data, (int)offset);
        }

        public static Exception ScanNotFoundException(string varDescription)
            => new Exception(I18n.Translate("internal/Memory/scannotfoundexception",
                "Failed to find the memory signature when scanning for {0}", varDescription));

        #endregion

        #region MarkingController

        private static int _offset1B;
        private static readonly SemaphoreSlim _semaphoreSlim1B = new SemaphoreSlim(1, 1);

        public static int Offset1B
        {
            get
            {
                _semaphoreSlim1B.Wait();
                try { return _offset1B; }
                finally { _semaphoreSlim1B.Release(); }
            }
            private set
            {
                _semaphoreSlim1B.Wait();
                try
                {
                    _offset1B = value;
                    plug.UnfilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Memory/update1B",
                        "Headmarker offset updated to ({0})", _offset1B));
                }
                finally { _semaphoreSlim1B.Release(); }
            }
        }

        /// <summary> 
        /// Update the headmarker offset. (0x1B log line) <br />
        /// This method is invoked asynchronously when the zone changed,
        /// and locks the offset value until the update is finished.
        /// </summary>
        public static async void UpdateOffset1B()
        {
            await _semaphoreSlim1B.WaitAsync();
            try { _offset1B = await Task.Run(() => GetHeadMarkerOffset()); }
            catch (Exception e)
            {
                plug.UnfilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Memory/update1Berror",
                    "Update headmarker offset failed due to exception:\n\n{0}", e.ToString()));
            }
            finally { _semaphoreSlim1B.Release(); }
        }

        //private static int? _headMarkerOffsetRelAddress3;
        private static int GetHeadMarkerOffset()
        {
            return 0; // SE was not using this offset since 7.0
            /*
            try
            {   // 6.x
                byte[] moduleData = ReadModuleData(XivProc);

                int relAddress1 = ScanPoint(moduleData, "89 1d * * * * 40 ? ? 75", false)
                    ?? throw ScanNotFoundException("headMarkerOffsetRelAddress1");
                int relAddress2 = ScanPoint(moduleData, "41 ? ? 89 15 * * * * 48 ? ? ? 5f", false)
                    ?? throw ScanNotFoundException("headMarkerOffsetRelAddress2");
                int relAddress3 = _headMarkerOffsetRelAddress3 ?? ScanPoint(moduleData, "8b ? * * * * 44 ? ? ? ? ? ? 4c 89 b4 24", false)
                    ?? throw ScanNotFoundException("headMarkerOffsetRelAddress3");

                _headMarkerOffsetRelAddress3 = relAddress3; // client-based fixed value

                int param1 = BytesToStructure<int>(moduleData, relAddress1);
                int param2 = BytesToStructure<int>(moduleData, relAddress2);
                int param3 = BytesToStructure<int>(moduleData, relAddress3);

                return Math.Min(param1 - param2 + param3, 0);
            }
            catch
            {
                _headMarkerOffsetRelAddress3 = 0;
            }
            */
        }

        // FFXIVClientStructs/FFXIV/Client/Game/UI/MarkingController.cs
        private static IntPtr _markingControllerPtr = IntPtr.Zero;
        public static IntPtr MarkingControllerPtr
        {
            get
            {
                if (_markingControllerPtr == IntPtr.Zero)
                {
                    byte[] moduleData = ReadModuleData(XivProc);
                    int offset = ScanPoint(moduleData, "48 8d 0d * * * * 4c 8b 85") ?? throw ScanNotFoundException("MarkingControllerPtr");
                    _markingControllerPtr = XivBaseAddress + offset;
                }
                return _markingControllerPtr;
            }
        }

        public static IntPtr TargetMarkersPtr => MarkingControllerPtr + 0x10;
        public static IntPtr WaymarksPtr => MarkingControllerPtr + 0x1E0;

        public enum TargetMarkerEnum
        {
            None = -1,
            Attack1 = 0, Attack2 = 1, Attack3 = 2, Attack4 = 3, Attack5 = 4,
            Bind1 = 5, Bind2 = 6, Bind3 = 7,
            Stop1 = 8, Stop2 = 9,
            Square = 10, Circle = 11, Cross = 12, Triangle = 13,
            Attack6 = 14, Attack7 = 15, Attack8 = 16,
        }

        public static uint? EntityIdByTargetMarker(string rawType)
        {
            rawType = rawType.Trim();
            if (Enum.TryParse(rawType, ignoreCase: true, out TargetMarkerEnum type))
                return EntityIdByTargetMarker(type);
            else if (int.TryParse(rawType, out int id))
                return EntityIdByTargetMarker((TargetMarkerEnum)id);
            else
                return null;
        }

        public static uint EntityIdByTargetMarker(TargetMarkerEnum type)
        {
            return Read<uint>(XivProcHandle, TargetMarkersPtr + 8 * (int)type);
        }

        public static TargetMarkerEnum TargetMarkerOnEntity(uint entityId)
        {
            byte[] mem = ReadBytes(XivProcHandle, TargetMarkersPtr, 8 * 28);
            for (int i = 0; i < 28; i++)
            {
                uint value = BytesToStructure<uint>(mem, 8 * i);
                if (value == entityId)
                {
                    return (TargetMarkerEnum)i;
                }
            }
            return TargetMarkerEnum.None;
        }

        public enum WaymarkEnum
        {
            A = 0, B = 1, C = 2, D = 3, One = 4, Two = 5, Three = 6, Four = 7
        }

        public class Waymark
        {
            public const int SIZE = 0x20;
            public WaymarkEnum Type;
            public float X, Y, Z;
            public bool Active;
            // The in-game marking method only has 0.001 precision
            // The value is converted to double is to avoid the ToString() method rounding the float value.
            // e.g. if the waymark is set to x = 10000.456, then the actual float value will be 10000.45605f.
            // 10000.45605f.ToString("0.###") gets 10000.46, but we want the actual value 10000.456.
            // Values within ±16384 has the 3rd decimal place precision.
            public string X3 => ((double)X).ToString("0.###", CultureInfo.InvariantCulture);
            public string Y3 => ((double)Y).ToString("0.###", CultureInfo.InvariantCulture);
            public string Z3 => ((double)Z).ToString("0.###", CultureInfo.InvariantCulture);

            public static Waymark Read(WaymarkEnum type)
            {
                byte[] bytes = ReadBytes(XivProcHandle, WaymarksPtr + SIZE * (int)type, SIZE);
                Waymark wm = new Waymark { 
                    Type = type,
                    Active = BitConverter.ToBoolean(bytes, 0x1C)
                };
                if (wm.Active)
                {
                    wm.X = BitConverter.ToSingle(bytes, 0);
                    wm.Z = BitConverter.ToSingle(bytes, 4);
                    wm.Y = BitConverter.ToSingle(bytes, 8);
                }
                return wm;
            }

            // ${_waymark[A].active}  ${_waymark[One].x}  ${_waymark[6].xyz}
            public static string QueryWaymark(string rawType, string rawProp)
            {
                if (!Enum.TryParse(rawType.Trim(), ignoreCase: true, out WaymarkEnum type))
                {
                    if (int.TryParse(rawType, out int typeIdx))
                    {
                        if (typeIdx >= 0 && typeIdx < 8)
                        { 
                            type = (WaymarkEnum)typeIdx;
                        }
                        else throw Context.InvalidValueError("waymark", I18n.TranslateWord("index"), rawType, $"${{_waymark[{rawType}].{rawProp}}}");
                    }
                    else throw Context.InvalidValueError("waymark", I18n.TranslateWord("type"), rawType, $"${{_waymark[{rawType}].{rawProp}}}");
                }
                Waymark wm = Read(type);
                switch (rawProp.ToLower())
                {
                    case "active": 
                        return wm.Active ? "1" : "0";
                    case "x":   case "posx":
                        return wm.X3;
                    case "y":   case "posy": 
                        return wm.Y3;
                    case "z":   case "posz": 
                        return wm.Z3;
                    case "xy":  case "posxy":
                        return $"{wm.X3}, {wm.Y3}";
                    case "xyz": case "pos":
                        return $"{wm.X3}, {wm.Y3}, {wm.Z3}";
                    default:
                        throw Context.InvalidValueError("waymark", I18n.TranslateWord("property"), rawProp, $"${{_waymark[{rawType}].{rawProp}}}");
                }
            }
        }

        public class Waymarks : IEnumerable<Waymark>
        {
            public Waymark A, B, C, D, One, Two, Three, Four;
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public IEnumerator<Waymark> GetEnumerator()
            {
                yield return A;   yield return B;   yield return C;     yield return D;
                yield return One; yield return Two; yield return Three; yield return Four;
            }
            public static Waymarks Read() => new Waymarks 
            {
                A     = Waymark.Read(WaymarkEnum.A),
                B     = Waymark.Read(WaymarkEnum.B),
                C     = Waymark.Read(WaymarkEnum.C),
                D     = Waymark.Read(WaymarkEnum.D),
                One   = Waymark.Read(WaymarkEnum.One),
                Two   = Waymark.Read(WaymarkEnum.Two),
                Three = Waymark.Read(WaymarkEnum.Three),
                Four  = Waymark.Read(WaymarkEnum.Four)
            };
        }

        #endregion MarkingController

        public static IntPtr GetCameraAddress()
        {
            byte[] moduleData = ReadModuleData(XivProc);
            try
            {
                int relativeAddress = ScanPoint(moduleData, "4C 8D 35 * * * * 48 8B 09", false) ?? throw ScanNotFoundException("camaraAddress7.0");
                IntPtr pointerValue = Read<IntPtr>(XivProc.Handle, XivBaseAddress + relativeAddress);
                return pointerValue;
            }
            catch
            {
                ScanPattern pattern = new ScanPattern(              // svr2kos2@github
                    "48 83 c4 28 " +                                // add rsp, 28
                    "e9 ?? ?? ?? ?? " +                             // jmp xxxxxxxx
                    "cc cc cc cc cc cc cc cc cc cc cc cc cc " +     // int 3 * 13
                    "48 8d 0d ");                                   // lea
                int lea = ScanPoint(moduleData, pattern) - 0x76 ?? throw ScanNotFoundException("camaraAddress6.0");
                int relativeOffset = BytesToStructure<int>(moduleData, lea + 0x3);
                var absoluteAddress = IntPtr.Add(XivBaseAddress, lea + relativeOffset + 7);

                IntPtr pointerValue = Read<IntPtr>(XivProc.Handle, absoluteAddress);
                return pointerValue;
            }
        }
    }
}