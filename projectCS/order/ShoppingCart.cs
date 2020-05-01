using projectCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    /// <summary>
    ///     This class takes several components from catalogue and build locker with objects stored in list.
    ///     It build also cupboard with lockers and angle bracket stored in a other list.
    /// </summary>
    public static class ShoppingCart
    {
        private static List<CatalogueComponents> _catalogueComponentsList = new List<CatalogueComponents>();
        public static List<CatalogueComponents> catalogueComponentsList
        {
            get => _catalogueComponentsList;
        }

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

        private static int _heigtChosen;
        public static int HeigtChosen 
        { 
            get => _heigtChosen; 
            set => _heigtChosen = value; 
        }

        private static int _depthChosen;
        public static int depthChosen
        {
            get => _depthChosen;
        }

        private static int _heigtLockerChosen;
        public static int HeigtLockerChosen 
        { 
            get => _heigtLockerChosen; 
            set => _heigtLockerChosen = value; 
        }

        private static ComponentColor _colorDoodChosen;
        public static ComponentColor ColorDoodChosen 
        { 
            get => _colorDoodChosen;
            set => _colorDoodChosen = value; 
        }

        private static Cupboard _cupboard;
        public static Cupboard cupboard
        {
            get => _cupboard;
        }

        private static int _currentLocker = 0;
        public static int currentLocker
        {
            get => _currentLocker;
            set => _currentLocker = value;
        }

        public static void addCupboardUserChoices(int width, int depth, int boxNumber, ComponentColor colorAngleBracket)
        {
            _widthChosen = width;
            _depthChosen = depth;
            _boxNumberChosen = boxNumber;
            _colorAngleBracketChosen = colorAngleBracket;
        }
        
        public static void addLockerUserChoices(int heigt, ComponentColor panelColor, ComponentColor doodColor)
        {
            _heigtLockerChosen = heigt;
            _colorAngleBracketChosen = panelColor;
            _colorDoodChosen = doodColor;
        }

        // todo : voir si on autorise d'ajouter plus de composant pour un locker ou si on limite
        public static void addCatalogueComponent(CatalogueComponents component)
        {
            _catalogueComponentsList.Add(component);
        }

        // todo : voir si on autorise d'ajouter plus de composant pour un locker ou si on limite
        public static void removeCatalogueComponent(CatalogueComponents component)
        {
            _catalogueComponentsList.Remove(component);
        }

        /// <summary>
        ///     Builds locker from components stored in list. It also removes components which are used to build locker.
        /// </summary>
        /// <returns>
        ///     Returns the locker built.
        /// </returns>
        public static Locker buildLocker()
        {
            Locker locker = new Locker();
            // temporary list which store components added to the locker and is used thereafter to remove components in the main list
            List<CatalogueComponents> tempList = new List<CatalogueComponents>();
            bool componentWasAdded = false;

            foreach (CatalogueComponents component in _catalogueComponentsList)
            {
                componentWasAdded = locker.addComponent(component);
                if (componentWasAdded)
                    tempList.Add(component);
            }

            foreach (CatalogueComponents component in tempList)
            {
                _catalogueComponentsList.Remove(component);
            }

            return locker;
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
        ///     Builds cupboard from components stored. It also removes components which are used to build cupboard.
        /// </summary>
        /// <returns>
        ///     Returns the cupboard built.
        /// </returns>
        public static Cupboard buildCupboard()
        {
            _cupboard = new Cupboard();
            // temporary list which store components added to the cupboard and is used thereafter to remove components in the main list
            List<ICupboardComponents> tempList = new List<ICupboardComponents>();

            foreach (ICupboardComponents cupboardComponent in _cupboardComponentsList)
            {
                _cupboard.addCupboardComponent(cupboardComponent);
                tempList.Add(cupboardComponent);
            }

            foreach (ICupboardComponents component in tempList)
            {
                _cupboardComponentsList.Remove(component);
            }
            return _cupboard;
        }

        public static Locker getSpecificLocker(int lockerID)
        {
            int lockerEmplacement = 0;
            foreach(ICupboardComponents component in _cupboardComponentsList)
            {
                if(component is Locker)
                {
                    if (((Locker)component).ID == lockerID)
                        break;
                }
                lockerEmplacement += 1;
            }
            return (Locker)_cupboardComponentsList.ElementAt(lockerEmplacement);
        }
        
        public static string ToString()
        {
            return "catalogue components list : "
                   + _catalogueComponentsList
                   + ", cupboard componentsList list : "
                   + _cupboardComponentsList;
        }
    }
}
