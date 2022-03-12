﻿#region

using System.Collections;
using ModestTree;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject.Tests.Factories.PrefabFactory;

#endregion

namespace Zenject.Tests.Factories
{
    public class TestPrefabFactory : ZenjectIntegrationTestFixture
    {
        private string FooPrefabResourcePath => "TestPrefabFactory/Foo";

        private GameObject FooPrefab => FixtureUtil.GetPrefab(FooPrefabResourcePath);

        private string Foo2PrefabResourcePath => "TestPrefabFactory/Foo2";

        private GameObject Foo2Prefab => FixtureUtil.GetPrefab(Foo2PrefabResourcePath);

        [UnityTest]
        public IEnumerator Test1()
        {
            PreInstall();

            Container.BindFactory<Object, Foo, Foo.Factory>().FromFactory<PrefabFactory<Foo>>();
            Container.Bind<IInitializable>().To<Runner>().AsSingle().WithArguments(FooPrefab);

            PostInstall();
            yield break;
        }

        [UnityTest]
        public IEnumerator Test2()
        {
            PreInstall();

            Container.BindFactory<Object, string, Foo2, Foo2.Factory>().FromFactory<PrefabFactory<string, Foo2>>();
            Container.Bind<IInitializable>().To<Runner2>().AsSingle().WithArguments(Foo2Prefab);

            PostInstall();
            yield break;
        }

        [UnityTest]
        public IEnumerator TestResource1()
        {
            PreInstall();

            Container.BindFactory<string, Foo, Foo.Factory2>().FromFactory<PrefabResourceFactory<Foo>>();
            Container.Bind<IInitializable>().To<Runner3>().AsSingle().WithArguments(FooPrefabResourcePath);

            PostInstall();
            yield break;
        }

        [UnityTest]
        public IEnumerator TestResource2()
        {
            PreInstall();

            Container.BindFactory<string, string, Foo2, Foo2.Factory2>()
                .FromFactory<PrefabResourceFactory<string, Foo2>>();
            Container.Bind<IInitializable>().To<Runner4>().AsSingle().WithArguments(Foo2PrefabResourcePath);

            PostInstall();
            yield break;
        }

        public class Runner : IInitializable
        {
            private readonly Foo.Factory _fooFactory;
            private readonly GameObject _prefab;

            public Runner(
                Foo.Factory fooFactory,
                GameObject prefab)
            {
                _prefab = prefab;
                _fooFactory = fooFactory;
            }

            public void Initialize()
            {
                var foo = _fooFactory.Create(_prefab);

                Assert.That(foo.WasInitialized);
            }
        }

        public class Runner2 : IInitializable
        {
            private readonly Foo2.Factory _fooFactory;
            private readonly GameObject _prefab;

            public Runner2(
                Foo2.Factory fooFactory,
                GameObject prefab)
            {
                _prefab = prefab;
                _fooFactory = fooFactory;
            }

            public void Initialize()
            {
                var foo = _fooFactory.Create(_prefab, "asdf");

                Assert.IsEqual(foo.Value, "asdf");
            }
        }

        public class Runner3 : IInitializable
        {
            private readonly Foo.Factory2 _fooFactory;
            private readonly string _prefabPath;

            public Runner3(
                Foo.Factory2 fooFactory,
                string prefabPath)
            {
                _prefabPath = prefabPath;
                _fooFactory = fooFactory;
            }

            public void Initialize()
            {
                var foo = _fooFactory.Create(_prefabPath);
                Assert.That(foo.WasInitialized);
            }
        }

        public class Runner4 : IInitializable
        {
            private readonly Foo2.Factory2 _fooFactory;
            private readonly string _prefabPath;

            public Runner4(
                Foo2.Factory2 fooFactory,
                string prefabPath)
            {
                _prefabPath = prefabPath;
                _fooFactory = fooFactory;
            }

            public void Initialize()
            {
                var foo = _fooFactory.Create(_prefabPath, "asdf");

                Assert.IsEqual(foo.Value, "asdf");
            }
        }
    }
}