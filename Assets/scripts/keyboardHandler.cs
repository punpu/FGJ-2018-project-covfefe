using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.WSA;
using Debug = UnityEngine.Debug;


public class keyboardHandler : MonoBehaviour
{
	private readonly List<Word> demWords = new List<Word>
	{
		new Word {Text = "kissa"},
		new Word {Text = "koira"},
		new Word {Text = "marsu"},
		new Word {Text = "olavi"}
	};

	private string previousWord;

	private UnityEvent valueChangeEvent;	
// Use this for initialization
	void Start () {
		if (GetComponent<InputField>() != null)
		{
			GetComponent<InputField>().onValueChanged.AddListener(delegate { HandleInput(); });
			
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	//	HandleInput();
	}

	private void HandleInput()
	{		
		var playerInput = GetComponent<InputField>();
		var currentChar = String.Empty;
		
		if (playerInput == null) return;
		
		Debug.Log("previosWord " + previousWord);
		
		if (!String.IsNullOrEmpty(previousWord))
		{
			if (previousWord.Length >= playerInput.text.Length)
			{
				playerInput.text = previousWord;
				playerInput.MoveTextEnd(false);
				return;
			}

			currentChar = playerInput.text.Replace(previousWord, "");
			
		}
		else
		{
			currentChar = playerInput.text;
		}
		Debug.Log("Current word " + playerInput.text);
		
		Debug.Log("Current Char " + currentChar);

		foreach (var word in demWords)
			{
				if(word.Text.Length >= playerInput.text.Length)
				{
					if (word.Text.ElementAt(word.currentIndex).ToString() == currentChar)
					{
						word.HitCount++;
						word.currentIndex++;

					}
					else if (word.currentIndex != 0)
					{
						word.MissCount++;
						word.currentIndex++;
					}
				}
			}
		
		previousWord = playerInput.text != "" ? playerInput.text : previousWord;

		if (demWords.ElementAt(0).HitCount == 0 && demWords.ElementAt(0).MissCount == 0) return;
		var hits = demWords.ElementAt(0).HitCount;
		var misses = demWords.ElementAt(0).MissCount;

		float points = demWords.ElementAt(0).HitCount / (demWords.ElementAt(0).HitCount + demWords.ElementAt(0).MissCount);
		Debug.Log("Pojot " + points);
	}
}


