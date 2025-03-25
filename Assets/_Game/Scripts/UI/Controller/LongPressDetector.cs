using System;
using System.Collections;
using TB_RPG_2D.Settings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TB_RPG_2D.UI.Controller
{
    // TODO: UniTask
    public class LongPressDetector : MonoBehaviour, ILongPressDetector, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isPressing;
        private bool _longPressedTriggered;

        public Action OnLongPressed { get; set; }
        public Action OnLongPressReleased { get; set; }

        Coroutine _longPressCoroutine;
        Coroutine _longPressReleaseRoutine;

        private WaitForSeconds _waitForLongPressDuration;

        private void Awake()
        {
            float longPressDuration = SettingsProvider.Instance.LongPressSettings.LongPressDuration;
            _waitForLongPressDuration = new WaitForSeconds(longPressDuration);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressing = true;
            _longPressedTriggered = false;
            _longPressCoroutine = StartCoroutine(LongPressRoutine());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            StopCoroutine(_longPressCoroutine);
            StartCoroutine(LongPressReleaseRoutine());
        }

        private IEnumerator LongPressRoutine()
        {
            yield return _waitForLongPressDuration;

            if (_isPressing)
            {
                _longPressedTriggered = true;
                OnLongPressed?.Invoke();
                Debug.Log("Long press triggered.");
            }
        }

        private IEnumerator LongPressReleaseRoutine()
        {
            // this is for separate click lift and long press lift
            yield return new WaitForEndOfFrame();

            _isPressing = false;

            if (_longPressedTriggered)
            {
                OnLongPressReleased?.Invoke();
                Debug.Log("Long press completed, finger lifted.");
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}