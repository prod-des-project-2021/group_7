using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("There is no instance of the inventory in the scene");
            return;
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }
    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
