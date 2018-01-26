using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Events;
using UnityEngine.UI;


public class keyboardHandler : MonoBehaviour
{
	private List<Word> demWords = new List<Word>
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
		if(GetComponent<InputField>() != null)
			GetComponent<InputField>().onValueChanged.AddListener(delegate {HandleInput(); });

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
		
		Debug.Log("InputFieldi " + playerInput.text);

		if (!String.IsNullOrEmpty(previousWord))
		{
			currentChar = playerInput.text.Replace(previousWord, "");
			
			Debug.Log("Current Char" + currentChar);
				
			
			foreach (var word in demWords)
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

		Debug.Log("Uus merkki " + currentChar);

		previousWord = playerInput.text != "" ? playerInput.text : previousWord;
	}
}


