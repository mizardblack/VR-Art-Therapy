//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("Scripts/MRTK/Examples/SliderChangeColorHSV")]

    public class SliderChangeColorHSV : MonoBehaviour
    {
        [SerializeField]
        private Renderer TargetRendererBrush;
        [SerializeField]
        private Renderer TargetRendererLight;
        [SerializeField]
        private Renderer TargetRendererTrack1;
        [SerializeField]
        private Renderer TargetRendererTrack2;
        private MaterialPropertyBlock propertyBlock;

        void Start()
        {
            //create propertyblock only if none exists
            if (propertyBlock == null)
            {
                propertyBlock = new MaterialPropertyBlock();
            }

            //Get a renderer component either of the own gameobject or of a child
            TargetRendererBrush = GetComponentInChildren<Renderer>();

            //set the color property
            if ((TargetRendererBrush != null) && (TargetRendererBrush.material != null))
            {
                TargetRendererBrush.material.color = Color.HSVToRGB(0.32f, 0.77f, 0.58f);
            }
            propertyBlock.SetColor("_Color", TargetRendererBrush.material.color);

            //apply propertyBlock to renderer
            TargetRendererLight.SetPropertyBlock(propertyBlock);
        }

        public void OnSliderUpdatedHue(SliderEventData eventData)
        {
            //create propertyblock only if none exists
            if (propertyBlock == null)
            {
                propertyBlock = new MaterialPropertyBlock();
            }

            //Get a renderer component either of the own gameobject or of a child
            TargetRendererBrush = GetComponentInChildren<Renderer>();

            //set the color property
            if ((TargetRendererBrush != null) && (TargetRendererBrush.material != null))
            {
                float H, S, V;
                Color.RGBToHSV(TargetRendererBrush.material.color, out H, out S, out V);
                TargetRendererBrush.material.color = Color.HSVToRGB(eventData.NewValue, S, V);
                TargetRendererTrack1.material.color = Color.HSVToRGB(eventData.NewValue, 1f, 1f);
                TargetRendererTrack2.material.color = Color.HSVToRGB(eventData.NewValue, 1f, 1f);
            }
            propertyBlock.SetColor("_Color", TargetRendererBrush.material.color);

            //apply propertyBlock to renderer
            TargetRendererLight.SetPropertyBlock(propertyBlock);
        }

        public void OnSliderUpdatedSaturation(SliderEventData eventData)
        {
            //create propertyblock only if none exists
            if (propertyBlock == null)
            {
                propertyBlock = new MaterialPropertyBlock();
            }

            //Get a renderer component either of the own gameobject or of a child
            TargetRendererBrush = GetComponentInChildren<Renderer>();

            //set the color property
            if ((TargetRendererBrush != null) && (TargetRendererBrush.material != null))
            {
                float H, S, V;
                Color.RGBToHSV(TargetRendererBrush.material.color, out H, out S, out V);
                TargetRendererBrush.material.color = Color.HSVToRGB(H, eventData.NewValue, V);
            }
            propertyBlock.SetColor("_Color", TargetRendererBrush.material.color);

            //apply propertyBlock to renderer
            TargetRendererLight.SetPropertyBlock(propertyBlock);
        }

        public void OnSliderUpdateValue(SliderEventData eventData)
        {
            //create propertyblock only if none exists
            if (propertyBlock == null)
            {
                propertyBlock = new MaterialPropertyBlock();
            }

            //Get a renderer component either of the own gameobject or of a child
            TargetRendererBrush = GetComponentInChildren<Renderer>();

            //set the color property
            if ((TargetRendererBrush != null) && (TargetRendererBrush.material != null))
            {
                float H, S, V;
                Color.RGBToHSV(TargetRendererBrush.material.color, out H, out S, out V);
                TargetRendererBrush.material.color = Color.HSVToRGB(H, S, eventData.NewValue);
            }
            propertyBlock.SetColor("_Color", TargetRendererBrush.material.color);

            //apply propertyBlock to renderer
            TargetRendererLight.SetPropertyBlock(propertyBlock);
        }
    }
}
