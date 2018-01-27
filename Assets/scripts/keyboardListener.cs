using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.VR;
using System.Linq;

public class keyboardListener : MonoBehaviour
{
	private readonly List<Word> demWords = new List<Word>
	{
		new Word {Text = "kissa"},
		new Word {Text = "koira"},
		new Word {Text = "marsu"},
		new Word {Text = "olavi"}
	};

	private string inputWord;
	
	// Use this for initialization
	void Start () {
	}

//	private void OnGUI()
//	{
//		var e = Event.current;
//		if (e.type == EventType.KeyDown)
//		{
//			HandleKey(e.character.ToString());
//		
//		}
//	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("entterii");
			
			HandleReturn();
			return;
		}
		HandleText(Input.inputString);

		
	}

	private void HandleReturn()
	{
		inputWord = "";

		foreach (var word in demWords)
		{
			if (word.Text == inputWord)
			{
				// send shit
				
				
			}
			else
			{
				word.Clear();
			}
		}
	}

	private void HandleText(string character)
	{
		Debug.Log("merrki " + character);
		
		inputWord = inputWord + character;

		foreach (var word in demWords)
		{
			if(word.Text.Length >= inputWord.Length && word.CurrentIndex < word.Text.Length && !word.IsSent)
			{
				if (word.Text.ElementAt(word.CurrentIndex).ToString() == character)
				{
					word.HitCount++;
					word.CurrentIndex++;

				}
				else if (word.CurrentIndex != 0)
				{
					word.MissCount++;
					word.CurrentIndex++;
				}
					
				
				word.Points = word.HitCount / (word.HitCount + word.MissCount);
			}
		}
		
		Debug.Log("stringi " + inputWord );
	}
}
