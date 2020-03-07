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

        // todo : voir si quand on ajoute en trop ca cause pas de prob
        public void addCatalogueComponent(CatalogueComponents component) 
        {
            _catalogueComponentsList.Add(component);
        }

        // todo : voir si quand on enlève en trop ca cause pas de prob
        public void removeCatalogueComponent(CatalogueComponents component) 
        {
            _catalogueComponentsList.Remove(component);
        }

        /// <summary>
        ///     build locker from component stored in list
        /// </summary>
        /// <returns>
        ///     return the locker built
        /// </returns>
        public Locker buildLocker()
        {
            Locker locker = new Locker();

            foreach(CatalogueComponents component in _catalogueComponentsList)
            {
                locker.addComponent(component);
            }
            resetLists(locker);
            return locker;
        }

        public void addCupboardComponent(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Add(cupboardComponent);
        }

        public void removeCupboardComponen(ICupboardComponents cupboardComponent)
        {
            _cupboardComponentsList.Remove(cupboardComponent);
        }

        public Cupboard buildCupboard()
        {
            Cupboard Cupboard = new Cupboard();

            foreach (ICupboardComponents cupboardComponent in _cupboardComponentsList)
            {
                Cupboard.addCupboardComponent(cupboardComponent);
            }
            resetLists(new int());
            return Cupboard;
        }
        
        private void resetLists(Object typeListToReset)
        {
            if(typeListToReset.GetType() is ICupboardComponents)
                _cupboardComponentsList = new List<ICupboardComponents>();
            else
                _catalogueComponentsList = new List<CatalogueComponents>();
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
