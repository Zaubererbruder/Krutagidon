using Assets.Scripts.Krutagidon;
using Assets.Scripts.Network;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scenes
{
    public class InGameController : MonoBehaviour
    {
        [SerializeField] WizardInfoUIGroup _wizardInfoUIGroup;
        private GameManager _gameManager;
        private Server _server;

        [Inject]
        public void Construct(GameManager gameManager, Server server)
        {
            _gameManager = gameManager;
            _server = server;
        }

        private void Start()
        {
            _server.PlayersListChanged += UpdatePlayersUI;
        }

        private void UpdatePlayersUI()
        {
            //_wizardInfoUIGroup.UpdateWizards(_server.Players);
        }

        private void OnDestroy()
        {
            _server.PlayersListChanged -= UpdatePlayersUI;
        }
    }
}
