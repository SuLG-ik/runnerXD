using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using Random = UnityEngine.Random;

namespace Achievement.Processor
{
    public class AchievementsProcessorImpl : MonoBehaviour, IAchievementsProcessor
    {
        private AchievementCatalog _catalog;

        private event UnityAction<List<AchievementInfo>> UpdateAchievementsListeners;
        private event UnityAction<AchievementInfo> UpdateAchievementInfoListener;

        private AchievementCatalog GetCatalog()
        {
            return _catalog ??= FindObjectOfType<AchievementCatalog>();
        }

        private IAchievementsStorage _storage;

        private IAchievementsStorage GetStorage()
        {
            return _storage ??= FindObjectOfType<PrefsAchievementsStorage>();
        }

        private List<IAchievementHandler> _currentHandlers;

        private void Start()
        {
            GetCurrentHandlersOrFetch();
        }

        private List<IAchievementHandler> GetCurrentHandlersOrFetch()
        {
            return _currentHandlers == null || _currentHandlers.IsEmpty()
                ? _currentHandlers = FetchCurrentHandlersAndInitialize()
                : _currentHandlers;
        }

        private List<IAchievementHandler> FetchCurrentHandlersAndInitialize()
        {
            var handlersIds = GetStorage().FetchSavedHandlersId();
            var handlers = handlersIds != null
                ? FindHandlersByIds(handlersIds)
                : InvalidateHandlers(PickRandomHandlers());
            return InitializeHandlers(handlers);
        }

        private List<IAchievementHandler> FindHandlersByIds(List<string> ids)
        {
            return GetCatalog().GetAchievementHandlers(OnAchievementComplete, OnUpdateAchievements)
                .Where(handler => ids.ContainsItem(handler.GetInfo().HandlerId)).ToList();
        }

        private void OnAchievementComplete(IAchievementHandler handler)
        {
            handler.Destroy();
        }

        private List<IAchievementHandler> InvalidateHandlers(List<IAchievementHandler> handlers)
        {
            handlers?.ForEach(handler => handler.Invalidate());
            return handlers;
        }

        private List<IAchievementHandler> InitializeHandlers(List<IAchievementHandler> handlers)
        {
            handlers?.ForEach(handler =>
            {
                if (!handler.GetInfo().Progress.IsCompleted)
                    handler.Initialize();
            });
            return handlers;
        }

        private List<IAchievementHandler> DestroyHandlers(List<IAchievementHandler> handlers)
        {
            handlers?.ForEach(handler => handler.Destroy());
            return handlers;
        }

        private List<IAchievementHandler> PickRandomHandlers()
        {
            return new List<IAchievementHandler>() {PickRandomHandler(), PickRandomHandler(), PickRandomHandler()};
        }

        private IAchievementHandler PickRandomHandler()
        {
            var handlers = GetCatalog().GetAchievementHandlers(OnAchievementComplete, OnUpdateAchievements);
            return handlers[Random.Range(0, handlers.Count)];
        }

        public List<AchievementInfo> GetCurrentAchievements()
        {
            return GetCurrentHandlersOrFetch().Select(handler => handler.GetInfo()).ToList();
        }

        public void NextAchievements()
        {
            DestroyHandlers(_currentHandlers);
            _currentHandlers = PickRandomHandlers();
            InvalidateHandlers(_currentHandlers);
            InitializeHandlers(_currentHandlers);
        }

        public void RegisterUpdateCurrentAchievementsListener(UnityAction<List<AchievementInfo>> listener)
        {
            UpdateAchievementsListeners += listener;
        }

        public void RegisterUpdateAchievementListener(UnityAction<AchievementInfo> listener)
        {
            UpdateAchievementInfoListener += listener;
        }

        private void OnUpdateAchievements(IAchievementHandler info)
        {
            UpdateAchievementsListeners?.Invoke(GetCurrentAchievements());
            UpdateAchievementInfoListener?.Invoke(info.GetInfo());
        }

        private void SaveAll()
        {
            GetStorage().SaveNewAchievements(GetCurrentAchievements());
        }

        private void OnDestroy()
        {
            SaveAll();
            DestroyHandlers(_currentHandlers);
        }
    }
}