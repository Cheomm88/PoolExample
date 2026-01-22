using UnityEngine;
using UnityEngine.InputSystem;
public class Lanzador : MonoBehaviour
{
    private ControlesJuego controles;

    private void Awake()
    {
        controles = new ControlesJuego();
    }
    private void OnEnable()
    {
        controles.Enable();
        controles.ShootingActions.Disparar.performed += JugadorDispara;
    }

    private void OnDisable()
    {
        controles.Disable();
        controles.ShootingActions.Disparar.performed -= JugadorDispara;
    }

    void JugadorDispara(InputAction.CallbackContext context)
    {
        Vector2 posicionClick = controles.ShootingActions.Posicion.ReadValue<Vector2>();
        Debug.Log("Ha hecho click " + posicionClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
