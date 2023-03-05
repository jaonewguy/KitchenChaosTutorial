using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
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

    public override void InteractAlternate(Player player) {
        if (HasKitchenObject()) {
            // There is a KitchenObject here, let's cut it.
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
