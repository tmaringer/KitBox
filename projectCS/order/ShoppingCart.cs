using projectCS.physic_components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.order
{
    public class ShoppingCart
    {
        private List<Components> _componentsList;
        public List<Components> componentsList 
        { 
            get => _componentsList;
        }
        // TODO : refactorer quand on saura s'il faut utiliser plusieurs listes ou une seul
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
            this._componentsList = new List<Components>();
            /*
this._crossBarList = new List<CrossBar>();
this._pannelList = new List<Pannel>();
this._doorList = new List<Door>();
this._cleatList = new List<Cleat>();
this._lockerList = new List<Locker>();
this._angleBracket = new AngleBracket();
*/
        }
                
        public void addComponent(Components component) 
        {
            _componentsList.Add(component);
        }

        public void removeComponent(Components component) 
        {
            _componentsList.Remove(component);
        }

        /// <summary>
        ///     build locker from component stored in list
        /// </summary>
        /// <returns>
        ///     return the locker builded
        /// </returns>
        public Locker buildLocker()
        {
            foreach(Components component in _componentsList)
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
        
        public Cupboard buildCupboard(CupboardComponents component)
        {
            return new Cupboard();
        }
    }
}
