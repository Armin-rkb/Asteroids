using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    protected abstract void PickupCollected();

    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.gameObject.CompareTag(Tags.playerTag)) return;

        PickupCollected();
    }

}