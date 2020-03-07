using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS
{
    public class Cupboard
    {
        private static readonly int _lockerMaxAvailable = 7;

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
            _lockerAvailable = _lockerMaxAvailable;
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
            // the first part of "or" boolean expression check if when a locker is pass in parameter, there is enough locker available
            // the second part check if the angle bracket is in list, if not the function "locationOfAngleInList()" return -1
            if (((_lockerAvailable > 0) && (component is Locker)) || ((component is AngleBracket) && (locationOfAngleInList() == -1)))
            {
                _cupboardComponentsList.Add(component);
                if (component is Locker)
                    _lockerAvailable -= 1;
            }
        }

        public void addCupboardComponent(List<ICupboardComponents> componentList)
        {
            foreach(ICupboardComponents cupboardComponents in componentList)
            {
                addCupboardComponent(cupboardComponents);
            }
        }

        public void removeCupboardComponent(ICupboardComponents component)
        {
            if ((_cupboardComponentsList.Count > 0) )//&& (_lockerAvailable <= _lockerMaxAvailable))
            {
                _cupboardComponentsList.Remove(component);
                if(component is Locker)
                    _lockerAvailable += 1;
            }
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

        public int getHeightOfLocker()
        {
            int height = 0;
            foreach(ICupboardComponents component in _cupboardComponentsList)
            {
                if (component is Locker)
                    height += component.height;
            }
            return height;
        }

        private int locationOfAngleInList()
        {
            int angleNumberInList = -1;
            bool angleBracketDontExist = true;

            foreach (ICupboardComponents componants in _cupboardComponentsList)
            {
                angleNumberInList++;
                if (componants is AngleBracket)
                {
                    angleBracketDontExist = false;
                    break;
                }
            }
            if (angleBracketDontExist)
                angleNumberInList = -1;
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
