using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallDetector : MonoBehaviour
{
    [SerializeField] private float _lerpTime = 3f;
    [SerializeField] private Vector3 _originalSize = new Vector3(0.6f, 0.6f, 1f);

    private bool _coroutineRunning;
    private bool _isShrinking;
    private Vector3 _targetScale;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.transform.tag == "Player")
        {
            StopAllCoroutines();
            _targetScale = _originalSize;
            StartCoroutine(BallScale(_lerpTime, _targetScale));
            _isShrinking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.transform.tag == "Player")
        {
            StopAllCoroutines();
            _targetScale = transform.localScale;
            _isShrinking = false;
        }
    }

    IEnumerator BallScale(float lerpTime, Vector3 targetScale)
    {
        _coroutineRunning = true;
        Vector3 currentScale = transform.localScale;
        float elapsedTime = 0f;

        // Gradually scale object
        while (elapsedTime < lerpTime)
        {
            transform.localScale = Vector3.Lerp(currentScale, targetScale, (elapsedTime / lerpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Just to eliminate any floating point errors and ensure the object reaches the target scale
        transform.localScale = targetScale;

        // Check if the ball should start shrinking again
        if (_isShrinking)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second before shrinking again
            _targetScale = _originalSize;
            StartCoroutine(BallScale(_lerpTime, _targetScale));
        }

        _coroutineRunning = false;
    }
}