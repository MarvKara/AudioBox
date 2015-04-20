using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Audiobox_Server.Modules.SessionManagement.Objects
{
    /// <summary>
    /// Represents a Track consisting of an mp3-file
    /// #######################################################
    /// Copyright: Marvin Karaschewski, Stenden Hogeschool 2013
    /// </summary>
    class Mp3Track : Track
    {
        public string Filename{ get; set; }

        /// <summary>
        /// Default constructor for an Mp3-Track
        /// </summary>
        /// <param name="filename">The filename as on harddisk</param>
        public Mp3Track(string filename, string id)
        {
            this.Filename = filename;
            base.Id = id;
            base.Title = Path.GetFileNameWithoutExtension(filename);
            base.Upvotes = 0;
            base.Downvotes = 0;
        }
    }
}
