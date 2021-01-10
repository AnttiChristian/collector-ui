using System;
using System.Collections.Generic;
using System.Text;

namespace Collector.Formats.Tapes
{
    /// <summary>
    /// This format must be designed to merge all other formats together to provide one and only generic cassette tape format.
    /// Simply stereo wav file with different data encoding methods focusing on size of resulting file.
    /// Digital data should support conversions like in TZX , audio data than flac or wav or mp3 encodings.
    /// </summary>
    public class Cassette
    {
        /// <summary>
        /// 
        /// </summary>
        public const string LongExtension = "cassette";

        /// <summary>
        /// 
        /// </summary>
        public const string ShortExtension = "cas";

        /// <summary>
        /// 
        /// </summary>
        public List<Track> Tracks { get; } = new();
    }
}
