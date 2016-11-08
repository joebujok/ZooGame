using UnityEngine;
using System.Collections;

public interface IDogState {

    void UpdateState();

    void ToSleepState();

    void ToWalkingState();

    void ToRunningState();

    void HandleRoomClick(RaycastHit hit);

    void HandleMeClick(RaycastHit hit);
}
