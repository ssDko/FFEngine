using System;
using System.Collections.Generic;
using System.Text;

namespace TiledEngine.DatabaseObjects
{
    [Serializable]
    public class DBAnimation
    {
        #region Declarations
        private int id;
        private string name;
        private string image1;
        private string image2;
        private AnimationPosition position;
        private int maxFrames;

        private List<SoundFXandFlashTiming> soundFXandFlashTimings;

        private List<AnimationFrame> frames;
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image1 { get => image1; set => image1 = value; }
        public string Image2 { get => image2; set => image2 = value; }
        public AnimationPosition Position { get => position; set => position = value; }
        public int MaxFrames { get => maxFrames; set => maxFrames = value; }

        public List<SoundFXandFlashTiming> SoundFXandFlashTimings { get => soundFXandFlashTimings; set => soundFXandFlashTimings = value; }

        public List<AnimationFrame> Frames { get => frames; set => frames = value; }
        #endregion

        #region Constructor(s)
        public DBAnimation()
        {
            Id = 1;
            Name = "";
            Image1 = "";
            Image2 = "";
            Position = AnimationPosition.Center;
            MaxFrames = 1;

            SoundFXandFlashTimings = new List<SoundFXandFlashTiming>();
            Frames = new List<AnimationFrame>();

        }

        public DBAnimation(int id, 
                           string name, 
                           string image1, 
                           string image2, 
                           AnimationPosition position, 
                           int maxFrames, 
                           List<SoundFXandFlashTiming> soundFXandFlashTimings, 
                           List<AnimationFrame> frames)
        {
            Id = id;
            Name = name;
            Image1 = image1;
            Image2 = image2;
            Position = position;
            MaxFrames = maxFrames;
            SoundFXandFlashTimings = soundFXandFlashTimings;
            Frames = frames;
        }
        #endregion

        #region Methods

        #endregion

    }
}
