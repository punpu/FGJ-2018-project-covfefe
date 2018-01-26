using UnityEngine;
using UnityEngineInternal;

namespace DefaultNamespace
{
    public class Word
    {
        public int HitCount { get; set; }
        public int MissCount { get; set; }
        public string Text { get; set; }
        public int currentIndex { get; set; }
        public Word()
        {
            HitCount = 0;
            MissCount = 0;
            currentIndex = 0;
            Text = "";
        }
    }
}