using Birds;
using Plugins.Unify.Core.Installers;
using UnityEngine;

namespace Installers
{
    public class BirdInstaller : UnifyMonoInstaller
    {

        public GameObject bird;
        
        public override void RegisterDependencies()
        {
            DefineDependency<Camera>().FromInstance(Camera.main).Register();
            DefineDependency<Rigidbody2D>().FromComponentOnGameObject(bird).Register();
            DefineDependency<BirdMotor>().FromComponentOnGameObject(bird).Register();
            DefineDependency<SpringJoint2D>().FromComponentOnGameObject(bird).Register();
            DefineDependency<SpringController>().FromComponentOnGameObject(bird).Register();
        }
    }
}