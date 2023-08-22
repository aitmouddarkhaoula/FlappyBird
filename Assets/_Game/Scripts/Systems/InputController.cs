using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MobileInputSystem {
    public enum InputDevice {
        Screen,
        Mouse
    }
    public enum InputType {
        CurrentPosition,
        DeltaPosition,
    }
    public class InputController : MonoBehaviour {
        public InputDevice _inputDevice = InputDevice.Screen;
        public InputType _inputType = InputType.CurrentPosition;
        
        public static event Action<Vector3> OnTouchDown;
        public static event Action OnTouchUp;

        private Vector3 startPosition;
        private Vector3 endPosition;
        private Vector3 deltaPosition;


        private void FixedUpdate() {
            switch (_inputDevice) {
                case InputDevice.Screen:
                    HandleTouchInput();
                    break;
                case InputDevice.Mouse:
                    HandleMouseInput();
                    break;
            }
        }

        private void HandleTouchInput() {
            if (Input.touchCount <= 0) OnTouchUp?.Invoke();
            else {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase) { 
                    case TouchPhase.Began: // When the touch begins (the frame when the user first touches the screen)
                        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)) return;

                        startPosition = touch.position;
                        break;
                    case TouchPhase.Moved: // When the user moves his finger over the screen
                    case TouchPhase.Stationary: // When the user holds his finger over the screen
                        if (startPosition == Vector3.zero) return;

                        endPosition = touch.position;
                        deltaPosition = endPosition - startPosition;
                        OnTouchDown?.Invoke(_inputType == InputType.CurrentPosition ? touch.position : deltaPosition);
                        startPosition = endPosition;
                        break;

                    case TouchPhase.Ended: // When the user lifts his finger from the screen
                        endPosition = touch.position;
                        deltaPosition = endPosition - startPosition;
                        OnTouchDown?.Invoke(_inputType == InputType.CurrentPosition ? touch.position : deltaPosition);
                        startPosition = endPosition;
                        break;
                }
            }
        }

        private void HandleMouseInput() {
            if (Input.GetMouseButtonDown(0)) { // When the user clicks the mouse button for the first time
                startPosition = Input.mousePosition;
                OnTouchDown?.Invoke(_inputType == InputType.CurrentPosition ? Input.mousePosition : Vector3.zero);
                return;
            }

            if (Input.GetMouseButton(0)) { // When the user holds the mouse button
                if (startPosition == Vector3.zero) return;
                if (startPosition == Input.mousePosition) return;

                endPosition = Input.mousePosition;
                deltaPosition = endPosition - startPosition;
                OnTouchDown?.Invoke(_inputType == InputType.CurrentPosition ? Input.mousePosition : deltaPosition);
                startPosition = endPosition;
                return;
            }

            if (Input.GetMouseButtonUp(0)) { // When the user releases the mouse button 
                endPosition = Input.mousePosition;
                deltaPosition = endPosition - startPosition;
                OnTouchUp?.Invoke();
                startPosition = endPosition;
            }

            return;
        }
    }
}