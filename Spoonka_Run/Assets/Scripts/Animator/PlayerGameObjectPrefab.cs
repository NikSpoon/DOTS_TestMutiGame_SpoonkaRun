using Unity.Entities;
using UnityEngine;

public class PlayerGameObjectPrefab : IComponentData
{
    public GameObject Value;
}

public class PayerAnimatorReference : ICleanupComponentData
{
    public Animator Value;
}

