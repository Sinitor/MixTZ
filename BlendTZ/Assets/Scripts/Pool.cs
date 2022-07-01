using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public Transform Container { get; private set; }
    public Queue<GameObject> objects; 
    public Pool(Transform container)
    {
        Container = container;
        objects = new Queue<GameObject>();
    }
}
