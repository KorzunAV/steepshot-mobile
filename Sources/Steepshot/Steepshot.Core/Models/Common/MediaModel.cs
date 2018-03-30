﻿
namespace Steepshot.Core.Models.Common
{
    public class MediaModel
    {
        public Thumbnails Thumbnails { get; set; }

        public string Url { get; set; }

        public string IpfsHash { get; set; }

        public FrameSize Size { get; set; }
    }
}
