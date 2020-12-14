using Collector.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Collector.Import
{
    public class RedumpDataMiner
    {
        private ReleaseEntity GetRelease(DumpEntity dump)
        {
            var nameParts = dump.Name.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new ReleaseEntity
            {
                Name = nameParts[0],
                Region = nameParts[1]
            };

            if (nameParts.Length > 2)
            {
                for (var i = 2; i < nameParts.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(nameParts[i])) continue;

                    var modifierType = (nameParts[i]) switch
                    {
                        "Demo" => "Demo",
                        "Alt" => "Alternative",
                        _ => "Unknown",
                    };

                    if (nameParts[i].StartsWith("Rev"))
                    {
                        modifierType = "Release";
                    }

                    dump.Modifiers.Add(new DumpModifierEntity
                    {
                        Description = nameParts[i],
                        ModType = modifierType
                    });
                }
            }

            return result;
        }

        public IEnumerable<ReleaseEntity> GetReleases(IEnumerable<DumpEntity> dumpEntities)
        {
            var result = new List<ReleaseEntity>();

            foreach (DumpEntity dump in dumpEntities)
            {
                ReleaseEntity release = GetRelease(dump);
                ReleaseEntity? existingRelease = result.FirstOrDefault(r => r.Name == release.Name && r.Region == release.Region);
                if (existingRelease == null)
                {
                    release.Dumps.Add(dump);
                    result.Add(release);
                }
                else
                {
                    existingRelease.Dumps.Add(dump);
                }
            }

            return result;
        }
    }
}
