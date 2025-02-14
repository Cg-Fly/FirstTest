using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace CGFramework
{
	public abstract class Model
	{
		    public string Name { get; }

		    protected void SendEvent(string eventName, object data=null)
		    {
			    MVC.SendCommand(eventName, data);
		    }
	}
}