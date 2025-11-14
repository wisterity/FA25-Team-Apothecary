using UnityEngine;

public class CauldronDropZone : MonoBehaviour
{
    //any item with DraggableItem gets registered when it touched the cauldron
    public OrderManager orderManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggableItem item = collision.GetComponent<DraggableItem>();  

        if (item != null)
        {
            Debug.Log("Item dropped in cauldron: " + item.itemName);
            orderManager.AddIngredient(item.itemName);  //send name of item to orderManager
        }
    }
}
