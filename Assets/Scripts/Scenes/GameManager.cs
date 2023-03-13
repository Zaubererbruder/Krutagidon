using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scenes
{
    public class GameManager
    {
        public bool IsHost { get; set; } = true;
        public string Name { get => $"Player {(IsHost?"Host":"Joined")}"; }
    }
}
