﻿using UnityEngine;
using System.Collections;

public class HUDResultNextButton : MonoBehaviour 
{
	public string lobbyScene;

	void Start()
	{
		Game.Progress ().postStop += ListenGameStop;
	}

	void OnDestroy()
	{
		Game.Progress ().postStop -= ListenGameStop;
	}

	public void OnSubmit()
	{
		Game.Progress ().StopGame ();
	}

	public void ListenGameStop()
	{
		var _transition = new LobbyTransition ();
		_transition.scene = lobbyScene;
		Global.Transition ().RequestStartLobby (_transition);
	}
}
