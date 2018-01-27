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
		new Word {Text = "marsu"},
		new Word {Text = "olavi"},
		new Word {Text = "satelliitti", Target = "satellite"},
		new Word {Text = "mursu", Target = "spy"},
		new Word {Text = "ilmari"},
		new Word {Text = "jarno"},
		new Word {Text = "kuu", Target = "satellite"},
		new Word {Text = "japani", Target = "spy"},
		new Word {Text = "kanada"},
		new Word {Text = "karstula"},
		new Word {Text = "tommi lantinen", Target = "satellite"},
		new Word {Text = "huhuu", Target = "spy"},
		new Word {Text = "tirppa"},
		new Word {Text = "hullu"}
		
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
		var indx = Random.Range(0, Words.Count - 1);
		uiText.text = Words.ElementAt(indx).Text;
		uiText.color = Color.black;
		Words.ElementAt(indx).textObject = uiText;
		currentWords.Add(Words.ElementAt(indx));
		Words.RemoveAt(indx);
	}
}
