﻿// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.Collections.Specialized;
using System.Text;
using System.IO;

namespace OSU_player
{
    public class Beatmap
    {

        public string location;
        public string name;
        public string path;
        private string osb;
        public struct Timing
        {
            public int offset;
            public double bpm;
            public int meter;
            public CSample sample;
            public int volume;
            public int type;
            public int kiai;
        }
        public struct note
        {
            public int x;
            public int y;
        }
        public struct HitObject
        {
            public int x;
            public int y;
            public int starttime;
            public ObjectFlag type;
            public int allhitsound;
            public int EndTime;
            public CSample sample;
            public CSample A_sample;
            public char slidertype;
            public note[] slidernodes;
            public int repeatcount;
            public double length;
            public List<int> Hitsounds;
            public List<CSample> samples;
            public List<CSample> A_samples;
        }
        public enum modes
        {
            All = 0,
            Taiko = 1,
            CTB = 2,
            Mania = 3
        }
        public string[] Rawdata = new string[(int)OSUfile.OSUfilecount];
        public string FileVersion
        {
            get
            {
                return Rawdata[(int)OSUfile.FileVersion];
            }
        }
        public string Audio
        {
            get
            {
                return Rawdata[(int)OSUfile.AudioFilename];
            }
        }
        public int Previewtime
        {
            get
            {
                if (Rawdata[(int)OSUfile.PreviewTime] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.PreviewTime]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public string SampleSet
        {
            get
            {
                if (Rawdata[(int)OSUfile.SampleSet] != "")
                {
                    return Rawdata[(int)OSUfile.SampleSet];
                }
                else
                {
                    return "Normal";
                }
            }
        }
        public modes Mode
        {
            get
            {
                if (Rawdata[(int)OSUfile.Mode] != "")
                {

                    return (modes)Enum.Parse(typeof(modes), Rawdata[(int)OSUfile.Mode]);
                }
                else
                {
                    return modes.All;
                }
            }
        }
        public string Artist
        {
            get
            {
                if (Rawdata[(int)OSUfile.ArtistUnicode] != "")
                {
                    return Rawdata[(int)OSUfile.ArtistUnicode];
                }
                else
                {
                    return (Rawdata[(int)OSUfile.Artist]);
                }
            }
        }
        public string ArtistRomanized
        {
            get
            {
                if (Rawdata[(int)OSUfile.Artist] != "")
                {
                    return Rawdata[(int)OSUfile.Artist];
                }
                else
                {
                    return "<unknown artist>";
                }
            }
        }
        public string Title
        {
            get
            {
                if (Rawdata[(int)OSUfile.TitleUnicode] != "")
                {
                    return Rawdata[(int)OSUfile.TitleUnicode];
                }
                else
                {
                    return (Rawdata[(int)OSUfile.Title]);
                }
            }
        }
        public string TitleRomanized
        {
            get
            {
                if (Rawdata[(int)OSUfile.Title] != "")
                {
                    return Rawdata[(int)OSUfile.Title];
                }
                else
                {
                    return "<unknown title>";
                }
            }
        }
        public string Creator
        {
            get
            {
                return Rawdata[(int)OSUfile.Creator];
            }
        }
        public string Version
        {
            get
            {
                return Rawdata[(int)OSUfile.Version];
            }
        }
        public string Source
        {
            get
            {
                if (Rawdata[(int)OSUfile.Source] != "")
                {
                    return Rawdata[(int)OSUfile.Source];
                }
                else
                {
                    return "<unknown source>";
                }
            }
        }
        private string tags;
        private List<string> I_tagList = new List<string>();
        public List<string> Taglist
        {
            get
            {
                return I_tagList;
            }
        }
        public int beatmapId
        {
            get
            {
                if (Rawdata[(int)OSUfile.BeatmapID] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.BeatmapID]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int beatmapsetId
        {
            get
            {
                if (Rawdata[(int)OSUfile.BeatmapSetID] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.BeatmapSetID]);
                }
                else
                {
                    return -1;
                }
            }
        }
        public int HPDrainRate
        {
            get
            {
                if (Rawdata[(int)OSUfile.HPDrainRate] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.HPDrainRate]);
                }
                else
                {
                    return 5;
                }
            }
        }
        public int CircleSize
        {
            get
            {
                if (Rawdata[(int)OSUfile.CircleSize] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.CircleSize]);
                }
                else
                {
                    return 5;
                }
            }
        }
        public int OverallDifficulty
        {
            get
            {
                if (Rawdata[(int)OSUfile.OverallDifficulty] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.OverallDifficulty]);
                }
                else
                {
                    return 5;
                }
            }
        }
        public int ApproachRate
        {
            get
            {
                if (Rawdata[(int)OSUfile.ApproachRate] != "")
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.ApproachRate]);
                }
                else
                {
                    return Convert.ToInt32(Rawdata[(int)OSUfile.OverallDifficulty]);
                }
            }
        }
        public double SliderMultiplier
        {
            get
            {
                if (Rawdata[(int)OSUfile.SliderMultiplier] != "")
                {
                    return Convert.ToDouble(Rawdata[(int)OSUfile.SliderMultiplier]);
                }
                else
                {
                    return 1;
                }
            }
        }
        public double SliderTickRate
        {
            get
            {
                if (Rawdata[(int)OSUfile.SliderTickRate] != "")
                {
                    return Convert.ToDouble(Rawdata[(int)OSUfile.SliderTickRate]);
                }
                else
                {
                    return 1;
                }
            }
        }
        public string background = "";
        public string backgroundOffset = "";
        public string Video;
        public int VideoOffset;
        //diff-wide storyboard
        public StoryBoard SB;
        //TimingPoints
        public List<Timing> timingpoints = new List<Timing>();
        //HitObjects
        public List<HitObject> HitObjects = new List<HitObject>();
        public bool haveSB = false;
        public bool haveVideo = false;
        private List<string> tmpSB = new List<string>();
        private string picknext(ref string str)
        {
            string ret = "";
            if (!str.Contains(","))
            {
                ret = str;
                str = "";
            }
            else
            {
                ret = str.Substring(0, str.IndexOf(","));
                str = str.Substring(str.IndexOf(",") + 1);
            }
            return ret;
        }
        private ObjectFlag check(string op)
        {
            int tmp = Convert.ToInt32(op);
            if (((tmp >> 0) & 1) == 1)
            {
                return ObjectFlag.Normal;
            }
            if (((tmp >> 1) & 1) == 1)
            {
                return ObjectFlag.Slider;
            }
            if (((tmp >> 3) & 1) == 1)
            {
                return ObjectFlag.Spinner;
            }
            return ObjectFlag.ColourHax;
        }
        public enum osuFileScanStatus
        {
            FORMAT_UNKNOWN,
            GENERAL,
            EDITOR,
            METADATA,
            DIFFICULTY,
            VARIABLES,
            EVENTS,
            TIMINGPOINTS,
            COLOURS,
            HITOBJECTS
        }
        public void GetDetail()
        {
            path = System.IO.Path.Combine(location, name);
            List<string> content = new List<string>();
            content.AddRange(File.ReadAllLines(path));
            if (osb != "")
            {
                content.AddRange(File.ReadAllLines(System.IO.Path.Combine(location, osb)));
            }
            osuFileScanStatus position = new osuFileScanStatus();
            try
            {
                position = osuFileScanStatus.FORMAT_UNKNOWN;
                foreach (string row in content)
                {
                    if (row.Trim() == "")
                    {
                        continue;
                    }
                    if (row.StartsWith("//") || row.Length == 0)
                    {
                        continue;
                    }
                    if (row.StartsWith("["))
                    {
                        position = (osuFileScanStatus)Enum.Parse(typeof(osuFileScanStatus),(row.Substring(1, row.Length - 2).ToUpper()));
                        if (position == osuFileScanStatus.EVENTS)
                        {
                            tmpSB.Add("[Events]");
                        }
                        if (position == osuFileScanStatus.VARIABLES)
                        {
                            tmpSB.Add("[Variables]");
                        }
                        continue;
                    }
                    switch (position)
                    {
                        case osuFileScanStatus.FORMAT_UNKNOWN:
                            Rawdata[(int)OSUfile.FileVersion] = row.Substring(17);
                            break;
                        case osuFileScanStatus.GENERAL:
                        case osuFileScanStatus.METADATA:
                        case osuFileScanStatus.EDITOR:
                        case osuFileScanStatus.DIFFICULTY:
                            string[] s = row.Split(new char[] { ':' }, 2);
                            Rawdata[(int)(OSUfile)Enum.Parse(typeof(OSUfile), (s[0].Trim()))] = s[1].Trim();
                            break;
                        case osuFileScanStatus.EVENTS:
                            if (row.StartsWith("0,0,"))
                            {
                                string str = row.Substring(5, row.Length - 6);
                                if (str.Contains("\""))
                                {
                                    backgroundOffset = str.Substring(str.IndexOf("\"") + 2);
                                    str = str.Substring(0, str.IndexOf("\""));
                                }
                                background = str;
                            }
                            else if (row.StartsWith("1,") || row.StartsWith("Video"))
                            {
                                haveVideo = true;
                                string[] vdata = row.Split(new char[] { ',' });
                                VideoOffset = Convert.ToInt32(vdata[1]);
                                Video = vdata[2].Substring(1, System.Convert.ToInt32(vdata[2].Length - 2));
                            }
                            else if (row.StartsWith("3,") || row.StartsWith("2,"))
                            {
                                break;
                            }
                            else
                            {
                                tmpSB.Add(row);
                                haveSB = true;
                            }
                            break;
                        case osuFileScanStatus.VARIABLES:
                            tmpSB.Add(row);
                            break;
                        case osuFileScanStatus.TIMINGPOINTS:
                            Timing tmp = new Timing();
                            string tmpop;
                            tmpop = "";
                            string row_t = row;
                            tmp.offset = (int)(Convert.ToDouble(picknext(ref row_t)));
                            tmp.bpm = Convert.ToDouble(picknext(ref row_t));
                            tmpop = picknext(ref row_t);
                            if (tmpop == "")
                            {
                                tmp.meter = 4;
                            }
                            else
                            {
                                tmp.meter = Convert.ToInt32(tmpop);
                            }
                            tmpop = picknext(ref row_t);
                            if (tmpop == "")
                            {
                                tmp.sample = new CSample((int)TSample.Normal, 0);
                            }
                            else
                            {
                                tmp.sample = new CSample((int)(TSample)Enum.Parse(typeof(TSample), tmpop), Convert.ToInt32(picknext(ref row_t)));
                            }
                            tmpop = picknext(ref row_t);
                            if (tmpop == "")
                            {
                                tmp.volume = 100;
                            }
                            else
                            {
                                tmp.volume = Convert.ToInt32(tmpop);
                            }
                            tmpop = picknext(ref row_t);
                            if (tmpop == "")
                            {
                                tmp.type = 1;
                            }
                            else
                            {
                                tmp.type = Convert.ToInt32(tmpop);
                            }
                            tmpop = picknext(ref row_t);
                            if (tmpop == "")
                            {
                                tmp.kiai = 0;
                            }
                            else
                            {
                                tmp.kiai = Convert.ToInt32(tmpop);
                            }
                            if (tmp.type == 1)
                            {
                                tmp.bpm = 60000 / tmp.bpm;
                            }
                            else
                            {
                                tmp.bpm = -100 / tmp.bpm;
                            }
                            timingpoints.Add(tmp);
                            break;
                        case osuFileScanStatus.HITOBJECTS:
                            HitObject tmpo = new HitObject();
                            tmpop = "";
                            row_t = row;
                            tmpo.x = Convert.ToInt32(picknext(ref row_t));
                            tmpo.y = Convert.ToInt32(picknext(ref row_t));
                            tmpo.starttime = Convert.ToInt32(picknext(ref row_t));
                            if (check(picknext(ref row_t)) == ObjectFlag.Normal)
                            {
                                tmpo.allhitsound = Convert.ToInt32(picknext(ref row_t));
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    if (tmpop.Length > 3)
                                    {
                                        tmpo.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[4]));
                                        if (tmpop.Length < 7)
                                        {
                                            tmpop = tmpop + ":0:";
                                        }
                                        tmpo.A_sample = new CSample(Convert.ToInt32(tmpop[2]), Convert.ToInt32(tmpop[6]));
                                    }
                                    else
                                    {
                                        tmpo.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[2]));
                                        tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                    }
                                }
                                else
                                {
                                    tmpo.sample = new CSample((int)TSample.Normal, 0);
                                    tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                }
                            }
                            else if (check(picknext(ref row_t)) == ObjectFlag.Spinner)
                            {
                                tmpo.allhitsound = Convert.ToInt32(picknext(ref row_t));
                                tmpo.EndTime = Convert.ToInt32(picknext(ref row_t));
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    if (tmpop.Length > 3)
                                    {
                                        tmp.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[4]));
                                        if (tmpop.Length < 7)
                                        {
                                            tmpop = tmpop + ":0:";
                                        }
                                        tmpo.A_sample = new CSample(Convert.ToInt32(tmpop[2]), Convert.ToInt32(tmpop[6]));
                                    }
                                    else
                                    {
                                        tmpo.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[2]));
                                        tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                    }
                                }
                                else
                                {
                                    tmpo.sample = new CSample((int)TSample.Normal, 0);
                                    tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                }
                            }
                            else if (check(picknext(ref row_t)) == ObjectFlag.Slider)
                            {
                                tmpo.allhitsound = Convert.ToInt32(picknext(ref row_t));
                                tmpop = picknext(ref row_t);
                                //ignore all anthor
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    tmpo.repeatcount = Convert.ToInt32(tmpop);
                                }
                                else
                                {
                                    tmpo.repeatcount = 0;
                                }
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    tmpo.length = Convert.ToDouble(tmpop);
                                }
                                else
                                {
                                    tmpo.length = 0;
                                }
                                tmpop = picknext(ref row_t);
                                tmpo.Hitsounds = new List<int>();
                                tmpo.samples = new List<CSample>();
                                tmpo.A_samples = new List<CSample>();
                                if (tmpop != "")
                                {
                                    foreach (string str in tmpop.Split(new char[] { '|' }))
                                    {
                                        tmpo.Hitsounds.Add(Convert.ToInt32(str));
                                    }
                                }
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    foreach (string str in tmpop.Split(new char[] { '|' }))
                                    {
                                        tmpo.samples.Add(new CSample(Convert.ToInt32(str[0]), 0));
                                        tmpo.A_samples.Add(new CSample(Convert.ToInt32(str[2]), 0));
                                    }
                                }
                                tmpop = picknext(ref row_t);
                                if (tmpop != "")
                                {
                                    if (tmpop.Length > 3)
                                    {
                                        tmpo.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[4]));
                                        if (tmpop.Length < 7)
                                        {
                                            tmpop = tmpop + ":0:";
                                        }
                                        tmpo.A_sample = new CSample(Convert.ToInt32(tmpop[2]), Convert.ToInt32(tmpop[6]));
                                    }
                                    else
                                    {
                                        tmpo.sample = new CSample(Convert.ToInt32(tmpop[0]), Convert.ToInt32(tmpop[2]));
                                        tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                    }
                                }
                                else
                                {
                                    tmpo.sample = new CSample((int)TSample.Normal, 0);
                                    tmpo.A_sample = new CSample((int)TSample.Normal, 0);
                                }
                                //HitSound,(SampleSet&Addition|SampleSet&Addition),(All SampleSet&Addition)
                                //SampleSet&Addition 只有sample没有setcount
                                //All SampleSet&Addition 啥都有
                                //数值1为不反复
                                //Length=长度（乘以每小节时间60000/BPM再乘以滑条速度SliderMultiplier为滑条时间长度）
                                //HitSound S1|S2|S3|S4......Sn 计算公式n=RepeatCount+1
                            }
                            else
                            {
                                //Throw New FormatException("Failed to read .osu file")
                                //this is for mania
                            }
                            break;

                    }
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.StackTrace);
                throw (new FormatException("Failed to read .osu file", e));
            }
            tags = Rawdata[(int)OSUfile.Tags];
            if (tags != "")
            {
                foreach (string s in tags.Split(new char[] { ' ' }))
                {
                    I_tagList.Add(s);
                }
            }
            if (haveSB)
            {
                SB = new StoryBoard(tmpSB);
            }
        }
        public Beatmap(string location_F, string name_F, string osb_F)
        {
            location = location_F;
            name = name_F;
            osb = osb_F;
        }
        public override string ToString()
        {
            return ArtistRomanized + " - " + TitleRomanized + " (" + Creator + " ) [" + Version + "]";
        }
        //-1 if this beatmap's artist is before the other beatmap's artist
        //0 if this beatmap's artist AND the beatmap's title is before the other beatmap's artist/title
        //1 if this beatmap's artist is after the other beatmap's artist
        public int CompareTo(Beatmap other)
        {
            int artist = this.ArtistRomanized.CompareTo(other.ArtistRomanized);
            if (artist == 0)
            {
                return this.TitleRomanized.CompareTo(other.TitleRomanized);
            }
            else
            {
                return artist;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Beatmap)
            {
                Beatmap b = (Beatmap)obj;
                if ((b.beatmapId == beatmapId) && (beatmapId != 0))
                {
                    return true;
                }
                return this.ToString().Equals(b.ToString()) && this.Creator.Equals(b.Creator);
            }
            else
            {
                return false;
            }
        }
        public string difftostring()
        {
            return Version;
        }

        public string tmpop { get; set; }
    }
}
