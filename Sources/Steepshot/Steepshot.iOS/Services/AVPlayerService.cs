using System;
using AVFoundation;
using Steepshot.iOS.Cells;

namespace Steepshot.iOS.Services
{
    public class AVPlayerService
    {
        private static AVPlayerService thisRef;

        public AVPlayer AVPlayer;
        public NewFeedCollectionViewCell container;

        public static AVPlayerService Instance
        { 
            get
            {
                if (thisRef == null)
                    thisRef = new AVPlayerService();

                return thisRef;
            }
        }

        public AVPlayerService() { }
    }
}
