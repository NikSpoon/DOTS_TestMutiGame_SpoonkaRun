
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public struct PlayerInput : IInputComponentData
{
    public int Horizontal;
    public int Vertical;
}

[UpdateInGroup(typeof(GhostInputSystemGroup))]
public partial struct MoveInput : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<NetworkStreamInGame>();
        state.RequireForUpdate<CubeSpawner>();
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (var playerInput in SystemAPI.Query<RefRW<PlayerInput>>().WithAll<GhostOwnerIsLocal>())
        {

            playerInput.ValueRW = default;
            if (Input.GetKey(KeyCode.A))
                playerInput.ValueRW.Horizontal -= 1;
            if (Input.GetKey(KeyCode.D))
                playerInput.ValueRW.Horizontal += 1;
            if (Input.GetKey(KeyCode.S))
                playerInput.ValueRW.Vertical -= 1;
            if (Input.GetKey(KeyCode.W))
                playerInput.ValueRW.Vertical += 1;

        }
    }
}

