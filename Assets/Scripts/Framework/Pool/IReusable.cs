using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************************************
*Create By CG
*Function ����ؿ��ظ�ʹ�ýӿ�
*******************************************************************************/
namespace CGFramework
{
	public interface IReusable
	{
		void OnSpawn();//ȡ��
		void OnUnspawn();//����
	}
}