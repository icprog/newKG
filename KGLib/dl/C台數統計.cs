using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tw.com.kg.lib
{
    public class C台數統計
    {
        public string 所別 { get; set; }
        public int R_精緻洗車 { get; set; }
        public int M_磁土美容 { get; set; }
        public int S_超值美容 { get; set; }
        public int L_亮新I { get; set; }
        public int N_亮新II { get; set; }
        public int I_內裝美容 { get; set; }
        public int E_引擎清潔 { get; set; }
        public int R_精緻洗車money { get; set; }
        public int M_磁土美容money { get; set; }
        public int S_超值美容money { get; set; }
        public int L_亮新Imoney { get; set; }
        public int N_亮新IImoney { get; set; }
        public int I_內裝美容money { get; set; }
        public int E_引擎清潔money { get; set; }

        public int G_玻璃油膜 { get; set; }
        public int G_玻璃油膜money { get; set; }

        public int D00_高運 { get; set; }
        public int D00_高運money { get; set; }

        //多區分中古車整備 2011-11-23 way
        public int D00_CPO2 { get; set; }
        public int D00_CPO2money { get; set; }

        

        public int A_小美容 { get; set; }
        public int A_小美容money { get; set; }
        public int B_覆膜 { get; set; }
        public int B_覆膜money { get; set; }
    }
}
