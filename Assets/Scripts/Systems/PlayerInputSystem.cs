using Leopotam.Ecs;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, HasWeapon> _filter;
    private EcsWorld _ecsWorld;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get1(i);
            ref var hasWeapon = ref _filter.Get2(i); // текущее оружие

            input.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            input.shootInput = Input.GetMouseButton(0);
            if (Input.GetKeyDown(KeyCode.R))
            {
                ref var weapon = ref hasWeapon.weapon.Get<Weapon>();

                if (weapon.currentInMagazine < weapon.maxInMagazine) // если патронов недостаточно, то начать перезарядку
                {
                    ref var entity = ref _filter.GetEntity(i);
                    entity.Get<TryReload>();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _ecsWorld.NewEntity().Get<PauseEvent>();
            }
        }
    }
}
