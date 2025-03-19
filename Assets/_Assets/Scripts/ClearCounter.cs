using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    
    [SerializeField] private KitchenObjectSO kitchenObjectSo;

    
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // no kitchen object here
            if (player.HasKitchenObject())
            {
                //player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player has nothing
            }
        }
        else
        {
            //there is a kitchen object here
            if (player.HasKitchenObject())
            {
                //player carrying something
                
            }
            else
            {
                //player carrying nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }


    
}


