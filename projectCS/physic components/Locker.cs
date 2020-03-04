using System.Collections.Generic;

namespace projectCS
{
    public class Locker : ICupboardComponents
    {
        /// <summary>
        ///     group all maximum value for each components which the locker can have
        /// </summary>
        private static readonly int maximumCrossBars = 8;
        private static readonly int maximumPannels = 5;
        private static readonly int maximumDoors = 2;
        private static readonly int maximumCleats = 4;

        // TODO : compléter pour que sa calcul automatiquement la hauteur en fonction des composants
        public int height 
        { 
            get => 0;
        }

        public double price
        {
            get
            {
                double componentsPrice = 0;
                foreach (CatalogueComponents component in _componentsList)
                {
                    componentsPrice += component.price;
                }
                return componentsPrice;
            }
        }

        // TODO : compléter pour que sa calcul automatiquement la hauteur en fonction des composants
        private int _width;
        public int width
        {
            get => _width;
        }

        // TODO : compléter pour que sa calcul automatiquement la hauteur en fonction des composants
        private int _depth;
        public int depth
        {
            get => _depth;
        }

        // TODO : a refactorer si inutile par la suite
        /*
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
        */
        private List<CatalogueComponents> _componentsList;
        public List<CatalogueComponents> componentsList
        {
            get => _componentsList;
        }
               
        public Locker()
        {
            _width = 0;
            _depth = 0;
            _componentsList = new List<CatalogueComponents>();
        }

        public void addComponent(CatalogueComponents component)
        {
            bool isOk = false;
            switch (component)
            {
                case CrossBar c:
                    if (numberOfComponentInList(component) < maximumCrossBars)
                        isOk = true;
                    break;
                case Pannel p:
                    if (numberOfComponentInList(component) < maximumPannels)
                        isOk = true;
                    break;
                case Door d:
                    if (numberOfComponentInList(component) < maximumDoors)
                        isOk = true;
                    break;
                case Cleat cl:
                    if (numberOfComponentInList(component) < maximumCleats)
                        isOk = true;
                    break;
                default:
                    break;
            }          
            
            if (isOk)
                _componentsList.Add(component);
        }

        // TODO : vérifier dans l'ajout qu'il ya encore de la place dans le locker et qu'on a pas atteint le nbr de composant max
        public void addComponent(List<CatalogueComponents> componentList)
        {
            _componentsList.AddRange(componentList);
        }

        // TODO : vérifier si ca ne bugge pas quand on enlève un composant qui n'existe pas
        public void removeComponent(CatalogueComponents component)
        {
            _componentsList.Remove(component);
        }

        /// <summary>
        ///     check if the locker have all components that it must have 
        /// </summary>
        /// <returns>
        ///     return true if the locker have all components, false in other case
        /// </returns>
        public bool isComplete()
        {
            bool isOk = false;
            int numberOfCrossBar = numberOfComponentInList(new CrossBar());
            int numberOfPannel = numberOfComponentInList(new Pannel());
            int numberOfCleat = numberOfComponentInList(new Cleat());

            // check if the locker has 8xcrossbar + 5xPannel + 4xCleat
            if ((numberOfCrossBar == maximumCrossBars) && (numberOfPannel == maximumPannels) && (numberOfCleat == maximumCleats))
                isOk = true;

            return isOk;
        }

        /// <summary>
        ///     this function return the number of component which is a LockerComponent type and owned by locker class
        /// </summary>
        /// <param name="component">
        ///     take a component to search in locker component list
        /// </param>
        /// <returns>
        ///     return the number of component found
        /// </returns>
        private int numberOfComponentInList(CatalogueComponents componentGiven)
        {            
            int numberofComponent = 0;
            foreach (CatalogueComponents componentInList in _componentsList)
            {
                if(componentInList.GetType() == componentGiven.GetType())
                    numberofComponent++;
            }
            return numberofComponent;
        }
    }
}
