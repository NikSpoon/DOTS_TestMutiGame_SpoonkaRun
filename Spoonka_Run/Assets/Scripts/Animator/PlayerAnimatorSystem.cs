
using Unity.Entities;
using Unity.Collections;
using UnityEngine;

[UpdateInGroup(typeof(PresentationSystemGroup), OrderFirst = true)]
partial struct PlayerAnimatorSystem : ISystem
{
  
    public void OnUpdate(ref SystemState state)
    {

        var ecb = new EntityCommandBuffer(Allocator.Temp);


        foreach(var (playerGameObjectPrefab,entity )
            in 
            SystemAPI.Query<PlayerGameObjectPrefab>().
            WithNone<PayerAnimatorReference>().
            WithEntityAccess())
            
        {
            var newCompanionGameObject = Object.Instantiate(playerGameObjectPrefab.Value);
            var newAnimatorReferense = new PayerAnimatorReference
            {
                Value = newCompanionGameObject.GetComponent<Animator>()
            };

            ecb.AddComponent(entity, newAnimatorReferense);
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }


}
