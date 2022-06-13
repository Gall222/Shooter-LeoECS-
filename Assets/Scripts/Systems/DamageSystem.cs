using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : IEcsRunSystem
{
    private EcsFilter<DamageEvent> damageEvents;

    public void Run()
    {
        foreach (var i in damageEvents)
        {
            ref var e = ref damageEvents.Get1(i);
            ref var health = ref e.target.Get<Health>();

            health.value -= e.value;

            // ���� ������ �����
            if (health.value <= 0)
            {
                e.target.Get<DeathEvent>();
            }

            damageEvents.GetEntity(i).Destroy();
        }
    }
}
