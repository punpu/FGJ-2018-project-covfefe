using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.VR;
using System.Linq;
using Debug = UnityEngine.Debug;

public class keyboardListener : MonoBehaviour
{
	private GameObject satellite;

	private List<Word> demWords;

	private string inputWord;
	
	// Use this for initialization
	void Start ()
	{
		demWords = textHandler.currentWords;
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
			HandleReturn();
			return;
		}
		HandleText(Input.inputString);

		
	}

	private void HandleReturn()
	{	
		foreach (var word in demWords)
		{
			if (word.Text == inputWord && !word.IsSent)
			{
				var target = GameObject.Find(word.Target);
				
				if(target != null) target.SendMessage("Activate");
				word.IsSent = true;
				word.textObject.color = Color.red;
			}
			else
			{
				word.Clear();
			}
		}

		demWords.RemoveAll(x => x.IsSent);

		if (demWords.Count == 0)
		{
			textHandler.SetTexts();
			demWords = textHandler.currentWords;
		}
		
		inputWord = "";
	}

	private void HandleText(string character)
	{	
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
	}
}
