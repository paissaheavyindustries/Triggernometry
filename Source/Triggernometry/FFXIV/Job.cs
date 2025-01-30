using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Triggernometry.FFXIV
{
    public partial class Job
    {
        public readonly static Job EmptyJob = new Job() { JobType = JobEnum.None };
        public JobEnum JobType { get; private set; }
        public int JobID => (int)JobType; // actually byte
        public int DefaultOrder { get; private set; }
        public string NameCN { get; private set; }
        public string NameDE { get; private set; }
        public string NameEN { get; private set; }
        public string NameFR { get; private set; }
        public string NameJP { get; private set; }
        public string NameKR { get; private set; }
        public string NameTCN { get; private set; } // Not really "traditional", but could be displayed in the global server.
        public string NameCN1 { get; private set; }
        public string NameCN2 { get; private set; }
        public string NameEN3 => JobType.ToString();
        public string NameJP1 { get; private set; }
        public string NameTCN1 { get; private set; }
        public string NameTCN2 { get; private set; }
        public RoleType SubRole { get; private set; }
        public RoleType Role => SubRole & RoleType.MainRole;
        public bool IsTank => Role == RoleType.Tank;
        public bool IsHealer => Role == RoleType.Healer;
        public bool IsDPS => Role == RoleType.DPS;
        public bool IsMeleeDPS => SubRole == RoleType.StrengthMelee || SubRole == RoleType.DexterityMelee;
        public bool IsRangedDPS => SubRole == RoleType.PhysicalRanged || SubRole == RoleType.MagicalRanged;
        public bool IsCrafter => Role == RoleType.Crafter;
        public bool IsGatherer => Role == RoleType.Gatherer;

        public enum RoleType
        {
            None = 0,
            Tank = 8,
            Healer = 16,
            DPS = 24,
            Crafter = 32,
            Gatherer = 48,
            MainRole = 56,

            // leave blank integers for possible future changes
            PureHealer = Healer | 1,
            FlexHealer = Healer | 2, // in case added back
            BarrierHealer = Healer | 3,
            StrengthMelee = DPS | 1,
            DexterityMelee = DPS | 2,
            PhysicalRanged = DPS | 4,
            MagicalRanged = DPS | 6,
        }

        private static List<Job> _jobs = new List<Job>();
        private static Dictionary<string, Job> _jobByNames = new Dictionary<string, Job>(StringComparer.OrdinalIgnoreCase);

        /// <summary>Retrieve a Job object using a JobEnum identifier.</summary>
        /// <param name="job">The job enum value.</param>
        /// <returns>The Job object.</returns>
        public static Job GetJob(JobEnum job) => GetJob((int)job);

        /// <summary>Retrieve a Job object using a numeric job ID.</summary>
        /// <param name="jobID">The integer job ID.</param>
        /// <returns>The Job object.</returns>
        /// <exception cref="ArgumentException">Thrown if the job ID is out of the valid range.</exception>
        public static Job GetJob(int jobID) => jobID >= 0 && jobID < _jobs.Count
            ? _jobs[jobID]
            : throw new ArgumentException(I18n.Translate("FFXIV/Job/UnknownJobId", "The job ID ({0}) is out of range.", jobID));

        /// <summary>Retrieve a Job object by its name, abbreviation or JobID index in any language.</summary>
        /// <param name="name">The name, abbreviation or JobID index of the job.</param>
        /// <returns>The Job object.</returns>
        /// <exception cref="ArgumentException">Thrown if the job name is not known.</exception>
        public static Job GetJob(string name) => _jobByNames.TryGetValue(name, out Job job)
            ? job
            : throw new ArgumentException(I18n.Translate("FFXIV/Job/UnknownJobName", "The job name ({0}) is not a known job.", name));

        /// <summary>Try to retrieve a Job object using a JobEnum identifier.</summary>
        /// <param name="job">The job enum value.</param>
        /// <param name="result">Outputs the Job object if found.</param>
        /// <returns>True if the job is successfully found.</returns>
        public static bool TryGetJob(JobEnum job, out Job result) => TryGetJob((int)job, out result);

        /// <summary>Try to retrieve a Job object using a numeric job ID.</summary>
        /// <param name="jobID">The integer job ID.</param>
        /// <param name="result">Outputs the Job object if found.</param>
        /// <returns>True if the job is successfully found.</returns>
        public static bool TryGetJob(int jobID, out Job result)
        {
            if (jobID >= 0 && jobID < _jobs.Count)
            {
                result = _jobs[jobID];
                return true;
            }
            result = null;
            return false;
        }

        /// <summary>Try to retrieve a Job object by its name, abbreviation, or JobID index in any language.</summary>
        /// <param name="name">The name, abbreviation or JobID index of the job.</param>
        /// <param name="result">Outputs the Job object if found.</param>
        /// <returns>True if the job is successfully found.</returns>
        public static bool TryGetJob(string name, out Job result) => _jobByNames.TryGetValue(name, out result);

        /// <summary> All property names that could be used to query a property. </summary>
        public static IEnumerable<string> LegalJobPropNames => _propAccessors.Keys;

        private static Dictionary<string, Func<Job, object>> _propAccessors 
            = new Dictionary<string, Func<Job, object>>(StringComparer.OrdinalIgnoreCase)
        {
            { "Role",       job => job.Role },
            { "SubRole",    job => job.SubRole },
            { "RoleID",     job => (int)job.SubRole },
            { "IsT",        job => job.IsTank },
            { "IsH",        job => job.IsHealer },
            { "IsTH",       job => job.IsTank || job.IsHealer },
            { "IsD",        job => job.IsDPS  },
            { "IsM",        job => job.IsMeleeDPS },
            { "IsR",        job => job.IsRangedDPS },
            { "IsTM",       job => job.IsTank || job.IsMeleeDPS },
            { "IsHR",       job => job.IsHealer || job.IsRangedDPS },
            { "IsC",        job => job.IsCrafter },
            { "IsG",        job => job.IsGatherer },
            { "IsCG",       job => job.IsCrafter || job.IsGatherer },
            { "JobID",      job => job.JobID },
            { "JobCN",      job => job.NameCN },
            { "JobDE",      job => job.NameDE },
            { "JobEN",      job => job.NameEN },
            { "JobFR",      job => job.NameFR },
            { "JobJP",      job => job.NameJP },
            { "JobKR",      job => job.NameKR },
            { "JobTCN",     job => job.NameTCN },
            { "JobCN1",     job => job.NameCN1 },
            { "JobCN2",     job => job.NameCN2 },
            { "Job",        job => job.NameEN3 },
            { "JobEN3",     job => job.NameEN3 },
            { "JobJP1",     job => job.NameJP1 },
            { "JobTCN1",    job => job.NameTCN1 },
            { "JobTCN2",    job => job.NameTCN2 }
        };

        /// <summary>Query a property of the Job object based on the specified property name (case-insensitive).</summary>
        /// <param name="propName">The name of the property to query, case-insensitive.</param>
        /// <returns>The value of the property as a string. Boolean values are represented as 0 or 1.</returns>
        /// <exception cref="ArgumentException">Thrown if the property name is not valid.</exception>
        public string QueryProperty(string propName) => TryQueryProperty(propName, out string result) ? result
            : throw new ArgumentException(I18n.Translate("FFXIV/Job/UnknownJobProperty", "The job property ({0}) is not valid.", propName));

        /// <summary>Try to query a property of the Job object based on the specified property name (case-insensitive).</summary>
        /// <param name="propName">The name of the property to query, case-insensitive.</param>
        /// <param name="result">Outputs the property as a string if found.</param>
        /// <returns>True if the property is successfully found.</returns>
        public bool TryQueryProperty(string propName, out string result)
        {
            if (_propAccessors.TryGetValue(propName, out Func<Job, object> accessor))
            {
                result = accessor(this).ToDataString();
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

    }
}