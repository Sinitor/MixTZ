using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private ObjectPool.ObjectInfo.ObjectType types;

    public void OnFruit()
    {
        if (FruitCount.isWin == false)
        {
            GameManager.type = types;
            GameManager.isDown = true;
        }
    }
}
