using UnityEngine;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{
    public OrderManager orderManager;

    public List<string> remainingIngredients = new List<string>();  //list for ingredients generated that are 

    public void ResetCauldron(List<string> newOrder)        //just resets cauldron stuff
    {
        remainingIngredients.Clear();   
        remainingIngredients.AddRange(newOrder);
        Debug.Log("Cauldron reset.");
    }

    private void OnTriggerEnter2D(Collider2D collision)     //for detecting if the items are dragged into the cauldron
    {
        var item = collision.GetComponent<DraggableItem>();

        if (item != null)
        {
            return;
        }

        string ingredientName = item.itemName.Trim().ToLower();   //ingredient recognized despite formatting

        Debug.Log("Cauldron received item: " + ingredientName);

        if (remainingIngredients.Exists(x => x.Trim().ToLower() == ingredientName))   //if ingredient exists
        {
            int index = remainingIngredients.FindIndex(x => x.Trim().ToLower() == ingredientName); //find index of ingredient
            remainingIngredients.RemoveAt(index);     //remove ingredient

            Debug.Log("Ingredient accepted! Remaining: " + string.Join(", ", remainingIngredients));

            orderManager.AddIngredient(item.itemName);  //tell ordermanage an item is added 

            //could destroy object or maybe have it disappear and a new one fade in 
            //in its old place? to show that the items come back even after being used
            //and lets multiple items be used

            if (remainingIngredients.Count == 0)            //win condition
            {
                Debug.Log("WIN! Correct potion created.");  //needs to become a screen or pop up
                orderManager.cauldron.Win();    //doesnt actually doing anything yet
            }
            return;

        }
            Debug.Log("FAIL! Incorrect ingredient added."); //needs to become a screen or pop up
                                                            //we also need a way to return to the beginning 
    }

    public void Win()
    {
        Debug.Log("Win condition triggered.");
    }

    public void Fail()
    {
        Debug.Log("Lose condition triggered.");
    }
}
