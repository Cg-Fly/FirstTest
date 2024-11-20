using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace function02
{
	public class function02 : MonoBehaviour
	{
		    
	}
	public interface IEventManager
	{

    }
	public interface IGameEvent
    {

    }
	public delegate void EventHandler<T>(T e) where T:IGameEvent;
	public delegate void EventHandler(IGameEvent e);
}