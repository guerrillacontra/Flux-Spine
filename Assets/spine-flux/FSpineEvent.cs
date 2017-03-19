using UnityEngine;
using System.Collections;
using Flux;
using Spine.Unity;
using Assets.WTWDT.Scripts;

[FEvent("Spine/Play Animation", typeof(FSpineTrack))]
public class FSpineEvent : FEvent
{
    [HideInInspector]
    [SerializeField]
    private SkeletonAnimation _animation;

    [SerializeField]
    private string _animName;

    [SerializeField]
    private bool _loop;


    [SerializeField]
    private bool _stopWhenExited;

    protected override void SetDefaultValues()
    {

        base.SetDefaultValues();
    }

    protected override void OnInit()
    {
        if (!_animation)
        {
            _animation = Owner.gameObject.GetComponent<SkeletonAnimation>();
        }


        _spineTrack = (FSpineTrack)_track;


        base.OnInit();
    }


    private bool _wasInteractive = false;
   

    protected override void OnTrigger(float timeSinceTrigger)
    {
        
        if (Owner.gameObject.GetComponent<MeshRenderer>())
        {
            Owner.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }


        if(Owner.gameObject.GetComponent<InteractableCharacter>())
        {
            _wasInteractive = Owner.gameObject.GetComponent<InteractableCharacter>().enabled;
            Owner.gameObject.GetComponent<InteractableCharacter>().enabled = false;
        }

        _delta = 0;

        _animation.skeleton.FlipX = false;

        _animation.Initialize(false);
        _animation.state.SetAnimation(0, _animName, _loop);
     

        base.OnTrigger(timeSinceTrigger);
    }

    public void OnEditorUpdateEvent(float time)
    {
        if (_animation == null || _animation.state == null) return;

        var track = _animation.state.GetCurrent(0);

        if (track == null) return;

        track.Time = time;

        _animation.Update(0);
    }


    protected override void OnFinish()
    {
        if (Owner.gameObject.GetComponent<InteractableCharacter>())
        {
            Owner.gameObject.GetComponent<InteractableCharacter>().enabled = _wasInteractive;
        }

        if (_stopWhenExited)
        {
            _animation.state.ClearTracks();
        }


        base.OnFinish();
    }

    protected override void OnUpdateEvent(float timeSinceTrigger)
    {

        base.OnUpdateEvent(timeSinceTrigger);
    }



    private float _delta = 0;
    private FSpineTrack _spineTrack;
}
