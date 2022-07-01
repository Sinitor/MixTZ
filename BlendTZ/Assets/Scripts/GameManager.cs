using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform mixerCup;
    [SerializeField] private Transform mixerNewPos;
    [SerializeField] private Transform mixerDefaultPos;
    [SerializeField] private Transform fruitTarget;
    [SerializeField] private Transform mixer;
    [SerializeField] private GameObject smooth;
    public static bool isDown = false;
    public static bool isMix = false;
    public static ObjectPool.ObjectInfo.ObjectType type;

    private void Update()
    {
        if (isDown)
        {
            StartCoroutine("AddFruit");
        }
        if (isMix)
        {
            StartCoroutine("Mix");
        }
    }

    public IEnumerator AddFruit()
    {
        isDown = false;
        mixerCup.DOMove(mixerNewPos.position, 0.6f, false);
        mixerCup.DORotate(new Vector3(0, 0, 90), 0.6f, RotateMode.Fast);
        GameObject go = ObjectPool.Instance.GetObject(type); 
        Color colorGO = go.GetComponent<Renderer>().material.color;
        FruitCount.color.Add(colorGO);
        go.transform.position = fruitTarget.position; 
        yield return new WaitForSeconds(0.6f);
        go.transform.DOMove(mixerDefaultPos.position, 0.6f, false);
        yield return new WaitForSeconds(0.6f);
        go.AddComponent<Rigidbody>();
        mixerCup.DOMove(mixerDefaultPos.position, 0.6f, false);
        mixerCup.DORotate(new Vector3(0, 0, 0), 0.6f, RotateMode.Fast);
    } 
    public IEnumerator Mix()
    {
        isMix = false;
        smooth.SetActive(true);
        mixer.DOShakeRotation(2, 5, 5, 20);
        smooth.transform.DOScale(new Vector3(0.65f, 0.35f, 0.65f), 2);
        smooth.transform.DORotate(new Vector3(0,360,180), 2, RotateMode.Fast);
        yield return new WaitForSeconds(3); 
        smooth.transform.DOScale(new Vector3(0.3f, 0f, 0.3f), 1);
        smooth.transform.DORotate(new Vector3(0, 0, 180), 1, RotateMode.Fast);
        yield return new WaitForSeconds(1);
        smooth.SetActive(false);
    }
}
