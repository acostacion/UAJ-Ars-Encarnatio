using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Parameters
    [SerializeField] private GameObject _line;
    [SerializeField] private AudioClip _escribeSound;
    private Vector3 mousePos = Vector3.zero;
    private Vector3 _newPoint = Vector3.zero;
    private AudioSource _audioSource;
    public AudioSource aSource { get { return _audioSource; } }

    private int LEFT_OFFSET = Screen.width / 2 + Screen.width / 100;
    private int RIGHT_OFFSET = Screen.width / 5;
    private int UP_OFFSET = Screen.height / 5 - Screen.width / 100;
    private int DOWN_OFFSET = Screen.height / 6;
    #endregion

    #region References
    private DrawingComponent _drawingComponent;
    public DrawingComponent DrawingComponent { get { return _drawingComponent; } }
    #endregion

    // Parametro auxiliar para registrar la posicion del raton
    float auxT = 0.0f;

    // Start is called before the first frame update
    void Start() {
        _drawingComponent = _line.GetComponent<DrawingComponent>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _escribeSound;
    }

    // Update is called once per frame
    void Update() {
        _newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameStates.GAME) {
            bool isInDrawingArea = _drawingComponent != null
                                    && Input.mousePosition.x > LEFT_OFFSET
                                    && Input.mousePosition.x < Screen.width - RIGHT_OFFSET
                                    && Input.mousePosition.y < Screen.height - UP_OFFSET
                                    && Input.mousePosition.y > DOWN_OFFSET;

            leftClickDown(isInDrawingArea);
            leftClickPressing(isInDrawingArea);
            leftClickUp();
        }

        auxT += Time.deltaTime;
        if (auxT >= 1.0f)
        {
            TrackerManager.Instance.registerMouseMovementEvent(Input.mousePosition.x, Input.mousePosition.y);
            auxT = 0.0f;
        }
    }

    //Al pulsar, se a�ade una l�nea
    void leftClickDown(bool isInDrawingArea) {
        if (Input.GetMouseButtonDown(0)) {
            mousePos = Input.mousePosition;

            // [TELEMETRIA] raycast para evitar que salte null cuando no toca
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (isInDrawingArea)
            {
                // [TELEMETRIA] donde empieza a dibujar (pero en el cuaderno)
                TrackerManager.Instance.registerDrawStartEvent(Input.mousePosition.x, Input.mousePosition.y);
                TrackerManager.Instance.registerUIInteractionEvent(InteractionTarget.DIBUJO, Input.mousePosition.x, Input.mousePosition.y);

                _drawingComponent.VariasLineas();
            }
            // tiene en cuenta el collider para que no mande dos clics al clicar sobre un InutilComponent.
            else {
                if (hit.collider == null) {
                    TrackerManager.Instance.registerUIInteractionEvent(InteractionTarget.NULL, Input.mousePosition.x, Input.mousePosition.y);
                }
            }
        }
    }

    //Cada vez que se pulsa, empieza o termina el trazo
    void leftClickPressing(bool isInDrawingArea) {
        if (Input.GetMouseButton(0)) {
            mousePos = Input.mousePosition;
            if (isInDrawingArea) {
                if (_drawingComponent != null && _newPoint != null) _drawingComponent.Paint(_newPoint);
                if (_audioSource != null && !_audioSource.isPlaying) _audioSource.Play();
            }
        }
    }

    void leftClickUp() {
        if (Input.GetMouseButtonUp(0)) {
            //  [TELEMETRIA] suelta trazo
            TrackerManager.Instance.registerDrawEndEvent(Input.mousePosition.x, Input.mousePosition.y);

            _audioSource.Stop();
        }
    }
}
