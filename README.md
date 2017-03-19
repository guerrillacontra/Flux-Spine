# Flux-Spine
Extend the Unity3D Asset "Flux" to support Spine Animations both in the editor and at run-time.

# Requirements

1 - Flux Unity3D Asset https://www.assetstore.unity3d.com/en/#!/content/18440

2 - Spine Unity3D runtime https://github.com/EsotericSoftware/spine-runtimes/tree/master/spine-unity

# How to use

Add the "spine-flux" folder to your Assets root once you have installed a version of Flux and Spine.

You will need to use the Spine "Skeleton utility" http://esotericsoftware.com/spine-unity#SkeletonUtility-and-SpineUnity-Modules to convert the Spine bones untiy a Unity heirachy so that the controller can track changes inside editor mode.

Finally you can use the "Spine/Play Animation" event inside a Flux timeline to control your Spine characters.
