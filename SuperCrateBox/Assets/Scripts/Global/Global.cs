﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
[RequireComponent(typeof(ServerManager))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(ReadyManager))]
[RequireComponent(typeof(TransitionManager))]
public class Global : Singleton<Global> 
{
	static bool s_IsAwaken = false;
	static bool s_IsStarted = false;

	public static Global Instance { 
		get { 
			if (! s_IsAwaken || ! s_IsStarted) 
				Debug.Log("Trying to access Instance before initialize.");
			return Singleton<Global>.Instance; 
		}
	}

	[HideInInspector]
	public ContextManager context;
	public static ContextManager Context() { return Instance.context; }

	[HideInInspector]
	public System.Random random;
	public static System.Random Random() { return Instance.random; }

	[HideInInspector]
	public ServerManager server;
	public static ServerManager Server() { return Instance.server; }

	[HideInInspector]
	public PlayerManager player;
	public static PlayerManager Player() { return Instance.player; }

	[HideInInspector]
	public ReadyManager ready;
	public static ReadyManager Ready() { return Instance.ready; }

	[HideInInspector]
	public TransitionManager transition;
	public static TransitionManager Transition() { return Instance.transition; }

	[HideInInspector]
	public CacheManager localCache = new CacheManager();
	public static CacheManager LocalCache() { return Instance.localCache; }

	// please implement this.
	/*
	[HideInInspector]
	public CacheManager networkCache = new 
	*/



	void Awake () {
		context = new ContextManager ();
		random = new System.Random ();

		if (networkView == null) gameObject.AddComponent<NetworkView>();
		networkView.stateSynchronization = NetworkStateSynchronization.Off;
		networkView.observed = null;

		server = GetComponent<ServerManager>();
		if (server == null) server = gameObject.AddComponent<ServerManager>();

		player = GetComponent<PlayerManager>();
		if (player == null) player = gameObject.AddComponent<PlayerManager>();

		ready = GetComponent<ReadyManager>();
		if (ready == null) ready = gameObject.AddComponent<ReadyManager>();

		transition = GetComponent<TransitionManager>();
		if (transition == null) transition = gameObject.AddComponent<TransitionManager>();

		s_IsAwaken = true;
	}

	void Start () {
		ready.Start ();
		s_IsStarted = true;
	}

}
