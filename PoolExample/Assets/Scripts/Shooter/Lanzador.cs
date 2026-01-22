using UnityEngine;
using UnityEngine.InputSystem;
public class Lanzador : MonoBehaviour
{
    [SerializeField]
    GameObject proyectil;

    private ControlesJuego controles;

    [SerializeField]
    float shootingForce = 100f;
    [SerializeField]
    float distanceDirection = 100f;
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

        Vector3 puntoOrigen = Camera.main.ScreenToWorldPoint(posicionClick);
        Vector3 puntoDestino = Camera.main.ScreenToWorldPoint(new Vector3(posicionClick.x, posicionClick.y, distanceDirection));

        Vector3 direction = (puntoDestino - puntoOrigen).normalized;

        GameObject proyectilDisparado = Instantiate(proyectil);
        proyectilDisparado.transform.rotation = Quaternion.LookRotation(direction);
        proyectilDisparado.transform.position = puntoOrigen;
        proyectilDisparado.GetComponent<Rigidbody>().AddForce(direction * shootingForce, ForceMode.Impulse);
    }
}
