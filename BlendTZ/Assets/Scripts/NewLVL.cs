using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewLVL : MonoBehaviour
{
    public static Color lvlColor;
    [SerializeField] private LvlManager[] lvl;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image cocktailImage;
    
    private int number = 1;

    private void Start()
    {
        lvlColor = lvl[0].currentColor;
        text.text = lvl[0].lvlText;
        cocktailImage.color = lvlColor;
    }

    public void LoadLVL()
    {
        if (number >= 3)
        {
            number = 0;
        }
        text.text = lvl[number].lvlText;
        lvlColor = lvl[number].currentColor;
        cocktailImage.color = lvlColor;
        number++;
        FruitCount.isWin = false;
    }
}
