using Game.Level;
using UnityEngine;
using Utils;
using Zenject;

public class GlobalContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PreferencesProgressSaver>().AsSingle();
        Container.BindInterfacesTo<SyncNavigator>().AsSingle();
    }
}