using System;
using System.Collections;
using System.Collections.Generic;
using RollABall;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

public class ListOfExecutables : IEnumerator, IEnumerable
{
    private IExecute[] _executableObjects;
    private int _index = -1;
    private InteractiveObject _currentInteractiveObject;
    private int ListLength => _executableObjects.Length;

    public ListOfExecutables()
    {
        var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        for (var i = 0; i < interactiveObjects.Length; i++)
        {
            if (interactiveObjects[i] is IExecute executableObject)
            {
                AddExecutableObject(executableObject);
            }
        }
    }

    private void AddExecutableObject(IExecute executableObject)
    {
        if (_executableObjects == null)
        {
            _executableObjects = new[] {executableObject};
            return;
        }
        Array.Resize(ref _executableObjects, ListLength + 1);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    //Имплементация нумератора
    public bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public object Current { get; }
    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}
