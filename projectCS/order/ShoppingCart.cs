using System.Collections.Generic;
using System.Linq;

namespace projectCS
{
    /// <summary>
    ///     This class takes several components from catalogue and build locker with objects stored in list.
    ///     It build also cupboard with lockers and angle bracket stored in a other list.
    /// </summary>
    public static class ShoppingCart
    {       
        private static List<ICupboardComponents> _cupboardComponentsList = new List<ICupboardComponents>();
        public static List<ICupboardComponents> cupboardComponentsList
        {
            get => _cupboardComponentsList;
        }

        private static ComponentColor _colorAngleBracketChosen;
        public static ComponentColor colorAngleBracketChosen
        {
            get => _colorAngleBracketChosen;
        }

        private static int _boxNumberChosen;
        public static int boxNumberChosen
        {
            get => _boxNumberChosen;
        }

        private static int _widthChosen;
        public static int widthChosen
        {
            get => _widthChosen;
        }

        public static int heigth
        {
            get
            {
                int height = 0;
                foreach (ICupboardComponents cupcompo in _cupboardComponentsList)
                {
                    if (cupcompo is Locker)
                        height += ((Locker)cupcompo).height;
                }
                return height;
            }
        }

        private static int _depthChosen;
        public static int depthChosen
        {
            get => _depthChosen;
        }

        private static int _currentLocker = 0;
        public static int currentLocker
        {
            get => _currentLocker;
            set => _currentLocker = value;
        }

        /// <summary>
        ///     Adds and saves customer's choices concerning cupboard.
        /// </summary>
        public static void addCupboardUserChoices(int width, int depth, int boxNumber, ComponentColor colorAngleBracket)
        {
            _widthChosen = width;
            _depthChosen = depth;
            _boxNumberChosen = boxNumber;
            _colorAngleBracketChosen = colorAngleBracket;
        }
     
        public static void addCupboardComponent(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Add(cupboardComponent);
        }

        public static void removeCupboardComponent(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Remove(cupboardComponent);
        }

        /// <summary>
        ///     Search for a locker in local list which matches with given id.
        /// </summary>
        /// <param name="lockerID">
        ///     Locker ID to find in local list.
        /// </param>
        /// <returns>
        ///     Locker which matches with given ID or a new locker.
        /// </returns>
        public static Locker getLockerByID(int lockerID)
        {
            int lockerEmplacement = 0;
            foreach (ICupboardComponents component in _cupboardComponentsList)
            {
                if (component is Locker)
                {
                    if (((Locker)component).ID == lockerID)
                        break;
                }
                lockerEmplacement += 1;
            }

            if (lockerEmplacement >= _cupboardComponentsList.Count)
                return new Locker();

            else
                return (Locker)_cupboardComponentsList.ElementAt(lockerEmplacement);
        }

        public static void resetShoppingCard()
        {
            _cupboardComponentsList = new List<ICupboardComponents>();

            _colorAngleBracketChosen = ComponentColor.black;

            _boxNumberChosen = 0;

            _widthChosen = 0;

            _depthChosen = 0;

            _currentLocker = 0;
        }

        public static string ToString()
        {
            return "cupboard componentsList list : "
                   + _cupboardComponentsList;
        }
    }
}
