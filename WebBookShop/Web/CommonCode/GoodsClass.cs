using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using BookShop.BLL;
/// <summary>
/// GoodsClass 的摘要说明
/// </summary>
public class GoodsClass
{
    BookShop.BLL.Categories categ = new Categories();
    BookShop.BLL.Book book = new Book();

	public GoodsClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 对DataList控件进行绑定
    /// </summary>
    /// <param name="dlName">DataList控件名</param>
    /// <param name="dsTable">数据集DataSet的表的集合</param>
    public void dlBind(DataList dlName,DataTable dsTable)
    {
        if (dsTable != null)
        {
            dlName.DataSource = dsTable.DefaultView;
            dlName.DataKeyField = dsTable.Columns[0].ToString();
            dlName.DataBind();
        }
    }
    /// <summary>
    /// 商品类别菜单栏
    /// </summary>
    /// <param name="dlName">绑定商品类别名的DataList控件</param>
    public void DLClassBind(DataList dlName)
    {
        DataTable dt = categ.GetList(10,"","").Tables[0];
        dlBind(dlName, dt);
    }
    /// <summary>
    /// 在首页面中，绑定商品信息
    /// </summary>
    /// <param name="IntDeplay">商品分类标志</param>
    /// <param name="dlName">绑定商品的DataList控件</param>
    /// <param name="TableName">数据集标志</param>
    public void DLDeplayGI(int IntDeplay, DataList dlName, string TableName)
    {
        DataTable dsTable = book.GetList(6, "", "").Tables [0];
        dlBind(dlName, dsTable);
    }
   
    /// <summary>
    /// 最新商品菜单栏
    /// </summary>
    /// <param name="dlName">绑定最新商品的DataList控件</param>
    public void DLNewGoods(DataList dlName)
    {
        DataTable dsTable = book.GetList(6, "", "").Tables[0];
        dlBind(dlName, dsTable);
    }
    /// <summary>
    /// 获取商品类别名
    /// </summary>
    /// <param name="IntClassID">商品类别号</param>
    /// <returns>返回商品类别名</returns>
    public string GetClass(int IntClassID)
    {

        return (categ.GetList("Id=" + IntClassID.ToString()).Tables[0].Rows[0][1]).ToString();
    }
    /// <summary>
    /// 对商品信息进行模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键信息</param>
    /// <returns>返回查询结果数据表DataTable</returns>
    public DataTable search(string strKeyWord)
    {
        DataTable dsTable=book.SearchList(strKeyWord).Tables[0];
        return dsTable;
    }
   
}
