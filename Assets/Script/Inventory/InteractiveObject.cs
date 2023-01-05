using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]private float radius = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform interactItem;
    [SerializeField] private LayerMask ItemMask;
    public float groundDistance = 0.4f;
    public bool ItemOnGround;

    bool hasInteract = false;
   
    // Update is called once per frame
    void Update()
    {
        ItemOnGround = Physics.CheckSphere(interactItem.position, groundDistance, ItemMask);
        float distance = Vector3.Distance(player.position, interactItem.position);
        if (distance<=radius && !hasInteract)
        {
            hasInteract = true;
            Interact();
            if (ItemOnGround)
            {
                hasInteract = true;
                Interact();
            }
            else
            {
                
            }
            
        }
    }

    public virtual void Interact()
    {

        Debug.Log("Item Active");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactItem.position, radius);
    }
}
