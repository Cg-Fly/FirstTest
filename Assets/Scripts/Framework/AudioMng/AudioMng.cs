using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace CGFramework
{
    public class AudioMng : MonoSingleton<AudioMng>
	{
        private List<AudioCtrl> _audios = new List<AudioCtrl>();
        public List<AudioCtrl> Audios { get { return _audios; } }
        
        private float _curVolume;

        /// <summary>
        /// –ﬁ∏ƒ“Ù¡ø
        /// </summary>
        /// <param name="volue"></param>
        public void AdjustVolume(float volue)
        {
            //WDebug.Log($"–ﬁ∏ƒ…˘“Ù£∫{volue}");
            _curVolume = volue;
            for (int i = 0; i < Audios.Count; i++)
            {
                Audios[i].AdjustVolume(volue);
            }
        }

        public void RegistAudio(AudioCtrl clip)
        {
            _audios.Add(clip);
        }
        
        public void UnRegistAudio(AudioCtrl clip)
        {
            _audios.Remove(clip);
        }
	}
}