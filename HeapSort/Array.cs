using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class MyDataArray : DataArray

    {

        public MyDataArray()

        {
            length = 10;
            var d = new Data[length];
            for (int i = 0; i < length; i++)
            {
                d[i] = new Data();
            }

            data = d;
        }
        
        public override void Swap(int i, int j, Data a, Data b)
            
        {
            data[i] = b; 
            data[j] = a; 
        }

    }

}
