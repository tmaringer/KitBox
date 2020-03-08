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
    public class ShoppingCart
    {
        private List<CatalogueComponents> _catalogueComponentsList;
        public List<CatalogueComponents> catalogueComponentsList 
        { 
            get => _catalogueComponentsList;
        }

        private List<ICupboardComponents> _cupboardComponentsList;
        public List<ICupboardComponents> cupboardComponentsList
        {
            get => _cupboardComponentsList;
        }

        private Cupboard _cupboard;
        public Cupboard cupboard
        {
            get => _cupboard;
        }

        public ShoppingCart()
        {
            this._catalogueComponentsList = new List<CatalogueComponents>();
            this._cupboardComponentsList = new List<ICupboardComponents>();
        }

        // todo : voir si on autorise d'ajouter plus de composant pour un locker ou si on limite
        public void addCatalogueComponent(CatalogueComponents component) 
        {
            _catalogueComponentsList.Add(component);
        }

        // todo : voir si on autorise d'ajouter plus de composant pour un locker ou si on limite
        public void removeCatalogueComponent(CatalogueComponents component) 
        {
            _catalogueComponentsList.Remove(component);
        }

        /// <summary>
        ///     Builds locker from components stored in list. It also removes components which are used to build locker.
        /// </summary>
        /// <returns>
        ///     Returns the locker built.
        /// </returns>
        public Locker buildLocker()
        {
            Locker locker = new Locker();
            // temporary list which store components added to the locker and is used thereafter to remove components in the main list
            List<CatalogueComponents> tempList = new List<CatalogueComponents>();
            bool componentWasAdded = false;

            foreach (CatalogueComponents component in _catalogueComponentsList)
            {
                componentWasAdded = locker.addComponent(component);
                if(componentWasAdded)
                    tempList.Add(component);
            }

            foreach(CatalogueComponents component in tempList)
            {
                _catalogueComponentsList.Remove(component);
            }

            return locker;
        }

        public void addCupboardComponent(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Add(cupboardComponent);
        }

        public void removeCupboardComponent(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Remove(cupboardComponent);
        }

        /// <summary>
        ///     Builds cupboard from components stored. It also removes components which are used to build cupboard.
        /// </summary>
        /// <returns>
        ///     Returns the cupboard built.
        /// </returns>
        public Cupboard buildCupboard()
        {
            Cupboard Cupboard = new Cupboard();
            // temporary list which store components added to the cupboard and is used thereafter to remove components in the main list
            List<ICupboardComponents> tempList = new List<ICupboardComponents>();

            foreach (ICupboardComponents cupboardComponent in _cupboardComponentsList)
            {
                Cupboard.addCupboardComponent(cupboardComponent);
                tempList.Add(cupboardComponent);
            }

            foreach (ICupboardComponents component in tempList)
            {
                _cupboardComponentsList.Remove(component);
            }
            return Cupboard;
        }

        public override string ToString()
        {
            return base.ToString()
                   + ", catalogue components list : "
                   + _catalogueComponentsList
                   + ", cupboard componentsList list : "
                   + _cupboardComponentsList;
        }
    }
}
