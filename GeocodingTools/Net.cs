using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GeocodingTools
{
    public class Net
    {
        //导入判断网络是否连接的dll
        [DllImport("wininet")]
        //判断网络状况的方法，返回值true为连接，false为未连接
        public extern static bool InternetGetConnectedState(out int conState, int reder);

        public static bool IsConnectedInternet()
        {
            int n = 0;
            if (InternetGetConnectedState(out n, 0))
                return true;//已联网
            else
                return false;//未联网
        }



    }
}
