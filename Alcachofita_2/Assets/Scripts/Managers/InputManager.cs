using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Parameters
    [SerializeField] private GameObject _line;
    [SerializeField] private AudioClip _escribeSound;
    private Vector3 mousePos = Vector3.zero;
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

    // Start is called before the first frame update
    void Start() {
        _drawingComponent = _line.GetComponent<DrawingComponent>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _escribeSound;
    }

    // Update is called once per frame
    void Update() {
        Vector3 newPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (GameManager.Instance != null && GameManager.Instance.CurrentState == GameManager.GameStates.GAME) {
            bool isInDrawingArea = _drawingComponent != null
                                    && mousePos.x > LEFT_OFFSET
                                    && mousePos.x < Screen.width - RIGHT_OFFSET
                                    && mousePos.y < Screen.height - UP_OFFSET
                                    && mousePos.y > DOWN_OFFSET;

            leftClickDown(isInDrawingArea);
            leftClickPressing(isInDrawingArea);
            leftClickUp();
        }
    }

    //Al pulsar, se a�ade una l�nea
    void leftClickDown(bool isInDrawingArea) {
        if (Input.GetMouseButtonDown(0)) {
            mousePos = Input.mousePosition;
            if (isInDrawingArea) {
                // [TELEMETRIA] donde empieza a dibujar (pero en el cuaderno)
                Tracker.Instance.registerDrawStartEvent(); // TODO pero le falta el VECTOR2, no??
                Tracker.Instance.registerUIInteractionEvent(InteractionTarget.DIBUJO, Input.mousePosition);

                _drawingComponent.VariasLineas();
            }
            else {
                // [TELEMETRIA] dibuja fuera del area del cuaderno
                Tracker.Instance.registerUIInteractionEvent(InteractionTarget.NULL, Input.mousePosition);
            }
        }
    }

    //Cada vez que se pulsa, empieza o termina el trazo
    void leftClickPressing(bool isInDrawingArea) {
        if (Input.GetMouseButton(0)) {
            mousePos = Input.mousePosition;
            if (isInDrawingArea) {
                if (_drawingComponent != null && newPoint != null) _drawingComponent.Paint(newPoint);
                if (_audioSource != null && !_audioSource.isPlaying) _audioSource.Play();
            }
        }
    }

    void leftClickUp() {
        if (Input.GetMouseButtonUp(0)) {
            //  [TELEMETRIA] suelta trazo
            Tracker.Instance.registerDrawEndEvent(); // TODO pero le falta el VECTOR2, no??

            _audioSource.Stop();
        }
    }
}
