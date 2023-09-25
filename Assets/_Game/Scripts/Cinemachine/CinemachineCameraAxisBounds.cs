using UnityEngine;
using Cinemachine.Utility;
using Cinemachine;

/// <summary>
/// An add-on module for Cinemachine Virtual Camera that Locks the Camera position to one or more axis
/// </summary>
[AddComponentMenu("")] // Hide in menu
#if UNITY_2018_3_OR_NEWER
[ExecuteAlways]
#else
[ExecuteInEditMode]
#endif
[SaveDuringPlay]
public class CinemachineCameraAxisBounds : CinemachineExtension {
    /// <summary>
    /// Lock Camera position to this axis
    /// </summary>
    public Vector2 _lockXRange = new Vector2(0, 0);

    public float posY=5.63f;

    /// <summary>
    /// Applies the specified offset to the camera state
    /// </summary>
    /// <param name="vcam">The virtual camera being processed</param>
    /// <param name="stage">The current pipeline stage</param>
    /// <param name="state">The current virtual camera state</param>
    /// <param name="deltaTime">The current applicable deltaTime</param>
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state,
        float deltaTime) {
        if (stage != CinemachineCore.Stage.Body) return;
        var pos = state.RawPosition;
        if (pos.x < _lockXRange.x) pos.x = _lockXRange.x;
        if (pos.x > _lockXRange.y) pos.x = _lockXRange.y;
        pos.y = posY;
        state.RawPosition = pos;
    }
}