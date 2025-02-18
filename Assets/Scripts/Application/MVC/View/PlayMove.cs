using System;
using CGFramework;
using UnityEngine;

/*******************************************************************************
*Create By CG
*Function 角色控制器
*******************************************************************************/
namespace Application
{
    public class PlayMove:View
    {
        public override string Name
        {
            get => Consts.V_PlayMove;
        }
        
        private float _speed = 10f;
        private CharacterController _controller;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _controller.Move(transform.forward * _speed * Time.deltaTime);
        }

        public override void HandleEvent(string eventName, object data)
        {
            
        }
    }
}