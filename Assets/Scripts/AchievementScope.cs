using Achievement;
using Zenject;

public class AchievementScope : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PrefsAchievementsStorage>().AsSingle();
    }
}