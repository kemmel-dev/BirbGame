using System;
using Birds;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Installers
{
    public class BirdInstaller : UnifyMonoInstaller
    {

        public BirdMono Bird;
        public CameraFollow CameraFollow;
        public Transform SwingPoint;
        
        public override void RegisterDependencies()
        {
            DefineDependency<Camera>().FromInstance(Camera.main).Register();
            DefineDependency<Rigidbody2D>().FromComponentOn(Bird).Register();
            DefineDependency<BirdMotor>().FromComponentOn(Bird).Register();
            DefineDependency<SpringJoint2D>().FromComponentOn(Bird).Register();
            DefineDependency<SpringController>().FromComponentOn(Bird).Register();
            DefineDependency<Transform>().FromInstance(Bird.transform).WithId(UnifyID.BirdTransform).Register();
            DefineDependency<Transform>().FromInstance(SwingPoint).WithId(UnifyID.SwingPoint).Register();
            DefineDependency<CameraFollow>().FromInstance(CameraFollow).Register();
        }
    }
}