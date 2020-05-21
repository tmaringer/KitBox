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

        public double price
        {
            get
            {
                double componentsPrice = 0;
                foreach (ICupboardComponents component in _cupboardComponentsList)
                {
                    componentsPrice += component.price;
                }
                return componentsPrice;
            }
        }


        public Cupboard()
        {
            _cupboardComponentsList = new List<ICupboardComponents>();
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
    }
}
