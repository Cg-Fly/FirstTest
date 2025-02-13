using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function 对象池可重复使用接口
*******************************************************************************/
namespace CGFramework
{
	public interface IReusable
	{
		void OnSpawn();//取出
		void OnUnspawn();//回收
	}
}