using Infrastructure.AudioModule.Base;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    [RequireComponent(typeof(CoinsProducer))]
    public class CoinProducerBustedAudioController : BustedAudioController
    {
        [SerializeField] private CoinsProducer _coinsProducer;

        protected override void Awake()
        {
            base.Awake();
            _coinsProducer ??= GetComponent<CoinsProducer>();
        }

        private void Start()
        {
            _coinsProducer.ProduceCoinEvent += OnCoinProduce;
        }

        private void OnCoinProduce()
        {
            _audioSource.Play();
        }
    }
}