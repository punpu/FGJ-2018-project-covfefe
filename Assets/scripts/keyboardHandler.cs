using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
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

	private string currentChar = "";
// Use this for initialization
	void Start () {
		if (GetComponent<InputField>() != null)
		{
			GetComponent<InputField>().onValueChanged.AddListener(delegate { HandleInput(); });
			GetComponent<InputField>().onEndEdit.AddListener(delegate { HandleSend();});
			GetComponent<InputField>().Select();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<InputField>() != null)
		{
			GetComponent<InputField>().Select();
		}
	}

	private void HandleSend()
	{
		var playerInput = GetComponent<InputField>();
		Debug.Log("SENDE'D");
		currentChar = "";
		playerInput.text = "";
		previousWord = "";
		playerInput.MoveTextEnd(false);
		
		demWords.ElementAt(0).IsSent = true;

		demWords.OrderByDescending(x => x.Points);

		var wordToSend = demWords.First();
		
		Debug.Log("Sent Word " + wordToSend.Text);
		
		foreach (var word in demWords)
		{
			word.Clear();
		}
		if(demWords.Count > 0)
			demWords.RemoveAt(0);
		else
		{
			Debug.Log("NEED MOAR WORDS");
		}
		
		GUI.FocusControl("PlayerTextInput");
	}
	private void HandleInput()
	{	
		var playerInput = GetComponent<InputField>();
		
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
				if(word.Text.Length >= playerInput.text.Length && !word.IsSent)
				{
					if (word.Text.ElementAt(word.CurrentIndex).ToString() == currentChar)
					{
						word.HitCount++;
						word.CurrentIndex++;

					}
					else if (word.CurrentIndex != 0)
					{
						word.MissCount++;
						word.CurrentIndex++;
					}
					
					word.Points = demWords.ElementAt(0).HitCount / (demWords.ElementAt(0).HitCount + demWords.ElementAt(0).MissCount);
				}
			}
		
		previousWord = playerInput.text != "" ? playerInput.text : previousWord;
	}
}


