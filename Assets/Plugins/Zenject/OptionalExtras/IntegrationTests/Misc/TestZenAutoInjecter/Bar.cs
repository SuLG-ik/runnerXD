#region

using UnityEngine;

#endregion

namespace Zenject.Tests.AutoInjecter
{
    public class Foo
    {
        [Inject] public DiContainer Container;
    }

    public class Bar : MonoBehaviour
    {
        public bool ConstructCalled;
        [Inject] public Foo Foo;

        [Inject]
        public void Construct()
        {
            ConstructCalled = true;
        }
    }
}