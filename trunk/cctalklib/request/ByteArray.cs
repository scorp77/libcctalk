using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.converter;

namespace cctalklib.request
{
    public class ByteArray : IByteArray
    {
        private List<int> list;
        public ByteArray()
        {
            this.list = new List<int>();
        }
        #region IByteArray Membri di

        public override string ToString()
        {
            byte value;
            StringBuilder str = new StringBuilder();
            foreach(int l in this.list) {
                value = (byte)l;
                str.Append(ByteToAscii.execute(value));

            }
            return str.ToString();
        }

        #endregion

        #region IList<int> Membri di

        public int IndexOf(int item)
        {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, int item)
        {
            this.list.Insert(index,item);
        }

        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        public int this[int index]
        {
            get
            {
                return this.list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }

        #endregion

        #region ICollection<int> Membri di

        public void Add(int item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(int item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            this.list.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(int item)
        {
            return this.list.Remove(item);
        }

        #endregion

        #region IEnumerable<int> Membri di

        public IEnumerator<int> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Membri di

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion
    }
}
