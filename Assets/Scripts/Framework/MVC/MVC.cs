using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace CGFramework
{
	public abstract class MVC
	{
		    public static Dictionary<string,Model> Models = new Dictionary<string, Model>();
		    public static Dictionary<string,View> Views = new Dictionary<string, View>();
		    public static Dictionary<string,Type> CommandMap = new Dictionary<string, Type>();

		    /// <summary>
		    /// 注册模型
		    /// </summary>
		    /// <param name="model"></param>
		    public static void RegisterModel(Model model)
		    {
			    Models.Add(model.Name, model);
		    }

		    /// <summary>
		    /// 注册视图
		    /// </summary>
		    /// <param name="view"></param>
		    public static void RegisterView(View view)
		    {
			    if (Views.ContainsKey(view.Name))
			    {
				    Debug.LogWarning("视图已存在，无法注册");
				    return;
			    }
			    view.RegisterAttention();
			    Views.Add(view.Name, view);
		    }

		    /// <summary>
		    /// 注册命令
		    /// </summary>
		    /// <param name="commandName"></param>
		    /// <param name="commandType"></param>
		    public static void RegisterCommand(string commandName, Type commandType)
		    {
			    CommandMap.Add(commandName, commandType);
		    }
		    /// <summary>
		    /// 获取模型
		    /// </summary>
		    /// <typeparam name="T"></typeparam>
		    /// <returns></returns>
		    public static T GetModel<T>() where T : Model
		    {
			    foreach (var m in Models.Values)
			    {
				    if (m is T)
				    {
					    return (T)m;
				    }
			    }
			    return null;
		    }
		    /// <summary>
		    /// 获取视图
		    /// </summary>
		    /// <typeparam name="T"></typeparam>
		    /// <returns></returns>
		    public static T GetView<T>() where T : View
		    {
			    foreach (var v in Views.Values)
			    {
				    if (v is T)
				    {
					    return (T)v;
				    }
			    }
			    return null;
		    }

		    public static void SendCommand(string eventName, object data = null)
		    {
			    if (CommandMap.TryGetValue(eventName, out var value))
			    {
				    Controller controller = Activator.CreateInstance(value) as Controller;
				    controller.Execute(data);
			    }

			    foreach (var v in Views.Values)
			    {
				    if (v.AttentionList.Contains(eventName))
				    {
					    v.HandleEvent(eventName,data);
				    }
			    }
		    }
	}
}