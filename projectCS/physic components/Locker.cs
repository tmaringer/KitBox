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

        // TODO : refactorer pour que sa prenne en compte Orientation
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

        // TODO : compléter pour que sa calcul automatiquement la hauteur en fonction des composants en fonction de Orientation
        private int _width;
        public int width
        {
            get => 0;
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
        /// <summary>
        ///     add a component or a component list which are stored in a components list
        /// </summary>
        /// <param name="component">
        ///     component to add in locker list
        /// </param>
        public bool addComponent(CatalogueComponents component)
        {
            bool componentIsAdded = false;
            bool isOk = false;

            switch (component)
            {
                case CrossBar c:
                    if (numberOfComponentInList(_componentsList, component) < _maximumCrossBars)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Pannel p:
                    if (numberOfComponentInList(_componentsList, component) < _maximumPannels)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Door d:
                    if (numberOfComponentInList(_componentsList, component) < _maximumDoors)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                case Cleat cl:
                    if (numberOfComponentInList(_componentsList, component) < _maximumCleats)
                        isOk = true;
                    else
                        isOk = false;
                    break;
                default:
                    break;
            }          
            
            if (isOk)
            {
                componentIsAdded = true;
                _componentsList.Add(component);
            }
            return componentIsAdded;
        }

        public bool addComponent(List<CatalogueComponents> componentList)
        {
            bool componentIsAdded = true;
            bool allComponentWereAdded = true;
            foreach (CatalogueComponents component in componentList)
            {
                componentIsAdded = addComponent(component);
                if (!componentIsAdded)
                    allComponentWereAdded = false;
            }
            return allComponentWereAdded;
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
            int numberOfCrossBar = numberOfComponentInList(componentList, new CrossBar());
            int numberOfPannel = numberOfComponentInList(componentList, new Pannel());
            int numberOfCleat = numberOfComponentInList(componentList, new Cleat());

            // check if the locker has 8xcrossbar + 5xPannel + 4xCleat
            if ((numberOfCrossBar == _maximumCrossBars) && (numberOfPannel == _maximumPannels) && (numberOfCleat == _maximumCleats))
                isOk = true;

            return isOk;
        }

        /// <summary>
        ///     this function return the number of components of a type being in a provided components list
        /// </summary>
        /// <param name="componentList">
        ///     list of components where the function will search existence of the component type given in second parametre
        /// </param>
        /// <param name="component">
        ///     the type of component which the function must compute in the list
        /// </param>
        /// <returns>
        ///     return the number of components of the type given in second parametre which the function found
        /// </returns>
        private int numberOfComponentInList(List<CatalogueComponents> componentList, CatalogueComponents component)
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
