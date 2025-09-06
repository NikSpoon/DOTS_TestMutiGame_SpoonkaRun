using Unity.Entities;
using UnityEngine;

public class PlayerAnimatorAuthoring : MonoBehaviour
{

    public GameObject PlaterGameObjectPrefab;

    public class PlayerGameObjectPrefabBeker : Baker<PlayerAnimatorAuthoring>
    {

        public override void Bake(PlayerAnimatorAuthoring authoring)
        {

            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponentObject(entity, new PlayerGameObjectPrefab { Value = authoring.PlaterGameObjectPrefab });


        }
    }

}
