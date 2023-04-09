using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    [SerializeField] private BarrierSpawner _spawner;
    [SerializeField] private BonusSpawner _bonusSpawner;

    public override void InstallBindings()
    {
        var position = new Vector3(
                (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)) + new Vector3(1, 0, 0)).x,
                transform.position.y,
                transform.position.z);

        _spawner.transform.position = position;
        _bonusSpawner.transform.position = position;

        Container.Bind<BarrierSpawner>().FromInstance(_spawner).AsSingle();
        Container.Bind<BonusSpawner>().FromInstance(_bonusSpawner).AsSingle();
    }
}