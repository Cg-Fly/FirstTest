using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************************
 *Create By CG
 *Function 总池子
 *******************************************************************************/
namespace CGFramework
{
    public class ObjectPool:MonoSingleton<ObjectPool>
    {
        public string RessourceDir;
        private readonly Dictionary<string, SubPool> _pools = new Dictionary<string, SubPool>();
        private readonly Transform _parent;

        /// <summary>
        /// 产出对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="subPoolParent"></param>
        /// <returns></returns>
        public GameObject Spawn(string name, Transform subPoolParent)
        {
            SubPool subPool;
            if (!_pools.ContainsKey(name))
            {
                RegisterSubPool(name, subPoolParent);
            }

            subPool = _pools[name];
            return subPool.Spawn();
        }

        private void RegisterSubPool(string name, Transform subPoolParent)
        {
            string pathTemp = RessourceDir + "/" + name;
            GameObject prefab = Resources.Load<GameObject>(pathTemp);
            SubPool subPool = new SubPool(prefab, subPoolParent, -1);
            _pools.Add(name, subPool);
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="go"></param>
        public void Unspawn(GameObject go)
        {
            SubPool subPool = null;
            foreach (var pool in _pools)
            {
                if (pool.Value.IsContainsInCurSubPool(go))
                {
                    subPool = pool.Value;
                    break;
                }
            }
            subPool?.Unspawn(go);
        }

        /// <summary>
        /// 回收所有对象
        /// </summary>
        public void UnspawnAll()
        {
            foreach (var pool in _pools)
            {
                pool.Value.UnspawnAll();
            }
        }
    }
}