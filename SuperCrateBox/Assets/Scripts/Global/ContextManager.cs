using UnityEngine;
using System.Collections;
using System;

public enum ContextType 
{
	NONE,
	LOBBY,
	GAME,
}

public class ContextManager
{
	private ContextType m_Context = ContextType.NONE;

	public ContextType context { 
		get { return m_Context; } 
		set { 
			if (m_Context == value) return;
			var _old = m_Context;
			m_Context = value;
			if (postChanged != null)
				postChanged(m_Context, _old);
		} 
	}

	public Action<ContextType, ContextType> postChanged;
}

