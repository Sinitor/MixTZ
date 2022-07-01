using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCount : MonoBehaviour
{
    [SerializeField] private Renderer smooth;
    [SerializeField] private GameObject interestText;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject winImage;
    private float interest;
    public static bool isWin = false;
    public static List<Color> color = new List<Color>();

    public void MixFruit()
    {
        if (isWin == false && color.Count >= 1)
        { 
            smooth.material.color = MixColor(color);

            interest = 100 * (1 - ((Mathf.Abs(smooth.material.color.r - NewLVL.lvlColor.r))
                + (Mathf.Abs(smooth.material.color.g - NewLVL.lvlColor.g))
                + (Mathf.Abs(smooth.material.color.b - NewLVL.lvlColor.b)) / (256 * 3)));
            ObjectPool.Instance.HideObject();

            GameManager.isMix = true;

            color.Clear();

            StartCoroutine("UIManager");
        }
    } 
    Color MixColor(List<Color> color)
    { 
        Color resultColor = new Color(0, 0, 0, 0);
        foreach (Color c in color)
        {
            resultColor += c;
        } 
        resultColor /= color.Count;
        return new Color(resultColor.r, resultColor.g, resultColor.b, resultColor.a * color.Count);
    } 
    IEnumerator UIManager()
    {
        interestText.SetActive(true);
        text.text = "" + (int)interest;
        yield return new WaitForSeconds(2);
        interestText.SetActive(false);
        if (interest >= 90)
        {
            winImage.SetActive(true);
            isWin = true;
        }
    }
}
