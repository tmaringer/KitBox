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
        private List<CatalogueComponents> _componentsList;
        public List<CatalogueComponents> componentsList 
        { 
            get => _componentsList;
        }
        // todo : refactorer quand on saura s'il faut utiliser plusieurs listes ou une seul
        /*
        private List<CrossBar> _crossBarList;
        public List<CrossBar> crossBarList
        {
            get => _crossBarList;
        }
        
        private List<Pannel> _pannelList;
        public List<Pannel> pannelList
        {
            get => _pannelList;
        }
        
        private List<Door> _doorList;
        public List<Door> doorList
        {
            get => _doorList;
        }
        
        private List<Cleat> _cleatList;
        public List<Cleat> cleatList
        {
            get => _cleatList;
        }
        
        private List<Locker> _lockerList;
        public List<Locker> lockerList
        {
            get => _lockerList;
        }
        
        private AngleBracket _angleBracket;
        public AngleBracket angleBracket
        {
            get => _angleBracket;
            set => _angleBracket = value;
        }
        */
        public ShoppingCart()
        {
            this._componentsList = new List<CatalogueComponents>();
            /*
this._crossBarList = new List<CrossBar>();
this._pannelList = new List<Pannel>();
this._doorList = new List<Door>();
this._cleatList = new List<Cleat>();
this._lockerList = new List<Locker>();
this._angleBracket = new AngleBracket();
*/
        }
                
        public void addComponent(CatalogueComponents component) 
        {
            _componentsList.Add(component);
        }

        public void removeComponent(CatalogueComponents component) 
        {
            _componentsList.Remove(component);
        }

        // TODO : à finir
        /// <summary>
        ///     build locker from component stored in list
        /// </summary>
        /// <returns>
        ///     return the locker builded
        /// </returns>
        public Locker buildLocker()
        {
            Locker locker = new Locker();

            foreach(CatalogueComponents component in _componentsList)
            {
                /*
                switch (component)
                {
                    case CrossBar c:
                        _numberOfLCrossBar++;
                        break;
                    case Pannel p:
                        _numberOfPannel++;
                        break;
                    case Door d:
                        _numberOfDoor++;
                        break;
                    case Cleat cl:
                        _numberOfCleat++;
                        break;
                    default:
                        break;
                }*/
            }
            return new Locker();
        }
        
        // TODO : finir la methode
        public Cupboard buildCupboard(ICupboardComponents component)
        {
            return new Cupboard();
        }
    }
}
