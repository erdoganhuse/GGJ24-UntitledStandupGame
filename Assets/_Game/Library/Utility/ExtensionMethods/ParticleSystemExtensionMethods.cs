using UnityEngine;

namespace Library.Utility
{
    public static class ParticleSystemExtensionMethods
    {
        public static void SetEmission(this ParticleSystem particleSystem, float emissionValue)
        {
            var emission = particleSystem.emission;
            emission.rateOverTime = emissionValue;
        }

        public static void SetSortOrder(this ParticleSystem particleSystem, int sortOrder)
        {
            var renderer = particleSystem.GetComponent<Renderer>();
            renderer.sortingOrder = sortOrder;
        }

        public static void SetLifeTime(this ParticleSystem particleSystem, float lifeTimeValue)
        {
            var main = particleSystem.main;
            main.startLifetime = lifeTimeValue;
        }

        public static void SetStartSpeed(this ParticleSystem particleSystem, float startSpeedValue)
        {
            var main = particleSystem.main;
            main.startSpeed = startSpeedValue;
        }

        public static void SetStartColor(this ParticleSystem particleSystem, ParticleSystem.MinMaxGradient startColor)
        {
            var main = particleSystem.main;
            main.startColor = startColor;
        } 
        
        public static void SetStartColor(this ParticleSystem particleSystem, Color startColor)
        {
            var main = particleSystem.main;
            main.startColor = new ParticleSystem.MinMaxGradient(startColor);
        } 
    }
}