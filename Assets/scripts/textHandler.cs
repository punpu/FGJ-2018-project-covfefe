using System.Collections;
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
		new Word {Text = "satellite", Target = "satellite"},
		new Word {Text = "spy", Target = "spy"},
		new Word {Text = "television", Target = "television"},
		new Word {Text = "telephone", Target = "telephone"},
		new Word {Text = "satelliitti", Target = "satellite"},
		new Word {Text = "vakooja", Target = "spy"},
		new Word {Text = "Oblong box", Target = "television"},
		new Word {Text = "phone", Target = "telephone"},
		new Word {Text = "fake moon", Target = "satellite"},
		new Word {Text = "fake news", Target = "television"},
		new Word {Text = "connecting people", Target = "telephone"},
		new Word {Text = "china", Target = "spy"},
		new Word {Text = "soviet union", Target = "satellite"},
		new Word {Text = "espionage", Target = "spy"},
		new Word {Text = "CNN news", Target = "television"},
		new Word {Text = "twitter", Target = "telephone"}
		
	};

	public static List<Word> currentWords;
	
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
		
		addWord(GameObject.Find("Text1Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text2Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text3Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text4Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text5Container").GetComponentInChildren<Text>());
		addWord(GameObject.Find("Text6Container").GetComponentInChildren<Text>());

		var testi = currentWords;
	}
	

	private static void addWord(Text uiText)
	{
		if (Words.Count <= 0) return;
		var indx = Random.Range(0, Words.Count - 1);
		uiText.text = Words.ElementAt(indx).Text;
		uiText.color = Color.black;
		Words.ElementAt(indx).textObject = uiText;
		currentWords.Add(Words.ElementAt(indx));
		Words.RemoveAt(indx);
	}
}
