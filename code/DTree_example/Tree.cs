﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node rootNode = null;

        protected void Start()
        {
            rootNode = SetupTree();
        }

        private void Update()
        {
            if (rootNode != null) rootNode.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}