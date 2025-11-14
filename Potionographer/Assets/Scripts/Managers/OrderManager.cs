using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public GameObject dialoguePanel;    //dialogue panel
    public Text orderText;   //order text

    public List<string> currentOrder = new List<string>();  //current order
    public List<string> addedIngredients = new List<string>();  //for keeping track of ingredients added

    public Cauldron cauldron;   //cauldron object will determine win and lose scenario based on ingredients put into it

    public void CreateOrder(string[] ingredients)   //called by NPCOrder
    {
        currentOrder.Clear();   //reset order
        currentOrder.AddRange(ingredients); //uses newOrder from NPCOrder

        addedIngredients.Clear(); //reset added ingredients

        dialoguePanel.SetActive(true);

        //show (currently) placeholder text
        orderText.text = "Customer Order:\n";
        foreach (string ing in currentOrder)
        {
            orderText.text += "- " + ing + "\n";    //all of this will be replaced with generated npc dialogue
        }

        //reset the cauldron
        cauldron.ResetCauldron(currentOrder);   //reset the state the cauldron is in 
    }

    public void AddIngredient(string ingredient)
    {
        addedIngredients.Add(ingredient);    //add the given ingredient to the list
        Debug.Log("Added ingredient: " + ingredient);
        CheckOrderCondition();
    }

    private void CheckOrderCondition()
    {
        //check if any incorrect ingredient was added
        foreach (string ing in addedIngredients)
        {
            if (!currentOrder.Contains(ing))    //if currentOrder does not contain that ingredient
            {
                Debug.Log("FAIL: Wrong ingredient added!"); //update to create pop up and reset
                cauldron.Fail();    //doesnt actually do anything yet
                return;
            }
        }
        if(addedIngredients.Count < currentOrder.Count) //not enough ingredients
        {
            return; //keep waiting
        }

        //otherwise
        Debug.Log("SUCCESS: All ingredients added correctl!");  //update to create pop up
        cauldron.Win(); //doesnt actually do anything yet
    }
}
