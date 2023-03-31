using Birds;
using Helpers;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Installers
{
    public class BirdInstaller : UnifyMonoInstaller
    {

        public float FlyForce;
        public BirdMotor BirdMotor;
        
        public override void RegisterDependencies()
        {
            DefineDependency<Bird>().FromInstance(new Bird(FlyForce)).Register();
            DefineDependency<BirdMotor>().FromInstance(BirdMotor).Register();
            DefineDependency<Rigidbody2D>().FromComponentOn(BirdMotor).Register();
            DefineDependency<SpringJoint2D>().FromComponentOnGameObject(BirdMotor.gameObject).Register();
            DefineDependency<SpringOrientationHelper>().FromComponentOnGameObject(BirdMotor.gameObject).Register();
        }
    }
}