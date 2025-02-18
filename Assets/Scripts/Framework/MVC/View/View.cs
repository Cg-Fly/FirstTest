using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
 *Create By CG
 *Function
 *******************************************************************************/
namespace CGFramework
{
    public abstract class View : MonoBehaviour
    {
        public abstract string Name { get; }
        [HideInInspector]
        public List<string> AttentionList=new List<string>();

        /// <summary>
        /// 注册关心的事件
        /// </summary>
        public void RegisterAttention()
        {
            
        }
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        public abstract void HandleEvent(string eventName,object data);

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        protected void SendEvent(string eventName, object data=null)
        {
            MVC.SendCommand(eventName, data);
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetModel<T>() where T : Model
        {
            return MVC.GetModel<T>();
        }
    }
}