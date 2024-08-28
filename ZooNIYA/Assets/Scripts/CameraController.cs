using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using static UnityEngine.UI.Image;

public class CameraController : MonoBehaviour
{
    [SerializeField] ScreenContainer screenContainer;
    private List<Transform> _screenPoints;
    private int _screenIndex = 0;
    //[SerializeField] private float _cameraSpeed = 1.0f;
    private bool _isMoving = false;

    enum Direction
    {
        Left,
        Right,
    }
    
    void Start()
    {
        _screenPoints = screenContainer.GetScreenList();
        
        Debug.Log("Screen count: " + _screenPoints.Count);
    }

    private void OnEnable()
    {
        screenContainer.NewScreenAdd += updateScreenPoints;
    }

    public void moveRight()
    {
        if (_screenIndex + 1 < _screenPoints.Count && !_isMoving) 
        {
            _screenIndex++;
            Vector3 newPosition = new Vector3(_screenPoints[_screenIndex].position.x, 0, transform.position.z);
            _isMoving = true;
            StartCoroutine(moveCamera(newPosition));
            Debug.Log("Current screen index: " + _screenIndex);
        }
    }

    public void moveLeft()
    {
        if (_screenIndex - 1 >= 0 && !_isMoving)
        {
            _screenIndex--;
            Vector3 newPosition = new Vector3(_screenPoints[_screenIndex].position.x, 0, transform.position.z);
            _isMoving = true;
            StartCoroutine(moveCamera(newPosition));
            Debug.Log("Current screen index: " + _screenIndex);
        }
    }


    private IEnumerator moveCamera(Vector3 dest)
    {
        float totalMovementTime = 1f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, dest) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.position, dest, currentMovementTime / totalMovementTime);
            yield return null;
        }
        _isMoving = false;
    }

    private void updateScreenPoints()
    {
        _screenPoints = screenContainer.GetScreenList();
    }

}
