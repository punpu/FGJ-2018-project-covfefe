using UnityEngine;
using UnityEngineInternal;

namespace DefaultNamespace
{
    public class Word
    {
        public float HitCount { get; set; }
        public float MissCount { get; set; }
        public string Text { get; set; }
        public int CurrentIndex { get; set; }
        public bool IsSent { get; set; }
        public float Points { get; set; }
        
        public Word()
        {
            HitCount = 0;
            MissCount = 0;
            CurrentIndex = 0;
            Text = "";
            IsSent = false;
            Points = 0;

        }

        public void Clear()
        {
            HitCount = 0;
            MissCount = 0;
            CurrentIndex = 0;
        }
    }
}