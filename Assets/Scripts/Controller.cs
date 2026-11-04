using UnityEngine;
using UnityEngine.InputSystem;


public class Controller : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction leftSelectAction;
    private InputAction rightSelectAction;
    private InputAction trashAction;
    private InputAction useAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction          =InputSystem.actions.FindAction("Move");
        jumpAction          =InputSystem.actions.FindAction("Jump");
        attackAction        =InputSystem.actions.FindAction("Attck");

        leftSelectAction    =InputSystem.actions.FindAction("CardSelectLeft");
        rightSelectAction   = InputSystem.actions.FindAction("CardSelectRight");
        trashAction         =InputSystem.actions.FindAction("CardTrash"); 
        useAction           =InputSystem.actions.FindAction("CardUse"); 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
