using System;
using Game;
using UnityEngine;

public abstract class SuspendableMonoBehaviour : MonoBehaviour, ISuspendable
{
    private GameProcessor processor;
        
    protected virtual void Start()
    {
        processor = FindObjectOfType<GameProcessor>();
        processor.RegisterSuspendable(this);
    }

    protected virtual void OnDestroy()
    {
        processor.UnregisterSuspendable(this);
    }

    public abstract void Suspend();

    public abstract void Continue();
}