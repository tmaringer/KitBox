using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public class Locker : CupboardComponents
    {
        public override double price
        {
            get
            {
                _price = 0;
                foreach (LockerComponents price in componentsList)
                {
                    _price += price.price; 
                } 
                return _price;
            }
        }

        private int _width;
        public int width
        {
            get => _width;
        }

        private int _depth;
        public int depth
        {
            get => _depth;
        }

        private int _numberOfLCrossBar;
        public int numberOfLCrossBar
        {
            get => _numberOfLCrossBar;
        }

        private int _numberOfPannel;
        public int numberOfPannel
        {
            get => _numberOfPannel;
        }

        private int _numberOfDoor;
        public int numberOfDoor
        {
            get => _numberOfDoor;
        }

        private int _numberOfCleat;
        public int numberOfCleat
        {
            get => _numberOfCleat;
        }

        private List<LockerComponents> _componentsList;
        public List<LockerComponents> componentsList
        {
            get => _componentsList;
        }

        public Locker() : this(0, "null", "0000", 0, false, 0)
        {
        }

        public Locker(double price,
                     string reference,
                     string code,
                     int size,
                     bool inStock,
                     double height) : base(price, reference, code, size, inStock, height)
        {
            _width = 0;
            _depth = 0;
            _componentsList = new List<LockerComponents>();
        }

        public void addComponent(LockerComponents component)
        {
            /*
            switch (component)
            {
                case CrossBar c:
                    _numberOfLCrossBar++;
                    break;
                case Pannel p:
                    _numberOfPannel++;
                    break;
                case Door d:
                    _numberOfDoor++;
                    break;
                case Cleat cl:
                    _numberOfCleat++;
                    break;
                default:
                    break;
            }          
            */
            _componentsList.Add(component);
        }

        public void addComponent(List<LockerComponents> componentList)
        {
            _componentsList.AddRange(componentList);
        }

        public void removeComponent(LockerComponents component)
        {
            _componentsList.Remove(component);
        }
        
        public bool isComplete()
        {
            bool isOk = false;
            int numberOfCrossBar = 0;
            int numberOfPannel = 0;
            int numberOfCleat = 0;

            foreach (LockerComponents component in _componentsList)
            {
                switch (component)
                {
                    case CrossBar c :
                        numberOfCrossBar++;
                        break;
                    case Pannel p:
                        numberOfPannel++;
                        break;
                    case Cleat cl:
                        numberOfCleat++;
                        break;
                    default:
                        break;
                }
            }

            // check if the locker has 8xcrossbar + 5xPannel + 4xCleat
            if ((numberOfCrossBar == 8) && (numberOfPannel == 5) && (numberOfCleat == 4))
                isOk = true;

            return isOk;
        }
    }
}
