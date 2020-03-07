using projectCS.Tools_class;
using System;
using System.Collections.Generic;

namespace projectCS
{
    public class Locker : ICupboardComponents
    {
        /// <summary>
        ///     group all maximum value for each components which the locker can have
        /// </summary>
        private static readonly int _maximumCrossBars = 8;
        private static readonly int _maximumPannels = 5;
        private static readonly int _maximumDoors = 2;
        private static readonly int _maximumCleats = 4;
        private static readonly int _maximumComponents = _maximumCrossBars + _maximumPannels + _maximumDoors + _maximumCleats;

        // TODO : compléter pour que sa calcul automatiquement la hauteur en fonction des composants
        public int height 
        {
            get
            {
                int height = 0;
                foreach(CatalogueComponents component in _componentsList)
                {
                    height += component.size;
                }
                return height;
            }
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

        // todo : refactorer
        public void addComponent(CatalogueComponents component)
        {
            bool isOk = false;

            switch (component)
            {
                case CrossBar c:
                    if (numberOfGivenComponentInAlist(_componentsList, component) < _maximumCrossBars)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Pannel p:
                    if (numberOfGivenComponentInAlist(_componentsList, component) < _maximumPannels)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Door d:
                    if (numberOfGivenComponentInAlist(_componentsList, component) < _maximumDoors)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Cleat cl:
                    if (numberOfGivenComponentInAlist(_componentsList, component) < _maximumCleats)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                default:
                    break;
            }          
            
            if (isOk)
                _componentsList.Add(component);
        }

        // todo : gérer exception et refactorer
        public void addComponent(List<CatalogueComponents> componentList)
        {
            if (!isComplete())
                _componentsList.AddRange(componentList);

            else
            { 
                   // ErrorWindow errorWindow = new ErrorWindow(ErrorMessages.componentMaxExceedMsg, ErrorMessages.componentMaxExceedTitle);
                   // errorWindow.displayWindow();                 
            }
        }

        public void removeComponent(CatalogueComponents component)
        {
            if(_componentsList.Contains(component))
                _componentsList.Remove(component);
        }

        /// <summary>
        ///     check if the locker has all components which it must have 
        /// </summary>
        /// <returns>
        ///     return true if the locker have all components, false in other case
        /// </returns>
        public bool isComplete()
        {
            return isComplete(_componentsList);
        }

        private bool isComplete(List<CatalogueComponents> componentList)
        {
            bool isOk = false;
            int numberOfCrossBar = numberOfGivenComponentInAlist(componentList, new CrossBar());
            int numberOfPannel = numberOfGivenComponentInAlist(componentList, new Pannel());
            int numberOfCleat = numberOfGivenComponentInAlist(componentList, new Cleat());

            // check if the locker has 8xcrossbar + 5xPannel + 4xCleat
            if ((numberOfCrossBar == _maximumCrossBars) && (numberOfPannel == _maximumPannels) && (numberOfCleat == _maximumCleats))
                isOk = true;

            return isOk;
        }

        /// <summary>
        ///     this function return the number of components of a given type which is in a component list
        /// </summary>
        /// <param name="componentList">
        ///     list of components given in which the function must search an occurence of a component type
        /// </param>
        /// <param name="component">
        ///     the type of component to find occurence
        /// </param>
        /// <returns>
        ///     return the number components for a type that the function found
        /// </returns>
        private int numberOfGivenComponentInAlist(List<CatalogueComponents> componentList, CatalogueComponents component)
        {            
            int numberOfComponent = 0;
            foreach (CatalogueComponents compo in componentList)
            {
                if(compo.GetType() == component.GetType())
                    numberOfComponent++;
            }
            return numberOfComponent;
        }
                

        public override string ToString()
        {
            string tostring = "";
            foreach (CatalogueComponents composant in _componentsList)
            {
                tostring += composant.ToString() + "\n";
            }
            return base.ToString() 
                + ", height : "
                + height
                + ", width : "
                + _width
                + ", depth : "
                + _depth
                + ", is Complete : "
                + isComplete()
                + "\n" + "\n" + "components list : " + "\n" + "\n"
                + tostring;
        }
    }
}
