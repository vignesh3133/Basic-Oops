using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ListDS
{
    public class CustomList<Type>:IEnumerable,IEnumerator

    {
        private int _count;
        private int _size;
        public int Count{get{return _count;}}
        public int Capacity{get{return _size;}}
        private Type[] _array;

        public Type this[int index]
        {
            get{return _array[index];}
            set{_array[index]=value;}
        }

        public CustomList()
        {
            _count=0;
            _size=4;
            _array=new Type[_size];

        }

        public CustomList(int size)
        {
            _count=0;
            _size=size;
            _array=new Type[_size];
        }

        public void Add(Type data)
        {
            if(_count==_size)
            {
                GrowSize(); 
            }
            _array[_count]=data;
            _count++;
        }

        private void GrowSize()
        {
            _size*=2;
            Type[] temp=new Type[_size];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }

        public void AddRange(CustomList<Type> dataList)
        {
            _size=_count+dataList.Count+4;
            Type [] temp= new Type[_size];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];

            }
            int k=0;
            for(int i=_count;i<_count+dataList.Count;i++)
            {
                temp[i]=dataList[k];
                k++;
            }
            _array=temp;
            _count+=dataList.Count;
        }

        public void insert(int position,Type data)
        {
            _size+=4;
            Type[] temp=new Type[_size];
            for(int i=0;i<_count;i++)
            {
                if(i<position)
                {
                    temp[i]=_array[i];
                }
                else if(i==position)
                {
                    temp[i]=data;
                }
                else
                {
                    temp[i]=_array[i-1];
                }
            }
            _array=temp;
            _count++;
        }
//indexof --if present position will print else -1.
        public int IndexOf(Type data)
        {
            int position=-1;
            for(int i=0;i<_count;i++)
            {
                if(data.Equals(_array[i]))
                {
                    position=i;
                    break;
                }
            }
            return position;
        }

        public void RemoveAt(int position)
        {
            for(int i=0;i<_count;i++)
            {
                if(i>=position)
                {
                    _array[i]=_array[i+1];
                }
            }
            _count--;
        }

        public bool Remove(Type data)
        {
            int position=IndexOf(data);
            if(position>-1)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }
        //get IEnumerator for foreach
        int location;
        public IEnumerator GetEnumerator()
        {
            location=-1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(location<_count-1)
            {
                location++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            location=-1;
            
        }
        public object Current{get{return _array[location];}}
    }
}