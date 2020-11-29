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
    public int ListLength => _executableObjects.Length;

    public ListOfExecutables()
    {
        //Ищем все интерактивные объекты и, если они реализуют интерфейс IExecute, добавляем их в массив
        var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        for (var i = 0; i < interactiveObjects.Length; i++)
        {
            if (interactiveObjects[i] is IExecute executableObject)
            {
                AddExecutableObject(executableObject);
            }
        }
    }

    
    //Метод добавления объектов, реализующих IExecute в массив
    public void AddExecutableObject(IExecute executableObject)
    {
        if (_executableObjects == null)
        {
            _executableObjects = new[] {executableObject};
            return;
        }
        Array.Resize(ref _executableObjects, ListLength + 1);
        _executableObjects[ListLength - 1] = executableObject;
    }

    //Индексатор
    public IExecute this[int index]
    {
        get => _executableObjects[index];
        set => _executableObjects[index] = value;
    }



    #region Имлпементация нумераторов
    public bool MoveNext()
    {
        if (_index == _executableObjects.Length - 1)
        {
            Reset();
            return false;
        }

        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }

    public object Current
    {
        get
        {
            return _executableObjects[_index];
        }
    }

    public IEnumerator GetEnumerator()
    {
        return this;
    }
    
    #endregion
}
