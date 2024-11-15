using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag,DirectionComponent> directionFilter = null;

        private float moveX;
        private float moveZ;


        public void Run()
        {
            SetDirection();
            foreach (var i in directionFilter)
            {
                ref var diretionComponent = ref directionFilter.Get2(i);
                ref var direction = ref diretionComponent.Direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
        }
        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
    }
}