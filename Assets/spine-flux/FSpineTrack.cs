using UnityEngine;
using System.Collections;
using Flux;

public class FSpineTrack : FTransformTrack
{
    public override void UpdateEventsEditor(int frame, float time)
    {
      
        base.UpdateEventsEditor(frame, time);

        if (Sequence.IsPlayingForward)
        {
            var e = GetEventAfter(frame) as FSpineEvent;

            if(e == null)return;

            e.OnEditorUpdateEvent(time - e.StartTime);
        }
        else
        {
            var e = GetEventBefore(frame) as FSpineEvent;

            if (e == null) return;

            e.OnEditorUpdateEvent(time - e.StartTime);

        }



    }
}
