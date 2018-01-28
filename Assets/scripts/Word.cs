using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;


    public class Word
    {
        public float HitCount { get; set; }
        public float MissCount { get; set; }
        public string Text { get; set; }
        public int CurrentIndex { get; set; }
        public bool IsSent { get; set; }
        public float Points { get; set; }
        public string Target { get; set; }
        public Text textObject { get; set; }
        public bool IsOnList { get; set; }
        
        public Word()
        {
            HitCount = 0;
            MissCount = 0;
            CurrentIndex = 0;
            Text = "";
            IsSent = false;
            Points = 0;
            IsOnList = false;

        }

        public void Clear()
        {
            HitCount = 0;
            MissCount = 0;
            CurrentIndex = 0;
        }
    }
