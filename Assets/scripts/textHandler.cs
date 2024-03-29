﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Schema;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class textHandler : MonoBehaviour
{

	private Text text1;
	private Text text2;
	private Text text3;
	private Text text4;
	private Text text5;
	private Text text6;
	
	
	public static readonly List<Word> Words = new List<Word>
	{
		new Word {Text = "Satellite", Target = "satellite"},
		new Word {Text = "Spy", Target = "spy"},
		new Word {Text = "Television", Target = "television"},
		new Word {Text = "Telephone", Target = "telephone"},
		new Word {Text = "Satelliitti", Target = "satellite"},
		new Word {Text = "Vakooja", Target = "spy"},
		new Word {Text = "Oblong box", Target = "television"},
		new Word {Text = "Phone", Target = "telephone"},
		new Word {Text = "Fake moon", Target = "satellite"},
		new Word {Text = "FAKE NEWS", Target = "television"},
		new Word {Text = "Connecting People", Target = "telephone"},
		new Word {Text = "CHINA", Target = "spy"},
		new Word {Text = "SOVIET UNION", Target = "satellite"},
		new Word {Text = "Espionage", Target = "spy"},
		new Word {Text = "CNN news", Target = "television"},
		new Word {Text = "Twitter", Target = "telephone"},
		new Word {Text = "ACTIVISM", Target = "loudspeaker"},
		new Word {Text = "Protest", Target = "loudspeaker"},
		new Word {Text = "Protestors", Target = "loudspeaker"},
		new Word {Text = "Biggest Crowd", Target = "loudspeaker"},
        new Word {Text = "James Bond", Target = "spy"},
        new Word {Text = "Sean Connery", Target = "spy"},
        new Word {Text = "MIR station", Target = "satellite"},
        new Word {Text = "Collusion", Target = "television"},
        new Word {Text = "Bananaphone", Target = "telephone"},
        new Word {Text = "Death Star", Target = "satellite"},
        new Word {Text = "Angry mob", Target = "loudspeaker"},
        new Word {Text = "Give me shoes", Target = "loudspeaker"},
        new Word {Text = "Blackberry", Target = "telephone"},
        new Word {Text = "SMS scandal", Target = "telephone"},
        new Word {Text = "Is that a plane", Target = "satellite"},
        new Word {Text = "Fox news", Target = "television"},
        new Word {Text = "Comrade lmao", Target = "spy"},
        new Word {Text = "Where is my derringer", Target = "spy"},
        new Word {Text = "Out of my lawn", Target = "spy"},
        new Word {Text = "Racket", Target = "television"},
        new Word {Text = "Beauty pageant", Target = "television"},
        new Word {Text = "Power Word COVFEFE"}

	};

	public static List<Word> currentWords;
	private static List<Word> availableWords; 
	
	// Use this for initialization
	void Start ()
	{
		SetTexts();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SetTexts()
	{
		currentWords = new List<Word>();
		
		
		foreach (var word in Words)
		{
			word.IsSent = false;
		}
		
		availableWords = Words;
		
		addWord(GameObject.Find("Text1Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text2Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text3Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text4Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text5Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text6Container").GetComponentInChildren<Text>());
	}

	private void newWords()
	{
		
	}
	

	private static void addWord(Text uiText)
	{
		
		
		if (availableWords.Count <= 0) return;
		var indx = Random.Range(0, availableWords.Count);
	
		uiText.text = availableWords.ElementAt(indx).Text;
		
        //uiText.color = Color(DECD0EFF);
        Color myColor = new Color32(0xDE, 0xCD, 0x0E, 0xFF);
        uiText.color = myColor;
		availableWords.ElementAt(indx).textObject = uiText;
		currentWords.Add(availableWords.ElementAt(indx));
		availableWords.RemoveAt(indx);
	}
}
