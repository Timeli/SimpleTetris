using Assets.CodeBase.GameField.Storeys;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderActivator : MonoBehaviour
{
    public List<GameObject> Blocks = new();

    public void ActivateColliders(StoreySetter storeySetter)
    {
        foreach (GameObject block in Blocks)
        {
            block.GetComponent<BoxCollider2D>().enabled = true;
            storeySetter.SetParentFor(block);
        }
        
        Destroy(transform.parent.gameObject);
    }
}
