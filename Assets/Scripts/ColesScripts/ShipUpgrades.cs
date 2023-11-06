using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUpgrades : MonoBehaviour
{
    class Decorator
    {
        static void Main(string[] args)
        {
            BaseShip ship = new Ship();
            BaseShip CannonDecorator = new CannonDecorator(ship);
            //Console.WriteLine(ship.GetShipTypes());
            //Console.ReadLine();
        }
    }

    //base interface
    interface BaseShip
    {
        string GetShipTypes();
    }

    //concrete implementation
    class Ship : BaseShip
    {
        public string GetShipTypes()
        {
            return "this ship is unadorned";
        }
    }

    //base decorator
    class ShipDecorator : BaseShip
    {
        private BaseShip _ship;

        public ShipDecorator(BaseShip ship)
        {
            _ship = ship;
        }

        public virtual string GetShipTypes()
        {
            return _ship.GetShipTypes();
        }
    }

    // concrete decorators
    class CannonDecorator : ShipDecorator
    {
        public CannonDecorator(BaseShip ship) : base(ship) { }

        public override string GetShipTypes()
        {
            string type = base.GetShipTypes();
            type += "\r\n with L cannons";
            return type;
        }
    }
}
