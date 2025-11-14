using UnityEngine;

public class NPCOrder : MonoBehaviour
{
    public OrderManager orderManager;
    public string[] possibleIngredients = { "eye", "mushroom", "herb", "bone" };

    // Call this from the UI Button
    public void OnNPCClicked()
    {
        string[] newOrder = new string[3];
        for (int i = 0; i < newOrder.Length; i++)
        {
            newOrder[i] = possibleIngredients[Random.Range(0, possibleIngredients.Length)];
        }

        orderManager.CreateOrder(newOrder);
    }
}
