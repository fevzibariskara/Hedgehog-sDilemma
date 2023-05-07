using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private float _lerpTime = 3f;
    [SerializeField] private Vector3 _originalSize = new Vector3(0.6f, 0.6f, 1f);

    private bool _coroutineRunning;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.transform.tag == "Player")
        {
            StartCoroutine(BallScale(_lerpTime, _originalSize));
        }
    }

    IEnumerator BallScale(float lerpTime, Vector3 scale)
    {
        _coroutineRunning = true;
        Vector3 currentScale = transform.localScale;
        float elapsedTime = 0f;

        //Gradually expand object
        while (elapsedTime < lerpTime)
        {
            transform.localScale = Vector3.Lerp(currentScale, scale, (elapsedTime / lerpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;

        //Gradually contract object to original size
        while (elapsedTime < lerpTime)
        {
            transform.localScale = Vector3.Lerp(scale, currentScale, (elapsedTime / lerpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //Just to eliminate any floating point errors and ensure the object returns to its original size
        transform.localScale = currentScale;
        _coroutineRunning = false;
    }
}
