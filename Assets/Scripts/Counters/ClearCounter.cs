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
                // Player is carrying something, do nothing.
            } else {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
