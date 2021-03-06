﻿using UnityEngine;
using System.Collections;
using Fungus;

namespace Fungus3D
{
    // declare this command in Fungus
    [CommandInfo("Action", "Grab", "Grab somthing with Left or Right arm")]

    /// <summary>
    /// The WalkTo Command for Fungus
    /// </summary>

    public class Action_Grab : Action_Command
    {
        #region Members

        public enum WhichArm { undefined, leftArm, rightArm }
        public enum GrabState { undefined, grab, release }

        // whether we should be sitting or not
        public WhichArm whichArm = WhichArm.undefined;
        public GrabState grabbing = GrabState.undefined;

        #endregion


        #region Action

        /// <summary>
        /// This code is executed when the command fires.
        /// </summary>

        public override void OnEnter()
        {
            if (whichArm == WhichArm.leftArm && grabbing == GrabState.grab)
            {
                animator.SetBool("ReachLeft", true);
            }
            else if (whichArm == WhichArm.leftArm && grabbing == GrabState.release)
            {
                animator.SetBool("ReachLeft", false);
            }
            else if (whichArm == WhichArm.rightArm && grabbing == GrabState.grab)
            {
                animator.SetBool("ReachRight", true);
            }
            else if (whichArm == WhichArm.rightArm && grabbing == GrabState.release)
            {
                animator.SetBool("ReachRight", false);
            }
            // move on to next Fungus command
            Continue();
        }

        #endregion


        #region Summary

        /// <summary>
        /// This is the summary that appears in the list of Fungus block commands
        /// </summary>

        public override string GetSummary()
        {
            string name = gameObject.GetComponentInParent<Animator>().gameObject.name;

            if (actor != null)
            {
                name = actor.name;
            }

            if (whichArm == WhichArm.leftArm && grabbing == GrabState.grab)
            {
                return name + " Reach Left Arm";
            }
            else if (whichArm == WhichArm.leftArm && grabbing == GrabState.release)
            {
                return name + " Release Left Arm";
            }
            else if (whichArm == WhichArm.rightArm && grabbing == GrabState.grab)
            {
                return name + " Reach Right Arm";
            }
            else if (whichArm == WhichArm.rightArm && grabbing == GrabState.release)
            {
                return name + " Release Right Arm";
            }

            return name + " Arm Undefined";
        }

        #endregion

    }

}
