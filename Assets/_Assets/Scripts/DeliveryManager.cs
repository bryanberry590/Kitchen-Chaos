using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeliveryManager : MonoBehaviour
{
   public event EventHandler OnRecipeSpawned;
   public event EventHandler OnRecipeCompleted;
   public static DeliveryManager Instance {get; private set; }

   [SerializeField] private RecipeListSO recipeListSO;
   private List<RecipeSO> waitingRecipeSOList;

   private float spawnRecipeTimer;
   private float spawnRecipeTimerMax = 4f;
   private int waitingRecipeMax = 4;


   private void Awake()
   {
      Instance = this;
      waitingRecipeSOList = new List<RecipeSO>();
   }
   private void Update()
   {
      spawnRecipeTimer -= Time.deltaTime;
      if (spawnRecipeTimer <= 0f)
      {
         spawnRecipeTimer = spawnRecipeTimerMax;
         if (waitingRecipeSOList.Count < waitingRecipeMax)
         {
            RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
            Debug.Log(waitingRecipeSO.recipeName);
            waitingRecipeSOList.Add(waitingRecipeSO);   
            
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
         }
         
      }
   }

   public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
   {
      for (int i = 0; i < waitingRecipeSOList.Count; i++)
      {
         RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

         if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
         {
            bool plateCountentsMatchesRecipe = true;
            //has the same number of ingredients
            foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
            {
               bool ingredientFound = false;
               //cycling through all ingredients in the recipe
               foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
               {
                  //cycling through all ingredients on the plate

                  if (plateKitchenObjectSO == recipeKitchenObjectSO)
                  {
                     //ingredient matches
                     ingredientFound = true;
                     break;
                  }
               }

               if (!ingredientFound)
               {
                  //this recipe ingredient was not found on the plate
                  plateCountentsMatchesRecipe = false;
               }
            }

            if (plateCountentsMatchesRecipe)
            {
               //player gave the correct recipe
               Debug.Log("Player gave correct recipe");
               waitingRecipeSOList.RemoveAt(i);
               OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
               return;
            }
            
         }
      }
   }

   public List<RecipeSO> GetWaitingRecipeSOList()
   {
      return waitingRecipeSOList;
   }

}
