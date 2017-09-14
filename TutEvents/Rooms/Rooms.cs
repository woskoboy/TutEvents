using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rooms {

    abstract class Location {
        public Location[] Exits { get; }
        public string Name { get; private set; }
        public virtual string Description {
            get {
                string description = "Вы находитесь в " + Name +
                    ". Вы видите двери ведущие в ";
                for (int i=0; i<Exits.Length-1; i++) {
                    description += Exits[i].Name + ", ";
                }
                return description += ".";
            }
        }
        public Location(string name) {
            Name = name;
        }
    }

    class Room : Location {
        private string decoration;
        private string name;
        public Room(string name, string decoration) : base(name) {
            this.decoration = decoration;
        }
        public override string Description {
            get {
                return base.Description + "Вы видите " + decoration;
            }
        }
    }

    class RoomWithDoor : Room, IHasExteriorDoor {
        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration) {
            DoorDescription = doorDescription;
        }
        public string DoorDescription { get; private set; }
        public Location DoorLocation { get; set; }
    }

    class Outside : Location {
        private bool hot;
        public bool Hot { get { return this.hot; } }
        public Outside(string name, bool hot) : base(name) {
            this.hot = hot;
        }
        public override string Description {
            get {
                string newDescription = base.Description;
                if (Hot)
                    newDescription += " Тут очень жарко.";
                return newDescription; 
            }
        }

    }

    class OutsideWithDoor : Outside, IHasExteriorDoor {
        public string DoorDescription { get; private set; }
        public Location DoorLocation { get; set; }
        public OutsideWithDoor(string name, bool hot, string doorDescription) : base(name, hot) {
            DoorDescription = doorDescription;
        }
        public override string Description {
            get {
                return base.Description + "Вы видите " + DoorDescription;
            }
        }
    }

    interface IHasExteriorDoor {
        Location DoorLocation { get; set; } 
        string DoorDescription { get; } 
    }
}
