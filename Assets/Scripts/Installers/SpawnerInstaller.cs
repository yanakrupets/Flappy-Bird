using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    [SerializeField] private Spawner _spawner;

    public override void InstallBindings()
    {
        _spawner.transform.position = new Vector3(
                (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)) + new Vector3(1, 0, 0)).x,
                transform.position.y,
                transform.position.z);

        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle();
    }
}