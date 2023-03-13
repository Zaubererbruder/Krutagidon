using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SceneBoardContext : MonoBehaviour
    {
        [field: SerializeField] public Transform PlayerCardContainer;
        [field: SerializeField] public EnemyView EnemyView;
    }
}
