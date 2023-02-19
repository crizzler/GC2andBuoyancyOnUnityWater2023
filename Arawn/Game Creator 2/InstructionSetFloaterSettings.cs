using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using JetBrains.Annotations;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting.Arawn
{
    [Version(1, 0, 0)]
    [Title("Set Floater Settings")]
    [Description("Sets the floater Settings of a Game Object with Rigidbody and Floater component")]
    [Image(typeof(IconPhysics), ColorTheme.Type.Gray)]
    [Category("Arawn/Unity Water/Set Floater Settings")]
    [Keywords("Set Floater Settings", "Arawn", "Ocean", "Water", "Buoyancy", "HDRP", "Unity Water")]

    [Serializable]
    public class InstructionSetFloaterSet : Instruction
    {
        [SerializeField] private PropertyGetGameObject m_Floater = new PropertyGetGameObject();
        [SerializeField] private PropertyGetDecimal m_DepthBeforeSub = new PropertyGetDecimal();
        [SerializeField] private PropertyGetDecimal m_DisplacementAmount = new PropertyGetDecimal();
        [SerializeField] private PropertyGetDecimal m_WaterDrag = new PropertyGetDecimal();
        [SerializeField] private PropertyGetDecimal m_WaterAngularDrag = new PropertyGetDecimal();

        public override string Title => $"Set Floating Properties {this.m_Floater}";

        protected override Task Run(Args args)
        {
            GameObject gameObject = this.m_Floater.Get(args);

            float depthBeforeSub = (float)this.m_DepthBeforeSub.Get(args);
            float displacementAmount = (float)this.m_DisplacementAmount.Get(args);
            float waterDrag = (float)this.m_WaterDrag.Get(args);
            float waterAngularDrag = (float)this.m_WaterAngularDrag.Get(args);

            Floater floater = gameObject.GetComponent<Floater>();
            floater.DepthBeforeSub = depthBeforeSub;
            floater.DisplacementAmount = displacementAmount;
            floater.WaterDrag = waterDrag;
            floater.WaterAngularDrag = waterAngularDrag;


            return DefaultResult;
        }
    }
}
