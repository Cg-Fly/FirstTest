using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*******************************************************************************
*Create By CG
*Function 
*******************************************************************************/
namespace Application
{
	public class RoadChange : MonoBehaviour
	{
		private GameObject _roadNow;
		private GameObject _roadNext;
		private Transform _roadParent;

		private void Awake()
		{
			if (_roadParent == null)
			{
				_roadParent = new GameObject("RoadParent").transform;
			}
			
			_roadNow=Game.Instance.ObjPool.Spawn("Pattern_1",_roadParent);
			_roadNext=Game.Instance.ObjPool.Spawn("Pattern_2",_roadParent);
			_roadNext.transform.position = _roadNow.transform.position + Vector3.forward * 160;
		}
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Road")
			{
				Game.Instance.ObjPool.Unspawn(other.gameObject);
				OnSpawnNewGeo();
			}
		}

		private void OnSpawnNewGeo()
		{
			int randomRoadIndex=Random.Range(1, 5);
			_roadNow=_roadNext;
			_roadNext=Game.Instance.ObjPool.Spawn("Pattern_"+randomRoadIndex,_roadParent);
			_roadNext.transform.position = _roadNow.transform.position + Vector3.forward * 160;
		}
	}
}