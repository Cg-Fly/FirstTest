using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/********************************************************************************
*Create By CG
*Function unityMono类单例模式
*********************************************************************************/
namespace CGFramework
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but could not be found.");
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            // 如果实例已经存在但不是这个实例，则销毁这个新实例
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = (T)(object)this;
                DontDestroyOnLoad(gameObject);//切换场景不销毁
            }
        }

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
