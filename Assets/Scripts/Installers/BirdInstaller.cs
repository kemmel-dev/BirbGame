using System;
using Birds;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Installers
{
    public class BirdInstaller : UnifyMonoInstaller
    {

        public BirdZoomTrigger Bird;
        public Camera mainCamera;
        public Transform SwingPoint;
        public Transform BirdCameraTarget;
        
        public override void RegisterDependencies()
        {
            DefineDependency<Camera>().FromInstance(Camera.main).Register();
            DefineDependency<Rigidbody2D>().FromComponentOn(Bird).Register();
            DefineDependency<BirdMotor>().FromComponentOn(Bird).Register();
            DefineDependency<SpringJoint2D>().FromComponentOn(Bird).Register();
            DefineDependency<SpringController>().FromComponentOn(Bird).Register();
            DefineDependency<Transform>().FromInstance(BirdCameraTarget).WithId(UnifyID.BirdCameraTarget).Register();
            DefineDependency<Transform>().FromInstance(SwingPoint).WithId(UnifyID.SwingPoint).Register();
            DefineDependency<CameraFollow>().FromComponentOn(mainCamera).Register();
            DefineDependency<CameraZoom>().FromComponentOn(mainCamera).Register();
        }
    }
}