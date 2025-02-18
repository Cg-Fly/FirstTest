using System.Collections;
using System.Collections.Generic;
using CGFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace Application
{
	[RequireComponent(typeof(ObjectPool))]
	[RequireComponent(typeof(AudioMng))]
	[RequireComponent(typeof(StaticData))]
	public class Game : MonoSingleton<Game>
	{
		[HideInInspector]
		public ObjectPool ObjPool;
		[HideInInspector]
		public AudioMng AudioMng;
		[HideInInspector]
		public StaticData StaticData;

		protected override void Awake()
		{
			base.Awake();
			ObjPool=ObjectPool.Instance;
			AudioMng=AudioMng.Instance;
			StaticData=StaticData.Instance;
			
			//注册控制器
			MVC.RegisterCommand(Consts.E_StartUp,typeof(StartUpCtrl));
			
			SceneManager.sceneLoaded += OnSceneLoaded;

			LoadLevel(4);
		}

		public void LoadLevel(int level)
		{
			//离开旧场景
			ScenesArgs args = new ()
			{
				SceneIndex = SceneManager.GetActiveScene().buildIndex
			};
			MVC.SendCommand(Consts.E_ExitScenes,args);
			
			//进入新场景
			SceneManager.LoadScene(level,LoadSceneMode.Single);
		}

		private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
		{
			ScenesArgs args = new ()
			{
				SceneIndex = arg0.buildIndex
			};
			MVC.SendCommand(Consts.E_EnterScenes, args);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}
}