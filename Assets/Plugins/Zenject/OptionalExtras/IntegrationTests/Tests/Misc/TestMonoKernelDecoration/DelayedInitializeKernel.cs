#region

using System.Threading.Tasks;

#endregion

namespace Zenject.Tests.TestAnimationStateBehaviourInject
{
    public class DelayedInitializeKernel : BaseMonoKernelDecorator
    {
        public override async void Initialize()
        {
            await Task.Delay(5000);
            DecoratedMonoKernel.Initialize();
        }
    }
}