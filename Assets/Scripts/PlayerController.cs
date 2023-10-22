using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;


    Camera cam;

    PlayerMotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Debug.Log("we hit" + hit.collider.name + "" +hit.point);
                motor.MoveToPoint(hit.point);

                RemoveFocus();
                
                
                
            }
        }
        
        if (Input.GetKey("z"))
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            
            
            if (Physics.Raycast(ray, out hit, 100))   
            {
                Interactable inter = hit.collider.GetComponent<Interactable>();
                
                if (inter != null)
                {
                    SetFocus(inter);
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if ( newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
           
            focus = newFocus;
            motor.FollowTarget(newFocus);

        }
        
        
        newFocus.OnFocused(transform);
        

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
       
        focus = null;
        motor.StopFollowingTarget();
    }
    
   

}


