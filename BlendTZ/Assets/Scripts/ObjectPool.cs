using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool: MonoBehaviour
{
    public static ObjectPool Instance;

    [Serializable] 
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            fruit_1, 
            fruit_2,  
            fruit_3,   
            fruit_4, 
            fruit_5, 
            fruit_6, 
            fruit_7
        } 
        public ObjectType type;
        public GameObject prefab;
        public int startCount;
    }
    [SerializeField]  
    private List<ObjectInfo> objectInfo;

    private Dictionary<ObjectInfo.ObjectType, Pool> pools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        InitPool();
    } 
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>(); 
        var emptyGO = new GameObject();
        foreach (var obj in objectInfo)
        {
            var container = Instantiate(emptyGO, transform, false); 
            container.name = obj.type.ToString();
            pools[obj.type] = new Pool(container.transform);
            for (int i = 0; i < obj.startCount; i++)
            {
                var go = InstiateObject(obj.type, container.transform);
                pools[obj.type].objects.Enqueue(go);
            }
        }
        Destroy(emptyGO);
    } 
    private GameObject InstiateObject(ObjectInfo.ObjectType type,Transform parent)
    {
        var go = Instantiate(objectInfo.Find(x => x.type == type).prefab, parent);
        go.SetActive(false);
        return go;
    } 
    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].objects.Count > 0 ? pools[type].objects.Dequeue() : InstiateObject(type, pools[type].Container);
        obj.SetActive(true);
        return obj;
    }  
    public void HideObject()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Fruit");
        for (int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }
    }
}
