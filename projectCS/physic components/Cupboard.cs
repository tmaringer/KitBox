using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS.physic_components
{
    public class Cupboard
    {
        private int _lockerAvailable;
        public int lockerAvailable
        {
            get => _lockerAvailable;
        }

        private List<CupboardComponents> _cupboardComponentsList;
        public List<CupboardComponents> cupboardComponentsList
        {
            get => _cupboardComponentsList;
        }

        public Cupboard()
        {
            _lockerAvailable = 7;
            _cupboardComponentsList = new List<CupboardComponents>();
        }

        public void cutAnglesBracket(int size)
        {
            getAngleBracket().height -= size;
        }

        public double getPrice()
        {
            double componentsPrice = 0;
            foreach (CupboardComponents component in _cupboardComponentsList)
            {
                componentsPrice += component.price;
            }
            return componentsPrice;
        }

        public void addCupboardComponent(CupboardComponents component)
        {
            _cupboardComponentsList.Add(component);
        }

        public void addCupboardComponent(List<CupboardComponents> componentList)
        {
            _cupboardComponentsList.AddRange(componentList);
        }

        public void removeCupboardComponent(CupboardComponents component)
        {
            _cupboardComponentsList.Remove(component);
        }

        public bool isComplete()
        {
            bool isOk = false;

            int numberOfAngleBracket = 0;
            int numberOfLocker = 0;

            foreach (CupboardComponents component in _cupboardComponentsList)
            {
                if (component is Locker)
                    numberOfLocker++;
                else
                    numberOfAngleBracket++;
            }

            // check if there is at least 1 locker and 1 angle (angle will be multiply by 4)
            if (((numberOfAngleBracket + numberOfLocker) >= 2) && allLockerIsComplete())
                isOk = true;
            return isOk;
        }

        public AngleBracket getAngleBracket()
        {
            return (AngleBracket)_cupboardComponentsList.ElementAt(locationOfAngleInList());
        }

        // TODO : terminer la classe qui calcul la haut des lockers
        private int computeHeightLocker()
        {
            return 0;
        }

        private int locationOfAngleInList()
        {
            int angleNumberInList = -1;

            foreach (CupboardComponents componants in _cupboardComponentsList)
            {
                angleNumberInList++;
                if (componants is AngleBracket)
                {
                    break;
                }
            }
            return angleNumberInList;
        }

        private bool allLockerIsComplete()
        {
            bool isOk = true;

            foreach (CupboardComponents component in _cupboardComponentsList)
            {
                Console.WriteLine(component);
                if (component is Locker)
                {
                    if (!((Locker)component).isComplete())
                    {
                        isOk = false;
                        break;
                    }
                }
            }
            return isOk;
        }
    }
}
