using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS
{
    public class Cupboard
    {
        private static readonly int _lockerMaxAvailable = 7;

        public int lockerAvailable
        {
            get
            {
                int currentAvailableLockers = _lockerMaxAvailable;
                foreach (ICupboardComponents component in _cupboardComponentsList)
                {
                    if (component is Locker)
                        currentAvailableLockers--;
                }
                return currentAvailableLockers;
            }
        }

        private List<ICupboardComponents> _cupboardComponentsList;
        public List<ICupboardComponents> cupboardComponentsList
        {
            get => _cupboardComponentsList;
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


        public Cupboard() : this(0, 0, 5, ComponentColor.black)
        {
        }
            
        public Cupboard(int width, int depth, int boxNumber, ComponentColor colorAngleBracket)
        {
            _cupboardComponentsList = new List<ICupboardComponents>();
            _width = width;
            _depth = depth;
        }

        /// <summary>
        ///     Resize the cupboard angles bracket
        /// </summary>
        /// <param name="size">
        ///     Size wich will be cut of angle bracket of cupboard
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

        /// <summary>
        ///     Adds a cupboard component to this cupboard.
        /// </summary>
        /// <param name="component">
        ///     Component to be added which must be eiher locker or angle bracket.
        /// </param>
        public void addCupboardComponent(ICupboardComponents component)
        {
            // the first part of "or" boolean expression check if when a locker is pass in parameter, there is enough locker available
            // the second part check if the angle bracket is in list, if not the function "locationOfAngleInList()" return -1
            if (((lockerAvailable > 0) && (component is Locker)) || ((component is AngleBracket) && (locationOfAngleInList() == -1)))
            {
                _cupboardComponentsList.Add(component);
            }
        }

        /// <summary>
        ///     Adds a list of cupboard components to this cupboard.
        /// </summary>
        /// <param name="componentList">
        ///     Components list to be added which must be eiher locker or angle bracket.
        /// </param>
        public void addCupboardComponent(List<ICupboardComponents> componentList)
        {
            foreach (ICupboardComponents cupboardComponents in componentList)
            {
                addCupboardComponent(cupboardComponents);
            }
        }

        /// <summary>
        ///     Removes a component from this cupboard.
        /// </summary>
        /// <param name="component">
        ///     Components to be removed from cupboard
        /// </param>
        public void removeCupboardComponent(ICupboardComponents component)
        {
            _cupboardComponentsList.Remove(component);
        }

        /// <summary>
        ///     Check if the cupboard has all minimal components which it must have.
        /// </summary>
        /// <returns>
        ///     Return true if the cupboard have all components, false in other case
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

        /// <summary>
        ///     Get angle bracket of this cupboard.
        /// </summary>
        /// <returns>
        ///     Return the angle bracket of cubpaord, otherwise return an default angle bracket
        /// </returns>
        public AngleBracket getAngleBracket()
        {
            AngleBracket angle = new AngleBracket();
            if (locationOfAngleInList() != -1)
                angle = (AngleBracket)_cupboardComponentsList.ElementAt(locationOfAngleInList());
            return angle;
        }

        public int getHeightOfLocker()
        {
            int height = 0;
            foreach (ICupboardComponents component in _cupboardComponentsList)
            {
                if (component is Locker)
                    height += component.height;
            }
            return height;
        }

        /// <summary>
        ///     Locates the position of angle bracket in CupboardComponent list.
        /// </summary>
        /// <returns>
        ///     Returns the position of angle bracket, otherwise returns -1.
        /// </returns>
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
        ///     Check if all lockers of cupboard have all components which they be able to contains.
        /// </summary>
        /// <returns>
        ///      Returns true if lockers have all components, false in other case
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
