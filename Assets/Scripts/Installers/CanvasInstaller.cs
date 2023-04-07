using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] private MenuUI _menu;
    [SerializeField] private GameUI _game;
    [SerializeField] private GameOverUI _gameOver;

    public override void InstallBindings()
    {
        Container.Bind<MenuUI>().FromInstance(_menu).AsSingle();
        Container.Bind<GameUI>().FromInstance(_game).AsSingle();
        Container.Bind<GameOverUI>().FromInstance(_gameOver).AsSingle();
    }
}