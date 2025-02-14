using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace CGFramework
{
	public abstract class AudioCtrl:MonoBehaviour
	{
		protected virtual void Awake()
		{
			AudioMng.Instance.RegistAudio(this);
		}

		protected virtual void OnDestroy()
		{
			AudioMng.Instance.UnRegistAudio(this);
		}

		public void AdjustVolume(float Volue)
		{
			transform.GetComponent<AudioSource>().volume = Volue;
		}
	}
}