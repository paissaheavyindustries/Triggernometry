using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using WMPLib;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        internal Dictionary<string, DateTime> TtsRepetitions = new Dictionary<string, DateTime>();
        internal Dictionary<string, DateTime> SoundRepetitions = new Dictionary<string, DateTime>();
        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        internal bool WMPUnavailable;

        private void InitAudio(ref string exwhere)
        {
            exwhere = I18n.Translate("internal/Plugin/iniwmp", "trying to initialize Windows Media Player");
            WMPUnavailable = false;
            try
            {
                wmp = new WMPLib.WindowsMediaPlayer();
            }
            catch (Exception ex)
            {
                WMPUnavailable = true;
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/iniwmperror", "Error while {0} ({1}), going to fallback to ACT hooks for sound playback", exwhere, ex.Message));
            }
            exwhere = I18n.Translate("internal/Plugin/initts", "trying to initialize TTS");
            tts = new SpeechSynthesizer();
            ui.wmp = wmp;
            ui.tts = tts;
        }

        private void DeInitAudio()
        {
            if (wmp != null)
            {
                wmp.close();
                wmp = null;
            }
            tts?.Dispose();
            tts = null;
        }

        internal void TtsPlaybackAct(Context ctx, Action a)
        {
            string text = TtsPlaybackGetTextFromAction(ctx, a);
            lock (TtsRepetitions)
            {
                if (RegisterRepetition(TtsRepetitions, cfg.TtsRepCooldown, text) == false)
                {
                    return;
                }
            }
            TtsPlaybackHook(text);
        }

        internal void SoundPlaybackAct(Context ctx, Action a, string filename)
        {
            lock (SoundRepetitions)
            {
                if (RegisterRepetition(SoundRepetitions, cfg.SoundRepCooldown, filename) == false)
                {
                    return;
                }
            }
            double vol = ctx.EvaluateNumericExpression(a.ActionContextLogger, ctx, a._PlaySoundVolumeExpression);
            vol *= (ctx.plug.cfg.SfxVolumeAdjustment / 100.0);
            if (vol < 0.0)
            {
                vol = 0.0;
            }
            if (vol > 100.0)
            {
                vol = 100.0;
            }
            SoundPlaybackHook(filename, (int)Math.Floor(vol));
        }

        internal string TtsPlaybackGetTextFromAction(Context ctx, Action a)
        {
            string text = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._UseTTSTextExpression);
            if (ctx.plug != null)
            {
                text = ctx.plug.cfg.PerformSubstitution(text, Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech);
            }
            return text;
        }

        internal void TtsPlaybackSelf(Context ctx, Action a)
        {
            string text = TtsPlaybackGetTextFromAction(ctx, a);
            lock (TtsRepetitions)
            {
                if (RegisterRepetition(TtsRepetitions, cfg.TtsRepCooldown, text) == false)
                {
                    return;
                }
            }
            SpeechSynthesizer mytts;
            if (/*a._UseTTSExclusive == */true)
            {
                mytts = new SpeechSynthesizer();
            }
            else
            {
                mytts = tts;
            }
            double vol = ctx.EvaluateNumericExpression(a.ActionContextLogger, ctx, a._UseTTSVolumeExpression);
            vol *= (ctx.plug.cfg.TtsVolumeAdjustment / 100.0);
            if (vol < 0.0)
            {
                vol = 0.0;
            }
            if (vol > 100.0)
            {
                vol = 100.0;
            }
            double rate = ctx.EvaluateNumericExpression(a.ActionContextLogger, ctx, a._UseTTSRateExpression);
            if (rate < -10.0)
            {
                rate = -10.0;
            }
            if (rate > 10.0)
            {
                rate = 10.0;
            }
            mytts.Volume = (int)Math.Ceiling(vol);
            mytts.Rate = (int)Math.Ceiling(rate);
            mytts.SpeakAsync(text);
        }

        internal void SoundPlaybackSelf(Context ctx, Action a, string filename)
        {
            lock (SoundRepetitions)
            {
                if (RegisterRepetition(SoundRepetitions, cfg.SoundRepCooldown, filename) == false)
                {
                    return;
                }
            }
            WindowsMediaPlayer mywmp;
            if (a._PlaySoundExclusive == true)
            {
                mywmp = new WindowsMediaPlayer();
                lock (a.players) // verified
                {
                    a.players.Add(mywmp);
                }
                mywmp.MediaError += a.Mywmp_MediaError;
                mywmp.PlayStateChange += a.Mywmp_PlayStateChange;
            }
            else
            {
                mywmp = wmp;
            }
            double vol = ctx.EvaluateNumericExpression(a.ActionContextLogger, ctx, a._PlaySoundVolumeExpression);
            vol *= (ctx.plug.cfg.SfxVolumeAdjustment / 100.0);
            if (vol < 0.0)
            {
                vol = 0.0;
            }
            if (vol > 100.0)
            {
                vol = 100.0;
            }
            mywmp.URL = "";
            mywmp.settings.volume = (int)Math.Ceiling(vol);
            mywmp.URL = filename;
        }

        internal void TtsPlaybackExternal(Context ctx, Action a)
        {
            string proc = (cfg.TtsExternalApp ?? "").Trim();
            if (proc.Length == 0)
            {
                return;
            }
            string text = TtsPlaybackGetTextFromAction(ctx, a);
            lock (TtsRepetitions)
            {
                if (RegisterRepetition(TtsRepetitions, cfg.TtsRepCooldown, text) == false)
                {
                    return;
                }
            }
            string args = cfg.TtsExternalAppArgs ?? "";
            args = args.Replace("$source", text);
            Process.Start(proc, args);
        }

        internal void SoundPlaybackExternal(Context ctx, Action a, string filename)
        {
            lock (SoundRepetitions)
            {
                if (RegisterRepetition(SoundRepetitions, cfg.SoundRepCooldown, filename) == false)
                {
                    return;
                }
            }
            string proc = (cfg.SoundExternalApp ?? "").Trim();
            if (proc.Length == 0)
            {
                return;
            }
            string args = cfg.SoundExternalAppArgs ?? "";
            args = args.Replace("$source", filename);
            Process.Start(proc, args);
        }

        internal bool RegisterRepetition(Dictionary<string, DateTime> repstore, int cooldown, string item)
        {
            if (cooldown == 0)
            {
                return true;
            }
            if (repstore.TryGetValue(item, out DateTime last) == true)
            {
                if (last.AddMilliseconds(cooldown) > DateTime.Now)
                {
                    return false;
                }
            }
            repstore[item] = DateTime.Now;
            // clean old entries while we're here
            var olds = (from rx in repstore where rx.Value.AddMilliseconds(cooldown) < DateTime.Now select rx.Key).ToList();
            foreach (var old in olds)
            {
                repstore.Remove(old);
            }
            return true;
        }

        internal void TtsPlaybackSmart(Context ctx, Action a)
        {
            switch (a._TTSRouting)
            {
                case Configuration.AudioRoutingMethodEnum.None:
                    if (cfg.TtsMethod == Configuration.AudioRoutingMethodEnum.ExternalApplication)
                    {
                        TtsPlaybackExternal(ctx, a);
                    }
                    else if (cfg.TtsMethod == Configuration.AudioRoutingMethodEnum.ACT)
                    {
                        TtsPlaybackAct(ctx, a);
                    }
                    else if (cfg.TtsMethod == Configuration.AudioRoutingMethodEnum.Triggernometry)
                    {
                        TtsPlaybackSelf(ctx, a);
                    }
                    break;
                case Configuration.AudioRoutingMethodEnum.ACT:
                    TtsPlaybackAct(ctx, a);
                    break;
                case Configuration.AudioRoutingMethodEnum.Triggernometry:
                    TtsPlaybackSelf(ctx, a);
                    break;
            }
        }

        internal void SoundPlaybackSmart(Context ctx, Action a)
        {
            string filename = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._PlaySoundFileExpression);
            Uri u = new Uri(filename);
            if (u.IsFile == false)
            {
                string fn = Path.Combine(path, "TriggernometryRemoteSounds");
                if (Directory.Exists(fn) == false)
                {
                    Directory.CreateDirectory(fn);
                }
                string ext = Path.GetExtension(u.LocalPath);
                fn = Path.Combine(fn, GenerateHash(u.AbsoluteUri) + Path.GetExtension(u.LocalPath));
                bool fromcache = false;
                if (File.Exists(fn) == true)
                {
                    FileInfo fi = new FileInfo(fn);
                    DateTime dt = DateTime.Now.AddMinutes(0 - cfg.CacheSoundExpiry);
                    if (fi.LastWriteTime > dt)
                    {
                        filename = fn;
                        fromcache = true;
                    }
                }
                if (fromcache == false)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers["User-Agent"] = "Triggernometry Sound Retriever";
                        byte[] data = wc.DownloadData(u.AbsoluteUri);
                        File.WriteAllBytes(fn, data);
                        filename = fn;
                    }
                }
            }
            switch (a._SoundRouting)
            {
                case Configuration.AudioRoutingMethodEnum.None:
                    if (cfg.SoundMethod == Configuration.AudioRoutingMethodEnum.ExternalApplication)
                    {
                        SoundPlaybackExternal(ctx, a, filename);
                    }
                    else if (WMPUnavailable == true || cfg.SoundMethod == Configuration.AudioRoutingMethodEnum.ACT)
                    {
                        SoundPlaybackAct(ctx, a, filename);
                    }
                    else if (cfg.SoundMethod == Configuration.AudioRoutingMethodEnum.Triggernometry)
                    {
                        SoundPlaybackSelf(ctx, a, filename);
                    }
                    break;
                case Configuration.AudioRoutingMethodEnum.ACT:
                    SoundPlaybackAct(ctx, a, filename);
                    break;
                case Configuration.AudioRoutingMethodEnum.Triggernometry:
                    SoundPlaybackSelf(ctx, a, filename);
                    break;
            }
        }

    }
}
