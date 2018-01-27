using UnityEngine;
using UnityEngineInternal;

namespace DefaultNamespace
{
    public class Word
    {
        public float HitCount { get; set; }
        public float MissCount { get; set; }
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