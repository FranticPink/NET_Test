using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    public class CommonClass
    {
        public CommonClass()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 说明：MessageBox用来在客户端弹出对话框，关闭对话框返回指定页。
        /// 参数：TxtMessage 对话框中显示的内容。
        /// Url 对话框关闭后，跳转的页
        /// </summary>
        public string MessageBox(string TxtMessage, string Url)
        {
            string str;
            str = "<script language=javascript>alert('" + TxtMessage + "');location='" + Url + "';</script>";
            return str;
        }
        /// <summary>
        /// 说明：MessageBox用来在客户端弹出对话框。
        /// 参数：TxtMessage 对话框中显示的内容。
        /// </summary>
        public string MessageBox(string TxtMessage)
        {
            string str;
            str = "<script language=javascript>alert('" + TxtMessage + "')</script>";
            return str;
        }
        /// <summary>
        /// 说明：MessageBoxPag用来在客户端弹出对话框，关闭对话框返回原页。
        /// 参数：TxtMessage 对话框中显示的内容。
        /// </summary>
        public string MessageBoxPage(string TxtMessage)
        {
            string str;
            str = "<script language=javascript>alert('" + TxtMessage + "');location='javascript:history.go(-1)';</script>";
            return str;
        }
        /// <summary>
        /// 实现随机验证码
        /// </summary>
        /// <param name="n">显示验证码的个数</param>
        /// <returns>返回生成的随机数</returns>
        public string RandomNum(int n) //
        {
            //定义一个包括数字、大写英文字母和小写英文字母的字符串
            string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            //将strchar字符串转化为数组
            //String.Split 方法返回包含此实例中的子字符串（由指定Char数组的元素分隔）的 String 数组。
            string[] VcArray = strchar.Split(',');
            int temp = -1;
            string VNum = "";
            Random rand = new Random();
            for (int i = 1; i < n + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return RandomNum(n);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }

        public string VarStr(string strHotPrice, int p)
        {
            return strHotPrice;
        }
    }
