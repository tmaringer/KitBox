using projectCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
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
                
        public void addCatalogueComponent(CatalogueComponents component) 
        {
            _catalogueComponentsList.Add(component);
        }

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
            return Cupboard;
        }
        
        private void resetLists(List<Object> list)
        {
            if(list.GetType() is CatalogueComponents)
                _catalogueComponentsList = new List<CatalogueComponents>();
            else
                _cupboardComponentsList = new List<ICupboardComponents>();
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
