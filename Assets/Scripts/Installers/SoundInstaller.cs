using UnityEngine;
using Zenject;

public class SoundInstaller : MonoInstaller
{
    [SerializeField] private SoundManager _soundManager;

    public override void InstallBindings()
    {
        Container.Bind<SoundManager>().FromInstance(_soundManager).AsSingle();
    }
}