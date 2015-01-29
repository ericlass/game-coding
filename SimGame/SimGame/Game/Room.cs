using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Game
{
  public class Room
  {
    public RoomDefinition Definition { get; set; }
    public int Level { get; set; }

    public Room(RoomDefinition definition)
    {
      Definition = definition;
    }
  }
}
