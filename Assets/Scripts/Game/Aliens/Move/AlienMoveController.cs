using GameExtensions;
using Infrastructure.Factory.GameFactory;
using UnityEngine;

namespace Game.Aliens.Move
{
    public class AlienMoveController
    {
        private readonly AlienMoveModel _alienMoveModel;
        private readonly AlienMove _alienMove;
        private readonly IGameFactory _gameFactory;

        public AlienMoveController(AlienMoveModel alienMoveModel, AlienMove alienMove, IGameFactory gameFactory)
        {
            _alienMoveModel = alienMoveModel;
            _alienMove = alienMove;
            _gameFactory = gameFactory;

            Subscribe();
        }

        private void Subscribe()
        {
            _alienMove.MoveToPlayer += AlienMoveOnMoveToPlayer;
        }

        private void AlienMoveOnMoveToPlayer(GameObject alien)
        {
            Vector3 directionToTarget = _gameFactory.PlayerShip.transform.position - alien.transform.position;
            Vector3 distance = directionToTarget.normalized * _alienMoveModel.Speed * Time.deltaTime;
            _alienMoveModel.Position = alien.transform.position + distance;
            alien.transform.position = _alienMoveModel.Position;
            alien.transform.LookAt2D(_gameFactory.PlayerShip.transform.position);
        }
    }
}