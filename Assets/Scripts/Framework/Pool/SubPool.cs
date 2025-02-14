using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
 *Create By CG
 *Function 子池子
 *******************************************************************************/
namespace CGFramework
{
    public class SubPool
    {
        private readonly Queue<GameObject> _subQueue;

        private readonly GameObject _prefab;
        
        private string _name;
        public string Name
        {
            get
            {
                if (_prefab != null)
                {
                    _name = _prefab.name;
                }
                return _name;
            }
        }

        private readonly Transform _parent;
        private readonly int _maxCount;

        public SubPool(GameObject prefab, Transform parent, int maxCount)
        {
            _subQueue = new Queue<GameObject>();
            _prefab = prefab;
            _parent = parent;
            _maxCount = maxCount;
        }

        /// <summary>
        /// 产出对象
        /// </summary>
        /// <returns></returns>
        public GameObject Spawn()
        {
            GameObject go = null;
            //判断当前集合是否包含没用的物体
            if (_subQueue.Count > 0)
            {
                for (int i = 0; i < _subQueue.Count; i++)
                {
                    GameObject tempObj = _subQueue.Peek();
                    if (!tempObj.activeSelf)
                    {
                        go = tempObj;
                    }
                }
            }

            if (go == null)
            {
                go = GameObject.Instantiate(_prefab, _parent);
                _subQueue.Enqueue(go);
                
                //如果超过最大数量，则删除
                if (_maxCount != -1)
                {
                    if (_subQueue.Count > _maxCount)
                    {
                        for (int i = 0; i < _subQueue.Count - _maxCount; i++)
                        {
                            GameObject tempObj = _subQueue.Peek();
                            //删除所有多余没用对象
                            if (!tempObj.activeSelf)
                            {
                                GameObject.Destroy(_subQueue.Dequeue());
                            }
                        }
                    }
                }
            }

            go.SetActive(true);
            go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

            return go;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="go"></param>
        public void Unspawn(GameObject go)
        {
            if (IsContainsInCurSubPool(go))
            {
                go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
                go.SetActive(false);
            }
        }

        /// <summary>
        /// 回收所有对象
        /// </summary>
        public void UnspawnAll()
        {
            for (int i = 0; i < _subQueue.Count; i++)
            {
                if (_subQueue.Peek().activeSelf)
                {
                    Unspawn(_subQueue.Peek());
                }
            }
        }

        /// <summary>
        /// 判断当前集合是否包含此物体
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public bool IsContainsInCurSubPool(GameObject go)
        {
            if (_subQueue.Count <= 0) return false;
            for (int i = 0; i < _subQueue.Count; i++)
            {
                GameObject tempObj = _subQueue.Peek();
                if (tempObj==go)
                {
                    return true;
                }
            }
            return false;
        }
    }
}