using projectCS.Tools_class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projectCS
{
    public class Locker : ICupboardComponents
    {
        /// <summary>
        ///     group all maximum value for each components which the locker can have
        /// </summary>
        private readonly int _maximumCrossBars = 8;
        private readonly int _maximumPannels = 5;
        private readonly int _maximumDoors = 2;
        private readonly int _maximumCleats = 4;

        private int _height;
        public int height
        {
            get => _height;
            set => _height = value;
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

        private int _width;
        public int width
        {
            get => _width;
            set => _width = value;
        }

        private int _depth;
        public int depth
        {
            get => _depth;
            set => _depth = value;
        }

        private static int _numberOfLockers = 0;

        private int _ID;
        public int ID
        {
            get => _ID;
        }

        private ComponentColor _doorsColor;
        public ComponentColor doorsColor 
        {
            get
            {
                ComponentColor color = ComponentColor.black;

                foreach (CatalogueComponents catalogueCompo in _componentsList)
                {
                    if (catalogueCompo is Door)
                        color = ((Door)catalogueCompo).color;
                }
                return color;
            }

            set
            {
                foreach (CatalogueComponents catalogueCompo in _componentsList)
                {
                    if (catalogueCompo is Door)
                        ((Door)catalogueCompo).color = value;
                }
                _doorsColor = value;
            }
        }

        private ComponentColor _panelColor;
        public ComponentColor panelColor 
        { 
            get
            {
                ComponentColor color = ComponentColor.black;

                foreach (CatalogueComponents catalogueCompo in _componentsList)
                {
                    if (catalogueCompo is Panels)
                        color = ((Panels)catalogueCompo).color;
                }
                return color;
            }

            set
            {
                foreach(CatalogueComponents catalogueCompo in _componentsList)
                {
                    if (catalogueCompo is Panels)
                        ((Panels)catalogueCompo).color = value;
                }
                _panelColor = value;
            }
        }

        private List<CatalogueComponents> _componentsList;
        public List<CatalogueComponents> componentsList
        {
            get => _componentsList;
        }


        public Locker()
        {
            _numberOfLockers++;
            _ID = _numberOfLockers;
            _componentsList = new List<CatalogueComponents>();
            _height = 0;
            _width = 0;
            _depth = 0;
        }


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
                case Panels p:
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
            if (_componentsList.Contains(component))
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

        /// <summary>
        ///     Checks if the locker has all components which it be able to contains.
        /// </summary>
        /// <param name="componentList">
        ///     The components list where the function must search.
        /// </param>
        /// <returns>
        ///     Returns true if complete, false otherwise.
        /// </returns>
        private bool isComplete(List<CatalogueComponents> componentList)
        {
            bool isOk = false;
            int numberOfCrossBar = numberOfComponentInList(componentList, new CrossBar());
            int numberOfPannel = numberOfComponentInList(componentList, new Panels());
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
                if (compo.GetType() == component.GetType())
                    numberOfComponent++;
            }
            return numberOfComponent;
        }

        private void resetID()
        {
            _numberOfLockers = 0;
        }

        public override string ToString()
        {
            string tostring = "";
            foreach (CatalogueComponents composant in _componentsList)
            {
                tostring += composant.ToString() + "\n";
            }
            return base.ToString()
                + ", locker ID : "
                + ID
                + ", price : "
                + price
                + ", height : "
                + height
                + ", width : "
                + width
                + ", depth : "
                + depth
                + ", is Complete : "
                + isComplete();
                //+ "\n" + "\n" + "components list : " + "\n" + "\n"
                //+ tostring;
        }
    }
}
