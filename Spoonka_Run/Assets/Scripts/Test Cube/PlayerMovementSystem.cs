using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Burst;

[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[BurstCompile]
public partial struct PlayerMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var speed = SystemAPI.Time.DeltaTime * 4;
        foreach (var (input, trans, moveState ) in SystemAPI.Query<RefRO<PlayerInput>, RefRW<LocalTransform>,RefRW <MoveState>>().WithAll<Simulate>())
        {
            var moveInput = new float2(input.ValueRO.Horizontal, input.ValueRO.Vertical);
            moveInput = math.normalizesafe(moveInput) * speed;
            trans.ValueRW.Position += new float3(moveInput.x, 0, moveInput.y);

            if (-1 < speed || speed < 1 )
            {
                moveState.ValueRW.IsMoving = true;
            }
            else
            {
                moveState.ValueRW.IsMoving = false;
            }
          
        }
    }
}
public struct MoveState : IComponentData
{
    public bool IsMoving;
}