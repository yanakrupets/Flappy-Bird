using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIController _controller;

    public override void InstallBindings()
    {
        Container.Bind<UIController>().FromInstance(_controller).AsSingle();
    }
}