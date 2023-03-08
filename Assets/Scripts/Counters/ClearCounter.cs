using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // Was only for testing purposes. Had a testing bool previously.
    //private void Update() {
    //    if (testing && Input.GetKeyDown(KeyCode.T)) {
    //        if (kitchenObject != null) {
    //            kitchenObject.SetKitchenObjectParent(secondClearCounter);
    //        }
    //    }
    //}

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            // Currently no Kitchen Object present.
            if (player.HasKitchenObject()) {
                // Player is carrying something.
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player not carrying anything.
            }
        } else {
            // There is a KitchenObject here.
            if (player.HasKitchenObject()) {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    // Player is holding a Plate.
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    // Player not carrying Plate but something else.
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        // Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
