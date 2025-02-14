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
    public abstract class Controller
    {
        public abstract void Execute(object data);
        
        /// <summary>
        /// 获取模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetModel<T>() where T : Model
        {
            return MVC.GetModel<T>();
        }
        
        /// <summary>
        /// 获取视图
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetView<T>() where T : View
        {
            return MVC.GetView<T>();
        }

        /// <summary>
        /// 注册模型
        /// </summary>
        /// <param name="model"></param>
        protected void RegisterModel(Model model)
        {
            MVC.RegisterModel(model);
        }

        /// <summary>
        /// 注册视图
        /// </summary>
        /// <param name="view"></param>
        protected void RegisterView(View view)
        {
            MVC.RegisterView(view);
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="commandType"></param>
        protected void RegisterCommand(string commandName, Type commandType)
        {
            MVC.RegisterCommand(commandName, commandType);
        }
    }
}