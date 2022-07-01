using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private ObjectPool.ObjectInfo.ObjectType types;

    private void OnMouseDown()
    {
        if (FruitCount.isWin == false)
        {
            GameManager.type = types;
            GameManager.isDown = true;
        }
    }
}
