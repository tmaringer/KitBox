using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS
{
    public class Cupboard
    {
        private int _lockerAvailable;
        public int lockerAvailable
        {
            get => _lockerAvailable;
        }

        private List<ICupboardComponents> _cupboardComponentsList;
        public List<ICupboardComponents> cupboardComponentsList
        {
            get => _cupboardComponentsList;
        }

        public Cupboard()
        {
            _lockerAvailable = 7;
            _cupboardComponentsList = new List<ICupboardComponents>();
        }

        /// <summary>
        ///     resize the cupboard angles bracket
        /// </summary>
        /// <param name="size">
        ///     size wich will be deduct from cupboard angle bracket
        /// </param>
        public void cutAnglesBracket(int size)
        {
            getAngleBracket().cutHeight(size);
        }

        public double getPrice()
        {
            double componentsPrice = 0;
            foreach (ICupboardComponents component in _cupboardComponentsList)
            {
                componentsPrice += component.price;
            }
            return componentsPrice;
        }

        public void addCupboardComponent(ICupboardComponents component)
        {
            _cupboardComponentsList.Add(component);
        }

        public void addCupboardComponent(List<ICupboardComponents> componentList)
        {
            _cupboardComponentsList.AddRange(componentList);
        }

        public void removeCupboardComponent(ICupboardComponents component)
        {
            _cupboardComponentsList.Remove(component);
        }

        /// <summary>
        ///     check if the cupboard have all components which it must have 
        /// </summary>
        /// <returns>
        ///     return true if the cupboard have all components, false in other case
        /// </returns>
        public bool isComplete()
        {
            bool isOk = false;

            int numberOfAngleBracket = 0;
            int numberOfLocker = 0;

            foreach (ICupboardComponents component in _cupboardComponentsList)
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

            foreach (ICupboardComponents componants in _cupboardComponentsList)
            {
                angleNumberInList++;
                if (componants is AngleBracket)
                {
                    break;
                }
            }
            return angleNumberInList;
        }

        /// <summary>
        ///     check if all lockers of cupboard have all components which it must have 
        /// </summary>
        /// <returns>
        ///      return true if lockers have all components, false in other case
        /// </returns>
        private bool allLockerIsComplete()
        {
            bool isOk = true;

            foreach (ICupboardComponents component in _cupboardComponentsList)
            {
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
