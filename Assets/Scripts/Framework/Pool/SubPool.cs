using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
 *Create By CG
 *Function �ӳ���
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
        /// ��������
        /// </summary>
        /// <returns></returns>
        public GameObject Spawn()
        {
            GameObject go = null;
            //�жϵ�ǰ�����Ƿ����û�õ�����
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
                
                //������������������ɾ��
                if (_maxCount != -1)
                {
                    if (_subQueue.Count > _maxCount)
                    {
                        for (int i = 0; i < _subQueue.Count - _maxCount; i++)
                        {
                            GameObject tempObj = _subQueue.Peek();
                            //ɾ�����ж���û�ö���
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
        /// ���ն���
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
        /// �������ж���
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
        /// �жϵ�ǰ�����Ƿ����������
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